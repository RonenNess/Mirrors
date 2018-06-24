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

    /// <summary>
    /// Tried to convert string of bad format.
    /// </summary>
    public class BadStringFormatException : Exception
    {
        /// <summary>
        /// Create exception.
        /// </summary>
        public BadStringFormatException()
        {
        }

        /// <summary>
        /// Create exception with message.
        /// </summary>
        /// <param name="message">Message string.</param>
        public BadStringFormatException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Create exception with message and inner exception.
        /// </summary>
        /// <param name="message">Message string.</param>
        /// <param name="inner">Inner exception</param>
        public BadStringFormatException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    /// <summary>
    /// Field does not support convertion.
    /// </summary>
    public class MissingConverterException : Exception
    {
        /// <summary>
        /// Create exception.
        /// </summary>
        public MissingConverterException()
        {
        }

        /// <summary>
        /// Create exception with message.
        /// </summary>
        /// <param name="message">Message string.</param>
        public MissingConverterException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Create exception with message and inner exception.
        /// </summary>
        /// <param name="message">Message string.</param>
        /// <param name="inner">Inner exception</param>
        public MissingConverterException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
