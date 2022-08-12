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
    public class TerminalesController : ControllerBase
    {
        private readonly TerminalesRepository _repository;

        public TerminalesController(TerminalesRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Terminales>>> GetAll()
        //{
        //    return await _repository.GetAll();
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Terminales>>> GetTerminalesActivos()
        {
            return await _repository.GetTerminalesActivos();
        }
    }
}
