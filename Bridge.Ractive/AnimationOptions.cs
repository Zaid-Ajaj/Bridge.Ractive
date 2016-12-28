using System;

namespace Bridge.Ractive
{
    [ObjectLiteral]
    [External]
    public class AnimationOptions
    {
        /// <summary>
        /// Defaults to 400. How many milliseconds the animation should run for
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Defaults to 'Linear'. The name of an easing function on Ractive.easing, or the easing function itself
        /// </summary>
        public Union<Easing, Func<double, double>> Easing { get; set; }

        /// <summary>
        /// A function to be called on each step of the animation. Receives t and value as arguments, where t is the animation progress (between 0 and 1, as determined by the easing function) and value is the intermediate value at t
        /// </summary>
        public Action<double, double> Step { get; set; }

        /// <summary>
        /// A function to be called when the animation completes, with the same argument signature as step (i.e. t is 1, and value is the destination value)
        /// </summary>
        public Action<double, double> Complete { get; set; }
    }

    [Enum(Emit.StringName)]
    [External]
    public enum Easing
    {
        Linear, 
        EaseIn, 
        EaseOut,
        EaseInOut
    }
}