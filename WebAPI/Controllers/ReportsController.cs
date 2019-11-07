using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using Newtonsoft.Json;
using WebAPI.Models.ViewsModel;

namespace WebAPI.Controllers
{

    [RoutePrefix("api/Reports")]
    [AllowAnonymous]
    public class ReportsController : ApiController
    {
        // private DB_A4DEDC_CTReportEntities db = new DB_A4DEDC_CTReportEntities();

        [Route("Consolidate")]
        public IHttpActionResult GetConsolidate()
        {
            using (var manager = new DB_A4DEDC_CTReportEntities())
            {
                var consolidate = manager.Consolidate.Select(c => new ConsolidateViewModel
                {
                    IdConsolidate = c.IdConsolidate,
                    CodVehicle = c.CodVehicle,
                    NameRoute = c.NameRoute,
                    LapsManual = c.LapsManual,
                    Passenger = c.Passenger,
                    Day = c.Day,
                    Month = c.Month,
                    Year = c.Year
                }).ToList();

                if (consolidate == null)
                    return Content(HttpStatusCode.BadRequest, "Error al obtener los datos de la consulta de Consolidado");
                else
                    return Ok(consolidate);
            }
        }

        [HttpGet]
        [Route("ConsolidatedNumberId/")]
        public IHttpActionResult GetConsolidatedNumberId([FromUri] string numberId)
        {
            using (var manager = new DB_A4DEDC_CTReportEntities())
            {
                if (numberId.Equals(""))
                {
                    return BadRequest("El número de identificación es requerido"); // HTTP 400
                }

                //var consolidate = from 


                //if (consolidate.Count == 0)
                //    return NotFound();

                //if (consolidate == null)
                //    return BadRequest("Error al realizar la consulta");

                //return Ok(consolidate);
                return Ok("Estoy funcionando...");
            }
        }
    }
}
