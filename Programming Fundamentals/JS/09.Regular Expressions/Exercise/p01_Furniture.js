function solve(arr) {
  const pattern = />>([a-zA-Z]+)<<(\d+\.?\d+)!(\d+)/gm;

  arr = arr.slice(0, arr.indexOf('Purchase')).join("\n");
  let furniture = Array.from(arr.matchAll(pattern));

  let names = `Bought furniture:`;
  let cost = 0;
  furniture.forEach(match => {
      names += "\n" + match[1];
      cost += Number(match[2]) * Number(match[3]);
  })
 
  console.log(names + `\nTotal money spend: ${cost.toFixed(2)}`);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['>>Sofa<<312.23!3', '>>TV<<300!5', '>Invalid<<!5', 'Purchase']);
