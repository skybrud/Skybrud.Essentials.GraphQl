using Newtonsoft.Json;

namespace Skybrud.Essentials.GraphQl {

    /// <summary>
    /// Interface describing a field in a GraphQL query.
    /// </summary>
    public interface IField {

        /// <summary>
        /// Gets the name of the query
        /// </summary>
        [JsonProperty("name")]
        string Name { get; }

    }

}