using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MiniMarketPresentacion.Models;
using System.Threading.Tasks;

using RestSharp;

namespace MiniMarketPresentacion.Controllers
{
    public class ProductoController : Controller
    {

        RestClient client;
        // GET: Producto
        public async Task<ActionResult> Index()
        {

            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync("https://localhost:44391/api/MiniMarket");

            var listaProducto = JsonConvert.DeserializeObject<List<Producto>>(json);  //  .DeserializeObject<List<Producto>>(json);

            return View(listaProducto);
        }

        // GET: Producto/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync("https://localhost:44391/api/MiniMarket/"+id);

            var producto = JsonConvert.DeserializeObject<Producto>(json);  //  .DeserializeObject<List<Producto>>(json);

            return View(producto);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
        
            string descripcion = collection["descripcion"];
            string medidas = collection["medidas"];
            string  cantidad = collection["cantidad"];
            string precio = collection["precio"];

                Producto producto = new Producto();

                producto.id = 1;
                producto.descripcion = descripcion;
                producto.medidas = medidas;
                producto.cantidad = Convert.ToInt32(cantidad);
                producto.precio = Convert.ToDecimal(precio);

                string parametroJson = JsonConvert.SerializeObject(producto);

                

                var client = new RestClient();
                var request = new RestRequest("https://localhost:44391/api/MiniMarket", Method.POST, DataFormat.Json);

                request.AddParameter("application/json", JsonConvert.SerializeObject(parametroJson), ParameterType.RequestBody);

                var response = client.Execute(request);

                var content = response.Content;

                var resultado = JsonConvert.DeserializeObject<string>(content);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync("https://localhost:44391/api/MiniMarket/" + id);

            var producto = JsonConvert.DeserializeObject<Producto>(json);  

            return View(producto);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                string descripcion = collection["descripcion"];
                string medidas = collection["medidas"];
                string cantidad = collection["cantidad"];
                string precio = collection["precio"];

                Producto producto = new Producto();

                producto.id = id;
                producto.descripcion = descripcion;
                producto.medidas = medidas;
                producto.cantidad = Convert.ToInt32(cantidad);
                producto.precio = Convert.ToDecimal(precio);

                string parametroJson = JsonConvert.SerializeObject(producto);



                var client = new RestClient();
                var request = new RestRequest("https://localhost:44391/api/MiniMarket/"+ id, Method.POST, DataFormat.Json);

                request.AddParameter("application/json", JsonConvert.SerializeObject(parametroJson), ParameterType.RequestBody);

                var response = client.Execute(request);

                var content = response.Content;

                var resultado = JsonConvert.DeserializeObject<string>(content);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    
    }
}
