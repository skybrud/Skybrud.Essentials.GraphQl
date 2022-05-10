namespace Skybrud.Essentials.GraphQl {
    
    /// <summary>
    /// Enum class indicating the formatting when converting a GraphQL uery to it's string representation.
    /// </summary>
    public enum Formatting {

        /// <summary>
        /// Indicates that the query should be indented.
        /// </summary>
        Indented,

        /// <summary>
        /// Indicates that the query should not be indented, ensuring the length of the generated string representation is kept to a minimum.
        /// </summary>
        None

    }

}