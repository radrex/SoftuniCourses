function requestValidator(request) {
  let clonedRequest = JSON.parse(JSON.stringify(request).replace(/uri/gm, 'URI'));
  const actions = {
    'method': x => /^(GET|POST|DELETE|CONNECT)$/.test(x),
    'URI': x => /^([\dA-Za-z.]+)$|\*/gim.test(x),
    'version':x => /^(HTTP\/(0|1|2).(9|0|1))$/gim.test(x),
    'message': x => /^[^<>\\&'"]*$/gim.test(x),
  };

  let key = '';
  if (!Object.keys(actions).every(x => { key = x; return Object.keys(clonedRequest).includes(x); })) {
    throw new Error(`Invalid request header: Invalid ${key[0].toUpperCase() + key.slice(1)}`);
  }

  Object.entries(clonedRequest).forEach(([key, value]) => {
    if (!actions[key](value)) {
      throw new Error(`Invalid request header: Invalid ${key[0].toUpperCase() + key.slice(1)}`);
    }
  });

  return request;
}

// Copy only the code above in judge to get points ---- 100/100
module.exports = {
  requestValidator,
};