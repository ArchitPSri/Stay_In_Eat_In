using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SIEI_Entites;
using SIEI_HostelDAO;


namespace Stay_In_Eat_In.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TiffinController : Controller
    {
        [HttpGet("[action]")]
        public void GetTiffinList()
        {
            
        }

        [HttpPost("[action]")]
        public void SaveTiffinDetails([FromBody] HostelDetails hostelDetails)
        {
            try
            {
                //if (hostelDetails != null)
                //{
                //    HostelDAO hostelDAO = new HostelDAO();
                //}
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Unsuccessful Query Excution -> " + e);
            }
        }


    }
}
