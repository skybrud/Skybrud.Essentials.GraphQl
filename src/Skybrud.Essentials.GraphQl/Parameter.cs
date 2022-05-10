namespace Skybrud.Essentials.GraphQl {

    /// <summary>
    /// Class representing a parameter of a GraphQL query or connection.
    /// </summary>
    public class Parameter : IParameter {

        #region Properties

        /// <summary>
        /// Gets the name of the parameter.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the name of the parameter.
        /// </summary>
        public object Value { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new parameter with the specified <paramref name="name"/> and <paramref name="value"/>.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        public Parameter(string name, object value) {
            Name = name;
            Value = value;
        }

        #endregion

        #region Static methods

        public static Parameter<T> Create<T>(string name, T value) {
            return new(name, value);
        }

        #endregion

    }

    /// <summary>
    /// Class representing a parameter of a GraphQL query or connection.
    /// </summary>
    /// <typeparam name="T">The value type of the parameter.</typeparam>
    public class Parameter<T> : IParameter<T> {

        #region Properties

        /// <summary>
        /// Gets the name of the parameter.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the value of the parameter.
        /// </summary>
        public T Value { get; }

        object IParameter.Value => Value;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new parameter with the specified <paramref name="name"/> and <paramref name="value"/>.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        public Parameter(string name, T value) {
            Name = name;
            Value = value;
        }

        #endregion

    }

}