using System;

namespace Bridge.Ractive.Example
{
    [ObjectLiteral]
    public class EventHandlers
    {
        public Action<int> ToggleTodo;
        public Action<int> DeleteTodo;
        public Action ShowAll;
        public Action ShowComplete;
        public Action ShowIncomplete;
        public Action AddTodo;
    }
}