using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Village_project_teast_19._1._21.Models;

namespace Village_project_teast_19._1._21.Controllers.api
{
    public class SeniorController : ApiController
    {
        static string stringConnection = "Data Source=LAPTOP-HG30JHU1;Initial Catalog=OldPeopleDB;Integrated Security=True;Pooling=False";
        OldPeopleDBDataContext dataContext = new OldPeopleDBDataContext(stringConnection);
        // GET: api/Senior
        public IHttpActionResult Get()
        {
            try
            {
                List<Senior> listOfSeniors = dataContext.Seniors.ToList();
                if (listOfSeniors == null) { return Ok("there is no data to show"); }
                return Ok(new { listOfSeniors });
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Senior/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Senior senior = dataContext.Seniors.First(item => item.Id == id);
                if (senior == null) { return Ok("there is not such as id"); }
                return Ok(new { senior });
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Senior
        public IHttpActionResult Post([FromBody] Senior senior)
        {
            try
            {
                dataContext.Seniors.InsertOnSubmit(senior);
                if (senior == null) { return Ok("there is not data in this item"); }
                dataContext.SubmitChanges();
                return Get();
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Senior/5
        public IHttpActionResult Put(int id, [FromBody] Senior senior)
        {
            try
            {
                Senior choosenSenior = dataContext.Seniors.First(item => item.Id == id);
                if (choosenSenior == null) { return Ok("there is not data in htis item"); }
                choosenSenior.Name = senior.Name;
                choosenSenior.DateBirth = senior.DateBirth;
                choosenSenior.Seniority = senior.Seniority;
                dataContext.SubmitChanges();
                return Get();
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Senior/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Senior senior = dataContext.Seniors.First(item => item.Id == id);
                if (senior == null) { return Ok("there is not data in this item"); }
                dataContext.Seniors.DeleteOnSubmit(senior);
                dataContext.SubmitChanges();
                return Get();
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
