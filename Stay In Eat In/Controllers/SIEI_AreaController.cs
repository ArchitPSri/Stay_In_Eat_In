using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SIEI_AreaDAO;
using SIEI_AreaEntites;

namespace Stay_In_Eat_In.Controllers
{
    [Route("api/[controller]")]
    public class SIEI_AreaController : Controller
    {
        [HttpPost("[action]")]
        public List<AreaList> GetAreaList([FromBody] string areaOf)
        {
            List<AreaList> areaLists = new List<AreaList>();
            try
            {
                if (areaOf != null)
                {
                    AreaDAO areaDAO = new AreaDAO();
                    areaLists = areaDAO.GetAreaList(areaOf);
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
