using System.Collections.Generic;

namespace BindableEnum.Library.Models
{
    /// <summary>
    /// Represents an enumeration that is bind safe.
    /// </summary>
    public interface IBindableEnum
    {
        /// <summary>
        /// Whether the enum was able to be binded.
        /// </summary>
        public bool Binded { get; }

        /// <summary>
        /// The enum values for binding to be successful.
        /// </summary>
        public IEnumerable<string> Values { get; }
    }
}
