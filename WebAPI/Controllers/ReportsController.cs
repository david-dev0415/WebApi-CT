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
using System.Globalization;

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

        [HttpPost]
        [Route("GetConsolidatedPerDateVehicle/")]
        public IHttpActionResult GetConsolidatedPerDateVehicle([FromBody] ConsolidateViewModel dateParameters, [FromUri] string numberId)
        {
            using (var manager = new DB_A4DEDC_CTReportEntities())
            {                
                var dayParameter = new SqlParameter("@day", dateParameters.Day);
                var monthParameter = new SqlParameter("@month", dateParameters.Month);
                var yearParameter = new SqlParameter("@year", dateParameters.Year);
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

        [HttpGet]
        [Route("GetDetailedReport/")]
        public IHttpActionResult GetDetailedReport([FromUri] string numberId, string dateTimeStart, string dateTimeFinal)
        {
            using (var manager = new DB_A4DEDC_CTReportEntities())
            {
                if (dateTimeStart.Contains(".") || dateTimeFinal.Contains("."))
                {
                    dateTimeStart = dateTimeStart.Replace(".", "").Replace(" ", "");
                    dateTimeFinal = dateTimeFinal.Replace(".", "").Replace(" ", "");
                }

                var numberIdParameter = new SqlParameter("@numberId", numberId);                
                var dateTimeStartParameter = new SqlParameter("@dateStart", dateTimeStart);
                var dateTimeFinalParameter = new SqlParameter("@dateFinal", dateTimeFinal);
                // manager.Database.ExecuteSqlCommand()
                var detailedReport = manager.Database.SqlQuery<HistoryCollectionViewTestModel>("SPDetailedByVehicle @numberId, @dateStart, @dateFinal", numberIdParameter, dateTimeStartParameter, dateTimeFinalParameter);
                if (detailedReport != null)
                {
                    return Ok(detailedReport.ToList());
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "No existe ningún registro para la fecha ingresada.");
                }
            }
        }
    }
}
