using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebApi.Data;
using model.entity;

namespace WebApi.Controllers
{
    public class ProductosController : Controller
    {
        // GET api/<controller>
        public ActionResult Inicio()
        {
            List<Productos> lista = ProductosData.Listar();
            return View(lista);
        }

        ProductosData objweb = new ProductosData();

   
        public List<Productos> Get(int id)
        {
            return ProductosData.Obtener(id);
        }


        public ActionResult Buscar(int id)
        {
            List<Productos> lista = ProductosData.Obtener(id);
            return View(lista);
            //return View(lista);
        }

        public ActionResult Create()
        {
            //mensajeInicio();

            return View();
        }

        public ActionResult Editar(int id)
        {
            //mensajeInicio();

            return View(id);
        }

        // POST api/<controller>
        public bool Post([FromBody]Productos oCliente)
        {
            return ProductosData.Registrar(oCliente);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Productos oCliente)
        {
            //ProductosData.Modificar(oCliente);
            return  ProductosData.Modificar(oCliente);
        }

        public ActionResult Modificar()
        {
            List<Productos> lista = ProductosData.Listar();
            return View(lista);
        }

        public ActionResult Acualizar(int id)
        {
            List<Productos> lista = ProductosData.Obtener(id);
            return View(lista);
        }


        // DELETE api/<controller>/5
        public ActionResult Delete(int id)
        {
            var  Eliminars = ProductosData.Eliminar(id);
            return View("Eliminar");
        }
    }
}