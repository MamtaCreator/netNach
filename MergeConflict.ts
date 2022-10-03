interface Generic{
    length:number;
}
function check<T extends Generic>(arg:T):void{
console.log(`string length ${arg.length}`);
}
check("String");