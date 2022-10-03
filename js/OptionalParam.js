"use strict";
function Print(text, fontsize, destination) {
    if (destination === void 0) { destination = 'abcd'; }
    console.log(text + " sent to destination: " + destination + " with fontsize: " + fontsize);
}
Print('HELLO', 20);
function add() {
    var numbers = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        numbers[_i] = arguments[_i];
    }
}
var tupleEx = [1, 1, 1,];
