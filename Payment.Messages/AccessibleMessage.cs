﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text.Json.Serialization;
using Payment.Messages.Attributes.Format;
using Payment.Messages.Attributes.Serialization;

namespace Payment.Messages
{
    public class AccessibleMessage<T> : IAccessibleMessage
    {
        public AccessibleMessage()
        { }

        #region Static Variables

        private static Lazy<FieldDefinition[]> fieldDefinitions =
            new Lazy<FieldDefinition[]>(
                    GetFieldCollection,
                    LazyThreadSafetyMode.ExecutionAndPublication
                );

        #endregion

        #region Public Methods and Properties

        /// <summary>
        /// Count of accessible property fields on the data object
        /// </summary>
        [JsonIgnore]
        [NotMapped]
        public int FieldCount => fieldDefinitions.Value.Length;

        [JsonIgnore]
        [NotMapped]
        public IEnumerable<FieldDefinition> FieldDefinitions
        {
            get
            {
                foreach(var field in fieldDefinitions.Value)
                {
                    yield return field;
                }
            }
        }

        #endregion

        #region "protected methods"

        protected static FieldDefinition[] GetFieldCollection()
        {
            return GetFieldProperties()
                .Select(pi => new FieldDefinition()
                {
                    FormatAttribute = pi.GetCustomAttribute<FormatAttribute>(),
                    PropertyInfo = pi,
                    SerializationAttribute = pi.GetCustomAttribute<SerializationAttribute>()
                })
                .ToArray();
        }

        /// <summary>
        /// A static method that finds public properties of the class. Any properties marked with
        /// the [NotMapped] attribute are ignored.
        /// </summary>
        protected static PropertyInfo[] GetFieldProperties()
        {
            return typeof(T).GetProperties()
                .Where(pi => !Attribute.IsDefined(pi, typeof(NotMappedAttribute)))
                .ToArray();
        }

        #endregion
    }
}
