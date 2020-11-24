const html = {
  siteNav: () => document.getElementById('siteNav'),
  createForm: () => document.getElementById('createForm'),
  makeInput: () => document.getElementById('new-make'),
  priceInput: () => document.getElementById('new-price'),
  modelInput: () => document.getElementById('new-model'),
  imageInput: () => document.getElementById('new-image'),
  yearInput: () => document.getElementById('new-year'),
  materialInput: () => document.getElementById('new-material'),
  descriptionInput: () => document.getElementById('new-description'),

  homeSection: () => document.getElementById('homeSection'),
  createSection: () => document.getElementById('createSection'),
  detailsSection: () => document.getElementById('detailsSection'),
  profileSection: () => document.getElementById('profileSection'),
};

export { html };