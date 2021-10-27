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
System.register("classes", [], function (exports_1, context_1) {
    "use strict";
    var Person, Student;
    var __moduleName = context_1 && context_1.id;
    return {
        setters: [],
        execute: function () {
            Person = /** @class */ (function () {
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
                Person.prototype.print = function (canvas) {
                    var _this = this;
                    this.container = document.createElement("div");
                    this.container.classList.add("Person");
                    canvas.appendChild(this.container);
                    [["Name", this.name], ["Surname", this.surname], ["ID", this.ID], ["Instagram", this.ig]].forEach(function (el) {
                        var label = document.createElement("label");
                        label.htmlFor = el[0];
                        label.innerHTML = el[1];
                        _this.container.appendChild(label);
                    });
                };
                ;
                return Person;
            }());
            exports_1("Person", Person);
            Student = /** @class */ (function (_super) {
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
                Student.prototype.print = function (canvas) {
                    _super.prototype.print.call(this, canvas);
                    var studentInfo = document.createElement("div");
                    studentInfo.classList.add("Student");
                    [["Index", this.indexID], ["Year", this.year]].forEach(function (el) {
                        var label = document.createElement("label");
                        label.htmlFor = el[0].toString();
                        label.innerHTML = el[1].toString();
                        studentInfo.appendChild(label);
                    });
                };
                return Student;
            }(Person));
            exports_1("Student", Student);
        }
    };
});
System.register("generics", [], function (exports_2, context_2) {
    "use strict";
    var Community;
    var __moduleName = context_2 && context_2.id;
    return {
        setters: [],
        execute: function () {
            Community = /** @class */ (function () {
                function Community(name) {
                    var _this = this;
                    this.setName = function (name) { _this.name = name; };
                    this.getName = function () { return _this.name; };
                    this.printCommunity = function (canvas) {
                        _this.container = document.createElement("div");
                        _this.container.classList.add("Community");
                        canvas.appendChild(_this.container);
                        var info = document.createElement("label");
                        info.htmlFor = "Name";
                        info.innerHTML = _this.name;
                        _this.container.appendChild(info);
                        _this.people.forEach(function (person) { person.print(_this.container); });
                    };
                    this.setName(name);
                }
                Community.prototype.addMember = function (person) { this.people.push(person); };
                ;
                return Community;
            }());
            exports_2("Community", Community);
        }
    };
});
