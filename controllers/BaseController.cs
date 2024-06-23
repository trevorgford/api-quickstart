using MyProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MyProject.Controllers;

public class BaseController<T>(IRepository<T> repository) : ControllerBase, IController {

    private readonly IRepository<T> _repository = repository;
    public int UserId { get; set; }
    public int TenantId { get; set; }

    [HttpGet]
    public virtual async Task<ActionResult<IEnumerable<T>>> GetAll() {
        var entities = await _repository.GetAllAsync();
        return Ok(entities);
    }

    [HttpGet("{id}")]
    public virtual async Task<ActionResult<T>> Get(int id) {
        var entity = await _repository.GetAsync(id);
        if (entity == null) return NotFound();
        return Ok(entity);
    }

    [HttpPost]
    public virtual async Task<ActionResult<int>> Create(T entity) {
        var result = await _repository.CreateAsync(entity, UserId, TenantId);
        return Ok(result);
    }

}
