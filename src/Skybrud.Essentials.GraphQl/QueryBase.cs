using System.Collections.Generic;
using System.Reflection;
using Skybrud.Essentials.Reflection.Extensions;
using Skybrud.Essentials.Strings.Extensions;

namespace Skybrud.Essentials.GraphQl {


    /// <summary>
    /// Abstract class representing query.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class QueryBase<T> : IQueryFields<T> {

        #region Properties

        /// <summary>
        /// Gets the name of the query
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets a collection of the fields that should be returned for the query.
        /// </summary>
        public List<IField> Fields { get; } = new();

        IReadOnlyList<IField> IQuery.Fields => Fields;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new query based on the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the query.</param>
        protected QueryBase(string name) {
            Name = name;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a list of parameters for the query.
        /// </summary>
        /// <returns>An instance of <see cref="IReadOnlyList{IParameter}"/>.</returns>
        public virtual IReadOnlyList<IParameter> GetParameters() {
            
            List<IParameter> temp = new();

            foreach (PropertyInfo property in GetType().GetProperties()) {
                if (!property.HasCustomAttribute(out ParameterAttribute attribute) || !attribute.Name.HasValue()) continue;
                object value = property.GetValue(this);
                if (value != null) {
                    temp.Add(new Parameter(attribute.Name, value));
                }
            }
            
            return temp;

        }

        #endregion

    }

}