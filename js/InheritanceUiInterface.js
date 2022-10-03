"use strict";
var ICICI = /** @class */ (function () {
    function ICICI() {
    }
    ICICI.prototype.payment = function (amount) {
        console.log("ICICI bank".concat(amount));
    };
    return ICICI;
}());
var SBI = /** @class */ (function () {
    function SBI() {
    }
    SBI.prototype.payment = function (amount1) {
        console.log("SBI Bank".concat(amount1));
    };
    return SBI;
}());
var Onj1 = new ICICI;
var Onj2 = new SBI;
Onj1.payment(50000);
Onj2.payment(10000);
