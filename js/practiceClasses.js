"use strict";
var Employee = /** @class */ (function () {
    function Employee() {
    }
    Employee.prototype.add = function (num1, num2) {
        console.log(num1 + num2);
    };
    return Employee;
}());
var emp = new Employee();
emp.add(10, 20);
