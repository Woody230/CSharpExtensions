﻿using System.Collections.Generic;

namespace Woody230.Collections.Generic;

/// <summary>
/// Represents a <see cref="IList{T}"/> that is extensible with additional functionality.
/// </summary>
/// <typeparam name="T">The type of model.</typeparam>
public interface IExtensibleList<T>: IExtensibleCollection<T>, IList<T>
{
}
