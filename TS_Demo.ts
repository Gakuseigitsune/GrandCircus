interface Pet{

    name: string;
    age: number;

}


let pet1:Pet ={

    name: 'sally',
    age: 2
}


let s = 'Hello';
console.log(s);
console.log(3+5);

//console.log(pet1);

let allpets:Pet[] =[


{name: 'Fred', age: 3},
{name:'Julie', age: 6},
{name:'Dylan', age: 5}


];

function showPet(thePet){

console.log(`Name: ${thePet.name} Age: ${thePet.age}`);

}

showPet(allpets[1]);

function findOldest(Pets: Pet[]):string {

    let oldest: number = 0;
    let oldestName: string ='';

    Pets.forEach(pet => {

        if(pet.age > oldest){
            oldest = pet.age;
            oldestName=pet.name;
        }    
    });
    return oldestName;
}