using System;
using Skybrud.Essentials.GraphQl;

namespace TestProject1.Models.Users {
    
    public class User {

        [Field("id")]
        public int Id { get; set; }

        [Field("key")]
        public Guid Key { get; set; }

        [Field("name")]
        public string Name { get; set; }

        [Field("friends")]
        public UserFriendsConnection Friends { get; set; }

    }

}