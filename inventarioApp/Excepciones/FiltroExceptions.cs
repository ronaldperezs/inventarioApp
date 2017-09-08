using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using Newtonsoft.Json;

namespace inventarioApp.Excepciones
{
    public class FiltroExceptions : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            Dictionary<string, string> errores = new Dictionary<string, string>();
            if (context.Exception is DbEntityValidationException)
            {
                var dbEx = context.Exception as DbEntityValidationException;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errores.Add(validationError.PropertyName, "Atributo es requerido");
                    }
                }
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.Content = new StringContent(JsonConvert.SerializeObject(errores), Encoding.UTF8, "application/json");
                context.Response = response;
            }
            //else
            //{
            //    var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            //    response.Content = new StringContent("Error Inesperado", Encoding.UTF8, "application/json");
            //    context.Response = response;
            //}
        }
    }
}