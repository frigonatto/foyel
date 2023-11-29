using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using foyel.Models;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace foyel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticuloController : ControllerBase
    {
        private readonly ILogger<ArticuloController> _logger;

        public ArticuloController(ILogger<ArticuloController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public void Post([FromBody] Articulo nuevoArticulo)
        {
            Random a = new Random();
            int codigo = a.Next();

            string renglon;

            renglon = codigo.ToString() + "|";
            renglon += nuevoArticulo.descripcion + "|";
            renglon += nuevoArticulo.precioUnitario.ToString("#.##") + "|";
            renglon += nuevoArticulo.modelo + "|";

            StreamWriter sw = new StreamWriter("f:\\temp\\foyel_articulo_" + codigo.ToString());
            sw.WriteLine(renglon);
            sw.Close();
        }

        [HttpGet]
        public Articulo Get()
        {
            Articulo a = new Articulo();
            a.codigo = 1390;
            a.descripcion = "PEN DRIVE 8 GB USB 2.0/3.0 KINGSTON";
            a.precioUnitario = 5.65m;
            a.modelo = "*Ninguno";

            return  a;
        }
    }
}
