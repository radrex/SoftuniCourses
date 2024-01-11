import { createContext } from 'react';

// Default value is set in cases where the context is being read in places where it is unreachable
// In other words if it is outside the scope of the provider tags (ex: TodoContext.Provider)
// Default value is passed as a parameter in the createContext() function, and it can be anything from function to simple value.
export const TodoContext = createContext();

