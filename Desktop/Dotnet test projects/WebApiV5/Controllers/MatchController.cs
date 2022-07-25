using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebApiV5.Models;

namespace WebApiV5.Controllers
{
    public class MatchController : ApiController
    {
        public HttpResponseMessage Getmatches()
        {
            MatchClass matchClass = new MatchClass();


            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(
                JsonConvert.SerializeObject(matchClass.getAllMatchStats(), Formatting.Indented),
                Encoding.UTF8,
                "application/json"
                );

            return response;
        }
        public HttpResponseMessage GetTalentMatch(int talentid,int eventid)
        {
            MatchClass matchClass = new MatchClass();


            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(
                JsonConvert.SerializeObject( matchClass.getTalentMatchStats(talentid,eventid), Formatting.Indented),
                Encoding.UTF8,
                "application/json"
                );

            return response;
        }

        public HttpResponseMessage ADDTalentMatchStats(int eventid, int talentid, int fouls, int goalAssit, int goals, int goalsSaved
            , string position, int redcards, string Stated, int tacklesMade, int yellowcards, int timeplayed, int passes
            , int shortOnTarget, int NumsuccessfulPasses)
        {
            MatchClass matchClass = new MatchClass();


            bool result = matchClass.AddMatchStats(eventid, talentid, fouls,goals, goalAssit, goalsSaved, position, redcards, Stated,
                tacklesMade, yellowcards, timeplayed,passes,shortOnTarget,NumsuccessfulPasses);

            HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.OK);
            responseMessage.Content = new StringContent(
                "{\"" + "MatchtDeleted\" : " + result + "}",
                Encoding.UTF8,
                "application/json"
                );

            return responseMessage;
        }

            public HttpResponseMessage GetALLTalentMatches(int Talentid)
        {

            MatchClass matchClass = new MatchClass();
 

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(
                JsonConvert.SerializeObject(matchClass.getAllTalentMatchStats(Talentid), Formatting.Indented),
                Encoding.UTF8,
                "application/json"
                );

            return response;
        }


        public HttpResponseMessage GetDeleteSport(int matchid)
        {


            MatchClass matchClass = new MatchClass();


            bool result = matchClass.DeleteMatchStats(matchid);

            HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.OK);
            responseMessage.Content = new StringContent(
                "{\"" + "MatchtDeleted\" : " + result + "}",
                Encoding.UTF8,
                "application/json"
                );

            return responseMessage;
        }

    }
}
