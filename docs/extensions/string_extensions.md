# String extensions

The class `Nuclear.Extensions.StringExtensions` provides extension methods to the type `System.String`.
These methods add either completely new functionality or enhanced functionality based on existing implementations.

## Table of contents

* [Methods](#methods)
  * [StartsWith(this String, Char)](#startswiththis-string-char)
  * [StartsWith(this String, Char, StringComparison)](#startswiththis-string-char-stringcomparison)
  * [EndsWith(this String, Char)](#endswiththis-string-char)
  * [EndsWith(this String, Char, StringComparison)](#endswiththis-string-char-stringcomparison)
  * [TrimOnce(this String, String)](#trimoncethis-string-string)
  * [TrimOnce(this String, Char)](#trimoncethis-string-char)
  * [TrimStartOnce(this String, String)](#trimstartoncethis-string-string)
  * [TrimStartOnce(this String, Char)](#trimstartoncethis-string-char)
  * [TrimEndOnce(this String, String)](#trimendoncethis-string-string)
  * [TrimEndOnce(this String, Char)](#trimendoncethis-string-char)

---

## Methods

`Nuclear.Extensions.StringExtensions` provides the following public methods.

### StartsWith(this String, Char)

Determines whether the beginning of `_this` matches `value`.

#### Signature:

```csharp
public static Boolean StartsWith(this String _this, Char value);
```

#### Parameters:

`this String _this`: The current `String` instance.

`Char value`: The char to compare.

#### Return value:

True if `_this` begins with `value`, otherwise false.

#### Example:

```csharp
if(someString.StartsWith('x')) {
    doSomething();
}
```

---

### StartsWith(this String, Char, StringComparison)

Determines whether the beginning of `_this` matches `value` when compared using `comparisonType`.

#### Signature:

```csharp
public static Boolean StartsWith(this String _this, Char value, StringComparison comparisonType);
```

#### Parameters:

`this String _this`: The current `String` instance.

`Char value`: The char to compare.

`StringComparison comparisonType`: A definition of how strings are compared.

#### Return value:

True if `_this` begins with `value`, otherwise false.

#### Example:

```csharp
if(someString.StartsWith('x', StringComparison.OrdinalIgnoreCase)) {
    doSomething();
}
```

---

### EndsWith(this String, Char)

Determines whether the end of `_this` matches `value`.

#### Signature:

```csharp
public static Boolean EndsWith(this String _this, Char value);
```

#### Parameters:

`this String _this`: The current `String` instance.

`Char value`: The char to compare.

#### Return value:

True if `_this` ends with `value`, otherwise false.

#### Example:

```csharp
if(someString.EndsWith('x')) {
    doSomething();
}
```

---

### EndsWith(this String, Char, StringComparison)

Determines whether the beginning of `_this` matches `value` when compared using `comparisonType`.

#### Signature:

```csharp
public static Boolean EndsWith(this String _this, Char value, StringComparison comparisonType);
```

#### Parameters:

`this String _this`: The current `String` instance.

`Char value`: The char to compare.

`StringComparison comparisonType`: A definition of how strings are compared.

#### Return value:

True if `_this` ends with `value`, otherwise false.

#### Example:

```csharp
if(someString.EndsWith('x', StringComparison.OrdinalIgnoreCase)) {
    doSomething();
}
```

---

### TrimOnce(this String, String)

Removes one leading and one trailing `String` occurrence from `_this`.

#### Signature:

```csharp
public static String TrimOnce(this String _this, String value);
```

#### Parameters:

`this String _this`: The current `String` instance.

`String value`: A string to remove or null.

#### Return value:

The `String` that remains after one occurrence of `value` is removed from the start and the end of `_this`.
If `value` is null or an empty string, the method returns the current instance unchanged.

#### Example:

```csharp
someString = someString.TrimOnce(@"//");
```

---

### TrimOnce(this String, Char)

Removes one leading and one trailing `Char` occurrence from `_this`.

#### Signature:

```csharp
public static String TrimOnce(this String _this, Char value);
```

#### Parameters:

`this String _this`: The current `String` instance.

`Char value`: A char to remove.

#### Return value:

The `String` that remains after one occurrence of `value` is removed from the start and end of `_this`.

#### Example:

```csharp
someString = someString.TrimOnce('/');
```

---

### TrimStartOnce(this String, String)

Removes one leading `String` occurrence from `_this`.

#### Signature:

```csharp
public static String TrimStartOnce(this String _this, String value);
```

#### Parameters:

`this String _this`: The current `String` instance.

`String value`: A string to remove or null.

#### Return value:

The `String` that remains after one occurrence of `value` is removed from the start of `_this`.
If `value` is null or an empty string, the method returns the current instance unchanged.

#### Example:

```csharp
someString = someString.TrimStartOnce(@"http://");
```

---

### TrimStartOnce(this String, Char)

Removes one leading `Char` occurrence from `_this`.

#### Signature:

```csharp
public static String TrimStartOnce(this String _this, Char value);
```

#### Parameters:

`this String _this`: The current `String` instance.

`Char value`: A char to remove.

#### Return value:

The `String` that remains after one occurrence of `value` is removed from the start of `_this`.

#### Example:

```csharp
someString = someString.TrimStartOnce('/');
```

---

### TrimEndOnce(this String, String)

Removes one trailing `String` occurrence from `_this`.

#### Signature:

```csharp
public static String TrimEndOnce(this String _this, String value);
```

#### Parameters:

`this String _this`: The current `String` instance.

`String value`: A string to remove or null.

#### Return value:

The `String` that remains after one occurrence of `value` is removed from the end of `_this`.
If `value` is null or an empty string, the method returns the current instance unchanged.

#### Example:

```csharp
someString = someString.TrimEndOnce(@".xml");
```

---

### TrimEndOnce(this String, Char)

Removes one trailing `Char` occurrence from `_this`.

#### Signature:

```csharp
public static String TrimEndOnce(this String _this, Char value);
```

#### Parameters:

`this String _this`: The current `String` instance.

`Char value`: A char to remove.

#### Return value:

The `String` that remains after one occurrence of `value` is removed from the end of `_this`.

#### Example:

```csharp
someString = someString.TrimEndOnce('/');
```

---