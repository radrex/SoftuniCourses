//---- I ------------ WITH MAP (working in judge) ----------------
function systemsRegister(arr = []) {
  let register = new Map();
  while (arr.length !== 0) {
    let [system, component, subComponent] = arr.shift().split(' | ');
    addSystem(system, component, subComponent);
  }

  sortRegister();
  printRegister();

  //-------------------------------- FUNCTIONS ------------------------------------------
  //---- ADD SYSTEM TO REGISTER ----
  function addSystem(system, component, subComponent) {
    // If no such SYSTEM available in the register, create one
    if (!register.has(system)) {
      register.set(system, new Map([[component, [subComponent]]]));
    } else {
      if (!register.get(system).has(component)) { // If no such COMPONENT in that SYSTEM, create one
        register.get(system).set(component, [subComponent]);
      } else { // Push SUBCOMPONENT in the found COMPONENT. (No need to check SUBCOMPONENT for duplicity)
        register.get(system).get(component).push(subComponent);
      }
    }
  }

  //---- SORT REGISTER ----
  function sortRegister() {
    // Order by amount of COMPONENTS, in descending order, as first criteria, and by alphabetical order as second criteria.
    register = new Map([...register.entries()].sort((a, b) => b[1].size - a[1].size || a[0].localeCompare(b[0])));

    // Order COMPONENTS by amount of SUBCOMPONENTS, in descending order.
    for (let key of register.keys()) {
      let value = register.get(key);
      value = new Map([...value.entries()].sort((a, b) => b[1].length - a[1].length));
      register.set(key, value);
    }
  }

  //---- PRINT REGISTER ----
  function printRegister() {
    for (let system of register) {
      console.log(system[0]);
      for (let component of system[1]) {
        console.log(`|||${component[0]}`);
        for (let subComponent of component[1]) {
          console.log(`||||||${subComponent}`);
        }
      }
    }
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
systemsRegister(['SULS | Main Site | Home Page',
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
                 'Indice | Session | Default Security']);


//---- II ------------ WITH OBJECTS (WITHOUT MAP) (working in judge) ----------------
/*
  function systemsRegister(arr = []) {
    let register = {};
    while (arr.length !== 0) {
      let [system, component, subComponent] = arr.shift().split(' | ');
      addSystem(system, component, subComponent);
    }

    sortRegister();
    printRegister();

    //-------------------------------- FUNCTIONS ------------------------------------------
    //---- ADD SYSTEM TO REGISTER ----
    function addSystem(system, component, subComponent) {
      // If no such SYSTEM available in the register, create one
      if (!register.hasOwnProperty(system)) {
        register[system] = {}; // Initialize a new key (SYSTEM NAME) in the object (REGISTER), and assign its value with an empty object (COMPONENT)
        register[system][component] = []; // Initialize a new key (COMPONENT NAME) in the object (COMPONENT), and assign its value with an empty array (SUBCOMPONENTS)
        register[system][component].push(subComponent); // Push the subcomponent in the array
      } else {
        if (!register[system].hasOwnProperty(component)) {  // If no such COMPONENT in that SYSTEM, create one
          register[system][component] = [];
          register[system][component].push(subComponent);
        } else {  // Push SUBCOMPONENT in the found COMPONENT. (No need to check SUBCOMPONENT for duplicity)
          register[system][component].push(subComponent);
        }
      }
    }

    //---- SORT REGISTER ----
    function sortRegister() {
      // Order by amount of COMPONENTS, in descending order, as first criteria, and by alphabetical order as second criteria.
      register = Object.keys(register).sort((a, b) => Object.keys(register[b]).length - Object.keys(register[a]).length || a.localeCompare(b))
                                      .reduce((a, c) => (a[c] = register[c], a), {});

      // Order COMPONENTS by amount of SUBCOMPONENTS, in descending order.
      for (const key of Object.keys(register)) {
        register[key] = Object.keys(register[key]).sort((a, b) => Object.keys(register[key][b]).length - Object.keys(register[key][a]).length)
                                                  .reduce((a, c) => (a[c] = register[key][c], a), {});
      }
    }

    //---- PRINT REGISTER ----
    function printRegister() {
      for (let system in register) {
        console.log(system);
        for (let component in register[system]) {
          console.log(`|||${component}`);
          for (let subComponent of register[system][component]) {
            console.log(`||||||${subComponent}`);
          }
        }
      }
    }
  }

  // Don't copy the calling of the function in judge, you won't get any points, just the code above
  systemsRegister(['SULS | Main Site | Home Page',
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
                  'Indice | Session | Default Security']);
*/

//---- III ------------ WITH OBJECT + ARRAY OF OBJECTS (WITHOUT MAP) (working in judge) ----------------
/*
  function systemsRegister(arr = []) {
    let register = {};
    while (arr.length !== 0) {
      let [system, component, subComponent] = arr.shift().split(' | ');
      addSystem(system, component, subComponent);
    }

    sortRegister();
    printRegister();

    //-------------------------------- FUNCTIONS ------------------------------------------
    //---- ADD SYSTEM TO REGISTER ----
    function addSystem(system, component, subComponent) {
      component = {
        name: component,
        subComponents: [subComponent],
      }

      // If no such SYSTEM available in the register, create one
      if (!register.hasOwnProperty(system)) {
        register[system] = []; // Initialize a new key (SYSTEM NAME) in the object (REGISTER), and assign its value with an empty array (array of COMPONENTS)
        register[system].push(component); // Push the component in the array
      } else {
        if (!register[system].some(x => x.name === component.name)) { // If no such COMPONENT in that SYSTEM, create one
          register[system].push(component);
        } else {  // Push SUBCOMPONENT in the found COMPONENT. (No need to check SUBCOMPONENT for duplicity)
          register[system].find(x => x.name === component.name).subComponents.push(subComponent);
        }
      }
    }

    //---- SORT REGISTER ----
    function sortRegister() {
      // Order by amount of COMPONENTS, in descending order, as first criteria, and by alphabetical order as second criteria.
      register = Object.keys(register).sort((a, b) => register[b].length - register[a].length || a.localeCompare(b)).reduce((a, c) => (a[c] = register[c], a), {});

      // Order COMPONENTS by amount of SUBCOMPONENTS, in descending order.
      for (const key of Object.keys(register)) {
        register[key].sort((a, b) => b.subComponents.length - a.subComponents.length);
      }
    }

    //---- PRINT REGISTER ----
    function printRegister() {
      for (let system in register) {
        console.log(system);
        for (let component of register[system]) {
          console.log(`|||${component.name}`);
          for (let subComponent of component.subComponents) {
            console.log(`||||||${subComponent}`);
          }
        }
      }
    }
  }

  // Don't copy the calling of the function in judge, you won't get any points, just the code above
  systemsRegister(['SULS | Main Site | Home Page',
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
    'Indice | Session | Default Security']);
*/