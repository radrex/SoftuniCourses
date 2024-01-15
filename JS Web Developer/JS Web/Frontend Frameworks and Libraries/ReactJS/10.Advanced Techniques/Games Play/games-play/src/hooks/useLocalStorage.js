import { useState } from "react";

// using localStorage to persist state for logged user, so he won't be logged out after browser refresh.
export const useLocalStorage = (key, initialValue) => {

  const [state, setState] = useState(() => {
    const persistedStateSerialized = localStorage.getItem(key);
    if (persistedStateSerialized) {
      const persistedState = JSON.parse(persistedStateSerialized);
      return persistedState;
    }

    return initialValue;
  });

  const setLocalStorageState = (value) => {
    setState(value);
    localStorage.setItem(key, JSON.stringify(value));
  };

  return [
    state,
    setLocalStorageState,
  ];
};