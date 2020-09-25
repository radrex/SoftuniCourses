function solve(input = []) {
  let systems = input.slice()
                     .map(x => x.split(' | '))
                     .reduce((map, [system, component, subComponent]) => {
                       if (!map.has(system)) {
                         map.set(system, new Map([[component, [subComponent]]]));
                         return map;
                       }
                     
                       let currentSystem = map.get(system);
                       if (!currentSystem.has(component)) {
                         currentSystem.set(component, [subComponent]);
                         return map;
                       }
                     
                       currentSystem.get(component).push(subComponent);
                       return map;
                     }, new Map());

  systems = new Map([...systems.entries()].sort((a, b) => b[1].size - a[1].size || a[0].localeCompare(b[0])));
  for (let key of systems.keys()) {
    let value = systems.get(key);
    value = new Map([...value.entries()].sort((a, b) => b[1].length - a[1].length));
    systems.set(key, value);
  }

  let output = '';
  for (let system of systems) {
    output += `${system[0]}\n`;
    for (let component of system[1]) {
      output += `|||${component[0]}\n`;
      for (let subComponent of component[1]) {
        output += `||||||${subComponent}\n`;
      }
    }
  }

  return output.trim();
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(['SULS | Main Site | Home Page',
                   'SULS | Main Site | Login Page',
                   'SULS | Main Site | Register Page',
                   'SULS | Judge Site | Login Page',
                   'SULS | Judge Site | Submittion Page',
                   'Lambda | CoreA | A23',
                   'SULS | Digital Site | Login Page',
                   'Lambda | CoreB | B24',
                   'Lambda | CoreA | A24',
                   'Lambda | CoreA | A25',
                   'Lambda | CoreC | C4',
                   'Indice | Session | Default Storage',
                   'Indice | Session | Default Security']));