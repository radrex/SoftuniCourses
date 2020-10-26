function solve(worker) {
  if (worker.dizziness) {
    worker.levelOfHydrated += 0.1 * worker.weight * worker.experience;
    worker.dizziness = false;
  }

  return worker;
}

// Don't copy the code below in judge, you won't get any points, just the code above
console.log(solve({ weight: 80,
                    experience: 1,
                    levelOfHydrated: 0,
                    dizziness: true }));

console.log(solve({ weight: 120,
                    experience: 20,
                    levelOfHydrated: 200,
                    dizziness: true }));

console.log(solve({ weight: 95,
                    experience: 3,
                    levelOfHydrated: 0,
                    dizziness: false }));