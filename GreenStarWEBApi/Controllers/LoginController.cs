using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;
using System.Web.Http.Cors;
using WebAPI.Service;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {

        // GET api/Login
        public HttpResponseMessage GetLogins()
        {
            DataTable dsResult = null;
            dsResult = LoginService.GetLogins();

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }



        // GET api/Login
        public HttpResponseMessage GetLoginsById(int Id)
        {
            DataTable dsResult = null;
            dsResult = LoginService.GetLoginsById(Id);

            if (dsResult == null || dsResult.Rows.Count < 1)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dsResult);
        }


        // PUT api/Login/5
        public IHttpActionResult PutLogin(int Id, Login objLogin)
        {
            LoginService.PutLogin(Id, objLogin);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Login
        [ResponseType(typeof(Login))]
        public IHttpActionResult PostLogin(Login objLogin)
        {
            LoginService.PostLogin(objLogin);
            return CreatedAtRoute("DefaultApi", new { id = objLogin.Id }, objLogin);
        }

        // DELETE api/Login/5
        [ResponseType(typeof(Login))]
        public IHttpActionResult DeleteLogin(int Id)
        {
            DataTable dsResult = null;
            dsResult = LoginService.GetLogins();
            DataRow retainDataRow=null;
            foreach (DataRow dr in dsResult.AsEnumerable())
            {
                if (Convert.ToInt32(dr[0]) == Id)
                {
                    retainDataRow = dr;
                }
            }

            LoginService.DeleteLogin(Id);
            return Ok(retainDataRow);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
