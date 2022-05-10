using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Skybrud.Essentials.GraphQl {

    /// <summary>
    /// Builder for converting <see cref="IQuery"/> instances to their string representation.
    /// </summary>
    public class QueryBuilder {

        /// <summary>
        /// Converts the specified <paramref name="query"/> to it's string representation.
        /// </summary>
        /// <param name="query">The query to be formatted.</param>
        /// <returns>The string representation of the query.</returns>
        public virtual string Format(IQuery query) {
            return Format(query, Formatting.Indented);
        }

        /// <summary>
        /// Converts the specified <paramref name="query"/> to it's string representation.
        /// </summary>
        /// <param name="query">The query to be formatted.</param>
        /// <param name="formatting">The formatting to be used.</param>
        /// <returns>The string representation of the query.</returns>
        public virtual string Format(IQuery query, Formatting formatting) {

            StringBuilder sb = new();

            using TextWriter writer = new StringWriter(sb);

            if (formatting == Formatting.Indented) {
                writer.WriteLine("query {");
            } else {
                writer.Write("query{");
            }

            WriteQuery(writer, query, 2, 1, formatting);

            writer.Write("}");

            return sb.ToString();


        }

        protected void WriteValue(TextWriter writer, object value, Formatting formatting) {
            
            switch (value) {
                
                case int:
                case long:
                case float:
                case double:
                case string:
                    writer.Write(JToken.FromObject(value).ToString(Newtonsoft.Json.Formatting.None));
                    break;

                case Enum:
                    writer.Write(JToken.FromObject(value).ToString(Newtonsoft.Json.Formatting.None).Replace("\"", ""));
                    break;

                case VariableReference reference:
                    writer.Write($"${reference.Name}");
                    break;

                default:

                    Type type = value.GetType();

                    int p = 0;

                    writer.Write("{");

                    foreach (PropertyInfo property in type.GetProperties()) {

                        if (p > 0) writer.Write(formatting == Formatting.Indented ? ", " : ",");

                        writer.Write(ReflectionUtils.GetPropertyAlias(property));
                        writer.Write(formatting == Formatting.Indented ? ": " : ":");
                        WriteValue(writer, property.GetValue(value), formatting);

                        p++;

                    }

                    writer.Write("}");
                    
                    break;

                        
            }


        }

        protected void WriteQuery(TextWriter writer, IQuery query, int indent, int level, Formatting formatting) {

            string pad = "".PadLeft(indent * level);

            if (formatting == Formatting.Indented) writer.Write(pad);
            writer.Write(query.Name);

            IReadOnlyList<IParameter> parameters = query.GetParameters();

            if (parameters.Any()) {
                
                writer.Write("(");

                int p = 0;

                foreach (IParameter parameter in parameters) {

                    if (p > 0) {
                        writer.Write(formatting == Formatting.Indented ? ", " : "");
                    }

                    writer.Write(parameter.Name);

                    writer.Write(formatting == Formatting.Indented ? ": " : ":");

                    WriteValue(writer, parameter.Value, formatting);

                    p++;

                }

                writer.Write(")");
            }

            if (formatting == Formatting.Indented) {
                writer.WriteLine(" {");
            } else {
                writer.Write("{");
            }

            int index = 0;
            foreach (IField field in query.Fields) {
                WriteField(writer, field, index++, indent, level + 1, formatting);
            }


            if (formatting == Formatting.Indented) {
                writer.Write(pad);
                writer.WriteLine("}");
            } else {
                writer.Write("}");
            }

        }

        protected void WriteField(TextWriter writer, IField field, int index, int indent, int level, Formatting formatting) {

            string pad;

            if (formatting == Formatting.Indented) {
                pad = "".PadLeft(2 * level, ' ');
            } else {
                pad = index == 0 ? "" : " ";
            }
            

            if (field is IQuery query) {
                if (formatting == Formatting.None) writer.Write(pad);
                WriteQuery(writer, query, indent, level, formatting);
            } else {
                writer.Write(pad);
                writer.Write(field.Name);
                if (formatting == Formatting.Indented) {
                    writer.WriteLine();
                }
            }

        }

    }

}