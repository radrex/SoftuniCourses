function employees() {
  //----------- BASE/ABSTRACT CLASS -----------
  class Employee {
    constructor(name, age) {
      if (new.target == Employee) {
        throw new Error("Cannot make instance of abstract class Employee.");
      }

      this.name = name;
      this.age = age;
      this.salary = 0;
      this.tasks = [];
    }

    work() {
      let currentTask = this.tasks.shift();
      console.log(`${this.name} ` + currentTask);
      this.tasks.push(currentTask);
    }

    collectSalary() {
      console.log(`${this.name} received ${this.getSalary()} this month.`)
    }

    getSalary() {
      return this.salary;
    }
  }

  //----------- CHILD CLASS -----------
  class Junior extends Employee {
    constructor(name, age) {
      super(name, age);
      this.tasks.push("is working on a simple task.");
    }
  }

  //----------- CHILD CLASS -----------
  class Senior extends Employee {
    constructor(name, age) {
      super(name, age);
      this.tasks.push("is working on a complicated task.");
      this.tasks.push("is taking time off work.");
      this.tasks.push("is supervising junior workers.");
    }
  }

  //----------- CHILD CLASS -----------
  class Manager extends Employee {
    constructor(name, age) {
      super(name, age);
      this.dividend = 0;
      this.tasks.push("scheduled a meeting.");
      this.tasks.push("is preparing a quarterly report.");
    }

    getSalary() {
      return super.getSalary() + this.dividend;
    }
  }

  return { Employee, Junior, Senior, Manager };
}

// Don't copy the code below in judge, you won't get any points, just the code above
let employeeClasses = employees();
let junior = new employeeClasses.Junior('Pesho', 20);
let senior = new employeeClasses.Senior('Gosho', 99);
let manager = new employeeClasses.Manager('Ivan', 37);

junior.work();
senior.work();
manager.work();

junior.collectSalary();
senior.collectSalary();
manager.collectSalary();

console.log(junior.getSalary());
console.log(senior.getSalary());
console.log(manager.getSalary());
