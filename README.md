# LeoECS Lite Unity Zoo

LeoECS Lite Unity Zoo is a big add-on to [LeoECS Lite](https://github.com/Leopotam/ecslite) for Unity, including the following features:
* ECS Startup (plain and feature-based);
* ECS Component Conversion;
* Unity Core ECS Components;
* ECS Injection; 
* Several extensions for EcsWorld, IEcsSystems and Unity-objects.

Link for [Russian README](https://github.com/aleverdes/leoecslite-zoo/blob/master/README_RU.md).

# Table of Contents

* [Introduction](#introduction)
* [Installation](#installation)
    * [Unity Package Manager](#unity-package-manager)
    * [Manual installation](#manual-installation)
* [Features](#features)
    * [ECS World Provider](#ecs-world-provider)
    * [Plain ECS Startup](#plain-ecs-startup)
    * [Feature-based ECS Startup](#feature-based-ecs-startup)
    * [ECS Unity Core Components](#ecs-unity-core-components)
    * [ECS Components Conversion](#ecs-components-conversion)
    * [ECS Injection and Globals](#ecs-injection-and-globals)
        * [GlobalMonoBehaviour](#globalmonobehaviour)
        * [Manual Injection](#manual-injection)
        * [Globals](#globals)
        * [EcsWorld Injection](#ecsworld-injection)
    * [OneFrame Systems](#oneframe-systems)
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
"com.affencode.leoecslite-zoo": "https://github.com/aleverdes/leoecslite-zoo.git",
```

## Manual installation

The code can also be cloned or obtained as an archive from the releases page.
Just put the LeoECS Lite Zoo folder in your unity project (in the Assets folder).

# Features

## ECS World Provider

The ECS World Provider is a MonoBehaviour class that contains the creation and deletion of an EcsWorld. 
You can also access the world through the corresponding World property.
The first world created is registered as the default world and is available through the static property `EcsWorldProvider.DefaultWorldProvider.World`.

Just add the EcsWorldProvider component to any scene object and a new EcsWorld will be created when the scene starts. 

## Plain ECS Startup

By itself, the ECS Startup class allows you to define a class in a few lines of code with the declaration of all the systems necessary for your application to work.
Plain ECS Startup is required for flat definition of systems for the format of Unity update methods.

EcsStartup is also a MonoBehaviour-class and requires the presence of this component on the scene to work.

For ECS Startup to work, you need a reference to the EcsWorldProvider component, I recommend creating an "ECS" object on the scene and adding the EcsWorldProvider components and the EcsStartup class heir to it.

EcsStartup includes functionality to synchronize EcsTransform with Unity-Transform component. Read more in [ECS Unity Core Components](#ecs-unity-core-components).

Just derive your class from EcsStartup and populate it with your systems.

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

FeaturedEcsStartup is a more complex but more convenient way to organize your systems in a project.

To organize the code, objects of the `IEcsFeature` type are added to FeaturedEcsStartup, which already include the declaration of the methods necessary for Unity to work correctly.

FeaturedEcsStartup is also a MonoBehaviour class and requires the presence of this component on the scene to work.

For FeaturedEcsStartup to work, you need a reference to the EcsWorldProvider component, I recommend creating an "ECS" object on the stage and adding the EcsWorldProvider components and the FeaturedEcsStartup class descendant to it.

FeaturedEcsStartup includes functionality to synchronize EcsTransform with UnityTransform. Read more in [ECS Unity Core Components](#ecs-unity-core-components).

Just derive your class from FeaturedEcsStartup and populate it with your features with systems.

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

EcsTransform is the main component, analogous to Transform in Unity, which contains information about the position, rotation and scale of an object. By default it works in global coordinates. If you need to get search results (if you have a TransformRef component) to local coordinates, add the LocalTransformSync component to the selected entity.
* EcsTransform is a representation of an ECS Transform that includes the position, rotation, and scale of an object.
* TransformRef contains a reference to Unity-transform.
  * Having both EcsTransform and TransformRef components allows the ECS state of transform to be synchronized with Unity-transform (only if you use EcsStartup or FeaturedEcsStartup).
* RigidbodyRef contains a reference to Unity-rigidbody.
  * Having both EcsTransform and RigidbodyRef components allows the ECS state of the transform to be synchronized with the Unity-rigidbody (only if you use EcsStartup or FeaturedEcsStartup). Synchronization is done in FixedUpdate().
* LocalTransformSync allows you to switch the synchronization of global coordinates to local ones for the EcsTransform and TransformRef (or EcsTransform and RigidbodyRef) binding.

Also:
* GameObjectRef contains a reference to the GameObject.
* RectTransformRef contains a reference to a RectTransform.
* Rigidbody2DRef contains a reference to a Rigidbody2D and works the same as RigidbodyRef.

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

LeoECS Lite Unity Zoo provides a mechanism to convert your components to ECS.
To do this, you need to add the `ConvertToEntity` component and your MonoBehaviour class that implements the `IConvertToEntity` interface to the object.

> Important! Using ConvertToEntity is only possible if the scene has an `EcsWorldProvider` or if any of the worlds is registered with `ConvertToEntity.DefaultConversionWorld`.

For more convenient work with Unity objects, LeoECS Lite Unity Zoo includes functions for converting Unity objects into ECS-entities with the necessary components.

I recommended to use Bootstrappers:

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

An easier way to convert your component to ECS is to use the ConvertComponent<T> class.

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

And for the correct conversion of Unity objects, you must use the `UnityObjectProvider` component. 
`UnityObjectProvider` calls the function to link gameobject, transform and rigidbody with the ECS entity.

## ECS Injection and Globals

LeoECS Lite Unity Zoo provides a mechanism for injecting your classes into the system's ECS and using Globals.

> **Important!** EcsInjection works by default only with EcsStartup and FeaturedEcsStartup. If you want to use Injection with your own ECS-definition, put `.Inject()`-method to the end of definition your EcsSystems. 

### GlobalMonoBehaviour

The easiest way, suitable for MonoBehaviour classes, is to inherit from the GlobalMonoBehaviour class.
Such a class should be in a single copy on the scene.
Further, you can simply declare a variable of the corresponding class in your system and use it.

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

If you want to manually declare your object as injectable, use the `LeoEcsInjector.AddInjection(this)` method.

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

There is also a Globals used as a ServiceLocator. Access to objects is provided through the Globals class.

```csharp
private void Awake()
{
    Globals.Add(this);
}

private void OnDestroy()
{
    Globals.Remove(this);
}
```
```csharp
if (Globals.Has<TestClass>())
{
    var test = Globals.Get<TestClass>();
}
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

## OneFrame Systems

LeoECS Lite Unity Zoo introduces a mechanism for removing single-frame components. 
Just add the OneFrame<T> method to the end of your systems list declaration.

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

# License

Code and documentation Copyright (c) 2022-2023 Alexander Travkin.

Code released under the MIT license.