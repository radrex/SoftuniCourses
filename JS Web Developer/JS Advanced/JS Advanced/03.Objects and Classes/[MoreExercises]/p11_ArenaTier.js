function solve(input = []) {
  let gladiators = input.slice()
                        .map(x => x.split(' -> '))
                        .reduce((acc, [gladiator, technique, skill]) => {
                          skill = +skill;
                          if (gladiator === 'Ave Cesar') {
                            return acc;
                          }
                        
                          if (gladiator.includes(' vs ')) {
                            let [gladiator1, gladiator2] = gladiator.split(' vs ');
                            if (acc.hasOwnProperty(gladiator1) && acc.hasOwnProperty(gladiator2)) {
                              if (acc[gladiator1].map(x => x.technique).some(x => acc[gladiator2].map(x => x.technique).includes(x))) {
                                acc[gladiator1].reduce((acc, value) => acc + value.skill, 0) >
                                  acc[gladiator2].reduce((acc, value) => acc + value.skill, 0) ? delete acc[gladiator2] : delete acc[gladiator1];
                              }
                            }
                            return acc;
                          }
                        
                          if (!acc.hasOwnProperty(gladiator)) {
                            acc[gladiator] = [{ technique: technique, skill: +skill }];
                            return acc;
                          }
                        
                          let g = acc[gladiator].find(x => x.technique === technique);
                          if (g === undefined) {
                            acc[gladiator].push({ technique: technique, skill: +skill });
                            return acc;
                          }
                        
                          if (g.skill < skill) {
                            g.skill = skill;
                          }
                          return acc;
                        }, {});
  let output = '';
  let sortedBySkillAndName = Object.entries(gladiators).sort((a, b) => b[1].reduce((acc, value) => acc + value.skill, 0) - a[1].reduce((acc, value) => acc + value.skill, 0) || a[0].localeCompare(b[0]));

  for (let [key, value] of sortedBySkillAndName) {
    output += `${key}: ${value.reduce((acc, value) => acc + value.skill, 0)} skill\n`;
    value.sort((a, b) => b.skill - a.skill || a.technique.localeCompare(b.technique)).forEach(x => output += `- ${x.technique} <!> ${x.skill}\n`);
  }

  return output.trim();
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(['Pesho -> BattleCry -> 400',
                   'Gosho -> PowerPunch -> 300',
                   'Stamat -> Duck -> 200',
                   'Stamat -> Tiger -> 250',
                   'Ave Cesar']));

console.log(solve(['Pesho -> Duck -> 400',
                   'Julius -> Shield -> 150',
                   'Gladius -> Heal -> 200',
                   'Gladius -> Support -> 250',
                   'Gladius -> Shield -> 250',
                   'Pesho vs Gladius',
                   'Gladius vs Julius',
                   'Gladius vs Gosho',
                   'Ave Cesar']));
