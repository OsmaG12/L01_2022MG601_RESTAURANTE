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

            //Filtro por cliente
            [HttpGet]
            [Route("GetByIdCliente/{id}")]

            public IActionResult Get(int id)
            {
                try
                {
                    Pedidos? pedido = (from p in _labContexto.Pedidos
                                       where p.clienteId == id
                                       select p).FirstOrDefault();
                    if (pedido == null)
                    {
                        return NotFound();
                    }
                    return Ok(pedido);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Error al procesar la solicitud");
                }
            }
            //Fin del filtro por cliente

            //filtro por motorista
            [HttpGet]
            [Route("GetByIdMoto/{id}")]

            public IActionResult Get(int? id)
            {
                try
                {
                    Pedidos? pedido = (from p in _labContexto.Pedidos
                                       where p.motoristaId == id
                                       select p).FirstOrDefault();
                    if (pedido == null)
                    {
                        return NotFound();
                    }
                    return Ok(pedido);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Error al procesar la solicitud");
                }
            }
            //Fin del filtro por motorista

            //Crear para Pedidos
            [HttpPost]
            [Route("Add")]
            public IActionResult GuardarPedido([FromBody] Pedidos pedido)
            {
                try
                {
                    _labContexto.Pedidos.Add(pedido);
                    _labContexto.SaveChanges();
                    return Ok(pedido);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
            //Fin de crear para pedidos

            //Modificar pedido
            [HttpPut]
            [Route("actualizar/{id}")]
            public IActionResult ActualizarPedido(int id, [FromBody] Pedidos pedidoModificar)
            {
                Pedidos? pedidoActual = (from p in _labContexto.Pedidos
                                         where p.pedidoId == id
                                         select p).FirstOrDefault();
                if (pedidoActual == null) 
                {
                    return NotFound();
                }

                pedidoActual.cantidad = pedidoModificar.cantidad;
                pedidoActual.pedidoId = pedidoModificar.pedidoId;
                pedidoActual.clienteId = pedidoModificar.clienteId;
                pedidoActual.platoId = pedidoModificar.platoId;
                pedidoActual.precio = pedidoModificar.precio;

                _labContexto.Entry(pedidoActual).State = EntityState.Modified;
                _labContexto.SaveChanges();

                return Ok(pedidoModificar);
            }
            //Fin de modificar pedido

            //Eliminar pedido
            [HttpDelete]
            [Route("eliminar/{id}")]
            public IActionResult EliminarPedido(int id)
            {
                Pedidos? pedido = (from p in _labContexto.Pedidos
                                   where p.pedidoId == id
                                   select p).FirstOrDefault();
                if (pedido == null)
                {
                    return NotFound();
                }

                _labContexto.Pedidos.Attach(pedido);
                _labContexto.Pedidos.Remove(pedido);
                _labContexto.SaveChanges();

                return Ok(pedido);
            }
            //Fin de eliminar pedido
        }
    }
}
