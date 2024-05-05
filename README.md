# 🦁 LeoECS Lite Unity Zoo

LeoECS Lite Unity Zoo is a big add-on to [LeoECS Lite](https://github.com/Leopotam/ecslite) for Unity, including the following features:
* ECS Runner;
* ECS Features;
* ECS Injection and custom DI containers support;
* ECS Component Conversion;
* Unity Core ECS Components; 
* Several extensions for EcsWorld, IEcsSystems and Unity-objects.

# Table of Contents

* [Introduction](#-introduction)
* [Requirements](#-requirements)
* [Installation](#-installation)
  * [Unity Package Manager](#-unity-package-manager)
  * [Manual installation](#-manual-installation)
* [Usage](#-usage)
  * [ECS Module Example](#-ecs-module-example)
  * [ECS Feature Example](#-ecs-feature-example)
  * [ECS System Example](#-ecs-system-example)
* [Work with DI Containers](#-work-with-di-containers)
  * [Zenject](#-zenject)
* [Features](#-features)
  * [ECS Module](#-ecs-module)
  * [ECS Feature](#-ecs-feature)
  * [ECS UnityObject Reference Component](#-ecs-unityobject-reference-component)
  * [ECS Components Conversion](#-ecs-components-conversion)
  * [ECS Injection](#-ecs-injection)
    * [ECS Query](#-ecs-query)
    * [EcsWorld Injection](#-ecsworld-injection)
    * [EcsPool Injection](#-ecspool-injection)
  * [DelHere Systems](#-delhere-systems)
  * [LeoECS Lite Extensions](#-leoecs-lite-extensions)
    * [Unity Extensions](#-unity-extensions)
    * [ECS World Extensions](#-ecs-world-extensions)
    * [Zenject Extensions](#-zenject-extensions)
* [License](#-license)


# 📘 Introduction

I developed LeoECS Lite Unity Zoo for my own use and have been developing it for a long time using it in my own projects. 
This add-on includes many features that simplify and speed up development, while not changing the main concept of LeoECS Lite. 
Any bug reports and suggestions for improvements are welcome.

# 📋 Requirements

* Unity 2019.4 or higher
* [LeoECS Lite 2022.3.22 or higher](https://github.com/Leopotam/ecslite)
* DI Container
  * For example: [Zenject 9.2.0 or higher](https://github.com/modesttree/Zenject/)

# 🛠️ Installation

## 🌐 Unity Package Manager

Installation is supported as a unity module via a git link in the PackageManager or direct editing of `Packages/manifest.json`:
```
"com.aleverdes.leoecslite-zoo": "https://github.com/aleverdes/leoecslite-zoo.git",
```

## 📦 Manual installation

The code can also be cloned or obtained as an archive from the releases page.
Just put the LeoECS Lite Zoo folder in your unity project (in the Assets folder).

# 🚀 Usage

Below is an example of how to run ECS Manager from LeoECS Lite Zoo along with injection, world initialization and systems running.

## ⭐ ECS Feature Example

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

## 🎮 ECS System Example

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

# 📦 Work with DI Containers

## 💉 Zenject

You need to declare the `EcsInstaller` class and bind the `GameEcsRunner` module to the DI container.
Also, you need to call the `RunFeatures` method to add the `TestFeature` to the `GameEcsRunner`.
For every ECS runner you can create a new world and add features to it.
For it you can use `.AsTransient()` for `GameEcsRunner` binding and declare a specific ECS Modules in separated scenarios or services.

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

In `GameEcsRunner` you need to implement invokes of the all methods of base `EcsRunner`: `Init()`, `Update()`, `LateUpdate()`, `FixedUpdate()`, `Destroy()`.

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

# 🌟 Features

## 🧩 ECS Feature

ECS Feature is the main way to organize and group in-game systems by context.

There are four types and each type can be combined with others.

- `EcsUpdateFeature` is a feature that runs in Unity `Update()`.
- `EcsLateUpdateFeature` is a feature that runs in Unity `LateUpdate()`.
- `EcsFixedUpdateFeature` is a feature that runs in Unity `FixedUpdate()`.

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

## 🎮 ECS UnityObject Reference Component

* UnityObjectRef<T> where T : UnityEngine.Object

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

## 🔁 ECS Components Conversion

LeoECS Lite Unity Zoo provides a mechanism to convert your components to ECS.
To do this, you need to add the `ConvertToEntity` component and your MonoBehaviour class that implements the `IConvertableToEntity` interface to the object.

For more convenient work with Unity objects, LeoECS Lite Unity Zoo includes functions for converting Unity objects into ECS-entities with the necessary components.

I recommended to use Bootstrappers:

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

Or

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

An easier way to convert your component to ECS is to use the ConvertComponent<T> class.

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

And for the correct conversion of Unity objects, you must use the `UnityObjectProvider` component. 
`UnityObjectProvider` calls the function to link gameobject, transform and rigidbody with the ECS entity.

## 💉 ECS Injection

LeoECS Lite Unity Zoo provides a mechanism for injecting your classes into the system's ECS.

### 🔍 ECS Query

`EcsQuery` is a filter wrapper that is automatically injected into systems and other injectables.
To use `EcsQuery`, you just need to declare it in your system, and `EcsQuery` will automatically create its own wrapper over the filter.
Next, you can call foreach using `EcsQuery` as if using a regular filter.
If you need to directly access the `EcsFilter` of this `EcsQuery`, just call the `GetFilter()` method;

To specify Include filter mask, just describe the list of the components in the generic parameters for `EcsQuery<T...>`.

To specify Exclude a filter mask, just describe the list of the components in the generic parameters for `EcsQuery<T1...>.Exc<T2...>`. Filter (and Query) cannot be created without an Include mask.

**Limit**: 16 components for Include mask and 16 components for Exclude mask.

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

### 🌍 EcsWorld Injection

So, you can use EcsWorld-injection in your systems:

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

### 🏊 EcsPool Injection

So, you can use EcsPool-injection in your systems:

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

## 🖥️ DelHere Systems

LeoECS Lite Unity Zoo introduces a mechanism for removing single-frame components. 
Just add the DelHere<T>() method to the end of your systems list declaration.

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

## 🌟 LeoECS Lite Extensions

### 🎮 Unity Extensions

```csharp
if (gameObject.TryGetEntity(out int entity))
    Debug.Log(entity);
```

### 🌍 ECS World Extensions

```csharp
var world = ConvertToEntity.DefaultConversionWorld;

world.NewEntityWith<TestComponent>() = new TestComponent()
{
    Value = "something"
};
```

### 💉 Zenject Extensions

You can use the `BindNewEcsWorldFor<T>()` extension to instantiate your single world with runners for specified module.

```csharp
Container.BindNewEcsWorldFor<GameEcsModule>().NonLazy();
```

You can use the `WithEcsModule<T>()` extension to instantiate your modules into `EcsRunner`.

```csharp
Container.BindInterfacesAndSelfTo<EcsRunner>().WithEcsModule<GameEcsModule>().NonLazy();
```

# ©️ License

Code and documentation Copyright (c) 2022-2024 Alexander Travkin.

Code released under the MIT license.
