using System;
using System.Collections.Generic;
using System.Linq;

public static class Instance<T> where T : class
{
    static Dictionary<Type, Object> instancesContainer;
    static readonly List<Type> types = new List<Type>();

    public static T Get()
    {
        if (instancesContainer is null)
            Init();

        if (!instancesContainer.ContainsKey(typeof(T)))
            SetInstance();      

        return (T)instancesContainer[typeof(T)];
    }

    static void Init()
    {
        instancesContainer = new Dictionary<Type, Object>();

        SetTypes();
    }

    static void SetTypes()
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            types.AddRange(assembly.GetTypes());
        }
    }

    static void SetInstance()
    {
        var type = types
            .Where(_ => _.GetInterface(typeof(T).Name) == typeof(T))
            .FirstOrDefault();

        if (type != null)
            instancesContainer.Add(typeof(T), Activator.CreateInstance(type));
    }
}
