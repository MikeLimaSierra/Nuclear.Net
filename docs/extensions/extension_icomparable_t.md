# IComparable&lt;T&gt; extensions

The class `Nuclear.Extensions.IComparableTExtensions` provides extension methods to the type `System.IComparable<T>`.
These methods add either completely new functionality or enhanced functionality based on existing implementations.

## Table of contents

* [Methods](#methods)
  * [IsClamped&lt;T&gt;(this T, T, T)](#isclampedtthis-t-t-t)
  * [IsClampedExclusive&lt;T&gt;(this T, T, T)](#isclampedexclusivetthis-t-t-t)
  * [Clamp&lt;T&gt;(this T, T, T)](#clamptthis-t-t-t)

---

## Methods

`Nuclear.Extensions.IComparableExtensions` provides the following public methods.

### IsClamped&lt;T&gt;(this T, T, T)

Checks if a value is clamped in a given inclusive range.

#### Signature:

```csharp
public static Boolean IsClamped<T>(this T _this, T min, T max);
```

#### Type Parameters:

`T : IComparable<T>`: Type must implement `IComparable<T>`.

#### Parameters:

`this T _this`: The value that is checked against the range.

`T min`: The lower border of the range. Is considered lower than `_this` if null.

`T max`: The upper border of the range. Is considered higher than `_this` if null.

#### Return value:

True if `_this` is clamped, false if not.

#### Example:

```csharp
if(someIndex.IsClamped(0, someList.Count - 1)) {
    doSomething(someIndex, someList);
}
```

---

### IsClampedExclusive&lt;T&gt;(this T, T, T)

Checks if a value is clamped in a given exclusive range.

#### Signature:

```csharp
public static Boolean IsClampedExclusive<T>(this T _this, T min, T max);
```

#### Type Parameters:

`T : IComparable<T>`: Type must implement `IComparable<T>`.

#### Parameters:

`this T _this`: The value that is checked against the range.

`T min`: The lower border of the range. Is considered lower than `_this` if null.

`T max`: The upper border of the range. Is considered higher than `_this` if null.

#### Return value:

True if `_this` is clamped, false if not.

#### Example:

```csharp
if(someIndex.IsClampedExclusive(-1, someList.Count)) {
    doSomething(someIndex, someList);
}
```

---

### Clamp&lt;T&gt;(this T, T, T)

Clamps `_this` to a given inclusive range.

#### Signature:

```csharp
public static T Clamp<T>(this T _this, T min, T max);
```

#### Type Parameters:

`T : IComparable<T>`: Type must implement `IComparable<T>`.

#### Parameters:

`this T _this`: The value that is clamped to the range.

`T min`: The lower border of the range. Is considered lower than `_this` if null.

`T max`: The upper border of the range. Is considered higher than `_this` if null.

#### Return value:

The clamped version of `_this`.

#### Exceptions:

`ArgumentNullException`: Thrown if `_this` is null.

#### Example:

```csharp
doSomething(someIndex.Clamp(0, someList.Count - 1), someList);
```

---