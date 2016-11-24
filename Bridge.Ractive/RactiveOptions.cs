using System;

namespace Bridge.Ractive
{
    [ObjectLiteral]
    public class RactiveOptions
    {
        [Name("el")] 
        public string Element { get; set; }
        public Union<string, ParsedTemplate> Template { get; set; }
        public dynamic Data { get; set; }
        public bool Magic { get; set; }
        /// <summary>
        /// Defaults to true. Whether or not two-way data binding is enabled 
        /// </summary>
        public bool Twoway { get; set; }
        /// <summary>
        /// Defaults to false. If two-way data binding is enabled, whether to only update data based on text inputs on change and blur events, rather than any event (such as key events) that may result in new data.
        /// </summary>
        public bool Lazy { get; set; }

        /// <summary>
        /// Defaults to false. This option is typically only relevant as an extension option for Components. Controls whether the component will look outside itself for data and registry items.
        /// </summary>
        public bool Isolated { get; set; }
        /// <summary>
        /// each time the instance is destroyed (after unrender, if the teardown is responsible for triggering the unrender)
        /// </summary>
        [Name("ontearname")]
        public Action OnTeardown { get; set; }
        /// <summary>
        /// When the instance is ready to be rendered
        /// </summary>
        public Action Init { get; set; }

        public bool Append { get; set; }

        public object Components { get; set; }

        public object Partials { get; set; }
    }
}