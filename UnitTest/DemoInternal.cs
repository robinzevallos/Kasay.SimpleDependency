namespace UnitTest
{
    using System;

    [SimpleDependency(typeof(IDemoInternal))]
    public class DemoInternal : IDemoInternal
    {
        public String Name { get; set; } = "DemoInternal";
    }

    public interface IDemoInternal
    {
        String Name { get; set; }
    }
}
