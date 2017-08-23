using System;
using System.Reflection;
using System.Threading;

namespace DotNetFuncTools
{
    public static partial class FuncUtils
    {

        /// <summary>
        /// Creates a debounced function that delays invoking func until after wait specify time span have elapsed since the last time the debounced function was invoked
        /// </summary>
        /// <param name="funcInfo"></param>
        /// <param name="span"></param>
        /// <returns></returns>
        public static Action<object[]> Debounce(this MethodInfo funcInfo, object target, TimeSpan span)
        {
            var last = DateTime.MinValue;
            Timer timer = null;

            return (args) =>
            {
                if (timer != null)
                {
                    timer.Dispose();
                    timer = null;
                }
                timer = new Timer((status) =>
                {
                    funcInfo.Invoke(target, args);
                }, null, span, TimeSpan.FromMilliseconds(-1));
            };
        }

        public static Action Debounce(this Action func, TimeSpan span)
        {
            var translatedFunc = Debounce(func.GetMethodInfo(), func.Target, span);
            return () =>
            {
                translatedFunc(new object[] { });
            };
        }

        public static Action<T> Debounce<T>(this Action<T> func, TimeSpan span)
        {
            var translatedFunc = Debounce(func.GetMethodInfo(), func.Target, span);
            return (args1) =>
            {
                translatedFunc(new object[] { args1 });
            };
        }

        /// <summary>
        /// Creates a throttled function that only invokes func at most once per every specify timespan.
        /// </summary>
        /// <param name="func">The function to translate, can be a lambda expression</param>
        /// <param name="span">the minimum interval between calling target function</param>
        /// <returns>throttled version of give function</returns>
        public static Action<T1, T2> Debounce<T1, T2>(this Action<T1, T2> func, TimeSpan span)
        {
            var translatedFunc = Debounce(func.GetMethodInfo(), func.Target, span);
            return (args1, args2) =>
            {
                translatedFunc(new object[] { args1, args2 });
            };
        }

        /// <summary>
        /// Creates a throttled function that only invokes func at most once per every specify timespan.
        /// </summary>
        /// <param name="func">The function to translate, can be a lambda expression</param>
        /// <param name="span">the minimum interval between calling target function</param>
        /// <returns>throttled version of give function</returns>
        public static Action<T1, T2, T3> Debounce<T1, T2, T3>(this Action<T1, T2, T3> func, TimeSpan span)
        {
            var translatedFunc = Debounce(func.GetMethodInfo(), func.Target, span);
            return (args1, args2, args3) =>
            {
                translatedFunc(new object[] { args1, args2, args3 });
            };
        }




        /// <summary>
        /// Creates a throttled function that only invokes func at most once per every specify timespan.
        /// </summary>
        /// <param name="func">The function to translate, can be a lambda expression</param>
        /// <param name="span">the minimum interval between calling target function</param>
        /// <returns>throttled version of give function</returns>
        public static Action<T1, T2, T3, T4> Debounce<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> func, TimeSpan span)
        {
            var translatedFunc = Debounce(func.GetMethodInfo(), func.Target, span);
            return (args1, args2, args3, args4) =>
            {
                translatedFunc(new object[] { args1, args2, args3, args4 });
            };
        }

        /// <summary>
        /// Creates a throttled function that only invokes func at most once per every specify timespan.
        /// </summary>
        /// <param name="func">The function to translate, can be a lambda expression</param>
        /// <param name="span">the minimum interval between calling target function</param>
        /// <returns>throttled version of give function</returns>
        public static Action<T1, T2, T3, T4, T5> Debounce<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> func, TimeSpan span)
        {
            var translatedFunc = Debounce(func.GetMethodInfo(), func.Target, span);
            return (args1, args2, args3, args4, args5) =>
            {
                translatedFunc(new object[] { args1, args2, args3, args4, args5 });
            };
        }
    }
}
