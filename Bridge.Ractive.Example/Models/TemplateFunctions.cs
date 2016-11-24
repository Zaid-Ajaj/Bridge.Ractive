using System;

namespace Bridge.Ractive.Example
{
    [ObjectLiteral]
    public class TemplateFunctions
    {
        public Func<TodoVisibility, Todo[], Todo[]> Filter;
    }
}