using Skybrud.Essentials.GraphQl;

namespace TestProject1.Models.Users {
    
    public class UserFriendsConnection : Query<User> {

        #region Properties

        [Parameter("first")]
        public int First {
            get => Parameters.TryGetValue("first", out object value) && value is int numeric ? numeric : 0;
            set => Parameters["first"] = value;
        }

        #endregion

        #region Constructors

        public UserFriendsConnection() {
            Name = "friends";
        }

        #endregion

    }

}