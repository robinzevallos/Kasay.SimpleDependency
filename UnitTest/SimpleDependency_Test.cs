using AssemblyToProcess;
using UnitTest;
using Xunit;

public class SimpleDependency_Test
{
    [Fact]
    public void ExternalAssembly_Test()
    {
        var instanceExpected = SimpleDependency.GetInstance<IDemoExternal>();
        var instanceActual = SimpleDependency.GetInstance<IDemoExternal>();

        Assert.Same(instanceExpected, instanceActual);

        SimpleDependency.GetInstance<IDemoExternal>().Name = "OtherName";
        var name = SimpleDependency.GetInstance<IDemoExternal>().Name;

        Assert.Equal("OtherName", name);
    }

    [Fact]
    public void InternalAssembly_Test()
    {
        var instanceExpected = SimpleDependency.GetInstance<IDemoInternal>();
        var instanceActual = SimpleDependency.GetInstance<IDemoInternal>();

        Assert.Same(instanceExpected, instanceActual);

        SimpleDependency.GetInstance<IDemoInternal>().Name = "OtherName";
        var name = SimpleDependency.GetInstance<IDemoInternal>().Name;

        Assert.Equal("OtherName", name);
    }
}
