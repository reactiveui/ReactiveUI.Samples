using Newtonsoft.Json;

namespace ReactiveAvalonia.RandomBuddyStalker {
    // User .json example: https://reqres.in/api/users/1
    // https://stackoverflow.com/questions/725348/plain-old-clr-object-vs-data-transfer-object
    public class UserDto {
        public class DataDto {
            [JsonProperty("id")]
            public int Id { get; set; }
            [JsonProperty("email")]
            public string Email { get; set; }
            [JsonProperty("first_name")]
            public string FirstName { get; set; }
            [JsonProperty("last_name")]
            public string LastName { get; set; }
            [JsonProperty("avatar")]
            public string AvatarUrl { get; set; }
        }

        [JsonProperty("data")]
        public UserDto.DataDto Data { get; set; }
    }
}
