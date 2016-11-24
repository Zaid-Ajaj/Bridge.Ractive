using Bridge;
using System.Collections.Generic;

namespace Bridge.Ractive.Example
{
    [ObjectLiteral]
    public class TodoAppState
    {
        public Todo[] Todos { get; set; }
        public string DescriptionInput { get; set; }
        public TodoVisibility Visibility { get; set; }
    }
}