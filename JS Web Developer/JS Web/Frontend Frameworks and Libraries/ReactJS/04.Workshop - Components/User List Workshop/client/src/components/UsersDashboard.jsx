import SearchBar from './SearchBar';
import UsersTable from './UsersTable';
import Pagination from './Pagination';

export default function UsersDashboard({
  users,
  onOpenUserEditModalHandler,
  onOpenUserInfoModalHandler,
  onOpenUserCreationFormHandler,
  onOpenUserDeleteModalHandler,
}) {
  return (
    <section className="card users-container">
      <SearchBar />
      <UsersTable
        users={users}
        onOpenUserEditModalHandler={onOpenUserEditModalHandler}
        onOpenUserInfoModalHandler={onOpenUserInfoModalHandler}
        onOpenUserDeleteModalHandler={onOpenUserDeleteModalHandler }
      />
      <button className="btn-add btn" onClick={onOpenUserCreationFormHandler}>Add new user</button>
      <Pagination />
    </section>
  );
}