/**
 * Extended / internal helpers, for more specific or advanced usage.
 * Author: Ronen Ness.
 * Since: 2018.
 */
using System;
using System.Reflection;


namespace Mirrors
{
    /// <summary>
    /// Internal / advanced reflection helpers.
    /// </summary>
    public static class MirrorsEx
    {
        /// <summary>
        /// Default flags to use for instance-related actions.
        /// </summary>
        public static BindingFlags DefaultInstanceFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;

        /// <summary>
        /// Set a property value from name.
        /// </summary>
        /// <param name="obj">Object to set value to.</param>
        /// <param name="fieldName">Property identifier.</param>
        /// <param name="value">Value to set.</param>
        /// <param name="ignoreCase">If true, field name will not be case-sensitive.</param>
        /// <param name="castFromStr">If true, will cast value from string to property type.</param>
        public static void SetProperty(object obj, string fieldName, object value, bool ignoreCase = false, bool castFromStr = false)
        {
            // set flags
            var flags = DefaultInstanceFlags;
            if (ignoreCase) flags |= BindingFlags.IgnoreCase;

            // get property
            PropertyInfo prop = obj.GetType().GetProperty(fieldName, flags);

            // not found? exception
            if (prop == null)
                throw new FieldNotFoundException("Property name '" + fieldName + "' wasn't found!");

            // not writable? exception
            if (!prop.CanWrite)
                throw new PropertyNotWritableException("Property '" + fieldName + "' is not writeable!");

            // set value
            try
            {
                prop.SetValue(obj, castFromStr ? FromString(prop, value.ToString()) : value, null);
            }
            catch (ArgumentException e)
            {
                throw new WrongTypeException("Property '" + fieldName + "' is not of type '" + value.GetType().ToString() + "'!", e);
            }
        }

        /// <summary>
        /// Get a property value from name.
        /// </summary>
        /// <typeparam name="T">Type of attribute to return.</typeparam>
        /// <param name="obj">Object to get attribute from.</param>
        /// <param name="fieldName">Property identifier.</param>
        /// <param name="ignoreCase">If true, property name will not be case-sensitive.</param>
        public static T GetProperty<T>(object obj, string fieldName, bool ignoreCase = false)
        {
            // set flags
            var flags = DefaultInstanceFlags;
            if (ignoreCase) flags |= BindingFlags.IgnoreCase;

            // get property
            PropertyInfo prop = obj.GetType().GetProperty(fieldName, flags);

            // not found? exception
            if (prop == null)
                throw new FieldNotFoundException("Property name '" + fieldName + "' wasn't found!");

            // not writable? exception
            if (!prop.CanRead)
                throw new PropertyNotReadableException("Property '" + fieldName + "' is not readable!");

            // get value
            T value;
            try
            {
                value = (T)prop.GetValue(obj);
            }
            // type mismatch?
            catch (InvalidCastException e)
            {
                throw new WrongTypeException("Property '" + fieldName + "' is not of type '" + typeof(T).ToString() + "'!", e);
            }

            // return value
            return value;
        }

        /// <summary>
        /// Set a field value from name.
        /// </summary>
        /// <param name="obj">Object to set value to.</param>
        /// <param name="fieldName">Field identifier.</param>
        /// <param name="value">Value to set.</param>
        /// <param name="ignoreCase">If true, field name will not be case-sensitive.</param>
        /// <param name="castFromStr">If true, will cast value from string to property type.</param>
        public static void SetField(object obj, string fieldName, object value, bool ignoreCase = false, bool castFromStr = false)
        {
            // set flags
            var flags = DefaultInstanceFlags;
            if (ignoreCase) flags |= BindingFlags.IgnoreCase;

            // get field
            FieldInfo field = obj.GetType().GetField(fieldName, flags);

            // not found? exception
            if (field == null)
                throw new FieldNotFoundException("Field named '" + fieldName + "' wasn't found!");

            // set value
            try
            {
                field.SetValue(obj, castFromStr ? FromString(field, value.ToString()) : value);
            }
            catch (ArgumentException e)
            {
                throw new WrongTypeException("Field '" + fieldName + "' is not of type '" + value.GetType().ToString() + "'!", e);
            }
        }

        /// <summary>
        /// Get a field value from name.
        /// </summary>
        /// <typeparam name="T">Type of field to return.</typeparam>
        /// <param name="obj">Object to get field from.</param>
        /// <param name="fieldName">Field identifier.</param>
        /// <param name="ignoreCase">If true, field name will not be case-sensitive.</param>
        public static T GetField<T>(object obj, string fieldName, bool ignoreCase = false)
        {
            // set flags
            var flags = DefaultInstanceFlags;
            if (ignoreCase) flags |= BindingFlags.IgnoreCase;

            // get field
            FieldInfo field = obj.GetType().GetField(fieldName, flags);

            // not found? exception
            if (field == null)
                throw new FieldNotFoundException("Field name '" + fieldName + "' wasn't found!");

            // get value
            T value;
            try
            {
                value = (T)field.GetValue(obj);
            }
            // type mismatch?
            catch (InvalidCastException e)
            {
                throw new WrongTypeException("Field '" + fieldName + "' is not of type '" + typeof(T).ToString() + "'!", e);
            }

            // return value
            return value;
        }

        /// <summary>
        /// Convert string to given field's type.
        /// </summary>
        /// <param name="field">Field to convert into.</param>
        /// <param name="val">String value to convert.</param>
        public static object FromString(FieldInfo field, string val)
        {
            try
            {
                var converter = System.ComponentModel.TypeDescriptor.GetConverter(field.FieldType);
                if (converter == null) throw new MissingConverterException("Field type does not implement IConvertible!");
                return converter.ConvertFromString(val);
            }
            catch (Exception e)
            {
                throw new BadStringFormatException("Failed to convert from string!", e);
            }
        }

        /// <summary>
        /// Convert string to given property's type.
        /// </summary>
        /// <param name="field">Field to convert into.</param>
        /// <param name="val">String value to convert.</param>
        public static object FromString(PropertyInfo field, string val)
        {
            try
            {
                var converter = System.ComponentModel.TypeDescriptor.GetConverter(field.PropertyType);
                if (converter == null) throw new MissingConverterException("Field type does not implement IConvertible!");
                return converter.ConvertFromString(val);
            }
            catch (Exception e)
            {
                throw new BadStringFormatException("Failed to convert from string!", e);
            }
        }
    }
}
