"use strict";
var A = /** @class */ (function () {
    function A() {
    }
    A.prototype.show = function (num) {
        return num;
    };
    return A;
}());
var B = /** @class */ (function () {
    function B() {
    }
    B.prototype.show = function (str) {
        return str;
    };
    return B;
}());
var obj = new A;
console.log("class a output:".concat(obj));
var obj1 = new B;
console.log("class b output:".concat(obj1));
