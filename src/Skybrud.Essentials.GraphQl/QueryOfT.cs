using System.Linq;

namespace Skybrud.Essentials.GraphQl {

    public class Query<T> : Query, IQueryFields<T> {

        #region Member methods

        public Query() { }

        public Query(string name) : base(name) {
            Name = name;
        }

        public Query(string name, IQueryFields<T> query) : base(name) {
            Name = name;
            Fields.AddRange(query.Fields);
            Parameters = query.GetParameters().ToDictionary(x => x.Name, x => x.Value);
        }

        #endregion

    }

}