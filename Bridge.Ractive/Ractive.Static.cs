namespace Bridge.Ractive
{
    public partial class Ractive
    {
        [Template("Ractive.escapeKey({0})")]
        public extern static string EscapeKey(string keyInput);

        /// <summary>
        /// Splits the given keypath into an array of unescaped keys e.g. Ractive.SplitKeypath( "foo.bar\.baz" ) => [ "foo", "bar.baz" ].
        /// </summary>
        /// <param name="keypath">The keypath to split into keys.</param>
        /// <returns>an array of unescaped keys</returns>
        [Template("Ractive.splitKeypath({0})")]
        public extern static string[] SplitKeypath(string keypath);

        /// <summary>
        /// Before templates can be used, they must be parsed. Parsing involves reading in a template string and converting it to a tree-like data structure, much like a browser's parser would. Ordinarily, parsing happens automatically. However you can use Ractive.parse() as a standalone function if, for example, you want to parse templates as part of your build process (it works in Node.js). See also Using Ractive with RequireJS.
        /// </summary>
        /// <param name="template">the template to be parsed</param>
        /// <returns></returns>
        public extern static ParsedTemplate Parse(string template);

        /// <summary>
        /// Before templates can be used, they must be parsed. Parsing involves reading in a template string and converting it to a tree-like data structure, much like a browser's parser would. Ordinarily, parsing happens automatically. However you can use Ractive.parse() as a standalone function if, for example, you want to parse templates as part of your build process (it works in Node.js). See also Using Ractive with RequireJS.
        /// </summary>
        /// <param name="template">the template to be parsed</param>
        /// <param name="options">more parsing options</param>
        /// <returns></returns>
        public extern static ParsedTemplate Parse(string template, ParseOptions options);

        [Template("Ractive.components[{0}] = {1}")]
        public static extern void AddGlobalComponent(string name, RactiveComponent component);

        [Template("Ractive.partials[{0}] = {1}")]
        public static extern void AddGlobalParial(string name, Union<string, ParsedTemplate> template);


        public static extern RactiveComponent Extend(RactiveOptions options);

        public static extern RactiveComponent Extend(object options);
    }
}