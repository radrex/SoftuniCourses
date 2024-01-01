export default function TodoItem({ _id, text, isCompleted, toggleTodoStatus }) {
  return (
    <tr className={isCompleted ? "todo is-completed" : "todo"}>
      <td>{text}</td>
      <td>{isCompleted ? "Complete" : "Incomplete"}</td>
      <td className="todo-action">
        <button className="btn todo-btn" onClick={() => toggleTodoStatus(_id)}>Change status</button>
      </td>
    </tr>
  );
}
