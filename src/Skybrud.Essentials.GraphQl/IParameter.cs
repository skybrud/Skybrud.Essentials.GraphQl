namespace Skybrud.Essentials.GraphQl {

    /// <summary>
    /// Interface describing a parameter of a GraphQL query or connection.
    /// </summary>
    public interface IParameter {

        /// <summary>
        /// Gets the name of the parameter.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets the value of the parameter.
        /// </summary>
        public object Value { get; }

    }

    /// <summary>
    /// Interface describing a parameter of a GraphQL query or connection.
    /// </summary>
    /// <typeparam name="T">The value type of the parameter.</typeparam>
    public interface IParameter<out T> : IParameter {

        /// <summary>
        /// Gets or sets the value of the parameter.
        /// </summary>
        public new T Value { get; }

    }

}