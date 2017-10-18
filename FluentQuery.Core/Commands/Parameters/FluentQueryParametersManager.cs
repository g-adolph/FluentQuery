using System;
using System.Collections.Concurrent;
using System.Text;
using FluentQuery.Core.Dialects.Base;
using FluentQuery.Core.Intrastructure;

namespace FluentQuery.Core.Commands.Parameters
{
    public class FluentQueryParametersManager : IStatementManager
    {
        private ConcurrentDictionary<string, object> Parameters { get; } = new ConcurrentDictionary<string, object>();

        public StringBuilder Build(IFluentQueryDialectCommand commandsCreator)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(object key)
        {
            if (key == null) return null;
            return Parameters.TryGetValue(key.ToString(), out var value) ? value : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Tuple<string, object> Add(object value)
        {
            return Tuple.Create((Parameters.Count + 1).ToString(), Parameters.TryAdd((Parameters.Count + 1).ToString(), value) ? value : null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public object Add(string key, object value) => Parameters.TryAdd(key, value) ? value : null;
    }
}