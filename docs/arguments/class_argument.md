# Argument

The class `Nuclear.Arguments.Argument` implements all possible types of arguments.
Instances of `Argument` can be created automatically by using [ArgumentCollector](class_argumentcollector.md) to parse command line arguments.

## Table of contents

* [Properties](#properties)
  * [SwitchName](#switchname)
  * [Value](#value)
  * [IsSwitch](#isswitch)
  * [HasValue](#hasvalue)

---

## Properties

`Nuclear.Arguments.Argument` provides the following properties.

### SwitchName

Gets the switch name of the `Argument`.

#### Signature:

```csharp
public String SwitchName { get; }
```

---

### Value

Gets the value of the `Argument`.

#### Signature:

```csharp
public String Value { get; }
```

---

### IsSwitch

Gets if the `Argument` is a switch. An `Argument` without a switch name is not a switch.

#### Signature:

```csharp
public Boolean IsSwitch { get; }
```

---

### HasValue

Gets if the `Argument` has an attached value.

#### Signature:

```csharp
public Boolean HasValue { get; }
```

---