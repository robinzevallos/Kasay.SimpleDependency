using AssemblyToProcess;
using UnitTest;
using Xunit;

public class SimpleDependency_Test
{
    [Fact]
    public void ExternalAssembly_Test()
    {
        var instanceExpected = Instance<IDemoExternal>.Get();
        var instanceActual = Instance<IDemoExternal>.Get();

        Assert.Same(instanceExpected, instanceActual);

        Instance<IDemoExternal>.Get().Name = "OtherName";
        var name = Instance<IDemoExternal>.Get().Name;

        Assert.Equal("OtherName", name);
    }

    [Fact]
    public void InternalAssembly_Test()
    {
        var instanceExpected = Instance<IDemoInternal>.Get();
        var instanceActual = Instance<IDemoInternal>.Get();

        Assert.Same(instanceExpected, instanceActual);

        Instance<IDemoInternal>.Get().Name = "OtherName";
        var name = Instance<IDemoInternal>.Get().Name;

        Assert.Equal("OtherName", name);
    }
}
