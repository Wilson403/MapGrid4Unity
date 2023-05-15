using System;

namespace MapGrid4Unity
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