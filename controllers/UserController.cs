using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using MyProject.Repositories;

namespace MyProject.Controllers;

[Route("api/users")]
[ApiController]
public class UserController(IRepository<UserModel> repository) : BaseController<UserModel>(repository) {}
