

# 🦁 LeoECS Lite Unity Zoo

LeoECS Lite Unity Zoo es un gran complemento para [LeoECS Lite](https://github.com/Leopotam/ecslite) para Unity, que incluye las siguientes características:
* ECS Runner;
* ECS Features;
* Soporte para inyección ECS y contenedores DI personalizados;
* Conversión de componentes ECS;
* Componentes ECS principales de Unity; 
* Varias extensiones para EcsWorld, IEcsSystems y objetos de Unity.

# Tabla de Contenido

* [Introducción](#-introduction)
* [Requisitos](#-requirements)
* [Instalación](#-installation)
  * [Unity Package Manager](#-unity-package-manager)
  * [Instalación manual](#-manual-installation)
* [Uso](#-usage)
  * [Ejemplo de módulo ECS](#-ecs-module-example)
  * [Ejemplo de característica ECS](#-ecs-feature-example)
  * [Ejemplo de sistema ECS](#-ecs-system-example)
* [Trabajar con contenedores DI](#-work-with-di-containers)
  * [Zenject](#-zenject)
* [Características](#-features)
  * [Módulo ECS](#-ecs-module)
  * [Característica ECS](#-ecs-feature)
  * [Componente de referencia ECS UnityObject](#-ecs-unityobject-reference-component)
  * [Conversión de componentes ECS](#-ecs-components-conversion)
  * [Inyección ECS](#-ecs-injection)
    * [Consulta ECS](#-ecs-query)
    * [Inyección de EcsWorld](#-ecsworld-injection)
    * [Inyección de EcsPool](#-ecspool-injection)
  * [Sistemas DelHere](#-delhere-systems)
  * [Extensiones de LeoECS Lite](#-leoecs-lite-extensions)
    * [Extensiones de Unity](#-unity-extensions)
    * [Extensiones de mundo ECS](#-ecs-world-extensions)
* [Licencia](#-license)


# 📘 Introducción

Desarrollé LeoECS Lite Unity Zoo para mi propio uso y lo he estado desarrollando durante mucho tiempo utilizándolo en mis propios proyectos. 
Este complemento incluye muchas características que simplifican y aceleran el desarrollo, sin cambiar el concepto principal de LeoECS Lite. 
Se aceptan informes de errores y sugerencias para mejoras.

# 📋 Requisitos

* Unity 2019.4 o superior
* [LeoECS Lite 2022.3.22 o superior](https://github.com/Leopotam/ecslite)
* Contenedor DI
  * Por ejemplo: [Zenject 9.2.0 o superior](https://github.com/modesttree/Zenject/)

# 🛠️ Instalación

## 🌐 Unity Package Manager

La instalación se admite como un módulo de Unity a través de un enlace git en el PackageManager o mediante la edición directa de `Packages/manifest.json`:
```
"com.aleverdes.leoecslite-zoo": "https://github.com/aleverdes/leoecslite-zoo.git",
```

## 📦 Instalación manual

El código también se puede clonar u obtener como un archivo desde la página de versiones.
Solo coloca la carpeta LeoECS Lite Zoo en tu proyecto de Unity (en la carpeta Assets).

# 🚀 Uso

A continuación se muestra un ejemplo de cómo ejecutar el ECS Manager de LeoECS Lite Zoo junto con la inyección, la inicialización del mundo y la ejecución de sistemas.

## ⭐ Ejemplo de característica ECS

```csharp
using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;
using Zenject;

namespace EcsSample
{
    public class TestFeature : IEcsUpdateFeature
    {
        [Inject] private readonly DiContainer _diContainer;
        
        public void SetupUpdateSystems(IEcsSystems systems)
        {
            systems.Add(_diContainer.Instantiate<TestSystem>());
        }
    }
}
```

## 🎮 Ejemplo de sistema ECS

```csharp
using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

namespace EcsSample
{
    public class TestSystem : IEcsInitSystem, IEcsRunSystem
    {
        [Inject] private TestObject _testObject;
        
        private EcsWorld _world;
        
        private EcsPool<TestComponent1> _testComponent1Pool;
        private EcsPool<TestComponent2> _testComponent2Pool;
        
        private EcsQuery<TestComponent1, TestComponent2> _query;
        
        public void Init(IEcsSystems systems)
        {
            var e1 = _world.NewEntity();
            _testComponent1Pool.Add(e1);
            
            var e2 = _world.NewEntity();
            _testComponent1Pool.Add(e2).Counter = 1234;
            
            Debug.Log(_testObject.name);
        }
        
        public void Run(IEcsSystems systems)
        {
            foreach (var e in _testComponent1Query)
            {
                ref var testComponent1 = ref _testComponent1Pool.Get(e);
                testComponent1.Counter++;
                Debug.Log($"TestComponent1.Counter: {testComponent1.Counter}");
            }
        }
    }
}
```

# 📦 Trabajar con contenedores DI

## 💉 Zenject

Debes declarar la clase `EcsInstaller` y vincular el módulo `GameEcsRunner` al contenedor DI.
Además, debes llamar al método `RunFeatures` para agregar `TestFeature` a `GameEcsRunner`.
Para cada ejecutor ECS puedes crear un mundo nuevo y agregarle características.
Para ello, puedes usar `.AsTransient()` para la vinculación de `GameEcsRunner` y declarar módulos ECS específicos en escenarios o servicios separados.

```csharp
using Leopotam.EcsLite;
using Zenject;

namespace EcsSample
{
    public class EcsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<GameEcsRunner>()
                .AsSingle()
                .OnInstantiated(RunFeatures)
                .NonLazy();
        }

        private void RunFeatures(InjectContext injectContext, object o)
        {
            if (o is not GameEcsRunner ecsRunner)
                throw new System.Exception("EcsRunner is not injected");
            
            var container = injectContext.Container;
            
            ecsRunner
                .SetWorld(new EcsWorld())
                .AddFeature(container.Instantiate<TestFeature>());
        }
    }
}
```

En `GameEcsRunner` debes implementar las invocaciones de todos los métodos de `EcsRunner` base: `Init()`, `Update()`, `LateUpdate()`, `FixedUpdate()`, `Destroy()`.

```csharp
using System;
using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;
using Zenject;

namespace EcsSample
{
    public class GameEcsRunner : EcsRunner, IInitializable, ITickable, ILateTickable, IFixedTickable, IDisposable
    {
        public void Initialize()
        {
            Init();
        }
        
        public void Tick()
        {
            Update();
        }

        public void LateTick()
        {
            LateUpdate();
        }

        public void FixedTick()
        {
            FixedUpdate();
        }

        public void Dispose()
        {
            Destroy();
        }
    }
}
```

# 🌟 Características

## 🧩 Característica ECS

ECS Feature es la forma principal de organizar y agrupar sistemas del juego por contexto.

Existen cuatro tipos y cada tipo puede combinarse con otros.

- `EcsUpdateFeature` es una característica que se ejecuta en `Update()` de Unity.
- `EcsLateUpdateFeature` es una característica que se ejecuta en `LateUpdate()` de Unity.
- `EcsFixedUpdateFeature` es una característica que se ejecuta en `FixedUpdate()` de Unity.

```csharp
using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;

public class DebugFeature : IEcsUpdateFeature, IEcsLateUpdateFeature, IEcsFixedUpdateFeature
{
    [Inject] private readonly DiContainer _diContainer;
    
    public void SetupUpdateSystems(IEcsSystems systems)
    {
        systems.Add(_diContainer.Instantiate<TestSystem>());
    }

    public void SetupLateUpdateSystems(IEcsSystems systems)
    {
    }

    public void SetupFixedUpdateSystems(IEcsSystems systems)
    {
    }
}
```

## 🎮 Componente de referencia ECS UnityObject

* UnityObjectRef<T> donde T : UnityEngine.Object

```csharp
using System;
using UnityEngine;

namespace AleVerDes.LeoEcsLiteZoo
{
    [Serializable]
    public struct UnityObjectRef<T> where T : UnityEngine.Object
    {
        public T Value;
    }
}
```

## 🔁 Conversión de componentes ECS

LeoECS Lite Unity Zoo proporciona un mecanismo para convertir tus componentes a ECS.
Para hacerlo, debes agregar el componente `ConvertToEntity` y tu clase MonoBehaviour que implementa la interfaz `IConvertableToEntity` al objeto.

Para un trabajo más conveniente con objetos de Unity, LeoECS Lite Unity Zoo incluye funciones para convertir objetos de Unity en entidades ECS con los componentes necesarios.

Recomiendo utilizar Bootstrappers:

```csharp
using AleVerDes.LeoEcsLiteZoo;

[RequireComponent(typeof(ConvertToEntity))]
public class PlayerBootstrapper : MonoBehaviour, IConvertableToEntity
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

O

```csharp
using AleVerDes.LeoEcsLiteZoo;

public class PlayerBootstrapper : EcsEntityProvider
{
    protected override void Setup()
    {
        Add<TestComponent>() = new TestComponent()
        {
            Name = "Test"
        };
    }
}
```

Una forma más fácil de convertir tu componente a ECS es usar la clase ConvertComponent<T>.

```csharp
using AleVerDes.LeoEcsLiteZoo;

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

Y para la conversión correcta de objetos de Unity, debes usar el componente `UnityObjectProvider`. 
`UnityObjectProvider` llama a la función para vincular gameobject, transform y rigidbody con la entidad ECS.

## 💉 Inyección ECS

LeoECS Lite Unity Zoo proporciona un mecanismo para inyectar tus clases en el ECS del sistema.

### 🔍 Consulta ECS

`EcsQuery` es un envoltorio de filtro que se inyecta automáticamente en sistemas y otros elementos inyectables.
Para usar `EcsQuery`, solo necesitas declararlo en tu sistema, y `EcsQuery` creará automáticamente su propio envoltorio sobre el filtro.
A continuación, puedes usar foreach con `EcsQuery` como si usaras un filtro normal.
Si necesitas acceder directamente al `EcsFilter` de este `EcsQuery`, simplemente llama al método `GetFilter()`;

Para especificar la máscara de filtro Include, solo describe la lista de los componentes en los parámetros genéricos para `EcsQuery<T...>`.

Para especificar una máscara de filtro Exclude, solo describe la lista de los componentes en los parámetros genéricos para `EcsQuery<T1...>.Exc<T2...>`. El filtro (y la consulta) no se puede crear sin una máscara Include.

**Límite**: 16 componentes para la máscara Include y 16 componentes para la máscara Exclude.

```csharp
using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;

public void TestSystem : IEcsRunSystem
{
    private EcsQuery<Test> _includeOnlyQuery;
    private EcsQuery<Health, Respawnable, HasSpawnPoint>.Exc<Dead> _deadQuery;
    
    public void Run(IEcsSystems systems)
    {
        foreach (var entity in _deadQuery)
        {
            // use pools to get components
        }
        
        var entitesCount = _includeOnlyQuery.GetFilter().GetEntitiesCount();
    }
}
```

### 🌍 Inyección de EcsWorld

Así, puedes usar la inyección de EcsWorld en tus sistemas:

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

### 🏊 Inyección de EcsPool

Así, puedes usar la inyección de EcsPool en tus sistemas:

```csharp
using Leopotam.EcsLite;

public void TestSystem : IEcsRunSystem
{
    private EcsPool<Test> _test;
    
    public void Run(IEcsSystems systems)
    {
        if (_test.Has(0))
        {
            Debug.Log("Exists");
        }
    }
}
```

## 🖥️ Sistemas DelHere

LeoECS Lite Unity Zoo introduce un mecanismo para eliminar componentes de un solo frame. 
Solo agrega el método DelHere<T>() al final de la declaración de tu lista de sistemas.

```csharp
...
public void Update(IEcsSystems ecsSystems)
{
    ecsSystems
        .Add(new TestUpdateSystem())
        .DelHere<TestComponent>()
        ;
}
```

## 🌟 Extensiones de LeoECS Lite

### 🎮 Extensiones de Unity

```csharp
if (gameObject.TryGetEntity(out int entity))
    Debug.Log(entity);
```

### 🌍 Extensiones de mundo ECS

```csharp
world.NewEntityWith<TestComponent>() = new TestComponent()
{
    Value = "something"
};
```

# ©️ Licencia

Código y documentación Copyright (c) 2022-2024 Alexander Travkin.

Código publicado bajo la licencia MIT.
