import './App.css';

import * as userService from './services/userService';
import { useEffect, useState } from 'react';

import Header from './components/Header';
import Footer from './components/Footer';
import UsersDashboard from './components/UsersDashboard';
import UserInfo from './components/UserInfo';
import UserForm from './components/UserForm';
import UserDeleteConfirmationModal from './components/UserDeleteConfirmationModal';

function App() {
  //--------- Read Users state/handlers -----------
  const [users, setUsers] = useState([]);
  
  useEffect(() => {
    userService.getAll()
      .then(users => {
        setUsers(users);
        console.log(users);
      })
      .catch(err => {
        console.log('Error' + err);
      });
  }, []);

  //--------- User info state/handlers -----------
  const [selectedUser, setSelectedUser] = useState(null);

  const onOpenUserInfoModalHandler = async (userId) => {
    const user = await userService.getById(userId);
    setSelectedUser(user);
  };

  const onCloseUserInfoModalHandler = () => {
    setSelectedUser(null);
  };

  //--------- Create/Edit User state/handlers ---------------
  const [isUserFormVisible, setUserFormVisibility] = useState(false);
  const [userForEdit, setUserForEdit] = useState(null);
  
  const onOpenUserCreationFormHandler = () => {
    setUserFormVisibility(true);
  };

  const onCloseUserCreationFormHandler = () => {
    setUserFormVisibility(false);
    setUserForEdit(null);
  };

  const onSubmitUserCreateOrUpdateFormHandler = async (e, userId, userForEdit) => {
    e.preventDefault();
    let data = Object.fromEntries(new FormData(e.target.form));

    if (userForEdit) {
      const updatedUser = await userService.update(userId, data);
      setUsers(state => state.map(x => x._id === userId ? updatedUser : x));
    } else {
      const createUser = await userService.create(data);
      setUsers(state => [...state, createUser]);
    }

    setUserForEdit(null);
    setUserFormVisibility(false);
  };

  const onOpenUserEditModalHandler = async (userId) => {
    const user = await userService.getById(userId);
    setUserForEdit(user);
    setUserFormVisibility(true);
  };

  //--------- Delete User state/handlers ----------------
  const [selectedUserForDelete, setSelectedUserForDelete] = useState(null);

  const onCloseUserDeleteModalHandler = () => {
    setSelectedUserForDelete(null);
  };

  const onOpenUserDeleteModalHandler = async (userId) => {
    const user = await userService.getById(userId);
    setSelectedUserForDelete(user);
  };

  const onSubmitUserDeleteModalHandler = async (userId) => {
    const deletedUserId = await userService.deleteById(userId);
    setSelectedUserForDelete(null);
    setUsers(state => state.filter(x => x._id !== deletedUserId));
  };

  //-----------------------------------------------

  return (
    <>
      <Header />
      <main className="main">
        <UsersDashboard 
          users={users}
          onOpenUserEditModalHandler={onOpenUserEditModalHandler}
          onOpenUserCreationFormHandler={onOpenUserCreationFormHandler}
          onOpenUserInfoModalHandler={onOpenUserInfoModalHandler}
          onOpenUserDeleteModalHandler={onOpenUserDeleteModalHandler}
        />

        {selectedUser &&
          <UserInfo
            {...selectedUser}
            onCloseUserInfoModalHandler={onCloseUserInfoModalHandler}
          />
        }

        {isUserFormVisible &&
          <UserForm
            userForEdit={userForEdit}
            onCloseUserCreationFormHandler={onCloseUserCreationFormHandler}
            onSubmitUserCreateOrUpdateFormHandler={onSubmitUserCreateOrUpdateFormHandler}
          />
        }

        {selectedUserForDelete &&
          <UserDeleteConfirmationModal
            {...selectedUserForDelete}
            onCloseUserDeleteModalHandler={onCloseUserDeleteModalHandler}
            onSubmitUserDeleteModalHandler={onSubmitUserDeleteModalHandler}
          />
        }
      </main>
      <Footer />
    </>
  );
}

export default App;
