function attachEventsListeners() {
  let convertBtn = document.getElementById('convert');
  let inputDistance = document.getElementById('inputDistance');
  let inputUnits = document.getElementById('inputUnits');
  let outputDistance = document.getElementById('outputDistance');
  let outputUnits = document.getElementById('outputUnits');

  if (convertBtn === null || inputDistance === null || inputUnits === null || outputDistance === null || outputUnits === null) {
    throw new Error('Something went wrong...');
  }

  const convertionRates = {
    'km-km': x => x * 1,
    'km-m': x => x * 1000,
    'km-cm': x => x * 100_000,
    'km-mm': x => x * 1_000_000,
    'km-mi': x => x * 0.62_137_119_223,
    'km-yrd': x => x * 1093.6_132_983,
    'km-ft': x => x * 3280.839_895,
    'km-in': x => x * 39_370.0_787,

    'm-km': x => x * 0.001,
    'm-m': x => x * 1,
    'm-cm': x => x * 100,
    'm-mm': x => x * 1000,
    'm-mi': x => x * 0.00_062_137_119_224,
    'm-yrd': x => x * 1.0_936_133,
    'm-ft': x => x * 3.280_839_895,
    'm-in': x => x * 39.3_700_787,
    
    'cm-km': x => x * 0.00_001,
    'cm-m': x => x * 0.01,
    'cm-cm': x => x * 1,
    'cm-mm': x => x * 10,
    'cm-mi': x => x * 0.0_000_062_137_119_224,
    'cm-yrd': x => x * 0.010_936_132_983,
    'cm-ft': x => x * 0.03_280_839_895,
    'cm-in': x => x * 0.3_937_007_874,

    'mm-km': x => x * 0.000_001,
    'mm-m': x => x * 0.001,
    'mm-cm': x => x * 0.1,
    'mm-mm': x => x * 1,
    'mm-mi': x => x * 0.000_000_621_371_192,
    'mm-yrd': x => x * 0.001_093_613_298,
    'mm-ft': x => x * 0.003_280_839_895,
    'mm-in': x => x * 0.03_937_007_874,

    'mi-km': x => x * 1.609_344,
    'mi-m': x => x * 1609.344,
    'mi-cm': x => x * 160934.4,
    'mi-mm': x => x * 1_609_344,
    'mi-mi': x => x * 1,
    'mi-yrd': x => x * 1760,
    'mi-ft': x => x * 5280,
    'mi-in': x => x * 63360,

    'yrd-km': x => x * 0.0_009_144,
    'yrd-m': x => x * 0.9144,
    'yrd-cm': x => x * 91.44,
    'yrd-mm': x => x * 914.4,
    'yrd-mi': x => x * 0.00_056_818_181,
    'yrd-yrd': x => x * 1,
    'yrd-ft': x => x * 3,
    'yrd-in': x => x * 36,

    'ft-km': x => x * 0.0_003_048,
    'ft-m': x => x * 0.3048,
    'ft-cm': x => x * 30.48,
    'ft-mm': x => x * 304.8,
    'ft-mi': x => x * 0.00_018_939_393,
    'ft-yrd': x => x * 0.3_333_333,
    'ft-ft': x => x * 1,
    'ft-in': x => x * 12,

    'in-km': x => x * 0.0_000_254,
    'in-m': x => x * 0.0254,
    'in-cm': x => x * 2.54,
    'in-mm': x => x * 25.4,
    'in-mi': x => x * 0.0_000_157_828_283,
    'in-yrd': x => x * 0.02_777_777_777,
    'in-ft': x => x * 0.0_833_333,
    'in-in': x => x * 1,
  };
  
  convertBtn.addEventListener('click', function() {
    let fromTo = `${inputUnits.options[inputUnits.selectedIndex].value}-${outputUnits.options[outputUnits.selectedIndex].value}`
    let distance = Number(inputDistance.value);
    let result = convertionRates[fromTo](distance);
    outputDistance.value = result;
  });
}