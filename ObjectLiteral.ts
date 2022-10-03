//dynamic field
let name1 = 'machine name';
let machine = {
   
    'machine hours': 10000,
    [name1]: {  //doubt
        server1: "MS",
        server2:"TR"
    }
};


let mname = machine[name1];
console.log(mname);
console.log(machine[name1]); // server
console.log(machine['machine hours']); // 10000
console.log(machine ); // 10000

let asd1 : {
    first:"hey hey",
    last:"bye bye"
}
// console.log(asd1);