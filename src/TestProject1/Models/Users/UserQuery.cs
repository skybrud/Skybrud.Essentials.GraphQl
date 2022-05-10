using Skybrud.Essentials.GraphQl;

namespace TestProject1.Models.Users {
    
    public class UserQuery : Query<User> {

        [Parameter("username")]
        public string Username {
            get => Parameters.TryGetValue("username", out object value) ? value as string : null;
            set => Parameters["username"] = value;
        }

        public UserQuery() {
            Name = "user";
        }

    }

}