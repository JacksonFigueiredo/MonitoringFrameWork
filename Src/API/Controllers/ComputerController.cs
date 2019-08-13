using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Business;
using API.Business.Interfaces;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace API.Controllers
{
 
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ComputerController : Controller
    {
        private readonly IComputerBusiness _computerBusiness;

        public ComputerController(IComputerBusiness computerbusiness)
        {
            _computerBusiness = computerbusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_computerBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _computerBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Capture computer)
        {
            if (computer == null) return BadRequest();
            return new ObjectResult(_computerBusiness.Create(computer));
        }
    }
    }
