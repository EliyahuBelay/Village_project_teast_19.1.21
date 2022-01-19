using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Village_project_teast_19._1._21.Models;

namespace Village_project_teast_19._1._21.Controllers.api
{
    public class CitizenController : ApiController
    {
        VillageDB dbContex = new VillageDB();
        // GET: api/Citizen
        public IHttpActionResult Get()
        {
            try
            {
                List<Citizen> listOfCitizens = dbContex.Citizens.ToList();
                if (listOfCitizens == null) { return Ok("there is no data to show"); }
                return Ok(new{listOfCitizens});
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

        // GET: api/Citizen/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                Citizen citizen = await dbContex.Citizens.FindAsync(id);
                if (citizen == null) { return Ok("there is not such as id"); }
                return Ok(new { citizen });
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

        // POST: api/Citizen
        public async Task<IHttpActionResult> Post([FromBody]Citizen citizen)
        {
            try
            {
                dbContex.Citizens.Add(citizen);
                if (citizen == null) { return Ok("there is not data in this item"); }
                await dbContex.SaveChangesAsync();
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

        // PUT: api/Citizen/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]Citizen citizenToUpdate)
        {
            try
            {
                Citizen choosenCitizen = await dbContex.Citizens.FindAsync(id);
                if(choosenCitizen == null ) { return Ok("there is not data in htis item");}
                choosenCitizen.FathrName = citizenToUpdate.FathrName;
                choosenCitizen.Gender = citizenToUpdate.Gender;
                choosenCitizen.IsBornInTheVillage = citizenToUpdate.IsBornInTheVillage;
                choosenCitizen.DateBith = citizenToUpdate.DateBith;
                await dbContex.SaveChangesAsync();
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

        // DELETE: api/Citizen/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                Citizen citizen = await dbContex.Citizens.FindAsync(id);
                if (citizen == null) { return Ok("there is not data in this item"); }
                dbContex.Citizens.Remove(citizen);
                await dbContex.SaveChangesAsync();
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
