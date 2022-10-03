interface Bank{
    payment:(arg:number)=>void;
}
class ICICI implements Bank{
    public payment(amount:number):void{
console.log(`ICICI bank${amount}`)
    }
}

class SBI implements Bank
{
    public payment(amount1:number):void
    {
        console.log(`SBI Bank${amount1}`);
    }
}

let Onj1:Bank=new ICICI;
let Onj2:Bank=new SBI;

Onj1.payment(50000);
Onj2.payment(10000);
