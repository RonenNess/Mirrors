/**
 * Library main API.
 * Author: Ronen Ness.
 * Since: 2018.
 */
using System.Collections.Generic;


namespace Mirrors
{
    /// <summary>
    /// Main class with reflection helpers.
    /// </summary>
    public static class Mirrors
    {
        /// <summary>
        /// Set field / property value by name.
        /// </summary>
        /// <param name="obj">Object to set value to.</param>
        /// <param name="fieldName">Property / field identifier.</param>
        /// <param name="value">Value to set.</param>
        /// <param name="ignoreCase">If true, field name will not be case-sensitive.</param>
        /// <param name="fromString">If true, will convert value from string.</param>
        private static void SetValue(object obj, string fieldName, object value, bool ignoreCase = false, bool fromString = false)
        {
            try
            {
                MirrorsEx.SetProperty(obj, fieldName, value, ignoreCase, fromString);
            }
            catch (FieldNotFoundException)
            {
                MirrorsEx.SetField(obj, fieldName, value, ignoreCase, fromString);
            }
        }

        /// <summary>
        /// Set field / property value by name.
        /// </summary>
        /// <param name="obj">Object to set value to.</param>
        /// <param name="fieldName">Property / field identifier.</param>
        /// <param name="value">Value to set.</param>
        /// <param name="ignoreCase">If true, field name will not be case-sensitive.</param>
        public static void SetValue(object obj, string fieldName, object value, bool ignoreCase = false)
        {
            SetValue(obj, fieldName, value, ignoreCase, false);
        }

        /// <summary>
        /// Set field / property value by name.
        /// </summary>
        /// <param name="obj">Object to set value to.</param>
        /// <param name="fieldName">Property / field identifier.</param>
        /// <param name="value">Value to set.</param>
        /// <param name="ignoreCase">If true, field name will not be case-sensitive.</param>
        public static void SetValueFromString(object obj, string fieldName, object value, bool ignoreCase = false)
        {
            SetValue(obj, fieldName, value, ignoreCase, true);
        }

        /// <summary>
        /// Get all field and property names of an object.
        /// </summary>
        /// <param name="obj">Object to get field and property names.</param>
        /// <param name="onlyPublic">If true, will only return public properties.</param>
        /// <returns>List with all field and property names.</returns>
        public static HashSet<string> Keys(object obj, bool onlyPublic = false)
        {
            // get fields
            HashSet<string> ret = MirrorsEx.GetAllFieldNames(obj, onlyPublic);

            // add properties
            var props = MirrorsEx.GetAllPropertyNames(obj, onlyPublic);
            foreach (var prop in props)
                ret.Add(prop);

            // return result
            return ret;
        }

        /// <summary>
        /// Get field / property value by name.
        /// </summary>
        /// <param name="obj">Object to get value from.</param>
        /// <param name="fieldName">Property / field identifier.</param>
        /// <param name="ignoreCase">If true, field name will not be case-sensitive.</param>
        public static T GetValue<T>(object obj, string fieldName, bool ignoreCase = false)
        {
            try
            {
                return MirrorsEx.GetProperty<T>(obj, fieldName, ignoreCase);
            }
            catch (FieldNotFoundException)
            {
                return MirrorsEx.GetField<T>(obj, fieldName, ignoreCase);
            }
        }
    }
}
