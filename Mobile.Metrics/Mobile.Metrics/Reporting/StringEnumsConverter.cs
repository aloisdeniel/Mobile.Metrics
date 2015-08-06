using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Metrics.Reporting
{
        /// <summary>
        /// Converts an <see cref="Enum"/> to and from its name string value.
        /// </summary>
        public class StringEnumsConverter<T> : JsonConverter
        {
            /// <summary>
            /// Gets or sets a value indicating whether the written enum text should be camel case.
            /// </summary>
            /// <value><c>true</c> if the written enum text will be camel case; otherwise, <c>false</c>.</value>
            public bool CamelCaseText { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether integer values are allowed.
            /// </summary>
            /// <value><c>true</c> if integers are allowed; otherwise, <c>false</c>.</value>
            public bool AllowIntegerValues { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="StringEnumConverter"/> class.
            /// </summary>
            public StringEnumsConverter()
            {
                AllowIntegerValues = true;
            }

            /// <summary>
            /// Writes the JSON representation of the object.
            /// </summary>
            /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
            /// <param name="value">The value.</param>
            /// <param name="serializer">The calling serializer.</param>
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                if (value == null)
                {
                    writer.WriteNull();
                    return;
                }

                Enum[] enumArray = ((T[])value).Cast<Enum>().ToArray();
            
                var enumNames = enumArray.Select((v) => v.ToString());

                writer.WriteStartArray();

                foreach (var item in enumNames)
                {
                    writer.WriteValue(item);
                }

                writer.WriteEndArray();
        }

            /// <summary>
            /// Reads the JSON representation of the object.
            /// </summary>
            /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
            /// <param name="objectType">Type of the object.</param>
            /// <param name="existingValue">The existing value of object being read.</param>
            /// <param name="serializer">The calling serializer.</param>
            /// <returns>The object value.</returns>
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Determines whether this instance can convert the specified object type.
            /// </summary>
            /// <param name="objectType">Type of the object.</param>
            /// <returns>
            /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
            /// </returns>
            public override bool CanConvert(Type objectType)
            {
                return true;
            }
        }
}
