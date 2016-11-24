using Bridge.Html5;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bridge.Javascript
{
    [ObjectLiteral]
    public class KeyValue
    {
        public string Key;
        public dynamic Value;
    }

    public class Http
    {
        public static void Get(GetConfig config)
        {
            var http = new XMLHttpRequest();
            http.Open("GET", config.Url, true);
            http.SetRequestHeader("Content-Type", "application/json");
            http.OnReadyStateChange = () =>
            {
                if (http.ReadyState == AjaxReadyState.Done && http.Status == 200)
                {
                    config.Success(http.ResponseText);
                }

                if (http.Status == 500 || http.Status == 404)
                {
                    config.Error();
                }
            };

            http.Send();
        }

        public static async Task<string> GetAsync(string url)
        {
            var tcs = new TaskCompletionSource<string>();
            var xmlHttp = new XMLHttpRequest();
            xmlHttp.Open("GET", url, true);
            xmlHttp.OnReadyStateChange = () =>
            {
                if (xmlHttp.ReadyState == AjaxReadyState.Done)
                {
                    if (xmlHttp.Status == 200 || xmlHttp.Status == 304)
                    {
                        tcs.SetResult(xmlHttp.ResponseText);
                    }
                    else
                    {
                        tcs.SetException(new Exception(xmlHttp.StatusText));
                    }
                }

            };

            xmlHttp.Send();
            return await tcs.Task;
        }

        /// <summary>
        /// Post's data to server
        /// </summary>
        /// <typeparam name="TData">The type of the data to send</typeparam>
        /// <typeparam name="TResult">The type of JSON.parse(http.ResponseText)</typeparam>
        /// <param name="config"></param>
        public static void PostJson<TData, TResult>(PostConfig<TData, TResult> config)
        {
            var http = new XMLHttpRequest();
            http.Open("POST", config.Url, true);
            http.SetRequestHeader("Content-Type", "application/json");
            http.OnReadyStateChange = () =>
            {
                if (http.ReadyState == AjaxReadyState.Done && http.Status == 200)
                {
                    var result = JSON.Parse(http.ResponseText);
                    config.Success(Script.Write<TResult>("result"));
                }

                if (http.Status == 500 || http.Status == 404)
                {
                    config.Error();
                }
            };

            var stringified = JSON.Stringify(config.Data);
            http.Send(stringified);
        }

        public static async Task<TResult> PostJsonAsync<TData, TResult>(PostAsyncConfig<TData> config)
        {
            var tcs = new TaskCompletionSource<TResult>();
            var xmlHttp = new XMLHttpRequest();
            xmlHttp.Open("POST", config.Url, true);
            xmlHttp.OnReadyStateChange = () =>
            {
                if (xmlHttp.ReadyState == AjaxReadyState.Done)
                {
                    if (xmlHttp.Status == 200 || xmlHttp.Status == 304)
                    {
                        var result = JSON.Parse(xmlHttp.ResponseText);
                        tcs.SetResult(Script.Write<TResult>("result"));
                    }
                    else
                    {
                        tcs.SetException(new Exception(xmlHttp.StatusText));
                    }
                }

            };

            var stringified = JSON.Stringify(config.Data);
            xmlHttp.Send(stringified);
            return await tcs.Task;
        }
    }

    [ObjectLiteral]
    public class PostConfig
    {
        public Action<string> Success { get; set; }
        public Action Error { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }
    }

    [ObjectLiteral]
    public class GetConfig
    {
        public Action<string> Success { get; set; }
        public Action Error { get; set; }
        public string Url { get; set; }
    }

    [ObjectLiteral]
    [IgnoreGeneric]
    public class PostConfig<TData, TResult>
    {
        public Action<TResult> Success { get; set; }
        public Action Error { get; set; }
        public string Url { get; set; }
        public TData Data { get; set; }
    }

    [ObjectLiteral]
    [IgnoreGeneric]
    public class PostAsyncConfig<TData>
    {
        public string Url { get; set; }
        public TData Data { get; set; }
    }

    public static class JS
    {
        public static KeyValue Prop(string key, object value) => new KeyValue { Key = key, Value = value };

        public static T[] Array<T>(params T[] items) => items;

        public static object Dict(params KeyValue[] keyValuePairs)
        {
            var result = Script.Write<object>("{ }");
            foreach (var pair in keyValuePairs)
            {
                result[pair.Key] = pair.Value;
            }
            return result;
        }

        public static object Dict(Dictionary<string, object> dict)
        {
            var result = Script.Write<object>("{ }");
            foreach (var pair in dict)
            {
                result[pair.Key] = dict[pair.Key];
            }
            return result;
        }

        [IgnoreGeneric]
        public static void Log<T>(T value) => Script.Write("console.log(value)");

        public static bool IsUndefined<T>(this T value)
        {
            return Script.Write<bool>("value === undefined");
        }

        [Template("{0}")]
        public extern static object Lambda<T>(Func<T> x);

        [Template("{0}")]
        public extern static object Lambda<T1, TResult>(Func<T1, TResult> x);

        [Template("{0}")]
        public extern static object Lambda<T1, T2, TResult>(Func<T1, T2, TResult> x);

        [Template("{0}")]
        public extern static object Lambda<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> x);

        [Template("{0}")]
        public extern static object Lambda<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> x);

        [Template("{0}")]
        public extern static object Func<T>(Func<T> x);

        [Template("{0}")]
        public extern static object Func<T1, TResult>(Func<T1, TResult> x);

        [Template("{0}")]
        public extern static object Func<T1, T2, TResult>(Func<T1, T2, TResult> x);

        [Template("{0}")]
        public extern static object Func<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> x);

        [Template("{0}")]
        public extern static object Func<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> x);

        [Template("{0}")]
        public extern static object Lambda(Action x);

        [Template("{0}")]
        public extern static object Lambda<T>(Action<T> x);

        [Template("{0}")]
        public extern static object Lambda<T1, T2>(Action<T1, T2> x);

        [Template("{0}")]
        public extern static object Lambda<T1, T2, T3>(Action<T1, T2, T3> x);

        [Template("{0}")]
        public extern static object Func(Action x);

        [Template("{0}")]
        public extern static object Func<T>(Action<T> x);

        [Template("{0}")]
        public extern static object Func<T1, T2>(Action<T1, T2> x);

        [Template("{0}")]
        public extern static object Func<T1, T2, T3>(Action<T1, T2, T3> x);

        public static void SetProperty<T>(this T obj, string propName, object value)
        {
            Script.Write("obj[propName] = value");
        }
        
        public static U GetProperty<T, U>(this T obj, string propName)
        {
            return Script.Write<U>("obj[propName]");
        }

        public static bool IsNull<T>(this T obj)
        {
            return Script.Write<bool>("obj === null");
        }


        public static bool IsNullOrUndefined<T>(this T obj) => obj.IsNull() || obj.IsUndefined();

        public static bool IsEmptyOrNullOrUndefined(this string input)
        {
            return input.IsNullOrUndefined() || input == "";
        }

        public static T Merge<T, U>(this T value, U otherValue)
        {
            var result = Script.Write<T>("{ }");
            /*@
            for (var key in value) { 
                if (typeof value[key] === 'function') {
                    //continue;
                }
                
                result[key] = value[key];
            
            }
           for (var key in otherValue) { 
                if (typeof otherValue[key] === 'function') {
                    //continue;
                }
                
                result[key] = otherValue[key];
            
            }
             */
            return result;
        }

        public static TResult MergeWith<T, U, TResult>(this T value, U otherValue)
        {
            var merged = value.Merge(otherValue);
            return Script.Write<TResult>("merged");
        }


        public static void OnTextChanged(this HTMLElement element, Action<string> handle)
        {
            element.AddEventListener("input", (Action)Lambda((Event<HTMLInputElement> e) => handle(e.CurrentTarget.Value)));
        }
    }
}