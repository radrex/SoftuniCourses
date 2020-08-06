function solve(arr = []) {
  let courses = new Map();

  while (arr.length !== 0) {
    let tokens = arr.shift().split(/: |\[|\] with email | joins /);
    if (tokens.length === 2) {
      let [course, capacity] = tokens;
      capacity = +capacity;
      
      if (!courses.has(course)) {
        courses.set(course, { courseCapacity: capacity, students: [] });
        continue;
      }

      courses.get(course).courseCapacity += capacity;
    } else if (tokens.length === 4) {
      let [username, credits, email, course] = tokens;
      credits = +credits;

      let extractedCourse = courses.get(course);
      if (extractedCourse !== undefined && extractedCourse.students.length < extractedCourse.courseCapacity) {
        let student = { username, credits, email };
        extractedCourse.students.push(student);
      }
    }
  }

  courses = new Map([...courses].sort((a, b) => b[1].students.length - a[1].students.length));
  for (let value of courses.values()) {
    value.students.sort((a, b) => b.credits - a.credits);
  }

  for (let [course, courseData] of courses) {
    console.log(`${course}: ${courseData.courseCapacity - courseData.students.length} places left`);
    courseData.students.forEach(x => console.log(`--- ${x.credits}: ${x.username}, ${x.email}`));
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['JavaBasics: 2',
       'user1[25] with email user1@user.com joins C#Basics',
       'C#Advanced: 3',
       'JSCore: 4',
       'user2[30] with email user2@user.com joins C#Basics',
       'user13[50] with email user13@user.com joins JSCore',
       'user1[25] with email user1@user.com joins JSCore',
       'user8[18] with email user8@user.com joins C#Advanced',
       'user6[85] with email user6@user.com joins JSCore',
       'JSCore: 2',
       'user11[3] with email user11@user.com joins JavaBasics',
       'user45[105] with email user45@user.com joins JSCore',
       'user007[20] with email user007@user.com joins JSCore',
       'user700[29] with email user700@user.com joins JSCore',
       'user900[88] with email user900@user.com joins JSCore']);
