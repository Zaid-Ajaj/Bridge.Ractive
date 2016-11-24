using Bridge.Html5;

namespace Bridge.Ractive
{
    [ObjectLiteral]
    public class ClickEventArgs
    {
        public string Name { get; set; }
        public HTMLElement Node { get; set; }
        public MouseEvent<HTMLElement> Original { get; set; }
    }
}