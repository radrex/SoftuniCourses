function solve(name, age, weight, height) {
  let calcBMI = () => Math.round(weight / (height/100 * height / 100));
  let status = () => {
    if (calcBMI() < 18.5) return 'underweight';
    if (calcBMI() < 25) return 'normal';
    if (calcBMI() < 30) return 'overweight';
    return 'obese';
  }

  let obj = {
    name: name,
    personalInfo: {
      age: age,
      weight: weight,
      height: height,
    },
    BMI: calcBMI(),
    status: status(),
  };

  if (obj.status === 'obese') {
    obj.recommendation = 'admission required';
  }

  return obj;
}

// Don't copy the code below in judge, you won't get any points, just the code above
console.log(solve('Peter', 29, 75, 182));
console.log(solve('Honey Boo Boo', 9, 57, 137));
