using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace netcore_session_redis.SessionHelpers
{
    public static class RedisSession
    {
        public static async Task<T> GetSessionValue<T>(this Controller controller, string key)
        {
            await controller.HttpContext.Session.LoadAsync();

            var data = controller.HttpContext.Session.Get(key);
            if (data == null)
            {
                return default(T);
            }

            return await data.Deserialize<T>();
        }

        public static async Task SetSessionValue<T>(this Controller controller, string key, T value) 
        {
            if(value == null)
                return;

            var serialized = await value.Serialize();

            controller.HttpContext.Session.Set(key, serialized);
            await controller.HttpContext.Session.CommitAsync();
        }
    }
}
