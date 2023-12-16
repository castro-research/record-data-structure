# Records

In this repository, I will introduce more than just an introdction to Records in C#. I will cover some use cases and explain how people who come from the TypeScript ecosystem can understand this.

# Context for TS Developers

Using Typescript, usually we can declare an interface, or type or class as DTO this: ( also in `examples/interface_types_dto_example.ts`)

```typescript
interface IPerson {
    name: string;
    age: number;
}

type PersonType = {
    name: string;
    age: number;
}

class PersonDTO {
    name: string;
    age: number;

    constructor(name: string, age: number) {
        this.name = name;
        this.age = age;
    }
}
```

Maybe you have some questions, like: What records are ? do we need more implementations ? Why Typescript does not have this?   

Before anwser those questions, remember that interfaces and type does not exist in Javascript, only classes. They are a superset that can read your code realtime, using TS Server, and give feedback about your code.

# Moving to C#

Release Note says: The introduction of records provides a concise syntax for reference types that follow value semantics for equality. You'll use these types to define data containers that typically define minimal behavior. Init-only setters provide the capability for non-destructive mutation (with expressions) in records. C# 9 also adds covariant return types so that derived records can override virtual methods and return a type derived from the base method's return type.

The pattern matching capabilities have been expanded in several ways. Numeric types now support range patterns. Patterns can be combined using and, or, and not patterns. Parentheses can be added to clarify more complex patterns:

Microsoft Documentation says: A record in C# is a class or struct that provides special syntax and behavior for working with data models. The record modifier instructs the compiler to synthesize members that are useful for types whose primary role is storing data. These members include an overload of ToString() and members that support value equality.

Let's consider the code: (ignore the redudant name of the classes)

```csharp
record PersonRecord(string FullName, int Age); // C# 9

class Person
{
    public string FullName { get; set; }
    public int Age { get; set; }
}

record struct PersonStructRecord (string FullName, int Age);  // C# 10

struct PersonStruct
{
    public string FullName { get; set; }
    public int Age { get; set; }
}
```

Here, we have more kind of Data Structure. It's not relevant here to explain all of them, but the use cases for Record.

- You can use positional parameters in a primary constructor to create and instantiate a type with immutable properties.

for example:

```csharp
PersonRecord personRecord = new("Alekito", 28);
```

This is different from using classes as:

```csharp
class Person
{
    string FullName { get; set; }
    int Age { get; set; }

    public Person(string fullName, int age)
    {
        FullName = fullName;
        Age = age;
    }
}

Person p = new("Alekito", 28);
```

- Records are immutable

```csharp
PersonRecord personRecord = new("Alekito", 28);
// personRecord.Age = 18 => Error

PersonStructRecord personStructRecord = new("Alekito", 28);
PersonStructRecord.Age = 18 // Works
```

- A record can inherit from another record. A record can't inherit from a class, and a class can't inherit from a record.

```csharp
public record struct Point(int X, int Y);
public record struct Pointer(int X, int Y);

// This cannot be done because the base class is not a record
public record struct Point3D(int X, int Y, int Z) : Point(X, Y); // Error

// This is allowed
public record Point(int X, int Y);
public record Point3D(int X, int Y, int Z) : Point(X, Y);
```

- Deconstruct a record

```csharp
var (name, age) = personRecord; // Record Struct also allow it
```

- Records are reference types
- You can use a with expression to create a copy of an immutable object with new values in selected properties.

```csharp
PersonRecord personRecord = new("Alekito", 28);
PersonRecord personRecord2 = personRecord with { Age = 18 };
```

- Records are sealed

```csharp
PersonRecord personRecord = new("Alekito", 28);
// PersonRecord personRecord2 = new PersonRecord("Alekito", 18) { Age = 18 }; => Error
```

- A record's ToString method creates a formatted string that shows an object's type name and the names and values of all its public properties.

```csharp
PersonRecord personRecord = new("Alekito", 28);
Console.WriteLine(personRecord); // PersonRecord { FullName = Alekito, Age = 28 }
```

- The same methods and operators that indicate reference equality or inequality in classes (such as Object.Equals(Object) and ==), indicate value equality or inequality in records.

```csharp
PersonRecord personRecord = new("Alekito", 28);
PersonRecord personRecord2 = new("Alekito", 28);
Console.WriteLine(personRecord == personRecord2); // True
Console.WriteLine(ReferenceEquals(personRecord, personRecord2)); // False
```


- The record also includes methods. 

```csharp
record PersonRecord(string FullName, int Age)
{
    public string GetGreeting() => $"Hello, my name is {FullName} and I am {Age} years old.";
}

PersonRecord personStructRecord = new("Alekito", 28);
Console.WriteLine(personStructRecord.GetGreeting()); // Output: Hello, my name is Alekito and I am 28 years old.
```

Record structs differ from structs in that the compiler synthesizes the methods for equality, and ToString. The compiler synthesizes a Deconstruct method for positional record structs.

The compiler synthesizes a public init-only property for each primary constructor parameter in a record class. In a record struct, the compiler synthesizes a public read-write property. The compiler doesn't create properties for primary constructor parameters in class and struct types that don't include record modifier.

The Point record is a reference type, indicated by the absence of the struct modifier. It is immutable by default, meaning that its properties cannot be modified after the object is created. The compiler automatically generates a public init-only property for each primary constructor parameter. This property allows you to set the initial values of the X and Y properties during object initialization, but you cannot modify them afterwards.

On the other hand, the Pointer record is a value type, indicated by the presence of the struct modifier. Value types are stored on the stack and have a different memory allocation behavior compared to reference types. The Pointer record is also immutable by default, but the compiler generates a public read-write property for each primary constructor parameter. This means that you can both set and modify the X and Y properties of a Pointer object.

In summary, the main difference between the Point and Pointer records is that Point is a reference type with init-only properties, while Pointer is a value type with read-write properties. The choice between them depends on your specific use case and requirements regarding mutability and memory allocation.

A record can inherit from another record. A record can't inherit from a class, and a class can't inherit from a record.

```csharp
public record Point(int X, int Y); // Record Class
public record struct Pointer(int X, int Y); // Record Struct
```

# Conclusion

C# is a great language, and it's always evolving. 

Even i love JavaScript, in the end, we can only "seal a class" if we use `Object.freeze` (Typescript has a workaround for this). In C#, we can use `sealed` keyword to prevent inheritance, and `readonly` to prevent mutation.

I hope you enjoy this repository, and if you have any question, please, open an issue.

# References

- [Microsoft - Records](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/records)
- [Microsoft - Records in C# 9](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#records)
- [Microsoft - Records in C# 10 ](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10#record-structs)
- [StackOverflow - When to use record vs class vs struct](https://stackoverflow.com/questions/64816714/when-to-use-record-vs-class-vs-struct)
- [Microsoft - Box Value Types](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/boxing-and-unboxing)
