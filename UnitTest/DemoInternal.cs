namespace UnitTest
{
    using System;

    public class DemoInternal : IDemoInternal
    {
        public String Name { get; set; } = "DemoInternal";
    }

    public interface IDemoInternal
    {
        String Name { get; set; }
    }
}
