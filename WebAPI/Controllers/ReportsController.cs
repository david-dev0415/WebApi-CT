using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using Newtonsoft.Json;
using WebAPI.Models.ViewsModel;
using System.Data.SqlClient;

namespace WebAPI.Controllers
{

    [RoutePrefix("api/Reports")]
    [AllowAnonymous]
    public class ReportsController : ApiController
    {
        //private DB_A4DEDC_CTReportEntities db = new DB_A4DEDC_CTReportEntities();

        [HttpGet]
        [Route("ConsolidatedNumberId/")]
        public IHttpActionResult GetConsolidatedNumberId([FromUri] string numberId)
        {
            using (var manager = new DB_A4DEDC_CTReportEntities())
            {
                var consolidate = manager.Database.SqlQuery<ConsolidateViewModel>("SPConsolidated @numberId", new SqlParameter("numberId", numberId));
                if (consolidate != null)
                {
                    return Ok(consolidate.ToList());
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "No existe ninguna asociación para el número de identificación ingresado.");
                }
            }
        }

        [HttpGet]
        [Route("GetConsolidatedPerDateVehicle/")]
        public IHttpActionResult GetConsolidatedPerDateVehicle([FromUri] string numberId, string day, string month, string year)
        {
            using (var manager = new DB_A4DEDC_CTReportEntities())
            {
                // Modificar 
                var dayParameter = new SqlParameter("@day", day);
                var monthParameter = new SqlParameter("@month", month);
                var yearParameter = new SqlParameter("@year", year);
                var numberIdParameter = new SqlParameter("@numberId", numberId);

                var consolidate = manager.Database.SqlQuery<ConsolidateViewModel>("SPConsolidatedPerDateVehicle @day, @month, @year, @numberId", dayParameter, monthParameter, yearParameter, numberIdParameter);
                if (consolidate != null)
                {
                    return Ok(consolidate.ToList());
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "No existe ningún registro para la fecha ingresada.");
                }
            }
        }

    }
}
