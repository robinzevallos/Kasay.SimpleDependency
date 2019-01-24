using Kasay.SimpleDependency;
using System;
using System.Collections.Generic;
using System.Reflection;

public static class SimpleDependency
{
    static AssemblyFactory assemblyBuilder;
    static Dictionary<Type, Object> dependencyImplementations;

    public static void Init()
    {
        assemblyBuilder = new AssemblyFactory();
        dependencyImplementations = new Dictionary<Type, Object>();

        AddInstances();
    }

    public static T GetInstance<T>()
    {
        return (T)dependencyImplementations[typeof(T)];
    }

    static void AddInstances()
    {
        foreach (var assembly in assemblyBuilder.GetAssemblies())
        {
            foreach (var type in assembly.GetTypes())
            {
                AddInstance(type);
            }
        }
    }

    static void AddInstance(Type type)
    {
        var dependecyAttribute = type.GetCustomAttribute<SimpleDependencyAttribute>();

        if (dependecyAttribute != null)
            dependencyImplementations.Add(dependecyAttribute.Implementor, Activator.CreateInstance(type));
    }
}
