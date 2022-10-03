var globalVar = "global var";
let globalLet = " global let";

function fun(){
    var varInFun = "Var in function";
    let letInFun="Let in funcion";
    console.log("Inside function")
    console.log(letInFun);
    console.log(globalVar);
    console.log(globalLet);
}
// console.log(varInFun);  // Compilation error
fun();
console.log(globalVar);
console.log(globalLet);