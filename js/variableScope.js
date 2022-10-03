"use strict";
var globalVar = "global var";
var globalLet = " global let";
function fun() {
    var varInFun = "Var in function";
    var letInFun = "Let in funcion";
    console.log("Inside function");
    console.log(letInFun);
    console.log(globalVar);
    console.log(globalLet);
}
// console.log(varInFun);  // Compilation error
fun();
console.log(globalVar);
console.log(globalLet);
