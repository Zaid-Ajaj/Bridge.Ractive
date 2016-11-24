using System;

namespace Bridge.Ractive
{
    public partial class Ractive
    {
        [External]
        public class Promise
        {
            [Template("new Ractive.Promise({0})")]
            public Promise(Action<Action<object>, Action<object>> contruct)
            {

            }

            public extern Promise Then(Action onSuccess, Action onError);

            public extern Promise Then(Action onSuccess);

            public extern Promise Then<T>(Action<T> onSuccess);

            public extern Promise Then<T>(Action<T> onSuccess, Action onError);

        }
    }
}