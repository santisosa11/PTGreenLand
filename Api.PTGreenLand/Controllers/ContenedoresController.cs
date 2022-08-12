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
    public class ContenedoresController : ControllerBase
    {
        private readonly ContenedoresRespository _repository;

        public ContenedoresController(ContenedoresRespository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contenedores>>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Contenedores>>> Get(int id)
        {
            var response = await _repository.GetByCodigoNaviera(id);
            if (response == null) { return NotFound(); }
            return response;
        }
    }
}
