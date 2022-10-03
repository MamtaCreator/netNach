"use strict";
var _a;
//dynamic field
var name1 = 'machine name';
var machine = (_a = {
        'machine hours': 10000
    },
    _a[name1] = {
        server1: "MS",
        server2: "TR"
    },
    _a);
var mname = machine[name1];
console.log(mname);
console.log(machine[name1]); // server
console.log(machine['machine hours']); // 10000
console.log(machine); // 10000
var asd1;
// console.log(asd1);
