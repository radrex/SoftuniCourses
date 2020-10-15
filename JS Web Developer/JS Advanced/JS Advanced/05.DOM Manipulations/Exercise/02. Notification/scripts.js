function notify(message) {
  let notificationElement = document.getElementById('notification');

  if (notificationElement === null) {
    throw new Error('Something went wrong...');
  }

  notificationElement.textContent = message;
  notificationElement.style.display = 'block';

  setTimeout(() => {
    notificationElement.style.display = 'none';
  }, 2000);
}