// This class will allow us to save our data in memory, as we don't have access
// to a database yet. It will also allow us to wipe the data as needed by restarting the app
namespace PartyInvites.Models {
    public static class Repository {
        private static List<GuestResponse> responses = new();

        // => is the Expression body definition operator
        // member => expression;
        // where expression is implicitely convertable to member
        public static IEnumerable<GuestResponse> Responses => responses;

        public static void AddResponse(GuestResponse response) {
            Console.WriteLine(response);
            responses.Add(response);
        }

    }
}