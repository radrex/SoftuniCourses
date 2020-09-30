function solve(kingdomsData = [], generals = []) {
  let kingdoms = kingdomsData.slice()
                             .reduce((acc, obj) => {
                               if (!acc.has(obj.kingdom)) {
                                 acc.set(obj.kingdom, new Map([[obj.general, { army: obj.army, wins: 0, losses: 0 }]]));
                                 return acc;
                               }

                               let currentKingdom = acc.get(obj.kingdom);
                               if (!currentKingdom.has(obj.general)) {
                                 currentKingdom.set(obj.general, { army: obj.army, wins: 0, losses: 0 });
                                 return acc;
                               }

                               currentKingdom.get(obj.general).army += obj.army;
                               return acc;
                             }, new Map());

  for (let i = 0; i < generals.length; i++) {
    if (generals[i][0] === generals[i][2]) {
      continue;
    }

    let attackingGeneral = kingdoms.get(generals[i][0]).get(generals[i][1]);
    let defendingGeneral = kingdoms.get(generals[i][2]).get(generals[i][3]);
    if (attackingGeneral.army === defendingGeneral.army) {
      continue;
    } else if (attackingGeneral.army > defendingGeneral.army) {
      attackingGeneral.army = Math.floor(attackingGeneral.army * 1.10);
      attackingGeneral.wins++;
      defendingGeneral.army = Math.floor(defendingGeneral.army * 0.90);
      defendingGeneral.losses++;
    } else if (attackingGeneral.army < defendingGeneral.army) {
      attackingGeneral.army = Math.floor(attackingGeneral.army * 0.90);
      attackingGeneral.losses++;
      defendingGeneral.army = Math.floor(defendingGeneral.army * 1.10);
      defendingGeneral.wins++;
    }
  }

  kingdoms = new Map([...kingdoms].sort((a, b) => [...b[1]].reduce((wins, general) => wins + general[1].wins, 0) - 
                                                  [...a[1]].reduce((wins, general) => wins + general[1].wins, 0)) || 
                                                  [...a[1]].reduce((losses, general) => losses + general[1].losses, 0) -
                                                  [...b[1]].reduce((losses, general) => losses + general[1].losses, 0) ||
                                                  a[0].localeCompare(b[0]));

  let winner = kingdoms.entries().next().value;
  let output = `Winner: ${winner[0]}\n`;
  for (let [general, army] of [...winner[1]].sort((a, b) => b[1].army - a[1].army)) {
    output += `/\\general: ${general}\n---army: ${army.army}\n---wins: ${army.wins}\n---losses: ${army.losses}\n`;
  }

  return output.trim();
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve([ { kingdom: "Maiden Way", general: "Merek", army: 5000 },
                    { kingdom: "Stonegate", general: "Ulric", army: 4900 },
                    { kingdom: "Stonegate", general: "Doran", army: 70000 },
                    { kingdom: "YorkenShire", general: "Quinn", army: 0 },
                    { kingdom: "YorkenShire", general: "Quinn", army: 2000 },
                    { kingdom: "Maiden Way", general: "Berinon", army: 100000 } ],
                  [ ["YorkenShire", "Quinn", "Stonegate", "Ulric"],
                    ["Stonegate", "Ulric", "Stonegate", "Doran"],
                    ["Stonegate", "Doran", "Maiden Way", "Merek"],
                    ["Stonegate", "Ulric", "Maiden Way", "Merek"],
                    ["Maiden Way", "Berinon", "Stonegate", "Ulric"] ]));

console.log(solve([ { kingdom: "Stonegate", general: "Ulric", army: 5000 },
                    { kingdom: "YorkenShire", general: "Quinn", army: 5000 },
                    { kingdom: "Maiden Way", general: "Berinon", army: 1000 } ],
                  [ ["YorkenShire", "Quinn", "Stonegate", "Ulric"],
                    ["Maiden Way", "Berinon", "YorkenShire", "Quinn"] ]));

console.log(solve([ { kingdom: "Maiden Way", general: "Merek", army: 5000 },
                    { kingdom: "Stonegate", general: "Ulric", army: 4900 },
                    { kingdom: "Stonegate", general: "Doran", army: 70000 },
                    { kingdom: "YorkenShire", general: "Quinn", army: 0 },
                    { kingdom: "YorkenShire", general: "Quinn", army: 2000 } ],
                  [ ["YorkenShire", "Quinn", "Stonegate", "Doran"],
                    ["Stonegate", "Ulric", "Maiden Way", "Merek"] ]));
