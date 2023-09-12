# LeoECS Lite Unity Zoo

LeoECS Lite Unity Zoo — это большое дополнение для [LeoECS Lite](https://github.com/Leopotam/ecslite) с использованием Unity, включаяющая в себя:
* ECS Feature Manager;
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
* [Возможности](#возможности)
    * [ECS StartUp](#ecs-startup)
    * [ECS Manager](#ecs-manager)
    * [ECS Feature](#ecs-feature)
    * [ECS Unity Core Components](#ecs-unity-core-components)
    * [ECS Components Conversion](#ecs-components-conversion)
    * [ECS Injection](#ecs-injection)
        * [ECS Injection Context](#ecs-injection-context)
        * [Manual Injection](#manual-injection)
        * [EcsWorld Injection](#ecsworld-injection)
        * [EcsPool Injection](#ecspool-injection)
    * [OneFrame Systems](#oneframe-systems)
    * [LeoECS Lite Extensions](#leoecs-lite-extensions)
        * [Unity Extensions](#unity-extensions)
        * [ECS World Extensions](#ecs-world-extensions)
* [Лицензия](#лицензия)

# Введение

Я разработал LeoECS Lite Unity Zoo для собственного использования и долгое время использую его в своих проектах.
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

## ECS Startup

Ниже приведен пример того, как запустить ECS Manager от LeoECS Lite Zoo вместе с инъекцией, инициализацией мира и работой систем.

```csharp
public class GameEcsStartup : MonoBehaviour
{
    [SerializeField] private List<EcsInjectionContext> _injectionContexts;

    private EcsWorld _world;
    private GameEcsManager _ecsManager;

    private void Awake()
    {
        _world = new EcsWorld();
        ConvertToEntity.DefaultConversionWorld = _world;
        
        _ecsManager = new GameEcsManager();
        _ecsManager.SetWorld(_world);
        foreach (var injectionContext in _injectionContexts)
        {
            var injector = injectionContext.GetInjector();
            injectionContext.Setup(injector);
            _ecsManager.AddInjector(injector);   
        }
        _ecsManager.Initialize();
    }

    private void Update()
    {
        _ecsManager.Update();
    }

    private void LateUpdate()
    {
        _ecsManager.LateUpdate();
    }

    private void FixedUpdate()
    {
        _ecsManager.FixedUpdate();
    }
}
```

## ECS Manager

ECS Manager — класс, в котором разработчик должен перечислить все необходимые EcsFeature.

```csharp
using AffenCode;

public class GameEcsManager : EcsManager
{
    protected override void AddFeatures(EcsSystemsContext systemsContext)
    {
        systemsContext
            .Add(new DebugFeature())
            .Add(new PlayerFeature())
            ;
    }
}
```

## ECS Feature

ECS Feature — основной способ организации и группировки внутриигровых систем по контексту.

```csharp
using AffenCode;

public class DebugFeature : EcsFeature
{
    protected override void SetupUpdateSystems(EcsFeatureSystems ecsFeatureSystems)
    {
        ecsFeatureSystems
            .Add(new DebugTeleportSystem())
            ;
    }

    protected override void SetupLateUpdateSystems(EcsFeatureSystems ecsFeatureSystems)
    {
    }

    protected override void SetupFixedUpdateSystems(EcsFeatureSystems ecsFeatureSystems)
    {
    }
}
```

## ECS Unity Core Components

LeoECS Lite Unity Zoo включает в себя несколько компонентов для упрощения взаимодействия с Unity-компонентами на сцене:
* TransformRef содержит ссылку на Unity-transform.
* RigidbodyRef содержит ссылку на Unity-rigidbody.
* GameObjectRef содержит ссылку на GameObject.
* RectTransformRef содержит ссылку на RectTransform.
* Rigidbody2DRef содержит ссылку на Rigidbody2D и дублирует функционал RigidbodyRef.

```csharp
using System;
using UnityEngine;

namespace AffenCode
{
    [Serializable]
    public struct TransformRef
    {
        public Transform Value;
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

> Важно! Использование `ConvertToEntity` возможно только если на сцене есть `EcsWorldProvider` или же какой-либо из миров зарегистрирован в `ConvertToEntity.DefaultConversionWorld`.

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

## ECS Injection

LeoECS Lite Unity Zoo предоставляет механизм инъекции объектов (injection) в ECS-системы.

### ECS Injection Context

Крайне простой способ объявления инъекций в коде. Достаточно просто объявить класс, который будет наследником EcsInjectionContext, и в нем прописать поля, которые хочется заинжектить.

```csharp
using AffenCode;

public class GameEcsInjectionContext : EcsInjectionContext
{
    private DebugSettings _debugSettings;
    private PlayerCamera _playerCamera;
    [SerializedField] private ItemDatabase _itemDatabase;
}
```

В дальнейшем, надо просто инициализровать EcsInjectionContext и зарегистрировать Injector контекста в EcsManager.

```csharp
using AffenCode;

public class GameEcsStartup : MonoBehaviour
{
    [SerializeField] private List<EcsInjectionContext> _injectionContexts;

    private GameEcsManager _ecsManager;
        
    private void Start()
    {
        ...
        foreach (var injectionContext in _injectionContexts)
        {
            var injector = injectionContext.GetInjector();
            injectionContext.Setup(injector);
            _ecsManager.AddInjector(injector);   
        }
        ...
    }
}

```

### Manual Injection

Есил вам необходимо заинджектить объект вручную, то используйте данные метод:

```csharp
var ecsInjectionContext = FindObjectOfType<EcsInjectionContext>();
...
ecsInjectionContext.GetInjector().AddInjectionObject(Value);
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

### EcsPool Injection

Также, если Вы используете Injection от LeoECS Lite Unity Zoo, то Вам доступно обращение к любом EcsPool<T> через простое объявление его в системе.

```csharp
using Leopotam.EcsLite;

public void TestSystem : IEcsRunSystem
{
    private EcsPool<DebugComponent> _debugComponentPool;
    
    public void Run(IEcsSystems systems)
    {
        ...
    }
}
```

## OneFrame Systems

Если Вам необходимо удалять в конце работы систем какой-либо компонент, LeoECS Lite Unity Zoo предоставляет Вам возможность это сделать через OneFrame-системы. 
Просто добавьте `.OneFrame<T>()` в конец Вашего списка систем с указанием необходимого для очистки типа компонентов.

```csharp
...
protected override void SetupUpdateSystems(EcsFeatureSystems ecsFeatureSystems)
{
    ecsFeatureSystems
        .Add(new DebugTeleportSystem())
        .OneFrame<DebugComponent>()
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
var world = ConvertToEntity.DefaultConversionWorld;

world.NewEntityWith<TestComponent>() = new TestComponent()
{
    Value = "something"
};
```

# Лицензия

Код и документация Copyright (c) 2022-2023 Alexander Travkin.

Распространяется под MIT license.