# ConditionalThrow

The class `Nuclear.Exceptions.ConditionalThrow` implements a range of methods that throw exceptions on certain conditions.

## Table of contents

* [Methods](#methods)
  * [Null(Object, String, String)](#nullobject-string-string)
  * [Null<TException>(Object, params Object[])](#nulltexceptionobject-params-object)
  * [OfType<TType>(Object, String, String)](#oftypettypeobject-string-string)
  * [OfType<TException, TType>(Object, params Object[])](#oftypetexception-ttypeobject-params-object)
  * [NullOrEmpty(String, String, String)](#nulloremptystring-string-string)
  * [NullOrEmpty<TException>(String, params Object[])](#nulloremptytexceptionstring-params-object)
  * [NullOrWhiteSpace(String, String, String)](#nullorwhitespacestring-string-string)
  * [NullOrWhiteSpace<TException>(String, params Object[])](#nullorwhitespacetexceptionstring-params-object)
  * [True(Boolean, String, String)](#trueboolean-string-string)
  * [True<TException>(Boolean, params Object[])](#truetexceptionboolean-params-object)
  * [False(Boolean, String, String)](#falseboolean-string-string)
  * [False<TException>(Boolean, params Object[])](#falsetexceptionboolean-params-object)

---

## Methods

`Nuclear.Exceptions.ConditionalThrow` provides the following public methods.

### Null(Object, String, String)

Throws an `ArgumentNullException` if `_object` is null.

#### Signature:

```csharp
public void Null(Object _object, String paramName, String message);
```

#### Parameters:

`Object _object`: The object to evaluate.

`String paramName`: The parameter name.

`String message`: The message.

#### Example:

```csharp
Throw.If.Null(fileName, "fileName", "The file name must not be null!");
```

---

### Null&lt;TException&gt;(Object, params Object[])

Throws an exception of type `TException` if `_object` is null.

#### Signature:

```csharp
public void Null<TException>(Object _object, params Object[] args) where TException : Exception;
```

#### Type Parameters:

`TException : Exception`: The type of the exception to be thrown.

#### Parameters:

`Object _object`: The object to evaluate.

`Object[] args`: The arguments needed to create the exception.

#### Example:

```csharp
Throw.If.Null<ArgumentException>(fileName, "The file name must not be null!", "fileName");
```

---

### OfType&lt;TType&gt;(Object, String, String)

Throws an `ArgumentNullException` if `_object` is null.
Throws an `ArgumentException` if `_object` is of type `TType`.

#### Signature:

```csharp
public void OfType<TType>(Object _object, String paramName, String message);
```

#### Type Parameters:

`TType : Exception`: The type of `_object` to be checked against.

#### Parameters:

`Object _object`: The object to evaluate.

`String paramName`: The parameter name.

`String message`: The message.

#### Example:

```csharp
Throw.If.OfType<MyClass>(obj, "The object must not derive from MyClass.");
```

---

### OfType&lt;TException, TType&gt;(Object, params Object[])

Throws an `ArgumentNullException` if `_object` is null.
Throws an exception of type `TException` if `_object` is of type `TType`.

#### Signature:

```csharp
public void OfType<TException, TType>(Object _object, params Object[] args) where TException : Exception;
```

#### Type Parameters:

`TException : Exception`: The type of the exception to be thrown.

`TType : Exception`: The type of `_object` to be checked against.

#### Parameters:

`Object _object`: The object to evaluate.

`Object[] args`: The arguments needed to create the exception.

#### Example:

```csharp
Throw.If.OfType<MyClass, NotImplementedException>(obj, "There is no implemented support for objects of type MyClass.");
```

---

### NullOrEmpty(String, String, String)

Throws an `ArgumentNullException` if `_string` is null.
Throws an `ArgumentException` if `_string` is empty.

#### Signature:

```csharp
public void NullOrEmpty(String _string, String paramName, String message);
```

#### Parameters:

`String _string`: The `String` to evaluate.

`String paramName`: The parameter name.

`String message`: The message.

#### Example:

```csharp
Throw.If.NullOrEmpty(fileName, "fileName", "The file name must be set.");
```

---

### NullOrEmpty&lt;TException&gt;(String, params Object[])

Throws an exception of type `TException` if the `_string` is null or empty.

#### Signature:

```csharp
public void NullOrEmpty<TException>(String _string, params Object[] args) where TException : Exception;
```

#### Type Parameters:

`TException : Exception`: The type of the exception to be thrown.

#### Parameters:

`String _string`: The `String` to evaluate.

`Object[] args`: The arguments needed to create the exception.

#### Example:

```csharp
Throw.If.NullOrEmpty<NotImplementedException>(fileName, "Implementation does not support file names without content.");
```

---

### NullOrWhiteSpace(String, String, String)

Throws an `ArgumentNullException` if `_string` is null.
Throws an `ArgumentException` if `_string` is white space or empty.

#### Signature:

```csharp
public void NullOrWhiteSpace(String _string, String paramName, String message);
```

#### Parameters:

`String _string`: The `String` to evaluate.

`String paramName`: The parameter name.

`String message`: The message.

#### Example:

```csharp
Throw.If.NullOrWhiteSpace(fileName, "fileName", "The file name must be set.");
```

---

### NullOrWhiteSpace&lt;TException&gt;(String, params Object[])

Throws an exception of type `TException` if `_string` is null or white space or empty.

#### Signature:

```csharp
public void NullOrWhiteSpace<TException>(String _string, params Object[] args) where TException : Exception;
```

#### Type Parameters:

`TException : Exception`: The type of the exception to be thrown.

#### Parameters:

`String _string`: The `String` to evaluate.

`Object[] args`: The arguments needed to create the exception.

#### Example:

```csharp
Throw.If.NullOrWhiteSpace<NotImplementedException>(fileName, "Implementation does not support file names without content.");
```

---

### True(Boolean, String, String)

Throws an `ArgumentException` if `condition` evaluates to true.

#### Signature:

```csharp
public void True(Boolean condition, String paramName, String message);
```

#### Parameters:

`Boolean condition`: The condition to evaluate.

`String paramName`: The parameter name.

`String message`: The message.

#### Example:

```csharp
Throw.If.True(myStream.CanRead, "The stream must not be able to read.");
```

---

### True&lt;TException&gt;(Boolean, params Object[])

Throws an exception of type `TException` if `condition` evaluates to true.

#### Signature:

```csharp
public void True<TException>(Boolean condition, params Object[] args) where TException : Exception;
```

#### Type Parameters:

`TException : Exception`: The type of the exception to be thrown.

#### Parameters:

`Boolean condition`: The condition to evaluate.

`Object[] args`: The arguments needed to create the exception.

#### Example:

```csharp
Throw.If.True<NotImplementedException>(myStream.CanTimeout, "Why are we having timeouts?");
```

---

### False(Boolean, String, String)

Throws an `ArgumentException` if `condition` evaluates to false.

#### Signature:

```csharp
public void False(Boolean condition, String paramName, String message);
```

#### Parameters:

`Boolean condition`: The condition to evaluate.

`String paramName`: The parameter name.

`String message`: The message.

#### Example:

```csharp
Throw.If.False(myStream.CanRead, "The stream must be able to read.");
```

---

### False&lt;TException&gt;(Boolean, params Object[])

Throws an exception of type `TException` if `condition` evaluates to false.

#### Signature:

```csharp
public void False<TException>(Boolean condition, params Object[] args) where TException : Exception;
```

#### Type Parameters:

`TException : Exception`: The type of the exception to be thrown.

#### Parameters:

`Boolean condition`: The condition to evaluate.

`Object[] args`: The arguments needed to create the exception.

#### Example:

```csharp
Throw.If.False<NotImplementedException>(myStream.CanTimeout, "Why can't we have timeouts?");
```

---

