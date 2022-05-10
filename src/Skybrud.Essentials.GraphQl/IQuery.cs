using System.Collections.Generic;

// ReSharper disable UnusedTypeParameter

namespace Skybrud.Essentials.GraphQl {

    /// <summary>
    /// Interface describing a GraphQL query.
    /// </summary>
    public interface IQuery : IField {
        
        /// <summary>
        /// Returns a list of the fields to be returned for the query.
        /// </summary>
        IReadOnlyList<IField> Fields { get; }

        /// <summary>
        /// Returns a list of the parameters of the query.
        /// </summary>
        /// <returns>A collection of <see cref="IParameter"/>.</returns>
        IReadOnlyList<IParameter> GetParameters();

    }

    /// <summary>
    /// Interface describing a GraphQL query.
    /// </summary>
    public interface IQuery<T> : IQuery { }

    /// <summary>
    /// Interface describing a GraphQL query.
    /// </summary>
    public interface IQueryFields : IQuery {

        /// <summary>
        /// Returns a list of the fields to be returned for the query.
        /// </summary>
        new List<IField> Fields { get; }

    }

    /// <summary>
    /// Interface describing a GraphQL query.
    /// </summary>
    public interface IQueryFields<T> : IQuery<T>, IQueryFields { }

}