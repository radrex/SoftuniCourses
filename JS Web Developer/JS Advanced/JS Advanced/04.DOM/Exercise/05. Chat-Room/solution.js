function solve() {
  //----------- GET DATA -----------
  let sendBtn = document.getElementById('send');
  let message = document.getElementById('chat_input');
  let messages = document.getElementById('chat_messages');

  if (sendBtn === null || message === null || messages === null) {
    throw new Error('Something went wrong...');
  }

  //-------- CONSTRUCT HTML --------
  sendBtn.addEventListener('click', function() {
    if (message.value === '') {
      return;
    }

    let messageDiv = document.createElement('div');
    messageDiv.className = 'message my-message';
    messages.appendChild(messageDiv);
  
    messageDiv.textContent = message.value;
    message.value = '';
  });
}
