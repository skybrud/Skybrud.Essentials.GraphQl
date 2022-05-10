namespace Skybrud.Essentials.GraphQl {
    
    /// <summary>
    /// Class representing a field in a GraphQL query.
    /// </summary>
    public class Field : IField {

        #region Properties

        /// <summary>
        /// Gets or sets the name of the query.
        /// </summary>
        public string Name { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new field.
        /// </summary>
        public Field() { }

        /// <summary>
        /// Initializes a new field with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the field.</param>
        public Field(string name) {
            Name = name;
        }

        #endregion

    }

}