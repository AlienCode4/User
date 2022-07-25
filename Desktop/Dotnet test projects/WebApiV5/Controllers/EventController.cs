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
    public class EventController : ApiController
    {

        public HttpResponseMessage GetEvents()
        {
            EventClass eventtClass = new EventClass();


            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(
                JsonConvert.SerializeObject(eventtClass.getAllEvenFromToday(), Formatting.Indented),
                Encoding.UTF8,
                "application/json"
                );

            return response;
        }
        public HttpResponseMessage GetSport(string Eventname)
        {
            EventClass eventtClass = new EventClass();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(
                JsonConvert.SerializeObject(eventtClass.getAllEventsByName(Eventname), Formatting.Indented),
                Encoding.UTF8,
                "application/json"
                );

            return response;
        }

        public HttpResponseMessage PostSport(string Addsportname)
        {

            SportClass sportClass = new SportClass();



            bool result = sportClass.addSport(Addsportname);

            HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.OK);
            responseMessage.Content = new StringContent(
                "{\"" + "SportAddded\" : " + result + "}",
                Encoding.UTF8,
                "application/json"
                );

            return responseMessage;
        }


        public HttpResponseMessage GetDeleteSport(int DeleteSportid)
        {


            SportClass sportClass = new SportClass();

            bool result = sportClass.DeleteSport(DeleteSportid);
            HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.OK);
            responseMessage.Content = new StringContent(
                "{\"" + "SportDeleted\" : " + result + "}",
                Encoding.UTF8,
                "application/json"
                );

            return responseMessage;
        }
    }
}
