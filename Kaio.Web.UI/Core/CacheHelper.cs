using System;
using System.Runtime.Caching;
using System.Web;
using System.Web.Caching;

namespace Kaio.Core
{
    public static class  CacheHelper
    {

        private static readonly Object _locker = new object();


      
        public static void Add(String key, object value, TimeSpan? slidingExpiration, DateTime? absoluteExpiration)
        {
            if (String.IsNullOrWhiteSpace(key)) throw new ArgumentException("Invalid cache key");
            if (value == null) throw new ArgumentNullException("Value is not null");
            
            if (MemoryCache.Default[key] == null)
            {
                lock (_locker)
                {
                    if (MemoryCache.Default[key] == null)
                    {
                        CacheEntryChangeMonitor monitor = MemoryCache.Default.CreateCacheEntryChangeMonitor(new[] { key });
        

                         var _policy = new CacheItemPolicy
                        {
                            
                            AbsoluteExpiration =
                                absoluteExpiration.HasValue ? absoluteExpiration.Value : DateTime.MaxValue,
                            SlidingExpiration = slidingExpiration.HasValue ? slidingExpiration.Value : TimeSpan.FromSeconds(60),
                            Priority = System.Runtime.Caching.CacheItemPriority.Default
                        };
                        _policy.ChangeMonitors.Add(monitor);
                        
                        MemoryCache.Default.Add(key, value, _policy);
                        
                    }
                }
            }
            
        }


        public static void Add<T>(T o, string key, double cacheInSeconds) where T : class
        {
            // NOTE: Apply expiration parameters as you see fit.
            // In this example, I want an absolute
            // timeout so changes will always be reflected
            // at that time. Hence, the NoSlidingExpiration.
            HttpRuntime.Cache.Insert(
                key,
                o,
                null,
                DateTime.Now.AddSeconds(cacheInSeconds), Cache.NoSlidingExpiration);
        }


        public static bool Exists(string key)
        {
            return MemoryCache.Default[key] != null;
        }


        public static object Get(string _key)
        {
            return HttpRuntime.Cache.Get(_key);
        }


        public static bool Get<T>(string key, out T value)
        {
            try
            {
                value = (T)MemoryCache.Default[key];
            }
            catch
            {
                value = default(T);
                return false;
            }

            return true;
        }


        public static T Get<T>(string key) where T : class
        {
            try
            {
                return (T)MemoryCache.Default[key];
            }
            catch
            {
                return null;
            }
        }

        public static object Remove(string key)
        {

            return HttpRuntime.Cache.Remove(key);

        }

        public static void Add(string _key, object _value)
        {
            HttpRuntime.Cache.Insert(_key, _value, null, DateTime.MaxValue, TimeSpan.Zero);
        }

        public static void Add(string _key, object _value, double _seconds)
        {
            if (_seconds > 0)
                HttpRuntime.Cache.Insert(_key, _value, null, DateTime.Now.AddSeconds(_seconds), TimeSpan.Zero);
        }

        public static void Add(string _key, object _value, DateTime _end)
        {
            HttpRuntime.Cache.Insert(_key, _value, null, _end, TimeSpan.Zero);
        }

      /*  public static void Add(string _key, object _value, string _fileDependency, double minutes)
        {
            HttpRuntime.Cache.Insert(_key, _value, new CacheDependency(_fileDependency), Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(minutes));
        }*/

       /* public static void Add(string _key, object _value, string[] _fileDependencies, double _minutes)
        {
            HttpRuntime.Cache.Insert(_key, _value, new CacheDependency(_fileDependencies), Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(_minutes));
        }
*/
        public static void Add(string _key, object _value, CacheDependency _dep)
        {

            HttpRuntime.Cache.Insert(_key, _value, _dep, DateTime.MaxValue, TimeSpan.Zero);

        }

        public static void Clear(string search)
        {
            var _ie = HttpRuntime.Cache.GetEnumerator();
            while (_ie.MoveNext())
            {

                var _k = _ie.Key.ToString();
                if (!string.IsNullOrWhiteSpace(search) && _k.Contains(search))
                    HttpRuntime.Cache.Remove(_k);
                else
                {
                    HttpRuntime.Cache.Remove(_k);
                }
            }

        }

        public static void Clear()
        {
            Clear(null);
        }



       
    }
}
