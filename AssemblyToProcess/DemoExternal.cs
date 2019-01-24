namespace AssemblyToProcess
{
    using System;

    [SimpleDependency(typeof(IDemoExternal))]
    public class DemoExternal : IDemoExternal
    {
        public String Name { get; set; } = "DemoExternal";
    }

    public interface IDemoExternal
    {
        String Name { get; set; }
    }
}
