using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiArandaSoftware.Application;
using WebApiArandaSoftware.Entities;
using WebApiArandaSoftware.WebApi.DTOs;

namespace WebApiArandaSoftware.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private IApplication<Producto> _producto;
        public ProductosController(IApplication<Producto> producto)
        {
            _producto = producto;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_producto.GetAll());
        }


        [HttpGet("GetById/{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_producto.GetById(Id));
        }

        [HttpPut]
        public IActionResult Put(Producto Producto)
        {
            var producto = _producto.GetById(Producto.id);
            if (producto != null)
            {
                producto.Nombre = Producto.Nombre;
                producto.Descripcion = Producto.Descripcion;
                producto.Imagen = Producto.Imagen;

                return Ok(_producto.Save(producto));
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult Save(ProductoDTO dto)
        {
            var obj = new Producto()
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Imagen = dto.Imagen
            };
            return Ok(_producto.Save(obj));
        }

        [HttpDelete]
        public void Delete(int Id)
        {
            _producto.Delete(Id);
        }
    }
}

