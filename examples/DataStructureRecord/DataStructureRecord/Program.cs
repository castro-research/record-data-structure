
Pessoa p = new()
{
    FullName = "João da Silva",
    Age = 30
};

Console.WriteLine("=============== Class Before change =====================");
Console.WriteLine("Idade: {0}", p.Age);

p.Age = 31;

Console.WriteLine("=============== Class after change =====================");
Console.WriteLine("Idade: {0}", p.Age);


PersonRecord personRecord = new("Alekito", 28);
PersonStructRecord personRecordStruct = new("Alekito 3", 28);
Pessoa personDto = new()
{
    FullName = "Alekito",
    Age = 28
};

// The same methods and operators that indicate reference equality or inequality in classes (such as Object.Equals(Object) and ==), indicate value equality or inequality in records.

personRecord = personRecord with { FullName = "Alekito 2" };

var personRecord2 = personRecord with { Age = 18 };

Console.WriteLine("=============== Equals - 2 Records =====================");
PersonRecord personaRecord = new("Alekito", 28);
PersonRecord personaRecord2 = new("Alekito", 28);
Console.WriteLine(personaRecord == personaRecord2); // true

Console.WriteLine("=============== Reference - 1 Record and 1 Struct Record =====================");
Console.WriteLine(ReferenceEquals(personaRecord, personaRecord2));

Console.WriteLine("=============== Equals - 2 Classes =====================");
Pessoa personDto1 = new()
{
    FullName = "Alekito",
    Age = 28
};
Pessoa personDto2 = new()
{
    FullName = "Alekito",
    Age = 28
};
Console.WriteLine(personDto1 == personDto2); // false

Console.WriteLine("=============== Equals - 2 Structs - skip =====================");
PersonStruct personStruct1 = new()
{
    FullName = "Alekito",
    Age = 28
};
PersonStruct personStruct2 = new()
{
    FullName = "Alekito",
    Age = 28
};

// Console.WriteLine(personStruct1 == personStruct2); // false
// Also Operator '==' cannot be applied to operands of type 'PersonStruct' and 'PersonStruct'

Console.WriteLine("=============== Equals - 1 Record and 1 Struct Record =====================");
PersonStructRecord personaRecordStruct = new("Alekito", 28);
PersonStructRecord personaRecordStruct2 = new("Alekito", 28);
Console.WriteLine(personaRecordStruct == personaRecordStruct2);

// ReferenceEquals(personaRecordStruct, personaRecordStruct2) this will not work because the struct is a value type
// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/boxing-and-unboxing

Console.WriteLine("=============== GetHashCode ====================");
Console.WriteLine("GetHashCode: {0}", personRecord.GetHashCode());
Console.WriteLine("GetHashCode: {0}", personDto.GetHashCode());
Console.WriteLine("=============== ToString ====================");
Console.WriteLine("ToString: {0}", personRecord.ToString());
Console.WriteLine("ToString: {0}", personDto.ToString());
Console.WriteLine("=============== Deconstruct ====================");
var (name, age) = personRecord;
Console.WriteLine("Name: {0}", name);
Console.WriteLine("Age: {0}", age);
Console.WriteLine("=============== With ====================");
PersonRecord person3 = personRecord with { FullName = "Alekito 3" };
Console.WriteLine("Name: {0}", person3.FullName);
Console.WriteLine("Age: {0}", person3.Age);
Console.WriteLine("=============== Clone ====================");

PersonDTOWithConstructor pers = new("Alekito", 28);

PersonStructRecord personStructRecord = new("Alekito", 28);

PersonStructRecord personStructRecord2 = new("Alekito", 28);

Console.WriteLine("=============== Equals - 2 Structs Record =====================");
Console.WriteLine(personStructRecord == personStructRecord2); // True

personStructRecord2.Age = 18;
Console.WriteLine("=============== Equals - 2 Structs Record changed =====================");
Console.WriteLine(personStructRecord == personStructRecord2); // False
Console.WriteLine("Age: {0}", personStructRecord2.Age);

Console.WriteLine("=============== ReferenceEquals - 2 Structs Record =====================");
Console.WriteLine(ReferenceEquals(personStructRecord, personStructRecord2)); // False

Console.WriteLine("=============== Struct Record with method =====================");

PersonStructRecordWithGreeting psrwg = new("Alekito", 28);
Console.WriteLine(psrwg.GetGreeting()); // Output: Hello, my name is Alekito and I am 28 years old.

var point = new Point(1, 2);
var point2 = new Pointer(1, 2);

point2.X = 3;

Console.WriteLine("=============== Point =====================");

Console.WriteLine(point);
Console.WriteLine(point2);

public record Point(int X, int Y);

public record struct Pointer(int X, int Y);




public record Point3D(int X, int Y, int Z) : Point(X, Y);


record PersonRecordWithGreeting(string FullName, int Age)
{
    public string GetGreeting() => $"Hello, my name is {FullName} and I am {Age} years old.";
}

record struct PersonStructRecordWithGreeting(string FullName, int Age)
{
    public string GetGreeting() => $"Hello, my name is {FullName} and I am {Age} years old.";
}

record PersonRecord(string FullName, int Age);

class Pessoa
{
    public string FullName { get; set; }
    public int Age { get; set; }
}

record struct PersonStructRecord (string FullName, int Age);

struct PersonStruct
{
    public string FullName { get; set; }
    public int Age { get; set; }
}


class PersonDTOWithConstructor
{
    string FullName { get; set; }
    int Age { get; set; }

    public PersonDTOWithConstructor(string fullName, int age)
    {
        FullName = fullName;
        Age = age;
    }
}

