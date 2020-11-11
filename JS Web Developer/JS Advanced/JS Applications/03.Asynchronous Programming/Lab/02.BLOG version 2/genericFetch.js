function handleError(x) {
  if (!x.ok) {
    throw new Error(x.statusText);
  }
  return x;
}

function deserializeData(x) { return x.json(); }

export function fetchData(hError = handleError, dData = deserializeData, url) {
  return fetch(url)
    .then(hError)
    .then(dData)
    .catch(console.error);
}
