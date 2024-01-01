export default function AddNewTodoButton({ addTodoItem }) {
  return (
    <div className="add-btn-container">
      <button className="btn" onClick={addTodoItem}>+ Add new Todo</button>
    </div>
  );
}