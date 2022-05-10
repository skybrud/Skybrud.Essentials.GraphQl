using System;
using System.Linq.Expressions;

namespace Skybrud.Essentials.GraphQl {
    
    /// <summary>
    /// Static class with extension methods for <see cref="QueryBase{T}"/>.
    /// </summary>
    public static class QueryBaseExtensions {

        public static QueryBase<TValue> AddField<TValue, TProperty>(this QueryBase<TValue> query, Expression<Func<TValue, TProperty>> selector) {

            if (query == null) return default;

            string name = ReflectionUtils.GetPropertyAlias(selector);

            query.Fields.Add(new Field(name));

            return query;

        }

        public static QueryBase<TValue> AddField<TValue, TProperty>(this QueryBase<TValue> query, Expression<Func<TValue, TProperty>> selector, IQueryFields subQuery) {

            if (query == null) return null;

            query.Fields.Add(subQuery);

            return query;

        }

        public static QueryBase<TValue> AddField<TValue, TProperty>(this QueryBase<TValue> query, Expression<Func<TValue, TProperty[]>> selector, IQueryFields<TProperty> subQuery) {

            if (query == null) return null;

            string name = ReflectionUtils.GetPropertyAlias(selector);
            query.Fields.Add(new Query<TProperty>(name, subQuery));

            return query;

        }

        public static QueryBase<TValue> AddField<TValue, TProperty>(this QueryBase<TValue> query, Expression<Func<TValue, TProperty>> selector, QueryBase<TProperty> subQuery) {

            if (query == null) return null;
            
            string name = ReflectionUtils.GetPropertyAlias(selector);
            query.Fields.Add(new Query<TProperty>(name, subQuery));

            return query;

        }

        public static QueryBase<TValue> AddField<TValue, TProperty>(this QueryBase<TValue> query, Expression<Func<TValue, TProperty[]>> selector, QueryBase<TProperty> subQuery) {

            if (query == null) return null;
            
            query.Fields.Add(subQuery);

            return query;

        }

    }

}