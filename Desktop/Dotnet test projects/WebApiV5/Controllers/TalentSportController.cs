using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebApiV5.DatabaseLinks;
using WebApiV5.Models;

namespace WebApiV5.Controllers
{
    public class TalentSportController : ApiController
    {
        // GET: api/TalentSport
        public HttpResponseMessage GetTalentSport(string position,int sportid)
        {
            TalentSportClass talenSporttClass = new TalentSportClass();

            // return users;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(
                JsonConvert.SerializeObject(talenSporttClass.getTalentByPosition(position,sportid), Formatting.Indented),
                Encoding.UTF8,
                "application/json"
                );

            return response;
        }
        public HttpResponseMessage GetTalentSports()
        {
            TalentSportClass talenSporttClass = new TalentSportClass();

            // return users;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(
                JsonConvert.SerializeObject(talenSporttClass.getAllTalents(), Formatting.Indented),
                Encoding.UTF8,
                "application/json"
                );

            return response;
        }

        public HttpResponseMessage PostTalentSport(TalentSport userobj)
        {
            // Catch the properties

            TalentSportClass talentSportClass = new TalentSportClass();


            bool result = talentSportClass.addTalentSport(userobj.SportID, userobj.TalentID, userobj.TalentPosition);

          
            // examle { "Registered" : 1 }
            HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.OK);
            responseMessage.Content = new StringContent(
                "{\"" + "talentSportAddded\" : " + result + "}",
                Encoding.UTF8,
                "application/json"
                );

            return responseMessage;
        }


        public HttpResponseMessage DeleteTalent(int sportid, int talentid, string talentPosition)
        {
            // Catch the properties

            TalentSportClass talentSportClass = new TalentSportClass();

            bool result = talentSportClass.DeleteTalentSport(sportid, talentid, talentPosition);
            HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.OK);
            responseMessage.Content = new StringContent(
                "{\"" + "TalentSportDeleted\" : " + result + "}",
                Encoding.UTF8,
                "application/json"
                );

            return responseMessage;
        }

    }
}
