const baseUrl = 'http://localhost:3005/api';

export const create = async (userData) => {
  const { country, city, street, streetNumber, ...data } = userData;
  data.address = { country, city, street, streetNumber };

  const response = await fetch(`${baseUrl}/users`, {
    method: 'POST',
    headers: {
      'content-type': 'application/json',
    },
    body: JSON.stringify(data),
  });

  const result = await response.json();
  return result.user;
}

export const update = async (userId, userData) => {
  const { country, city, street, streetNumber, ...data } = userData;
  data.address = { country, city, street, streetNumber };

  const response = await fetch(`${baseUrl}/users/${userId}`, {
    method: 'PUT',
    headers: {
      'content-type': 'application/json',
    },
    body: JSON.stringify(data),
  });

  const result = await response.json();
  return result.user;
}

export const getAll = async () => {
  const response = await fetch(`${baseUrl}/users`);
  const result = await response.json();

  return result.users;
};

export const getById = async (userId) => {
  const response = await fetch(`${baseUrl}/users/${userId}`);
  const result = await response.json();

  return result.user;
};

export const deleteById = async (userId) => {
  const response = await fetch(`${baseUrl}/users/${userId}`, {
    method: 'DELETE',
  });
  const result = await response.json();

  return result.userId;
};
