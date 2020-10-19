class Company {
  constructor(departments) {
    this.departments = [];
  }

  addEmployee(username, salary, position, department) {
    if ([...arguments].some(x => x == undefined || x == null || x === '') || salary < 0) {
      throw new Error('Invalid input!');
    }

    let dep = this.departments.find(x => x.name === department);
    if (dep == undefined) {
      let departmentObj = {
        name: department,
        employees: [{ username: username, salary: salary, position: position }],
      };

      dep = departmentObj;
      this.departments.push(departmentObj);
    }

    if (!dep.employees.some(x => x.username === username)) {
      dep.employees.push({ username: username, salary: salary, position: position });
    }

    return `New employee is hired. Name: ${username}. Position: ${position}`;
  }

  bestDepartment() {
    this.departments.sort((a, b) => b.employees.reduce((avgSalary, emp) => avgSalary + emp.salary, 0) / b.employees.length -
                                    a.employees.reduce((avgSalary, emp) => avgSalary + emp.salary, 0) / a.employees.length)
    let log = '';
    log += `Best Department is: ${this.departments[0].name}\n`;
    log += `Average salary: ${(this.departments[0].employees.reduce((avgSalary, emp) => avgSalary + emp.salary, 0) / this.departments[0].employees.length).toFixed(2)}\n`;
    this.departments[0].employees.sort((a, b) => b.salary - a.salary || a.username.localeCompare(b.username))
                                 .forEach(e => log += `${e.username} ${e.salary} ${e.position}\n`);
    return log.trimEnd();
  }
}

// Don't copy the code below in judge, you won't get any points, just the code above
let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
