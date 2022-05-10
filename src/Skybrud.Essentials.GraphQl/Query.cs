using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Essentials.GraphQl {
    
    /// <summary>
    /// Class representing a query (or query based field).
    /// </summary>
    public class Query : IQueryFields {

        #region Properties

        /// <summary>
        /// Gets or sets the name of the query.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a dictionary with the parameters of the query.
        /// </summary>
        public Dictionary<string, object> Parameters { get; set; } = new();

        /// <summary>
        /// Gets or sets the fields of the query.
        /// </summary>
        public List<IField> Fields { get; } = new();

        IReadOnlyList<IField> IQuery.Fields => Fields;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new query.
        /// </summary>
        public Query() { }

        /// <summary>
        /// Initializes a new query with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name"></param>
        public Query(string name) {
            Name = name;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Set the value of the of the parameter with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        protected void SetParameter(string name, object value) {
            if (value == null) {
                Parameters.Remove(name);
            } else {
                Parameters[name] = value;
            }
        }

        /// <summary>
        /// Gets the value of the parameter with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <returns>An instance of <see cref="object"/> if successful; otherwise, <c>null</c>.</returns>
        protected object GetParameter(string name) {
            return Parameters.TryGetValue(name, out object value) ? value : null;
        }

        /// <summary>
        /// Gets the value of the parameter with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <returns>An instance of <see cref="object"/> if successful; otherwise, <c>default</c>.</returns>
        protected TValue GetParameter<TValue>(string name) {
            return Parameters.TryGetValue(name, out object value) ? (TValue) value : default;
        }

        /// <summary>
        /// Returns a list of parameters of the query.
        /// </summary>
        /// <returns>An instance of <see cref="IReadOnlyList{IParameter}"/>.</returns>
        public IReadOnlyList<IParameter> GetParameters() {
            return Parameters.Select(x => Parameter.Create(x.Key, x.Value)).ToList();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new query of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the query.</typeparam>
        /// <returns>An instance of <see cref="Query{T}"/>.</returns>
        public static Query<T> Create<T>() {
            return new();
        }

        /// <summary>
        /// Returns a new query of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the query.</typeparam>
        /// <param name="name">The name of the query.</param>
        /// <returns>An instance of <see cref="Query{T}"/>.</returns>
        public static Query<T> Create<T>(string name) {
            return new(name);
        }

        #endregion

    }

}