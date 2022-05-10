using System;
using System.Linq.Expressions;
using System.Reflection;
using Newtonsoft.Json;
using Skybrud.Essentials.Reflection.Extensions;
using Skybrud.Essentials.Strings.Extensions;

namespace Skybrud.Essentials.GraphQl {
    
    /// <summary>
    /// Static class with various reflection based methods specific to this package.
    /// </summary>
    public static class ReflectionUtils {

        private static PropertyInfo GetPropertyInfo<T>(Expression<T> expression) {

            // TODO: Move to Skybrud.Essentials
            
            if (expression.Body is not MemberExpression member) {
                throw new ArgumentException($"Expression body is not of type MemberExpression: {expression}");
            }

            if (member.Member is not PropertyInfo propertyInfo) {
                throw new ArgumentException($"Expression member is not a property: {expression}");
            }

            return propertyInfo;

        }

        /// <summary>
        /// Returns the alias of the specified <paramref name="property"/>.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <returns>The alias of the property.</returns>
        /// <remarks>
        ///     <para>This method will find the alias by looking for a number of attribute types explicitly specifying an alias. If none is found, the CLR name of the property will be used as fallback.</para>
        /// </remarks>
        public static string GetPropertyAlias(PropertyInfo property) {

            if (property.HasCustomAttribute(out ParameterAttribute parameterAttribute) && parameterAttribute.Name.HasValue()) {
                return parameterAttribute.Name;
            }

            if (property.HasCustomAttribute(out FieldAttribute fieldAttribute) && fieldAttribute.Name.HasValue()) {
                return fieldAttribute.Name;
            }

            if (property.HasCustomAttribute(out JsonPropertyAttribute jsonAttribute) && jsonAttribute.PropertyName.HasValue()) {
                return jsonAttribute.PropertyName;
            }

            return property.Name;

        }

        /// <summary>
        /// Gets the alias of the property identified by the specified <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The value type of the property.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>The alias of the property.</returns>
        public static string GetPropertyAlias<T>(Expression<T> expression) {
            return GetPropertyAlias(GetPropertyInfo(expression));
        }

    }

}