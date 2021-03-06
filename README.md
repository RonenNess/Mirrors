# Mirrors

Micro C# lib for easier reflection.

# Install

`Install-Package Mirrors`

Or visit [https://www.nuget.org/packages/Mirrors/](https://www.nuget.org/packages/Mirrors/) for more details.

# API

## Example:

Lets start with a basic example:

```cs
// just a testing class..
class Annie
{
	public string Name;
	public string HitBy;
	public bool IsOk;

	public void TellUs(string what)
	{
	}
}

static void Main(string[] args)
{
	// create annie
	Annie annie = new Annie();
	
	// set some fields
	Mirrors.Set(annie, "Name", "Annie");
	Mirrors.Set(annie, "hitby", "A smooth criminal", ignoreCase: true);
	Mirrors.SetFromString(annie, "IsOk", "false");
	
	// get fields
	bool isOk = Mirrors.Get<bool>(annie, "IsOk");
	
	// invoke
	Mirrors.Invoke(annie, "TellUs", new object[] { "Are you ok?" });
}
```

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

#### Mirrors.ParseEnum<type>(str)

Parse enum value from string.

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
