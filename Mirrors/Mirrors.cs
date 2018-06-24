/**
 * Library main API.
 * Author: Ronen Ness.
 * Since: 2018.
 */
using System;
using System.Reflection;


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
        public static void SetValue(object obj, string fieldName, object value, bool ignoreCase = false)
        {
            try
            {
                MirrorsEx.SetProperty(obj, fieldName, value, ignoreCase);
            }
            catch (FieldNotFoundException)
            {
                MirrorsEx.SetField(obj, fieldName, value, ignoreCase);
            }
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
