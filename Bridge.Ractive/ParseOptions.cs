namespace Bridge.Ractive
{
    [ObjectLiteral]
    public class ParseOptions
    {
        public bool PreserveWhitespace { get; set; } = false;
        public Union<bool, SanitizeOptions> Sanitize { get; set; } = true;
    }
}