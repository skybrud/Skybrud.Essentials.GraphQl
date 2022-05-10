using System;
using System.Linq.Expressions;

namespace Skybrud.Essentials.GraphQl {

    /// <summary>
    /// Static class with extension methods for <see cref="Query{TValue}"/>.
    /// </summary>
    public static class QueryExtensions {
        
        /// <summary>
        /// Sets the parameter with the specified <paramref name="name"/> to <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="TQuery">The type of the query.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>The query.</returns>
        public static TQuery SetParameter<TQuery>(this TQuery query, string name, object value) where TQuery : Query {
            if (query == null) return null;
            query.Parameters[name] = value;
            return query;
        }

        public static TQuery SetParameter<TQuery, TProperty>(this TQuery query, Expression<Func<TQuery, TProperty>> selector, object value) where TQuery : Query {

            if (query == null) return default;

            string name = ReflectionUtils.GetPropertyAlias(selector);

            query.Parameters[name] = value;

            return query;

        }

        /// <summary>
        /// Appends a new field with the specified <paramref name="name"/>.
        /// </summary>
        /// <typeparam name="TQuery">The type of the query.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="name">The name of the field.</param>
        /// <returns>The query.</returns>
        public static TQuery AddField<TQuery, TValue>(this TQuery query, string name) where TQuery : Query<TValue> {
            query?.Fields?.Add(new Field(name));
            return query;
        }

        public static Query<TValue> AddField<TValue>(this Query<TValue> query, IField field) {
            query?.Fields?.Add(field);
            return query;
        }

        /// <summary>
        /// Appends a new field based on the result of the specified <paramref name="selector"/>.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="selector">The property selector.</param>
        /// <returns>The query.</returns>
        public static Query<TValue> AddField<TValue, TProperty>(this Query<TValue> query, Expression<Func<TValue, TProperty>> selector) {

            if (query == null) return default;

            string name = ReflectionUtils.GetPropertyAlias(selector);

            query.Fields.Add(new Field(name));

            return query;

        }

        //public static TQuery AddField2<TQuery, TValue, TProperty>(this TQuery query, Expression<Func<TValue, TProperty>> selector) where TQuery : Query {

        //    if (query == null) return default;

        //    string name = ReflectionUtils.GetPropertyAlias(selector);

        //    query.Fields.Add(new Field(name));

        //    return query;

        //}

    }

}