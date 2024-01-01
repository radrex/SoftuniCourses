import TodoItem from './TodoItem';

function TodoListTable({ todoItems, toggleTodoStatus }) {
  return (
    <table className="table">
      <thead>
        <tr>
          <th className="table-header-task">Task</th>
          <th className="table-header-status">Status</th>
          <th className="table-header-action">Action</th>
        </tr>
      </thead>
      <tbody>
        {todoItems.map((todoItem) => (<TodoItem key={todoItem._id} {...todoItem} toggleTodoStatus={toggleTodoStatus} />))}
      </tbody>
    </table>
  );
}

export default TodoListTable;