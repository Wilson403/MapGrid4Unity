using System;

namespace WorldSpace2Grid
{
    [AttributeUsage (AttributeTargets.Method)]
    public class ConsoleCmd : Attribute
    {
        public string Desc { get; private set; }

        public ConsoleCmd (string desc = "")
        {
            Desc = desc;
        }
    }
}