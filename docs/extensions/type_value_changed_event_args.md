# Class ValueChangedEventArgs

The class `Nuclear.Extensions.ValueChangedEventArgs` implements an event argument type that includes both old and new values of a change.

```csharp
public class ValueChangedEventArgs<TValue> : EventArgs
```

## Table of contents

* [Type parameters](#type_parameters)
* [Properties](#properties)
  * [Old](#old)
  * [New](#new)
  * [HasChanged](#haschanged)
* [Constructors](#constructors)
  * [ValueChangedEventArgs(TValue, TValue)](#valuechangedeventargstvalue-tvalue)
* [Delegate](#delegate)

---

## Type parameters

`TValue`: The type of the value.

## Properties

`Nuclear.Extensions.ValueChangedEventArgs` provides the following properties.

### Old

Gets the old value.

#### Signature:

```csharp
public TValue Old { get; }
```

---

### New

Gets the new value.

#### Signature:

```csharp
public TValue New { get; }
```

---

### HasChanged

Gets if the value has changed.

#### Signature:

```csharp
public Boolean HasChanged { get; }
```

---

## Constructors

`Nuclear.Extensions.ValueChangedEventArgs` provides the following public constructors.

### ValueChangedEventArgs(TValue, TValue)

Creates a new instance of `ValueChangedEventArgs<TValue>`

#### Signature:

```csharp
public ValueChangedEventArgs(TValue oldValue, TValue newValue);
```

#### Parameters:

`TValue oldValue`: The old value.

`TValue newValue`: The new value.

#### Example:

```csharp
var e = new ValueChangedEventArgs<Int32>(oldValue, newValue);
```

---

## Delegate

This is an eventhandler delegate to handle `ValueChangedEventHandler<TValue>` event payload.

#### Signature:

```csharp
public delegate void ValueChangedEventHandler<TValue>(Object sender, ValueChangedEventArgs<TValue> e);
```

#### Type parameters:

`TValue`: The type of the value.

#### Parameters:

`Object sender`: The sender of the event.

`ValueChangedEventArgs<TValue> e`: The event arguments.

---