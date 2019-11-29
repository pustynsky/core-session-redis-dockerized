using System;

namespace netcore_session_redis.Models
{
    [Serializable]
    public class PocoModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
