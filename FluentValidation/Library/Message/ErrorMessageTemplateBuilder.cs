using System.Text;
using Woody230.Text.StringBuilder;

namespace Woody230.FluentValidation.Message
{
    /// <summary>
    /// Represents a builder for creating an error message template.
    /// </summary>
    public class ErrorMessageTemplateBuilder: ExtensibleStringBuilder<ErrorMessageTemplateBuilder>
    {
        private const string PropertyName = "PropertyName";
        private const string PropertyValue = "PropertyValue";

        #region Placeholder 

        /// <summary>
        /// Appends the name of the placeholder surrounded by curly brackets.
        /// </summary>
        /// <param name="name">The name of the placeholder.</param>
        /// <returns>This builder.</returns>
        public ErrorMessageTemplateBuilder AppendPlaceholder(string name)
        {
            var placeholder = CreatePlaceholder(name);
            return Append(placeholder);
        }

        /// <summary>
        /// Inserts the name of the placeholder surrounded by curly brackets.
        /// </summary>
        /// <param name="index">The position to insert the placeholder.</param>
        /// <param name="name">The name of the placeholder.</param>
        /// <returns>This builder.</returns>
        public ErrorMessageTemplateBuilder InsertPlaceholder(int index, string name)
        {
            var placeholder = CreatePlaceholder(name);
            return Insert(index, placeholder);
        }

        /// <summary>
        /// Prepends the name of the placeholder surrounded by curly brackets.
        /// </summary>
        /// <param name="name">The name of the placeholder.</param>
        /// <returns>This builder.</returns>
        public ErrorMessageTemplateBuilder PrependPlaceholder(string name)
        {
            return Insert(0, CreatePlaceholder(name));
        }

        #endregion Placeholder

        #region PropertyName

        /// <summary>
        /// Appends the PropertyName placeholder.
        /// </summary>
        /// <returns>This builder.</returns>
        public ErrorMessageTemplateBuilder AppendPropertyName()
        {
            return AppendPlaceholder(PropertyName);
        }

        /// <summary>
        /// Inserts the PropertyName placeholder.
        /// </summary>
        /// <param name="index">The position to insert the placeholder.</param>
        /// <returns>This builder.</returns>
        public ErrorMessageTemplateBuilder InsertPropertyName(int index)
        {
            return InsertPlaceholder(index, PropertyName);
        }

        /// <summary>
        /// Prepends the PropertyName placeholder.
        /// </summary>
        /// <returns>This builder.</returns>
        public ErrorMessageTemplateBuilder PrependPropertyName()
        {
            return PrependPlaceholder(PropertyName);
        }

        #endregion PropertyName

        #region PropertyValue

        /// <summary>
        /// Appends the PropertyValue placeholder.
        /// </summary>
        /// <returns>This builder.</returns>
        public ErrorMessageTemplateBuilder AppendPropertyValue()
        {
            return AppendPlaceholder(PropertyValue);
        }

        /// <summary>
        /// Inserts the PropertyValue placeholder.
        /// </summary>
        /// <param name="index">The position to insert the placeholder.</param>
        /// <returns>This builder.</returns>
        public ErrorMessageTemplateBuilder InsertPropertyValue(int index)
        {
            return InsertPlaceholder(index, PropertyValue);
        }

        /// <summary>
        /// Prepends the PropertyValue placeholder.
        /// </summary>
        /// <returns>This builder.</returns>
        public ErrorMessageTemplateBuilder PrependPropertyValue()
        {
            return PrependPlaceholder(PropertyValue);
        }

        #endregion PropertyValue

        private static StringBuilder.AppendInterpolatedStringHandler CreatePlaceholder(string name)
        {
            var handler = new StringBuilder.AppendInterpolatedStringHandler();
            handler.AppendLiteral("{");
            handler.AppendLiteral(name);
            handler.AppendLiteral("}");
            return handler;
        }
    }
}
