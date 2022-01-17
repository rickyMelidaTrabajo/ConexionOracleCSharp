using ConexionOracle.Data;
using ConexionOracle.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ConexionOracle.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            string conString = "DATA SOURCE=localhost/xe;" + "PERSIST SECURITY INFO=True;USER ID=system; password=12345; Pooling = False;";

            GetData data = new GetData();
            data.GetUsuarios(conString);
            return Ok("ss");
        }

        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            return Ok(id);
        }


        



        
        
    }
}
