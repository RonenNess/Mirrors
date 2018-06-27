# Mirrors

Micro C# lib for easier reflection.

# Install

`Install-Package Mirrors`

Or visit [https://www.nuget.org/packages/Mirrors/](https://www.nuget.org/packages/Mirrors/) for more details.

# API

## Mirrors

`Mirrors` is the main API class with all basic functionality:

#### Mirrors.Set(obj, fieldName, value, [ignoreCase], [fromString])

Set field / property value by name (similar to Python's setattr).

#### Mirrors.SetFromString(obj, fieldName, value, [ignoreCase])

Set field / property value by name, after converting value from string.

#### Mirrors.Get<T>(obj, fieldName, [ignoreCase])

Get field / property value by name (similar to Python's getattr).

#### Mirrors.ClassName(obj)

Return object's classname as string.

#### Mirrors.Invoke(obj, funcName, [optionalParams], [_this])

Invoke a method by name.

#### Mirrors.Keys(obj, [publicOnly], [declaredOnly])

Get all field, property and method names in object.

## MirrorsEx

`MirrorsEx` provide some extra, more specific functionality. Check out class docs (in code) for more details.

## Exceptions

`Mirrors` may raise the following exceptions:

#### FieldNotFoundException

A field you were trying to access does not exist.

#### PropertyNotWritableException

You were trying to write to a read-only property.

#### PropertyNotReadableException

You were trying to read from a write-only property.

#### WrongTypeException

Wrong type in get value (for example tried to get bool from a string field).

#### BadStringFormatException

Tried to set value from string but had wrong format(for example tying to set bool from "bla bla" string).

#### MissingConverterException

Tried to set value from string to a class that doesn't support that type of converter.

# License

MIT License.
