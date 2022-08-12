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
    public class TotalContenedoresxNavieraController : ControllerBase
    {
        private readonly TotalContenedoresxNavierasRepository _repository;

        public TotalContenedoresxNavieraController(TotalContenedoresxNavierasRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TotalContxNavieras>>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
