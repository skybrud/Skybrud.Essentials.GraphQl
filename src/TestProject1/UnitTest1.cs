using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.GraphQl;
using TestProject1.Models.Users;

namespace TestProject1 {
    
    [TestClass]
    public class UnitTest1 {

        [TestMethod]
        public void TestMethod1() {

            var query = new UserQuery()
                .SetParameter(x => x.Username, "abjerner")
                .AddField(x => x.Id)
                .AddField(x => x.Name);

            var builder = new QueryBuilder();

            string str1 = builder.Format(query);
            string str2 = builder.Format(query, Formatting.None);

            const string expected1 = "query {\r\n  user(username: \"abjerner\") {\r\n    id\r\n    name\r\n  }\r\n}";
            const string expected2 = "query{user(username:\"abjerner\"){id name}}";

            Assert.AreEqual(expected1, str1, "#1");
            Assert.AreEqual(expected2, str2, "#2");

        }

        [TestMethod]
        public void TestMethod2() {

            var friends = new UserFriendsConnection()
                .SetParameter(x => x.First, 10)
                .AddField(x => x.Id)
                .AddField(x => x.Name);

            var query = new UserQuery()
                .SetParameter(x => x.Username, "abjerner")
                .AddField(x => x.Id)
                .AddField(x => x.Name)
                .AddField(friends);

            var builder = new QueryBuilder();

            string str1 = builder.Format(query);
            string str2 = builder.Format(query, Formatting.None);

            const string expected1 = "query {\r\n  user(username: \"abjerner\") {\r\n    id\r\n    name\r\n    friends(first: 10) {\r\n      id\r\n      name\r\n    }\r\n  }\r\n}";
            const string expected2 = "query{user(username:\"abjerner\"){id name friends(first:10){id name}}}";

            Assert.AreEqual(expected1, str1, "#1");
            Assert.AreEqual(expected2, str2, "#2");

        }

    }

}