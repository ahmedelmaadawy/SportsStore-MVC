using System.Text.Json;

namespace SportsStore_MVC.Infrastructure
{
    /// <summary>
    /// These Methods seralize objects into JSON Format to make it ease to store and retrieve cart objects
    /// </summary>
    public static class SessionExtentions
    {
        public static void SetJson(this ISession session,string key,object value)
        {
            session.SetString(key,JsonSerializer.Serialize(value));
        }
        public static T? GetJson<T>(this ISession session, string key) { 
            var sessionData =session.GetString(key);
            return sessionData == null ?
                default(T) :JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
