using Kasay.SimpleDependency;
using System;
using Xunit;

public class AssemblyFactory_Test
{
    [Theory]
    [InlineData("UnitTest")]
    [InlineData("AssemblyToProcess")]
    public void GetAssemblies_Test(String assemblyName)
    {
        var assemblyBuilder = new AssemblyFactory();
        var assemblies = assemblyBuilder.GetAssemblies();

        var assembly = AppDomain.CurrentDomain.Load(assemblyName);

        Assert.Contains(assembly, assemblies);
    }
}
