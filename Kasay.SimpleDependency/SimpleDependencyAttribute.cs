using System;

[AttributeUsage(AttributeTargets.Class)]
public class SimpleDependencyAttribute : Attribute
{
    public Type Implementor { get; }

    public SimpleDependencyAttribute(Type implementor)
    {
        Implementor = implementor;
    }
}
