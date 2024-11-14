using System;
using API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ServiceFilter(typeof(LogUserActivity))]
[ApiController]                          //Atributes 
[Route("api/[controller]")]              //

public class BaseApiController : ControllerBase
{

}
