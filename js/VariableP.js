"use strict";
var x1;
var x2 = 100;
var x4 = "ABC";
var x3 = true;
x1 = x2;
console.log(typeof x1);
//console.log(x1.toUpperCase())
x1 = x4;
console.log(typeof x1);
// console.log(x1.toUpperCase()); //compilation error x is unknown
if (typeof x1 === "string") {
    console.log(x1.toUpperCase());
}
