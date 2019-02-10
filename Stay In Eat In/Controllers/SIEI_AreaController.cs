using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SIEI_AreaDAO;
using SIEI_AreaEntites;
using System.Net.Http;

namespace Stay_In_Eat_In.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AreaController : Controller
    {
        [HttpPost("[action]")]
        public List<AreaList> GetAreaList([FromBody] Area area)
        {
            List<AreaList> areaLists = new List<AreaList>();
            try
            {
                if (area != null)
                {
                    AreaDAO areaDAO = new AreaDAO();
                    areaLists = areaDAO.GetAreaList(area.areaOf);
                    return areaLists;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("areaOf is null");
                    return null;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Unsuccessful Query Excution -> " + e);
                throw e;
            }
        }

        [HttpPost("[action]")]
        public void SaveArea()
        {

        }


    }
}
