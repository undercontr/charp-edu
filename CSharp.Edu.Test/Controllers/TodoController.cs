using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CSharp.Edu.Test.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : Controller
{
    private readonly IDbMock _db;
    public TodoController(IDbMock db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Json(_db.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Json(_db.Get(id));
    }

    [HttpPost]
    public IActionResult Post(Todo todo)
    {
        _db.Add(todo);
        return Created();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isSuccess = _db.Delete(id);
        return isSuccess ? Ok() : BadRequest();
    }

    [HttpPatch("{id}")]
    public IActionResult Update(int id, [FromBody] Todo todo)
    {
        _db.Update(id, todo);

        return Ok();
    }
}