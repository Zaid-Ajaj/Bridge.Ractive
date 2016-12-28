using Bridge.Html5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Ractive
{
    using Node = Union<HTMLElement, string>;

    [External]
    public sealed class RactiveComponent : Ractive
    {

    }

    [External]
    public static class Exts
    {
        [Template("new {0}({1})")]
        public static extern RactiveComponent Initialize(this RactiveComponent component, RactiveOptions options);

        [Template("new {0}({1})")]
        public static extern RactiveComponent Initialize(this RactiveComponent component, object options);
    }


    [External]
    public partial class Ractive
    {
        [Template("new Ractive({0})")]
        public Ractive(RactiveOptions options) { }

        [Template("new Ractive({0})")]
        public Ractive(object options) { }

        [Template("new Ractive()")]
        public Ractive() { }

        /// <summary>
        /// Updates data and triggers a re-render of any mustaches that are affected (directly or indirectly) by the change. Any observers of affected keypaths will be notified.
        /// A change event will be fired with keypath and value as arguments (or map, if you set multiple options at once).
        /// </summary>
        /// <param name="map">A map of { keypath: value } pairs, as above</param>
        [IgnoreGeneric]
        public extern Promise Set<T>(T map);

        /// <summary>
        /// Updates data and triggers a re-render of any mustaches that are affected (directly or indirectly) by the change. Any observers of affected keypaths will be notified.
        /// A change event will be fired with keypath and value as arguments (or map, if you set multiple options at once).
        /// </summary>
        /// <param name="keypath">The keypath of the data we're changing, e.g. user or user.name or user.friends[1] or users.*.status</param>
        /// <param name="value">The value we're changing it to. Can be a primitive or an object (or array), in which case dependants of downstream keypaths will also be re-rendered (if they have changed)</param>
        [IgnoreGeneric]
        public extern Promise Set<T>(string keypath, T value);

        /// <summary>
        /// Subscribe to events.
        /// </summary>
        /// <param name="value">An object with keys named for each event to subscribe to. The value at each key is the handler function for that event.</param>
        /// <returns>ICancellable</returns>
        [IgnoreGeneric]
        public extern ICancellable On<T>(T value);

        /// <summary>
        /// Increments the selected keypath.
        /// </summary>
        /// <param name="keypath">The keypath of the number we're incrementing, e.g. count</param>
        /// <param name="number">Defaults to 1. The number to increment by</param>
        public extern void Add(string keypath, int number = 1);

        /// <summary>
        /// Detaches the instance from the DOM, returning a document fragment. You can reinsert it, possibly in a different place, with ractive.insert() (note that if you are reinserting it immediately you don't need to detach it first - it will happen automatically).
        /// </summary>
        public extern void Detach();

        /// <summary>
        /// Returns the first element inside a given Ractive instance matching a CSS selector. This is similar to doing this.el.querySelector(selector) (though it doesn't actually use querySelector()).
        /// </summary>
        /// <param name="selector">A CSS selector representing the element to find</param>
        /// <returns>HTMLElement</returns>
        public extern HTMLElement Find(string selector);

        /// <summary>
        /// This method is similar to ractive.find(), with two important differences. Firstly, it returns a list of elements matching the selector, rather than a single node. Secondly, it can return a live list, which will stay in sync with the DOM as it continues to update.
        /// </summary>
        /// <param name="selector">A CSS selector representing the elements we want to be in our collection</param>
        /// <param name="live">Defaults to false. Whether to return a live list or a static one.</param>
        /// <returns></returns>
        [Template("findAll({0}, { live: {1} })")]
        public extern HTMLElement[] FindAll(string selector, bool live = false);

        public extern void Render(Union<HTMLElement, string> target);

        /// <summary>
        /// Fires an event, which will be received by handlers that were bound using ractive.on. In practical terms, you would mostly likely use this with Ractive.extend(), to allow applications to hook into your subclass.
        /// </summary>
        /// <param name="eventName">The name of the event</param>
        /// <param name="args">The arguments that event handlers will be called with</param>
        public extern void Fire(string eventName, params object[] args);

        /// <summary>
        /// Inserts the instance to a different location. If the instance is currently in the DOM, it will be detached first. See 
        /// </summary>
        /// <param name="target">The new parent element</param>
        public extern void Insert(Node target);


        /// <summary>
        /// Inserts the instance to a different location. If the instance is currently in the DOM, it will be detached first.
        /// </summary>
        /// <param name="target">The new parent element</param>
        /// <param name="anchor">The sibling element to insert the instance before</param>
        public extern void Insert(Node target, Node anchor);

        /// <summary>
        /// Creates a link between two keypaths that keeps them in sync. Since Ractive can't always watch the contents of objects, copying an object to two different keypaths in your data usually leads to one or both of them getting out of sync. link creates a sort of symlink between the two paths so that Ractive knows they are actually the same object. This is particularly useful for master/detail scenarios where you have a complex list of data and you want to be able to select an item to edit in a detail form.
        /// </summary>
        /// <param name="source">The keypath of the source item.</param>
        /// <param name="destination">The keypath to use as the destination - or where you'd like the data 'copied'.</param>
        public extern void Link(string source, string destination);


        /// <summary>
        /// Removes a link set up by ractive.link().
        /// </summary>
        /// <param name="destination">The destination supplied to link.</param>
        public extern void Unlink(string destination);

        /// <summary>
        /// Returns the value at keypath.
        /// </summary>
        /// <param name="keypath"></param>
        public extern T Get<T>(string keypath);

        /// <summary>
        /// Returns a shallow copy of all data (the equivalent of ractive.get('')). This does not include Computed Properties, but it does include any mappings if ractive happens to be a component instance with mappings.
        /// </summary>
        public extern T Get<T>();

        /// <summary>
        /// The Ractive equivalent to Array.push that appends one or more elements to the array at the given keypath and triggers an update event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keypath">The keypath of the array to change, e.g. list or order.items.</param>
        /// <param name="value">The value to append to the end of the array. One or more values may be supplied.</param>
        /// <returns></returns>
        public extern Promise Push<T>(string keypath, T value);

        /// <summary>
        /// The Ractive equivalent to Array.push that appends one or more elements to the array at the given keypath and triggers an update event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keypath">The keypath of the array to change, e.g. list or order.items.</param>
        /// <param name="value">The value to append to the end of the array. One or more values may be supplied.</param>
        /// <returns></returns>
        public extern Promise Push<T>(string keypath, params T[] value);

        /// <summary>
        /// Returns a Promise that will resolve with the removed element after the update is complete.
        /// </summary>
        /// <param name="keypath">The keypath of the array to change, e.g. list or order.items.</param>
        /// <returns></returns>
        public extern Promise Pop(string keypath);

        /// <summary>
        /// Resets the entire ractive.data object and updates the DOM. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The data to reset with. Defaults to {}.</param>
        /// <returns>Promise</returns>
        public extern Promise Reset<T>(T value);

        /// <summary>
        /// Resets the entire ractive.data object to {} and updates the DOM. 
        /// </summary>
        public extern Promise Reset();

        /// <summary>
        /// The Ractive equivalent to Array.shift that removes an element from the beginning of the array at the given keypath and triggers an update event.Returns a Promise that will resolve with the removed element after the update is complete.
        /// </summary>
        /// <param name="keypath">The keypath of the array to change, e.g. list or order.items.</param>
        public extern Promise Shift(string keypath);

        /// <summary>
        /// The Ractive equivalent to Array.splice that can add new elements to the array while removing existing elements.Returns a Promise that will resolve with the removed elements after the update is complete.
        /// </summary>
        /// <param name="keypath">The keypath of the array to change, e.g. list or order.items.</param>
        /// <param name="index">The index at which to start the operation.</param>
        /// <param name="removeCount">The number of elements to remove starting with the element at index. This may be 0 if you don't want to remove any elements.</param>
        /// <param name="args">Any elements to insert into the array starting at index. There can be 0 or more elements passed to add to the array.</param>
        /// <returns>Promise</returns>
        public extern Promise Splice(string keypath, int index, int removeCount, params object[] args);

        /// <summary>
        /// Decrements the selected keypath.
        /// </summary>
        /// <param name="keypath">The keypath of the number we're decrementing, e.g. count</param>
        /// <param name="count">Defaults to 1. The number to decrement by</param>
        /// <returns></returns>
        public extern Promise Substract(string keypath, int count = 1);

        /// <summary>
        /// Unrenders this Ractive instance, removing any event handlers that were bound automatically by Ractive. Calling ractive.teardown() causes a teardown event to be fired - this is most useful with Ractive.extend() as it allows you to clean up anything else (event listeners and other bindings) that are part of the subclass.
        /// </summary>
        /// <returns>Promise</returns>
        public extern Promise Teardown();

        /// <summary>
        /// Toggles the selected keypath. In other words, if foo is truthy, then ractive.toggle('foo') will make it false, and vice-versa.
        /// </summary>
        /// <param name="keypath">The keypath to toggle the value of. If keypath is a pattern, then all matching keypaths will be toggled.</param>
        /// <returns></returns>
        public extern Promise Toggle(string keypath);

        /// <summary>
        /// The Ractive equivalent to Array.unshift that prepends one or more elements to the array at the given keypath and triggers an update event. Returns a Promise that will resolve after the update is complete.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keypath">The keypath of the array to change, e.g. list or order.items.</param>
        /// <param name="value">The value to prepend to the beginning of the array. One or more values may be supplied</param>
        /// <returns></returns>
        public extern Promise Unshift<T>(string keypath, params T[] value);

        /// <summary>
        /// Forces everything that depends on the specified keypaths (whether directly or indirectly) to be 'dirty checked'. This is useful if you manipulate data without using the built in setter methods (i.e. ractive.set(), ractive.animate(), or array modification):
        /// </summary>
        /// <param name="keypath">The keypath to treat as 'dirty'. Any mustaches or observers that depend (directly or indirectly) on this keypath will be checked to see if they need to update</param>
        /// <returns></returns>
        public extern Promise Update(string keypath);

        /// <summary>
        /// Forces everything that depends on the specified keypaths (whether directly or indirectly) to be 'dirty checked'. This is useful if you manipulate data without using the built in setter methods (i.e. ractive.set(), ractive.animate(), or array modification). all mustaches and observers will be checked
        /// </summary>
        /// <returns></returns>
        public extern Promise Update();

        /// <summary>
        /// Resets a partial and re-renders all of its use-sites, including in any components that have inherited it. If a component has a partial with a same name that is its own, that partial will not be affected.
        /// </summary>
        /// <param name="name">The partial to reset.</param>
        /// <param name="template">will be parsed as a template</param>
        /// <returns>Promise</returns>
        public extern Promise ResetParial(string name, string template);

        /// <summary>
        /// Returns a chunk of HTML representing the current state of the instance. This is most useful when you're using Ractive in node.js, as it allows you to serve fully-rendered pages (good for SEO and initial pageload performance) to the client.
        /// </summary>
        /// <returns>string</returns>
        [Template("toHTML()")]
        public extern string ToHTML();

        public extern Promise Animate(string keypath, Union<double, int> value);

        public extern Promise Animate(string keypath, object map);

        public extern Promise Animate(string keypath, Union<double, int> value, AnimationOptions options);

        public extern Promise Animate(object map, AnimationOptions options);

        [IgnoreGeneric]
        public extern ICancellable Observe<T>(string keypath, Func<T, T> observer);

        public extern ICancellable Observe(object map, ObserveOptions options);

    }
}
