using Laboratorio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabController : ControllerBase
    {
        [Route("api/[controller]")]
        [ApiController]

        public class labController : ControllerBase
        {
            private readonly labContext _labContexto;

            public labController(labContext labContexto)
            {
                _labContexto = labContexto;
            }
        }
        


        /*
        [HttpPost]
        [Route("Add")]

        public IActionResult GuardarPedidos([FromBody] Pedidos pedido)
        {
            try
            {

            }
            catch(Exception ex)
            {
                
            }
        }
       */
    }
}
