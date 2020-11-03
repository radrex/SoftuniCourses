const assert = require('chai').assert;
const requestValidator = require('../p01_RequestValidator.js').requestValidator;

describe('Request Validator', function() {
  it('Function should return valid object', () => {
    let obj = { method: 'GET',
                uri: 'svn.public.catalog',
                version: 'HTTP/1.1',
                message: '' };

    let result = requestValidator(obj);
    assert.strictEqual(JSON.stringify(result), JSON.stringify(obj));
  });

  it('Function should throw error', function() {
    let objs = [{ method: 'OPTIONS', uri: 'git.master', version: 'HTTP/1.1', message: '-recursive' },
                { method: 'POST', uri: 'home.bash', message: 'rm -rf /*' },
                { method: 'POST', version: 'HTTP/2.0', message: 'rm -rf /*' },
                { method: 'POST', uri: 'home.bash', version: 'HTTP/2.0' },
                { method: 'GET ', uri: 'svn.public.catalog', version: 'HTTP/1.1', message: '' },
                { method: 'GET', uri: 'svn.public.catalog', version: 'HTTP/0.8', message: '' },
                { method: 'GET', uri: 'kkk jjjj', version: 'HTTP/0.8', message: '' }];

    objs.forEach(x => assert.throws(() => requestValidator(x), Error));
  });
});