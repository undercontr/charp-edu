namespace CSharp.Edu.Test;

public class DbMock : IDbMock
{
    private readonly IList<Todo> _todoList;

    public DbMock()
    {
        _todoList = new List<Todo>();
    }

    public void Add(Todo todo)
    {
        _todoList.Add(todo);
    }

    public bool Delete(int id)
    {
        var todo = _todoList.FirstOrDefault(x => x.Id == id);

        if (todo != null)
        {
            _todoList.Remove(todo);
            return true;
        }

        return false;
    }

    public void Update(int id, Todo todo)
    {
        todo.Id = id;

        var dbTodo = _todoList.FirstOrDefault(t => t.Id == id);

        if (dbTodo != null)
        {
            dbTodo.Title = todo.Title;
            dbTodo.Content = todo.Content;
            dbTodo.IsCompleted = todo.IsCompleted;
        }
    }

    public void Update(Todo todo)
    {
        Update(todo.Id, todo);
    }

    public Todo? Get(int id)
    {
        return _todoList.FirstOrDefault(t => t.Id == id);
    }

    public IEnumerable<Todo> GetAll()
    {
        return _todoList;
    }
}
