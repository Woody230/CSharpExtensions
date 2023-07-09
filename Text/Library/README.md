![](https://img.shields.io/github/license/Woody230/CSharpExtensions)
[![](https://img.shields.io/nuget/v/Woody230.Text)](https://www.nuget.org/packages/Woody230.Text)

# Text

Extensions for the System.Text namespace.

# ExtensibleStringBuilder

Wrapper around the System.Text.StringBuilder that is extensible since the System.Text.StringBuilder is sealed. 

It contains the following additional methods, which can be accessed without creating an implementation using the `ExtendedStringBuilder`.
| Name | Description |
| --- | --- |
| Prepend | Insert a string at the beginning of the string being built. |