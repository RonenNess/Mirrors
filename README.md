# Mirrors

Micro C# lib for easier reflection.

# API

## Mirrors

`Mirrors` is the main API class with all basic functionality:

### Mirrors.Set(obj, fieldName, value, [ignoreCase], [fromString])

Set field / property value by name (similar to Python's setattr).

### Mirrors.SetFromString(obj, fieldName, value, [ignoreCase])

Set field / property value by name, after converting value from string.

### Mirrors.Get<T>(obj, fieldName, [ignoreCase])

Get field / property value by name (similar to Python's getattr).

### Mirrors.ClassName(obj)

Return object's classname as string.

### Mirrors.ClassName(obj)

Return object's classname as string.

### Mirrors.Invoke(obj, funcName, [optionalParams], [_this])

Invoke a method by name.

### Mirrors.Keys(obj, [publicOnly], [declaredOnly])

Get all field, property and method names in object.

# License

MIT License.
