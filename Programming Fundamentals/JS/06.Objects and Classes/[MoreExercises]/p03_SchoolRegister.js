function getGradesInfo(arr = []) {
  let schoolRegister = {};

  let regex = new RegExp('(?:Student name: )(?<student>[A-Za-z]+)(?:, Grade: )(?<grade>\\d{1,2})(?:, Graduated with an average score: )(?<annualGrade>[1-6].\\d{1,2})');
  while (arr.length !== 0) {
    let [, student, grade, annualGrade] = regex.exec(arr.shift());
    
    grade = Number(grade);
    annualGrade = Number(annualGrade);

    if ((grade > 0 && grade < 12) && annualGrade >= 3.00 ) {
      grade++;

      if (!schoolRegister.hasOwnProperty(grade)) {
        schoolRegister[grade] = {};
        schoolRegister[grade].students = [student];
        schoolRegister[grade].avgAnnualGrade = annualGrade;
      } else {
        schoolRegister[grade].students.push(student);
        schoolRegister[grade].avgAnnualGrade += annualGrade;
      }
    }
  }

  for (let [key, value] of Object.entries(schoolRegister)) {
    value.avgAnnualGrade /= value.students.length;
    console.log(`${key} Grade`);
    console.log(`List of students: ${value.students.join(', ')}`);
    console.log(`Average annual grade from last year: ${value.avgAnnualGrade.toFixed(2)}`);
    console.log();
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
getGradesInfo(["Student name: Mark, Grade: 8, Graduated with an average score: 4.75",
               "Student name: Ethan, Grade: 9, Graduated with an average score: 5.66",
               "Student name: George, Grade: 8, Graduated with an average score: 2.83",
               "Student name: Steven, Grade: 10, Graduated with an average score: 4.20",
               "Student name: Joey, Grade: 9, Graduated with an average score: 4.90",
               "Student name: Angus, Grade: 11, Graduated with an average score: 2.90",
               "Student name: Bob, Grade: 11, Graduated with an average score: 5.15",
               "Student name: Daryl, Grade: 8, Graduated with an average score: 5.95",
               "Student name: Bill, Grade: 9, Graduated with an average score: 6.00",
               "Student name: Philip, Grade: 10, Graduated with an average score: 5.05",
               "Student name: Peter, Grade: 11, Graduated with an average score: 4.88",
               "Student name: Gavin, Grade: 10, Graduated with an average score: 4.00"]);
