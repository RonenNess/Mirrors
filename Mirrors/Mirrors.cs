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
        /// Version identifier.
        /// </summary>
        public static readonly string Version = "1.0.0.0";

        /// <summary>
        /// Set field / property value by name.
        /// </summary>
        /// <param name="obj">Object to set value to.</param>
        /// <param name="fieldName">Property / field identifier.</param>
        /// <param name="value">Value to set.</param>
        /// <param name="ignoreCase">If true, field name will not be case-sensitive.</param>
        /// <param name="fromString">If true, will convert value from string.</param>
        public static void Set(object obj, string fieldName, object value, bool ignoreCase = false, bool fromString = false)
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
        public static void SetFromString(object obj, string fieldName, string value, bool ignoreCase = false)
        {
            Set(obj, fieldName, value, ignoreCase, true);
        }

        /// <summary>
        /// Get all field and property names of an object.
        /// </summary>
        /// <param name="obj">Object to get field and property names.</param>
        /// <param name="publicOnly">If true, will only return public properties.</param>
        /// <param name="declaredOnly">If true, will only return keys declared in object itself, and not inherited.</param>
        /// <returns>List with all field and property names.</returns>
        public static HashSet<string> Keys(object obj, bool publicOnly = false, bool declaredOnly = false)
        {
            return MirrorsEx.GetAllMemberNames(obj, publicOnly, declaredOnly);
        }

        /// <summary>
        /// Invoke a method by name.
        /// </summary>
        /// <param name="obj">Object to invoke method from.</param>
        /// <param name="funcName">Method name.</param>
        /// <param name="optionalParams">Optional params to pass.</param>
        /// <param name="_this">Allow you to use different 'this' then the given object.</param>
        /// <returns>Return method's return code.</returns>
        public static object Invoke(object obj, string funcName, object[] optionalParams = null, object _this = null)
        {
            var type = obj.GetType();
            var method = type.GetMethod(funcName);
            return method.Invoke(_this ?? obj, optionalParams);
        }

        /// <summary>
        /// Get class name.
        /// </summary>
        /// <param name="obj">Object to get classname from.</param>
        /// <returns>Object's class name.</returns>
        public static string ClassName(object obj)
        {
            return obj.GetType().Name;
        }

        /// <summary>
        /// Get field / property value by name.
        /// </summary>
        /// <param name="obj">Object to get value from.</param>
        /// <param name="fieldName">Property / field identifier.</param>
        /// <param name="ignoreCase">If true, field name will not be case-sensitive.</param>
        public static T Get<T>(object obj, string fieldName, bool ignoreCase = false)
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
