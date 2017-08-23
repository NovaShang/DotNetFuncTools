using System;
using System.Reflection;
using System.Threading;

namespace DotNetFuncTools
{
    /// <summary>
    /// Static class for extend method of Actions and Functions
    /// </summary>
    public static partial class FuncUtils
    {
        /// <summary>
        /// Creates a throttled function that only invokes func at most once per every specify timespan.
        /// </summary>
        /// <param name="funcInfo">The function to translate, can be a lambda expression</param>
        /// <param name="span">the minimum interval between calling target function</param>
        /// <returns>throttled version of give function</returns>
        public static Action<object[]> Throttle(MethodInfo funcInfo, object target, TimeSpan span)
        {
            var last = DateTime.MinValue;
            Timer timer = null;
            return (args) =>
            {
                if (DateTime.Now - last > span)
                {
                    funcInfo.Invoke(target, args);
                    last = DateTime.Now;
                }
                else
                {
                    if (timer == null)
                    {
                        timer = new Timer((statues) =>
                        {
                            timer.Dispose();
                            timer = null;
                            funcInfo.Invoke(target, args);
                            last = DateTime.Now;
                        }, null, last + span - DateTime.Now, TimeSpan.FromMilliseconds(-1));
                    }
                }
            };
        }


        /// <summary>
        /// Creates a throttled function that only invokes func at most once per every specify timespan.
        /// </summary>
        /// <param name="func">The function to translate, can be a lambda expression</param>
        /// <param name="span">the minimum interval between calling target function</param>
        /// <returns>throttled version of give function</returns>
        public static Action Throttle(this Action func, TimeSpan span)
        {
            var translatedFunc = Throttle(func.GetMethodInfo(),func.Target, span);
            return () =>
            {
                translatedFunc(new object[] { });
            };
        }


        /// <summary>
        /// Creates a throttled function that only invokes func at most once per every specify timespan.
        /// </summary>
        /// <param name="func">The function to translate, can be a lambda expression</param>
        /// <param name="span">the minimum interval between calling target function</param>
        /// <returns>throttled version of give function</returns>
        public static Action<T> Throttle<T>(this Action<T> func, TimeSpan span)
        {
            var translatedFunc = Throttle(func.GetMethodInfo(),func.Target, span);
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
        public static Action<T1, T2> Throttle<T1, T2>(this Action<T1, T2> func, TimeSpan span)
        {
            var translatedFunc = Throttle(func.GetMethodInfo(),func.Target, span);
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
        public static Action<T1, T2, T3> Throttle<T1, T2, T3>(this Action<T1, T2, T3> func, TimeSpan span)
        {
            var translatedFunc = Throttle(func.GetMethodInfo(),func.Target, span);
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
        public static Action<T1, T2, T3, T4> Throttle<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> func, TimeSpan span)
        {
            var translatedFunc = Throttle(func.GetMethodInfo(),func.Target, span);
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
        public static Action<T1, T2, T3, T4, T5> Throttle<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> func, TimeSpan span)
        {
            var translatedFunc = Throttle(func.GetMethodInfo(),func.Target, span);
            return (args1, args2, args3, args4, args5) =>
            {
                translatedFunc(new object[] { args1, args2, args3, args4, args5 });
            };
        }

    }
}
