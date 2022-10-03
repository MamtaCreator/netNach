"use strict";
function printName(name) {
    if (name === void 0) { name = "No Name"; }
    console.log(name);
}
printName("String"); // String
printName(""); // No Name --> 
printName(undefined); // No Idea -->No Name
var pogo;
printName(pogo); // No Idea --> No Name
printName(); // No idea
