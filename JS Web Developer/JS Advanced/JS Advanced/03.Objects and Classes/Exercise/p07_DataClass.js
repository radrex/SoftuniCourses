class Request {
  constructor (method, uri, version, message) {
    this.method = method;
    this.uri = uri;
    this.version = version;
    this.message = message;
    this.response = undefined;
    this.fulfilled = false;
  }
}

// Don't copy the code below in judge, you won't get any points, just the code above
let myData = new Request('GET', 'http://google.com', 'HTTP/1.1', '')
console.log(myData);
