let x1:unknown;
let x2:number=100;
let x4:string="ABC";
let x3:boolean=true;

x1=x2;
console.log(typeof x1);
//console.log(x1.toUpperCase())

x1=x4;
console.log(typeof x1);
// console.log(x1.toUpperCase()); //compilation error x is unknown
if(typeof x1 === "string")
{
console.log(x1.toUpperCase());
}