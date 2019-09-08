# Nuclear.Arguments

This library provides a means of easily parsing arguments passed to applications.

The class [ArgumentCollector](arguments/class_argumentcollector.md) is used to parse any array of strings into a list of [Arguments](arguments/class_argument.md).

Switches are indicated by a leading indicator char.
The switch indicator char defaults to `-` and can be customized.

Value enumerations use a value seperator char to seperate values.
The value seperator char defaults to `;` and can be customized.

#### Example:

```
/Some/Path>SomeProgram.exe -xtc --force some/path/ some/other/path
```

```csharp
static void Main(String[] args) {
    var collector = new ArgumentCollector();
    collector.Collect(args);
	
    foreach(Argument _arg in collector.Arguments) {
       Console.WriteLine(_arg);
    }
	
    // Printout:
    // -x
    // -t
    // -c
    // --force some/path
    // /some/other/path
	
	if(collector.TryGetSwitch("force", out Argument arg)) {
	    DoSomething(arg.Value);
	}
}
```

## Table of contents

* [Argument types](#argument-types)
  * [Short switch](#short-switch)
  * [Short switch with payload](#short-switch-with-payload)
  * [Long switch](#long-switch)
  * [Long switch with payload](#long-switch-with-payload)
  * [Value](#value)

---

## Argument types

An argument is a string which can be appended to a command to pass additional information to a program.
Arguments are usually separated by white-spaces.
Sometimes arguments have a leading indicator char like `-` or `/`.

`Nuclear.Arguments` distinguishes between five types of arguments.

### Short switch

A short switch begins with one switch indicator followed by one char.
The char can only be a letter.
Multiple short switches can be combined to use one common switch indicator (see second example line).

#### Example:

```
/Some/Path>SomeProgram.exe -c
/Some/Path>SomeProgram.exe -wasd
```

---

### Short switch with payload

A value directly following a switch is considered a payload.
This payload is attached to the switch.
Short switches can only have one value as payload.

#### Example:

```
/Some/Path>SomeProgram.exe -x readme.txt
```

---

### Long switch

A long switch begins with two switch indicators followed by the switch name.
The switch name can be any string without white-spaces.

#### Example:

```
/Some/Path>SomeProgram.exe --create
```

---

### Long switch with payload

A value directly following a switch is considered a payload.
This payload is attached to the switch.
Long switches can only have one value as payload.

#### Example:

```
/Some/Path>SomeProgram.exe -extract readme.txt
```

---

### Value

Values have no leading switch indicators.
A value directly following a switch is considered a payload of that switch.
Values can be any string without white-spaces.

#### Example:

```
/Some/Path>SomeProgram.exe readme.txt
```

---