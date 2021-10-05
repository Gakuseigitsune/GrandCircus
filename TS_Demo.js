var pet1 = {
    name: 'sally',
    age: 2
};
var s = 'Hello';
console.log(s);
console.log(3 + 5);
//console.log(pet1);
var allpets = [
    { name: 'Fred', age: 3 },
    { name: 'Julie', age: 6 },
    { name: 'Dylan', age: 5 }
];
function showPet(thePet) {
    console.log("Name: " + thePet.name + " Age: " + thePet.age);
}
showPet(allpets[1]);
function findOldest(Pets) {
    var oldest = 0;
    var oldestName = '';
    Pets.forEach(function (pet) {
        if (pet.age > oldest) {
            oldest = pet.age;
            oldestName = pet.name;
        }
    });
    return oldestName;
}
