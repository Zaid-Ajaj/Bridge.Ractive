namespace Bridge.Ractive
{
    [ObjectLiteral]
    public class ObserveOptions
    {
        /// <summary>
        /// Defaults to true. Whether or not to initialise the observer, i.e. call the function with the current value of keypath as the first argument and undefined as the second
        /// </summary>
        public bool Init { get; set; }

        /// <summary>
        /// Defaults to false, in which case observers will fire before any DOM changes take place. If true, the observer will fire once the DOM has been updated.
        /// </summary>
        public bool Defer { get; set; }

        /// <summary>
        /// Defaults to ractive. The context the observer is called in (i.e. the value of this)
        /// </summary>
        public Ractive Context { get; set; }

    }
}