# Class ArgumentCollector

The class `Nuclear.Arguments.ArgumentCollector` implements the parsing and filtering mechanics required to transform an array of strings into functional [Arguments](class_argument.md).

## Table of contents

* [Properties](#properties)
  * [SwitchIndicator](#switchindicator)
  * [ValueSeparator](#valueseparator)
  * [Arguments](#arguments)
* [Constructors](#constructors)
  * [ArgumentCollector()](#argumentcollector-1)
  * [ArgumentCollector(Char, Char)](#argumentcollectorchar-char)
* [Methods](#methods)
  * [Collect(String[])](#collectstring)
  * [TryGetSwitch(String, out Argument)](#trygetswitchstring-out-argument)
  * [GetSeparatedValues(Argument)](#getseparatedvaluesargument)

---

## Properties

`Nuclear.Arguments.ArgumentCollector` provides the following properties.

### SwitchIndicator

Gets the `Char` that is used to identify switches. Default is `-`.

#### Signature:

```csharp
public Char SwitchIndicator { get; }
```

---

### ValueSeparator

Gets the `Char` that is used to seperate values. Default is `;`.

#### Signature:

```csharp
public Char ValueSeparator { get; }
```

---

### Arguments

Gets the collected list of arguments.

#### Signature:

```csharp
public List<Argument> Arguments { get; }
```

---

## Constructors

`Nuclear.Arguments.ArgumentCollector` provides the following public constructors.

### ArgumentCollector()

Creates a new instance of `ArgumentCollector` using `-` as switch indicator and `;` as value separator.

#### Signature:

```csharp
public ArgumentCollector();
```

#### Example:

```csharp
var argCollector = new ArgumentCollector();
```

---

### ArgumentCollector(Char, Char)

Creates a new instance of `ArgumentCollector` using custom settings.

#### Signature:

```csharp
public ArgumentCollector(Char switchIndicator, Char valueSeparator);
```

#### Parameters:

`Char switchIndicator`: The char to be used to identify switches.

`Char valueSeparator`: The char to be used to separate values.

#### Example:

```csharp
var argCollector = new ArgumentCollector('/', ':');
```

---

## Methods

`Nuclear.Arguments.ArgumentCollector` provides the following public methods.

### Collect(String[])

Transforms a given `Array` of `String` into a `List<Argument>`.

#### Signature:

```csharp
public void Collect(String[] args);
```

#### Parameters:

`String[] args`: The `Array` of `String` to transform.

#### Example:

```csharp
argCollector.Collect(args);
```

---

### TryGetSwitch(String, out Argument)

Tries to get a specific `Argument` by its switch name.

#### Signature:

```csharp
public Boolean TryGetSwitch(String _switch, out Argument arg);
```

#### Parameters:

`String _switch`: The switch name.

`out Argument arg`: The argument instance.

#### Return value:

True if the argument was found, false if not.

#### Example:

```csharp
if(argCollector.TryGetSwitch("h", out Argument arg)) {
    ShowHelpDialog();
}
```

---

### GetSeparatedValues(Argument)

Gets the separated values of a given `Argument`.
If an argument does not contain values, the returned `List<String>` will be empty.
If an argument contains only one value, the returned `List<String>` will contain one item.

#### Signature:

```csharp
public List<String> GetSeparatedValues(Argument arg);
```

#### Parameters:

`Argument arg`: The `Argument` to get values from.

#### Return value:

A `List<String>` of values from the supplied `Argument`.

#### Example:

```csharp
if(argCollector.TryGetSwitch("files", out Argument arg) && arg.HasValue) {
    ProcessFiles(argCollector.GetSeparatedValues(arg));
}
```

---