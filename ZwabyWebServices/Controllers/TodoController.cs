using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ZwabyWebServices.Models;
using System.Linq;

namespace ZwabyWebServices.Controllers
{
	[Route("api/Todo")]
	public class TodoController : Controller
	{
		private readonly TodoContext _context;

		// The constructor uses Dependency Injection to inject the database context (TodoContext) into the controller. 
        // The database context is used in each of the CRUD methods in the controller.
		// The constructor adds an item to the in-memory database if one doesn't exist.

		public TodoController(TodoContext context)
		{
			_context = context;

			if (_context.TodoItems.Count() == 0)
			{
				_context.TodoItems.Add(new TodoItem { Name = "Item1" });
				_context.SaveChanges();
			}
		}

		// The [HttpGet] attribute specifies an HTTP GET method. 
		// The GetAll method returns an IEnumerable. MVC automatically serializes the 
        // object to JSON and writes the JSON into the body of the response message. 
        // The response code for this method is 200, assuming there are no unhandled exceptions.

		[HttpGet]
		public IEnumerable<TodoItem> GetAll()
		{
			return _context.TodoItems.ToList();
		}

		// "{id}" is a placeholder variable for the ID of the todoitem. 
		// When GetById is invoked, it assigns the value of "{id}" in the URL to the method's id parameter.
		// Name = "GetTodo" creates a named route and allows you to link to this route in an HTTP Response.

		// In contrast, the GetById method returns the more general IActionResult type, which represents a wide range 
        // of return types. GetById has two different return types:
		// If no item matches the requested ID, the method returns a 404 error.This is done by returning NotFound.
	    // Otherwise, the method returns 200 with a JSON response body.This is done by returning an ObjectResult

		[HttpGet("{id}", Name = "GetTodo")]
		public IActionResult GetById(long id)
		{
			var item = _context.TodoItems.FirstOrDefault(t => t.Id == id);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

		// This is an HTTP POST method, indicated by the [HttpPost] attribute. 
        // The [FromBody] attribute tells MVC to get the value of the to-do item from the body of the HTTP request.

		[HttpPost]
		public IActionResult Create([FromBody] TodoItem item)
		{
			if (item == null)
			{
				return BadRequest();
			}

			_context.TodoItems.Add(item);
			_context.SaveChanges();

			// The CreatedAtRoute method returns a 201 response, which is the standard response 
            // for an HTTP POST method that creates a new resource on the server. CreatedAtRoute 
            // also adds a Location header to the response. The Location header specifies the URI of the newly created to-do item.
			return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
		}

		[HttpPut("{id}")]
		public IActionResult Update(long id, [FromBody] TodoItem item)
		{
			if (item == null || item.Id != id)
			{
				return BadRequest();
			}

			var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);
			if (todo == null)
			{
				return NotFound();
			}

			todo.IsComplete = item.IsComplete;
			todo.Name = item.Name;

			_context.TodoItems.Update(todo);
			_context.SaveChanges();
			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);
			if (todo == null)
			{
				return NotFound();
			}

			_context.TodoItems.Remove(todo);
			_context.SaveChanges();
			return new NoContentResult();
		}
	}
}
