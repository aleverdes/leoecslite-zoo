# 🦁 LeoECS Lite Unity Zoo

LeoECS Lite Unity Zoo is a big add-on to [LeoECS Lite](https://github.com/Leopotam/ecslite) for Unity, including the following features:
* ECS Manager;
* ECS Modules;
* ECS Features;
* ECS Injection;
* ECS Component Conversion;
* Unity Core ECS Components; 
* Several extensions for EcsWorld, IEcsSystems and Unity-objects.

# Table of Contents

* [Introduction](#introduction)
* [Installation](#installation)
    * [Unity Package Manager](#unity-package-manager)
    * [Manual installation](#manual-installation)
* [Usage](#usage)
    * [ECS Startup Example](#ecs-startup-example)     
    * [ECS Module Installer Example](#ecs-module-installer-example)     
    * [ECS Feature Example](#ecs-feature-example)     
* [Features](#features) 
    * [ECS Module](#ecs-module)
    * [ECS Module Installer](#ecs-module-installer)
    * [ECS Feature](#ecs-feature)
    * [ECS Unity Core Components](#ecs-unity-core-components)
    * [ECS Components Conversion](#ecs-components-conversion)
    * [ECS Injection](#ecs-injection)
        * [ECS Query](#ecs-query)
        * [ECS Injection Context](#ecs-injection-context)
        * [Manual Injection](#manual-injection)
        * [EcsWorld Injection](#ecsworld-injection)
        * [EcsPool Injection](#ecspool-injection)
    * [DelHere Systems](#delhere-systems)
    * [LeoECS Lite Extensions](#leoecs-lite-extensions)
        * [Unity Extensions](#unity-extensions)
        * [ECS World Extensions](#ecs-world-extensions)
* [License](#license)

# Introduction

I developed LeoECS Lite Unity Zoo for my own use and have been developing it for a long time using it in my own projects. 
This add-on includes many features that simplify and speed up development, while not changing the main concept of LeoECS Lite. 
Any bug reports and suggestions for improvements are welcome.

# Installation

## Unity Package Manager

Installation is supported as a unity module via a git link in the PackageManager or direct editing of `Packages/manifest.json`:
```
"com.aleverdes.leoecslite-zoo": "https://github.com/aleverdes/leoecslite-zoo.git",
```

## Manual installation

The code can also be cloned or obtained as an archive from the releases page.
Just put the LeoECS Lite Zoo folder in your unity project (in the Assets folder).

# Usage

Below is an example of how to run ECS Manager from LeoECS Lite Zoo along with injection, world initialization and systems running.

## ECS Startup Example

```csharp
using AleVerDes.LeoEcsLiteZoo;

public class MainEcsStartup : MonoBehaviour
{
    [SerializeField] private List<EcsInjectionContext> _injectionContexts;

    private EcsWorld _world;
    private EcsManager _ecsManager;

    private void Awake()
    {
        _world = new EcsWorld();
        ConvertToEntity.DefaultConversionWorld = _world;
        
        _ecsManager = new EcsManager();
        _ecsManager.SetWorld(_world);
        
        foreach (var injectionContext in _injectionContexts)
        {
            injectionContext.InitInjector();
            _ecsManager.AddInjector(injectionContext.GetInjector());   
        }
    }

    private void Start()
    {
        _ecsManager.InstallModule(new MainEcsModuleInstaller());
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

    private void OnDestroy()
    {
        _ecsManager.Destroy();
    }
}
```

## ECS Module Installer Example

```csharp
using AleVerDes.LeoEcsLiteZoo;

public class MainEcsModuleInstaller : IEcsModuleInstaller
{
    public IEcsModule Install()
    {
        var module = new EcsModule();
        
        module
            .AddFeature(new DebugFeature())
            .AddFeature(new PlayerFeature())
            ;

        return module;
    }
}
```

## ECS Feature Example

```csharp
using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;

public class DebugFeature : IEcsUpdateFeature, IEcsLateUpdateFeature, IEcsFixedUpdateFeature, IEcsInjectionFeature
{
    // Implementation of IEcsUpdateFeature - Systems that will be running in the Unity Update().
    public void SetupUpdateSystems(IEcsSystems systems)
    {
        systems
            .Add(new TestSystem())
            .Add(new DebugTeleportSystem())
            .DelHere<TestEvent>() // in this point all TestEvent components will be deleted from your entites
            ;
    }

    // Implementation of IEcsLateUpdateFeature - Systems that will be running in the Unity LateUpdate().
    public void SetupLateUpdateSystems(IEcsSystems systems)
    {
    }

    // Implementation of IEcsFixedUpdateFeature - Systems that will be running in the Unity FixedUpdate().
    public void SetupFixedUpdateSystems(IEcsSystems systems)
    {
    }

    // Implementation of EcsInjectionFeature - Here you can configure the injector common to the EcsModule.
    // All objects that you inject here will fall into all declared fields of all systems and other injection objects.
    // That is, these DebugService and TestService will be available not only in systems, but also in other services of other EcsFeatures of this EcsModule.
    public void SetupInjector(IEcsInjector injector)
    {
        injector
            .AddInjectionObject(new DebugService(), typeof(IDebugService), typeof(DebugService))
            .AddInjectionObject<ITestService>(new TestService())
            ;
    }
}
```

## ECS System Example

```csharp
using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;
using UnityEngine;

public class TestSystem : IEcsRunSystem
{
    // Automatically EcsWorld injection
    private EcsWorld _world;

    // Automatically EcsPool injection
    private EcsPool<Position> _position;
    private EcsPool<Move> _move;

    // Injectable alternative for EcsFilter
    private EcsQuery<TransformRef, Move>.Exc<Inactive> _query;
    
    // You can inject any injection object from any EcsFeature in this EcsModule
    private IDebugService _debugService;

    public void Run(IEcsSystems systems)
    {
        // Example of EcsQuery.GetEnumerator
        foreach (var entity in _query)
        {
            ref var position = ref _position.Get(entity);
            ref var move = ref _move.Get(entity);
            
            position.Value += move.UnitsPerSecond * Time.DeltaTime;
            
            if (position.Value > 1f)
            {
                position.Value = 0;

                // Example of NewEntityWith<T>
                _world.NewEntityWith<TestEvent>() = new TestEvent()
                {
                    Entity = entity
                };

                _debugService.InvokeTestMethod();
            }
        }
    }
}
```

# Features

## ECS Module

**ECS Module** is a container that is created and filled by **ECS Feature** using **ECS Module Installer**. The only way to organize code and execute it using **ECS Manager**.

## ECS Module Installer

**ECS Module Installer** is a special class that implements the `IEcsModuleInstaller` interface, in particular the `public IEcsModule Install() {}` method. It is assumed that a unique **ECS Module** will be created in the body of this method, which will be immediately filled with the necessary list of **ECS Features**.

The **ECS Module Installer** is used in the `InstallModule(IEcsModuleInstaller)` method of the **ECS Manager** class. This means that installer is the only correct way to create **ECS Modules** and then register them in **ECS Manager** for execution.

```csharp
using AleVerDes.LeoEcsLiteZoo;

public class MainEcsModuleInstaller : IEcsModuleInstaller
{
    public IEcsModule Install()
    {
        var module = new EcsModule();
        
        module
            .AddFeature(new DebugFeature())
            .AddFeature(new PlayerFeature())
            ;

        return module;
    }
}
```

## ECS Feature

ECS Feature is the main way to organize and group in-game systems by context.

```csharp
using AleVerDes.LeoEcsLiteZoo;
using Leopotam.EcsLite;

public class DebugFeature : IEcsFeature
{
    public void SetupUpdateSystems(IEcsSystems systems)
    {
        systems
            .Add(new DebugTeleportSystem())
            ;
    }

    public void SetupLateUpdateSystems(IEcsSystems systems)
    {
    }

    public void SetupFixedUpdateSystems(IEcsSystems systems)
    {
    }

    public void SetupInjector(IEcsInjector injector)
    {
        injector
            .AddInjectionObject(new DebugService(), typeof(IDebugService), typeof(DebugService))
            .AddInjectionObject<ITestService>(new TestService())
            ;
    }
}
```

## ECS Unity Core Components

* EcsTransform is a representation of an ECS Transform that includes the position, rotation, and scale of an object.
* TransformRef contains a reference to Unity-transform.
* RigidbodyRef contains a reference to Unity-rigidbody.
* GameObjectRef contains a reference to the GameObject.
* RectTransformRef contains a reference to a RectTransform.
* Rigidbody2DRef contains a reference to a Rigidbody2D and works the same as RigidbodyRef.
* UnityRef<T> where T : UnityEngine.Object, IUnityRef

```csharp
using System;
using UnityEngine;

namespace AleVerDes.LeoEcsLiteZoo
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
    
    public struct UnityRef<T> where T : UnityEngine.Object
    {
        public T Value;
    }
}
```

## ECS Components Conversion

LeoECS Lite Unity Zoo provides a mechanism to convert your components to ECS.
To do this, you need to add the `ConvertToEntity` component and your MonoBehaviour class that implements the `IConvertToEntity` interface to the object.

> Important! Using ConvertToEntity is only possible if the any world is registered as `ConvertToEntity.DefaultConversionWorld`.

For more convenient work with Unity objects, LeoECS Lite Unity Zoo includes functions for converting Unity objects into ECS-entities with the necessary components.

I recommended to use Bootstrappers:

```csharp
using AleVerDes.LeoEcsLiteZoo;

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

## ECS Injection

LeoECS Lite Unity Zoo provides a mechanism for injecting your classes into the system's ECS. 

### ECS Query

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
            // process entities
        }
        
        var entitesCount = _includeOnlyQuery.GetFilter().GetEntitiesCount();
    }
}
```

### ECS Injection Context

An extremely simple way to declare injections in code. It is enough to simply declare a class that will be the successor of EcsInjectionContext, and in it register the fields that you want to inject.

```csharp
using AleVerDes.LeoEcsLiteZoo;

public class GameEcsInjectionContext : EcsInjectionContext

    [SerializedField] private TestMonoBehaviour _testMonoBehaviour;
    [SerializedField] private TestScriptableObject _testScriptableObject;
}
```

In the future, you just need to initialize the EcsInjectionContext and register the context Injector in the EcsManager.

```csharp
using AleVerDes.LeoEcsLiteZoo;

public class GameEcsStartup : MonoBehaviour
{
    [SerializeField] private List<EcsInjectionContext> _injectionContexts;

    private IEcsManager _ecsManager;
        
    private void Start()
    {
        ...
        foreach (var injectionContext in _injectionContexts)
        {
            injectionContext.InitInjector();
            _ecsManager.AddInjector(injectionContext.GetInjector());   
        }
        ...
    }
}
```

The main thing is to remember to add your new Injection Context to the list!

### Manual Injection

If you need to inject an object manually, then use this method:

```csharp
var ecsInjectionContext = FindObjectOfType<EcsInjectionContext>();
...
ecsInjectionContext.GetInjector().AddInjectionObject(Value);
```

### EcsWorld Injection

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

### EcsPool Injection

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

## DelHere Systems

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

# License

Code and documentation Copyright (c) 2022-2023 Alexander Travkin.

Code released under the MIT license.
