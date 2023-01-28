# LeoECS Lite Unity Zoo

LeoECS Lite Unity Zoo — это большое дополнение для [LeoECS Lite](https://github.com/Leopotam/ecslite) с использованием Unity, включаяющая в себя:
* ECS Startup (плоский и feature-based);
* ECS Component Conversion;
* Unity Core ECS Components;
* ECS Injection;
* Несколько дополнений для EcsWorld, IEcsSystems и Unity-objects.

Ссылка на [англоязычный README](https://github.com/aleverdes/leoecslite-zoo/).

# Содержание

* [Введение](#введение)
* [Установка](#установка)
    * [Unity Package Manager](#unity-package-manager)
    * [Ручная установка](#ручная-установка)
* [Возмоности](#возможности)
    * [ECS World Provider](#ecs-world-provider)
    * [Plain ECS Startup](#plain-ecs-startup)
    * [Feature-based ECS Startup](#feature-based-ecs-startup)
    * [ECS Unity Core Components](#ecs-unity-core-components)
    * [ECS Components Conversion](#ecs-components-conversion)
    * [ECS Injection и Globals](#ecs-injection-и-globals)
        * [GlobalMonoBehaviour](#globalmonobehaviour)
        * [Manual Injection](#manual-injection)
        * [Globals](#globals)
        * [EcsWorld Injection](#ecsworld-injection)
    * [OneFrame Systems](#oneframe-systems)
    * [LeoECS Lite Extensions](#leoecs-lite-extensions)
        * [Unity Extensions](#unity-extensions)
        * [ECS World Extensions](#ecs-world-extensions)
* [Лицензия](#лицензия)

# Введение

Я разработал LeoECS Lite Unity Zoo для собственного использования и долгое время разрабатывал его, используя в своих проектах.
Это дополнение включает в себя множество функций, которые упрощают и ускоряют разработку, при этом не меняя основной концепции LeoECS Lite.
Любые сообщения об ошибках и предложения по улучшению приветствуются.

# Установка

## Unity Package Manager

Поддерживается установка в виде unity-модуля через git-ссылку в PackageManager или прямое редактирование `Packages/manifest.json`:

```
"com.affencode.leoecslite-zoo": "https://github.com/aleverdes/leoecslite-zoo.git",
```

## Ручная установка

Код так же может быть склонирован или получен в виде архива со страницы релизов.
Просто скопируйте папку LeoECS Lite Zoo в ваш проект или установите его через unitypackage со страницы Releases.

# Возможности

## ECS World Provider

ECS World Provider — это MonoBehaviour, который занимается созданием и удалением ECS-миров (EcsWorld).
Вы также можете получить доступ к миру через соответствующее свойство World.
Первый созданный мир регистрируется как мир по умолчанию и доступен через статическое свойство `EcsWorldProvider.DefaultWorldProvider.World`.

Просто добавьте компонент EcsWorldProvider к любому объекту сцены, и при запуске сцены будет создан новый EcsWorld.

## Плоский ECS Startup

Сам по себе класс ECS Startup позволяет определить список Ваших систем в несколько строк кода.
Для работы с EcsStartup, необходимо создать новый класс и отнаследоваться от класс EcsStartup и реализовать все объявленные в нём методы.

EcsStartup является классом MonoBehaviour и для работы требует присутствия этого компонента на сцене.

Для работы ECS Startup нужна ссылка на компонент EcsWorldProvider. Я рекомендую создать на сцене объект "ECS" и добавить к нему компоненты EcsWorldProvider и наследника класса EcsStartup.

EcsStartup включает в себя функциональность для синхронизации EcsTransform с компонентом Unity-Transform. Подробнее читайте в [ECS Unity Core Components](#ecs-unity-core-components).

Просто создайте свой класс на основе EcsStartup и заполните его своими системами.

```csharp
using AffenCode;
using Leopotam.EcsLite;

public class TestEcsStartup : EcsStartup
{
    protected override void AddUpdateSystems(EcsSystems ecsSystems)
    {
        ecsSystems
            .Add(new TestUpdateSystem())
            ;
    }

    protected override void AddLateUpdateSystems(EcsSystems ecsSystems)
    {
        ecsSystems
            .Add(new TestLateUpdateSystem())
            ;
    }

    protected override void AddFixedUpdateSystems(EcsSystems ecsSystems)
    {
        ecsSystems
            .Add(new TestFixedUpdateSystem())
            ;
    }
}
```

## Feature-based ECS Startup

FeaturedEcsStartup — более сложный, но более удобный способ организации ваших систем в проекте.

Для организации кода в FeaturedEcsStartup добавляются объекты типа IEcsFeature, которые уже включают в себя объявление методов, необходимых для корректной работы Unity.

FeaturedEcsStartup также является классом MonoBehaviour и для работы требует наличия этого компонента на сцене.

Для работы FeaturedEcsStartup нужна ссылка на компонент EcsWorldProvider. Я рекомендую создать на сцене объект «ECS» и добавить к нему компоненты EcsWorldProvider и класс-наследник FeaturedEcsStartup.

FeaturedEcsStartup включает функциональные возможности для синхронизации EcsTransform с UnityTransform. Подробнее читайте в [ECS Unity Core Components](#ecs-unity-core-components).

Просто унаследуйте свой класс от FeaturedEcsStartup и заполните его своими функциями с помощью систем.

```csharp
using AffenCode;
using Leopotam.EcsLite;

public class TestEcsStartup : FeaturedEcsStartup
{
    protected override void AddFeatures(FeatureEcsSystems systems)
    {
        systems
            .Add(new TestFeature())
            ;
    }
}

public class TestFeature : IEcsFeature
{
    public void Update(IEcsSystems ecsSystems)
    {
        ecsSystems
            .Add(new TestUpdateSystem())
            ;
    }

    public void LateUpdate(IEcsSystems ecsSystems)
    {
        ecsSystems
            .Add(new TestLateUpdateSystem())
            ;
    }

    public void FixedUpdate(IEcsSystems ecsSystems)
    {
        ecsSystems
            .Add(new TestFixedUpdateSystem())
            ;
    }
}
```

## ECS Unity Core Components

LeoECS Lite Unity Zoo включает в себя несколько компонентов для упрощения взаимодействия с Unity-компонентами на сцене:
* EcsTransform — это основной компонент, аналог Transform в Unity, содержащий в себе информацию о position, rotation и scale объекта. По умолчанию работает в глоабльных координатах. Если необходимо перевести работу методов синхронизации (при наличии TransformRef-компонента) на локальные координаты, добавьте компонент LocalTransformSync к выбранной сущности.
* TransformRef содержит ссылку на Unity-transform.
  * Наличие обоих компонентов (EcsTransform и TransformRef) позволяет настроить синхронизацию компонента с transform'ом на сцене, если используется один из вышеперечисленных типов EcsStartup.
* RigidbodyRef содержит ссылку на Unity-rigidbody.
  * Наличие обоих компонентов (EcsTransform и RigidbodyRef) позволяет настроить синхронизацию компонента с transform'ом на сцене, если используется один из вышеперечисленных типов EcsStartup. Данные в таком случае будут синхронизировать в FixedUpdate().
* LocalTransformSync позволяет перевести синхронизацию координат и вращения объекта с глобальных на локальные.

Также:
* GameObjectRef содержит ссылку на GameObject.
* RectTransformRef содержит ссылку на RectTransform.
* Rigidbody2DRef содержит ссылку на Rigidbody2D и дублирует функционал RigidbodyRef.

```csharp
using System;
using UnityEngine;

namespace AffenCode
{
    [Serializable]
    public struct EcsTransform
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Scale;
    }

    [Serializable]
    public struct TransformRef
    {
        public Transform Value;
    }

    [Serializable]
    public struct LocalTransformSync
    {
    }

    [Serializable]
    public struct RectTransformRef
    {
        public RectTransform Value;
    }

    [Serializable]
    public struct RigidbodyRef
    {
        public Rigidbody Value;
    }

    [Serializable]
    public struct Rigidbody2DRef
    {
        public Rigidbody2D Value;
    }

    [Serializable]
    public struct GameObjectRef
    {
        public GameObject Value;
    }
}
```

## ECS Components Conversion

LeoECS Lite Unity Zoo предоставляет механизм конвертации ваших компонентов в ECS.
Чтобы сделать это, просто добавьте MonoBehaviour-компонент `ConvertToEntity` на ваш объект и добавьте MonoBehaviour-компонент, являющийся наследником интерфейса `IConvertToEntity` на этот же объект.

Также, в LeoECS Lite Unity Zoo представлены функции класса `ConversionUtils` для связывания ECS-сущности с Unity-объектом на сцене посредством компонентов (указаны в пункте [ECS Unity Core Components](#ecs-unity-core-components)).

В своих проектах я чаще всего использую модель конвертации "Bootstrappers":

```csharp
using AffenCode;

[RequireComponent(typeof(ConvertToEntity))]
public class PlayerBootstrapper : MonoBehaviour, IConvertToEntity
{
    public void ConvertToEntity(EcsWorld ecsWorld, int entity)
    {
        // custom components
        ecsWorld.GetPool<TestComponent>().Add(entity) = new TestComponent()
        {
            Name = "Test"
        };
    
        // for linking ECS-entity with Unity-object
        ConversionUtils.SetupGameObjectRef(ecsWorld, entity, gameObject);
        ConversionUtils.SetupTransformRef(ecsWorld, entity, transform);
        ConversionUtils.SetupRigidbody(ecsWorld, entity, GetComponent<Rigidbody>());
    }
}
```

Но более простым способ является объявление MonoBehaviour-класса, являющегося наследником класса ConvertComponent<T> и добавление его к объекту на сцене..

```csharp
using AffenCode;

public class TestComponentProvider : ConvertComponent<TestComponent>
{
    // optional
    private void Reset()
    {
        Value = new TestComponent()
        {
            Name = "Test"
        };
    }
}
```

Важным является дополнение, что если Вы используете ConvertComponent-способ конвертации объектов, не забудьте добавить MonoBehaviour-компонент `UnityObjectProvider`. 
`UnityObjectProvider` позволит Вам связать Ваш Unity-объект с ECS-сущностью (будет ссылка на GameObject, свяжутся EcsTransform и TransformRef или, если есть Rigidbody, то EcsTransform и RigidbodyRef).

## ECS Injection и Globals

LeoECS Lite Unity Zoo предоставляет механизм инъекции объектов (injection) в ECS-системы и ServiceLocator местного разлива под названием Globals.

> **Важно!** ECS-injection работает по умолчанию только с наследниками EcsStartup и FeaturedEcsStartup. Если вы хотите использовать инъекцию от LeoECS Lite Unity Zoo в стандартном способе объявления систем LeoECS Lite, то просто вставьте метод `.Inject()` в конец объявления ваших систем, прямо перед Init. 

### GlobalMonoBehaviour

Самый простой способ объявить глобальный MonoBehaviour, который будет заинджекчен (injected) в Ваших системах и зарегистрирован в Globals является наследование от класса GlobalMonoBehaviour.
Наследник этого класса будет MonoBehaviour-компонентом с реализованными Awake и OnDestroy (не забудьте использовать override с base-вызовами если они вам необходимы) и потому он должен быть размещен на сцене в единственном экземпляре.
Чтобы воспользоваться заинджекченным объектом в ECS-системе, просто объявите переменную соответствующего заинджекченному объекту типа.

```csharp
using AffenCode;

public class InjectedMonoBehaviour : GlobalMonoBehaviour
{
    public string Value = "Test";
}
```
```csharp
using Leopotam.EcsLite;

public void TestSystem : IEcsRunSystem
{
    private InjectedMonoBehaviour _injectedMonoBehaviour;
    
    public void Run(IEcsSystems systems)
    {
        Debug.Log(_injectedMonoBehaviour);
    }
}
```

### Manual Injection

Есил вам необходимо заинджектить объект вручную, например если он не является наследником MonoBehaviour, то используйте методы `LeoEcsInjector.AddInjection(this)`.

```csharp
private void Awake()
{
    LeoEcsLiteInjector.AddInjection(Component);
}

private void OnDestroy()
{
    LeoEcsLiteInjector.RemoveInjection(Component);
}
```

### Globals

Также есть вышеупомянутый Globals-класс — класс типа ServiceLocator. Доступ к объектам в Globals доступен из любой точки Вашего кода посредством нижеописанных методов..

```csharp
private void Awake()
{
    Globals.Add(this); // регистрация в Globals
}

private void OnDestroy()
{
    Globals.Remove(this); // удаление из Globals
}
```
```csharp
if (Globals.Has<TestClass>()) // проверка на наличие в Globals
{
    var test = Globals.Get<TestClass>(); // Получение объекта из Globals
}
```

### EcsWorld Injection

Также, если Вы используете Injection от LeoECS Lite Unity Zoo, то Вам доступно обращение к миру через простое объявление его в системе. Необходимо, если вы реализуете кастомные методы в системе, в которые напрямую не передается мир или IEcsSystems.

```csharp
using Leopotam.EcsLite;

public void TestSystem : IEcsRunSystem
{
    private EcsWorld _world;
    
    public void Run(IEcsSystems systems)
    {
        int entity = _world.NewEntity();
    }
}
```

## OneFrame Systems

Если Вам необходимо удалять в конце работы систем какой-либо компонент, LeoECS Lite Unity Zoo предоставляет Вам возможность это сделать через OneFrame-системы. 
Просто добавьте `.OneFrame<T>` в конец Вашего списка систем с указанием необходимого для очистки типа компонентов.

```csharp
...
public void Update(IEcsSystems ecsSystems)
{
    ecsSystems
        .Add(new TestUpdateSystem())
        .OneFrame<TestComponent>()
        ;
}
```

## LeoECS Lite Extensions

### Unity Extensions

```csharp
if (gameObject.TryGetEntity(out var entity))
{
    Debug.Log(entity);
}
```

### ECS World Extensions

```csharp
var world = EcsWorldProvider.DefaultWorldProvider.World;

world.NewEntityWith<TestComponent>() = new TestComponent()
{
    Value = "something"
};
```

# Лицензия

Код и документация Copyright (c) 2022-2023 Alexander Travkin.

Распространяется под MIT license.