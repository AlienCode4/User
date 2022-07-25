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
    public class TalentController : ApiController
    {
        // GET: api/User


        public HttpResponseMessage GetTalents()
        {
            TalentClass talentClass = new TalentClass();

             HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(
                JsonConvert.SerializeObject(talentClass.GetAllTalents(), Formatting.Indented),
                Encoding.UTF8,
                "application/json"
                );

            return response;
        }
        public HttpResponseMessage GetTalent(int talentid)
        {
            TalentClass talentClass = new TalentClass();

             HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(
                JsonConvert.SerializeObject(talentClass.GetTalentByID(talentid), Formatting.Indented),
                Encoding.UTF8,
                "application/json"
                );

            return response;
        }

        public HttpResponseMessage PostTalent(Talent userobj,string email)
        {
            // Catch the properties
           
            TalentClass talentClass = new TalentClass();
 
            

            bool result = talentClass.AddTalent(email, userobj.TalentName, userobj.TalentName,
                userobj.TalentDOB, userobj.TalentGender, userobj.TalentHeight);

            // examle { "Registered" : 1 }
            HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.OK);
            responseMessage.Content = new StringContent(
                "{\"" + "talentAddded\" : " + result + "}",
                Encoding.UTF8,
                "application/json"
                );

            return responseMessage;
        }


        public HttpResponseMessage DeleteTalent(int Deleteid)
        {
            // Catch the properties

            TalentClass talentClass = new TalentClass();

            bool result = talentClass.DeleteByID(Deleteid);
            HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.OK);
            responseMessage.Content = new StringContent(
                "{\"" + "TalentDeleted\" : " + result + "}",
                Encoding.UTF8,
                "application/json"
                );

            return responseMessage;
        }
        public HttpResponseMessage PercentageTalent(int sizo, int sizoa)
        {
            // Catch the properties

            TalentClass talentClass = new TalentClass();

             HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.OK);
            responseMessage.Content = new StringContent(
                "{\"" + "TalentDeleted\" : " + talentClass.ProfileCompletePercentageTalent(sizo) + "}",
                Encoding.UTF8,
                "application/json"
                );

            return responseMessage;
        }



    }
}
