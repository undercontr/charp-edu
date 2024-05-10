namespace CSharp.Edu.Test;

public interface IDbMock
{
    Todo? Get(int id);
    IEnumerable<Todo> GetAll();
    void Add(Todo todo);
    bool Delete(int id);
    void Update(Todo todo);
    void Update(int id, Todo todo);
}
