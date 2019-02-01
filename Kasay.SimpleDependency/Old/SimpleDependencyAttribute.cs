using System;

[AttributeUsage(AttributeTargets.Class)]
internal class SimpleDependencyAttribute : Attribute
{
    public Type Implementor { get; }

    public SimpleDependencyAttribute(Type implementor)
    {
        Implementor = implementor;
    }
}
