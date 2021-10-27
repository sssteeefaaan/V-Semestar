var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var Person = /** @class */ (function () {
    function Person(name, surname, ID, ig) {
        var _this = this;
        this.getID = function () { return _this.ID; };
        this.name = name;
        this.surname = surname;
        this.setID(ID);
        this.ig = ig;
    }
    Person.prototype.setID = function (id) {
        this.ID = id;
    };
    return Person;
}());
var Student = /** @class */ (function (_super) {
    __extends(Student, _super);
    function Student(name, surname, ID, ig, indexID, year) {
        var _this = _super.call(this, name, surname, ID, ig) || this;
        _this.getIndexID = function () { return _this.indexID; };
        _this.setIndexID(indexID);
        _this.year = year;
        return _this;
    }
    Student.prototype.setIndexID = function (indexID) {
        this.indexID = indexID;
    };
    return Student;
}(Person));
