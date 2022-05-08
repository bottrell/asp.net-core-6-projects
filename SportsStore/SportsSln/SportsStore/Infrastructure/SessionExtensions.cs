using System.Text.Json;


//The session state feature in ASP.NET Core stores only int, string, and byte[] values
//Since we want to be able to persist a Cart object, I need to define extension methods to the ISession interface
//Which provides access to the session state data to serialize Cart objects into JSOn and convert them back
namespace SportsStore.Infrastructure {

    public static class SessionExtensions {

        public static void SetJson(this ISession session, string key, object value) {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? GetJson<T>(this ISession session, string key) {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }

    }

}