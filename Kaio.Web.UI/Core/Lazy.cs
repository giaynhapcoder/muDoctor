using System;
using System.Collections.Generic;

namespace Kaio.Core
{
    public class Lazy
    {

        private readonly static Lazy<Dictionary<string, object>> _instants = new Lazy<Dictionary<string, object>>(() => new Dictionary<string, object>());
        private readonly static object _lock = new object();

        public static T Create<T>() where T : new()
        {
            lock (_lock)
            {
                var _key = typeof (T).FullName;
                object _pool;

                if (!_instants.Value.TryGetValue(_key, out _pool))
                {
                    _pool = new Lazy<T>(() => new T()).Value;
                    _instants.Value.Add(_key,_pool);
                }

                return (T) _pool;
            }
            
        }

       /* public static T Create<T>() where T : new()
        {
            lock (_lock)
            {
                var _key = typeof(T).FullName;
                T _pool;

                if (!CacheHelper.Get(_key, out _pool))
                {
                    _pool = new Lazy<T>(() => new T()).Value;
                   // _instants.Value.Add(_key, _pool);
                    CacheHelper.Add(_key, _pool,null, null);
                }

                return _pool;
            }

        }
*/
    }

    
}
