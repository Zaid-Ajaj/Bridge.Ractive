using Bridge;

namespace Bridge.Ractive.Example
{
    [ObjectLiteral]
    public class Todo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}