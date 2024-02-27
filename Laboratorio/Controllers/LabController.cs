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

            public IActionResult GetCliente(int id)
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

            public IActionResult GetMoto(int id)
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



            //filtro cuando el precio de platos sea menor de un valor dado
            [HttpGet]
            [Route("GetByValor/{valor}")]

            public IActionResult GetValor(int valor)
            {
                try
                {
                    Platos? plato = (from pl in _labContexto.Platos
                                     where pl.precio < valor
                                     select pl).FirstOrDefault();
                    if (plato == null)
                    {
                        return NotFound();
                    }
                    return Ok(plato);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Error al procesar la solicitud");
                }
            }
            //Fin del filtro cuando el precio de platos sea menor de un valor dado

            //Crear para Platos
            [HttpPost]
            [Route("Add")]
            public IActionResult GuardarPlato([FromBody] Platos plato)
            {
                try
                {
                    _labContexto.Platos.Add(plato);
                    _labContexto.SaveChanges();
                    return Ok(plato);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
            //Fin de crear para platos

            //Modificar platos
            [HttpPut]
            [Route("actualizarPlatos/{id}")]
            public IActionResult ActualizarPlatos(int id, [FromBody] Platos platoModificar)
            {
                Platos? platoActual = (from pl in _labContexto.Platos
                                       where pl.platoId == id
                                       select pl).FirstOrDefault();
                if (platoActual == null)
                {
                    return NotFound();
                }

                platoActual.platoId = platoModificar.platoId;
                platoActual.nombrePlato = platoModificar.nombrePlato;
                platoActual.precio = platoModificar.precio;


                _labContexto.Entry(platoActual).State = EntityState.Modified;
                _labContexto.SaveChanges();

                return Ok(platoModificar);
            }
            //Fin de modificar platos

            //Eliminar platos
            [HttpDelete]
            [Route("eliminarPlatos/{id}")]
            public IActionResult EliminarPlatos(int id)
            {
                Platos? plato = (from pl in _labContexto.Platos
                                 where pl.platoId == id
                                 select pl).FirstOrDefault();
                if (plato == null)
                {
                    return NotFound();
                }

                _labContexto.Platos.Attach(plato);
                _labContexto.Platos.Remove(plato);
                _labContexto.SaveChanges();

                return Ok(plato);
            }
            //Fin de eliminar platos


            //filtro por el nombre del motorista
            [HttpGet]
            [Route("Find/{nombre}")]

            public IActionResult FindByName(string nombre)
            {
                try
                {
                    Motoristas? moto = (from m in _labContexto.Motoristas
                                        where m.nombreMotorista.Contains(nombre)
                                        select m).FirstOrDefault();
                    if (moto == null)
                    {
                        return NotFound();
                    }
                    return Ok(moto);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Error al procesar la solicitud");
                }
            }
            //Fin del filtro por el nombre del motorista

            //Crear para Motorista
            [HttpPost]
            [Route("Add")]
            public IActionResult GuardarMotorista([FromBody] Motoristas moto)
            {
                try
                {
                    _labContexto.Motoristas.Add(moto);
                    _labContexto.SaveChanges();
                    return Ok(moto);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
            //Fin de crear para Motorista

            //Modificar Motoristas
            [HttpPut]
            [Route("actualizarMotoristas/{id}")]
            public IActionResult ActualizarMotoristas(int id, [FromBody] Motoristas motoModificar)
            {
                Motoristas? motoActual = (from m in _labContexto.Motoristas
                                          where m.motoristaId == id
                                          select m).FirstOrDefault();
                if (motoActual == null)
                {
                    return NotFound();
                }

                motoActual.motoristaId = motoModificar.motoristaId;
                motoActual.nombreMotorista = motoModificar.nombreMotorista;

                _labContexto.Entry(motoActual).State = EntityState.Modified;
                _labContexto.SaveChanges();

                return Ok(motoModificar);
            }
            //Fin de modificar platos

            //Eliminar Motoristas
            [HttpDelete]
            [Route("eliminarMotoristas/{id}")]
            public IActionResult EliminarMotoristas(int id)
            {
                Motoristas? moto = (from m in _labContexto.Motoristas
                                    where m.motoristaId == id
                                    select m).FirstOrDefault();
                if (moto == null)
                {
                    return NotFound();
                }

                _labContexto.Motoristas.Attach(moto);
                _labContexto.Motoristas.Remove(moto);
                _labContexto.SaveChanges();

                return Ok(moto);
            }
            //Fin de eliminar platos
        }
    }
}
