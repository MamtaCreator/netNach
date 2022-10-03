interface Imain<T>{
    show:(a:T)=>T
}
class A implements Imain<number>{
    show(num:number):number{
return num;
    }
}

class B implements Imain<string>{
    show(str:string):string{
        return str;
    }
}
let obj:Imain<number>=new A;
console.log(`class a output:${obj}`);
let obj1:B=new B;
console.log(`class b output:${obj1}`);