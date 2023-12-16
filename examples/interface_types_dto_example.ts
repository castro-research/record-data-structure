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



// Using Type
let person3: PersonType = {
    name: 'Mark',
    age: 39
};

// Using interface
let person: IPerson = {
    name: 'Mark',
    age: 39
};

// Implementing interface
class Person implements IPerson {
    name: string;
    age: number;

    constructor(name: string, age: number) {
        this.name = name;
        this.age = age;
    }
}

// Using Class as DTO
let person2: IPerson = new PersonDTO("Lekito", 28);

let person4: IPerson = new Person("Lekito", 28);
