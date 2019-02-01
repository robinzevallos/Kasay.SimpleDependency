namespace AssemblyToProcess
{
    using System;

    public class DemoExternal : IDemoExternal
    {
        public String Name { get; set; } = "DemoExternal";
    }

    public interface IDemoExternal
    {
        String Name { get; set; }
    }
}
