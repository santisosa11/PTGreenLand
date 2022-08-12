using Core.PTGreenLand.Models;
using Infraestructure.PTGreenLand.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.PTGreenLand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NavierasController : ControllerBase
    {
        private readonly NavierasRepository _repository;

        public NavierasController(NavierasRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Navieras>>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
