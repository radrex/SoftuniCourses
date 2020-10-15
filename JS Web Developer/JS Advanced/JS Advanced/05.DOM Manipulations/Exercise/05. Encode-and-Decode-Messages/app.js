function encodeAndDecodeMessages() {
  let encodeTextAreaElement = document.getElementsByTagName('textarea')[0];
  let encodeBtnElement = document.getElementsByTagName('button')[0];
  let decodeTextAreaElement = document.getElementsByTagName('textarea')[1];
  let decodeBtnElement = document.getElementsByTagName('button')[1];

  if (encodeTextAreaElement === null || decodeTextAreaElement === null || encodeBtnElement === null || decodeBtnElement === null) {
    throw new Error('Something went wrong...');
  }

  encodeBtnElement.addEventListener('click', function() {
    let encodedMessage = '';
    for (let letter of encodeTextAreaElement.value) {
      encodedMessage += String.fromCharCode(letter.charCodeAt(0) + 1);
    }
    encodeTextAreaElement.value = '';
    decodeTextAreaElement.value = encodedMessage;
  });

  decodeBtnElement.addEventListener('click', function() {
    let decodedMessage = '';
    for (let letter of decodeTextAreaElement.value) {
      decodedMessage += String.fromCharCode(letter.charCodeAt(0) - 1);
    }
    decodeTextAreaElement.value = decodedMessage;
  });
}
