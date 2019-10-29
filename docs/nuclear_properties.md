# Nuclear.Properties

This library provides wrapper types that are meant to be used instead of value type properties.
All types implement specific functionality along with `System.ComponentModel.INotifyPropertyChanged`.

The classes and all deriving implementations can be used like any other type.
They really shine however when used in properties.

## Table of contents

* [TrackedProperty](#trackedproperty)
* [ClampedProperty](#clampedproperty)

---

## TrackedProperty

The class `Nuclear.Properties.TrackedProperties.TrackedProperty` holds a value that can be changed and an additional value that gets if the value was changed previously.
It also provides events to notify consumers if the value has been changed and how it has changed.

#### Example:

```csharp
class MyType {

    // Limits to values between 0 and 100 inclusive
    public ITrackedInt32 Percent { get; set; }

	// Limits to values >= MyValue.Zero
	public ITrackedProperty<MyValue> SomeProp { get; set; } = new ClampedProperty<MyValue>(default, MyValue.Zero, null);

    public MyType() {
        Percent.PropertyChanged += (sender, e) => Console.WriteLine("Property '" + e.PropertyName + "'");
        Percent.ValueClamped += (sender, e) => {
            Console.WriteLine("The value was tried to set to '" + e.Set + "' and was clamped back into range");
            Console.WriteLine("The value was '" + e.Old + "' and is now '" + e.New + "'");
        }
    }

    public void DoSomething() {
        Percent.Value = 200;
    }

}
```

---

## ClampedProperty

The class `Nuclear.Properties.TrackedProperties.ClampedProperty` holds a value that can be limited to a specific inclusive range.
It also provides events to notify consumers if the value has been changed or if it was tried to set to a value out of bounds.

#### Example:

```csharp
class MyType {

    // Limits to values between 0 and 100 inclusive
    public IClampedInt32 Percent { get; set; } = new ClampedInt32(0, 0, 100);

	// Limits to values >= MyValue.Zero
	public IClampedProperty<MyValue> SomeProp { get; set; } = new ClampedProperty<MyValue>(default, MyValue.Zero, null);

    public MyType() {
        Percent.PropertyChanged += (sender, e) => Console.WriteLine("Property '" + e.PropertyName + "'");
        Percent.ValueClamped += (sender, e) => {
            Console.WriteLine("The value was tried to set to '" + e.Set + "' and was clamped back into range");
            Console.WriteLine("The value was '" + e.Old + "' and is now '" + e.New + "'");
        }
    }

    public void DoSomething() {
        Percent.Value = 200;
    }

}
```

---