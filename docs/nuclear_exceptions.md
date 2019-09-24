# Nuclear.Exceptions

This library provides a means of easily throwing exceptions when necessary with very little effort.

While throwing exceptions usually requires multiple lines of code, `Nuclear.Exceptions` does that in just one line.
This results in easy to read code to guard against bad input which could otherwise break logic.

A [throw instruction](exceptions/class_conditional_throw.md) can be called by acccessing one of the two properties `If` and `IfNot` on the static class `Nuclear.Exceptions.Throw`.
Every throw instruction throws a specific type of exception according to its name and intellisense description.
Most throw instructions can also be called to throw any type of exception if needed.
The evaluated conditions for an instruction will be inverted if the instruction was called from `Throw.IfNot`.

#### Example:

```csharp

// these are probably bad examples but should be ok for demos.

public MyClass(IDbConnection connection) {
    Throw.If.Null(connection, "connection", "The connection object must not be null.");

    Init(...);
}

public void DoSomething(Object payload) {
    Throw.IfNot.OfType<MyFancyDto>(payload, "payload", String.Format("The given payload is of type {0} when it should be assignable to MyFancyDto", payload.GetType().FullName));
}

```

---