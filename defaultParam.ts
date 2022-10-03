function printName(name="No Name"){
    console.log(name);
}

printName("String");// String
printName(""); // No Name --> 
printName(undefined); // No Idea -->No Name
let pogo:undefined; 
printName(pogo); // No Idea --> No Name
printName(); // No idea
