//using System;
//using System.Collections.Generic;
//using System.Linq.Expressions;
//using System.Runtime.CompilerServices;

//namespace Skybrud.Essentials.GraphQl {

//    /// <summary>
//    /// Static class with extension methods for <see cref="Query{TValue}"/>.
//    /// </summary>
//    public static class QueryExtensions {

//        /// <summary>
//        /// Adds a new parameter with the specified <paramref name="name"/> and <paramref name="value"/>.
//        /// </summary>
//        /// <typeparam name="TValue">The type of the value.</typeparam>
//        /// <param name="list">The list of parameters.</param>
//        /// <param name="name">The name of the parameter.</param>
//        /// <param name="value">The value of the parameter.</param>
//        public static void Add<TValue>(this List<IParameter> list, string name, TValue value) {
//            list.Add(Parameter.Create(name, value));
//        }

//        /// <summary>
//        /// Adds a new parameter with the specified <paramref name="name"/> and <paramref name="value"/>.
//        /// </summary>
//        /// <typeparam name="TQuery">The type of the query.</typeparam>
//        /// <param name="query">The query.</param>
//        /// <param name="name">The name of the parameter.</param>
//        /// <param name="value">The value of the parameter.</param>
//        /// <returns>The query.</returns>
//        public static Query<TQuery> AddParameter<TQuery>(this Query<TQuery> query, string name, object value) {
//            if (query != null) query.Parameters[name] = value;
//            return query;
//        }

//        /// <summary>
//        /// Appends a new field with the specified <paramref name="name"/>.
//        /// </summary>
//        /// <typeparam name="TValue">The type of the value.</typeparam>
//        /// <param name="query">The query.</param>
//        /// <param name="name">The name of the field.</param>
//        /// <returns>The query.</returns>
//        public static Query<TValue> AddField<TValue>(this Query<TValue> query, string name) {
//            query?.Fields?.Add(new Field(name));
//            return query;
//        }

//        /// <summary>
//        /// Appends a new field based on the result of the specified <paramref name="selector"/>.
//        /// </summary>
//        /// <typeparam name="TValue">The type of the value.</typeparam>
//        /// <typeparam name="TProperty">The type of the property.</typeparam>
//        /// <param name="query">The query.</param>
//        /// <param name="selector">The property selector.</param>
//        /// <returns>The query.</returns>
//        public static Query<TValue> AddField<TValue, TProperty>(this Query<TValue> query, Expression<Func<TValue, TProperty>> selector) {

//            if (query == null) return default;

//            string name = ReflectionUtils.GetPropertyName(selector);

//            query.Fields.Add(new Field(name));

//            return query;

//        }

//        /// <summary>
//        /// Appends a new field based on the result of the specified <paramref name="selector"/>.
//        /// </summary>
//        /// <typeparam name="TValue">The type of the value.</typeparam>
//        /// <typeparam name="TProperty">The type of the property.</typeparam>
//        /// <param name="query">The query.</param>
//        /// <param name="selector">The property selector.</param>
//        /// <param name="subQuery">The sub query to be added.</param>
//        /// <returns>The query.</returns>
//        public static Query<TValue> AddField<TValue, TProperty>(this Query<TValue> query, Expression<Func<TValue, TProperty>> selector, Query<TProperty> subQuery) {

//            if (query == null) return null;

//            string name = ReflectionUtils.GetPropertyName(selector);

//            if (string.IsNullOrWhiteSpace(subQuery.Name)) subQuery.Name = name;

//            query.Fields.Add(subQuery);

//            return query;

//        }

//        /// <summary>
//        /// Appends a new field based on the result of the specified <paramref name="selector"/>.
//        /// </summary>
//        /// <typeparam name="TValue">The type of the value.</typeparam>
//        /// <typeparam name="TProperty">The type of the property.</typeparam>
//        /// <param name="query">The query.</param>
//        /// <param name="selector">The property selector.</param>
//        /// <param name="subQuery">The sub query to be added.</param>
//        /// <returns>The query.</returns>
//        public static Query<TValue> AddField<TValue, TProperty>(this Query<TValue> query, Expression<Func<TValue, TProperty>> selector, QueryBase<TProperty> subQuery) {

//            if (query == null) return null;

//            query.Fields.Add(subQuery);

//            return query;

//        }

//        /// <summary>
//        /// Appends a new field based on the result of the specified <paramref name="selector"/>.
//        /// </summary>
//        /// <typeparam name="TValue">The type of the value.</typeparam>
//        /// <typeparam name="TProperty">The type of the property.</typeparam>
//        /// <param name="query">The query.</param>
//        /// <param name="selector">The property selector.</param>
//        /// <param name="subQuery">The sub query to be added.</param>
//        /// <returns>The query.</returns>
//        public static Query<TValue> AddField<TValue, TProperty>(this Query<TValue> query, Expression<Func<TValue, TProperty[]>> selector, Query<TProperty> subQuery) {

//            if (query == null) return null;

//            string name = ReflectionUtils.GetPropertyName(selector);

//            if (string.IsNullOrWhiteSpace(subQuery.Name)) subQuery.Name = name;

//            query.Fields.Add(subQuery);

//            return query;

//        }

//        /// <summary>
//        /// Appends a new field based on the result of the specified <paramref name="selector"/>.
//        /// </summary>
//        /// <typeparam name="TValue">The type of the value.</typeparam>
//        /// <typeparam name="TProperty">The type of the property.</typeparam>
//        /// <param name="query">The query.</param>
//        /// <param name="selector">The property selector.</param>
//        /// <param name="subQuery">The sub query to be added.</param>
//        /// <returns>The query.</returns>
//        public static Query<TValue> AddField<TValue, TProperty>(this Query<TValue> query, Expression<Func<TValue, TProperty[]>> selector, QueryBase<TProperty> subQuery) {

//            if (query == null) return null;

//            query.Fields.Add(subQuery);

//            return query;

//        }

//        public static TQuery Update<TQuery>(this TQuery query, Action<TQuery> callback) where TQuery : IQuery {
//            callback(query);
//            return query;
//        }

//    }

//}