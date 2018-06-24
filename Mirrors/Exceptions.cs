/**
 * Different exceptions Mirrors can throw.
 * Author: Ronen Ness.
 * Since: 2018.
 */
using System;

namespace Mirrors
{
    /// <summary>
    /// Field name wasn't found.
    /// </summary>
    public class FieldNotFoundException : Exception
    {
        /// <summary>
        /// Create exception.
        /// </summary>
        public FieldNotFoundException()
        {
        }

        /// <summary>
        /// Create exception with message.
        /// </summary>
        /// <param name="message">Message string.</param>
        public FieldNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Create exception with message and inner exception.
        /// </summary>
        /// <param name="message">Message string.</param>
        /// <param name="inner">Inner exception</param>
        public FieldNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    /// <summary>
    /// Field is not writable.
    /// </summary>
    public class PropertyNotWritableException : Exception
    {
        /// <summary>
        /// Create exception.
        /// </summary>
        public PropertyNotWritableException()
        {
        }

        /// <summary>
        /// Create exception with message.
        /// </summary>
        /// <param name="message">Message string.</param>
        public PropertyNotWritableException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Create exception with message and inner exception.
        /// </summary>
        /// <param name="message">Message string.</param>
        /// <param name="inner">Inner exception</param>
        public PropertyNotWritableException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    /// <summary>
    /// Field is not readable.
    /// </summary>
    public class PropertyNotReadableException : Exception
    {
        /// <summary>
        /// Create exception.
        /// </summary>
        public PropertyNotReadableException()
        {
        }

        /// <summary>
        /// Create exception with message.
        /// </summary>
        /// <param name="message">Message string.</param>
        public PropertyNotReadableException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Create exception with message and inner exception.
        /// </summary>
        /// <param name="message">Message string.</param>
        /// <param name="inner">Inner exception</param>
        public PropertyNotReadableException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    /// <summary>
    /// Field is of unexpected / wrong type.
    /// </summary>
    public class WrongTypeException : Exception
    {
        /// <summary>
        /// Create exception.
        /// </summary>
        public WrongTypeException()
        {
        }

        /// <summary>
        /// Create exception with message.
        /// </summary>
        /// <param name="message">Message string.</param>
        public WrongTypeException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Create exception with message and inner exception.
        /// </summary>
        /// <param name="message">Message string.</param>
        /// <param name="inner">Inner exception</param>
        public WrongTypeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
