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
    public class VideoController : ApiController
    {
        // GET: api/Video

        public HttpResponseMessage GetVideo()
        {
            VideoClass videoClass = new VideoClass();

            // return users;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(
                JsonConvert.SerializeObject(videoClass.getAllVideo(), Formatting.Indented),
                Encoding.UTF8,
                "application/json"
                );

            return response;
        }
        public HttpResponseMessage GetVideo(int id)
        {
            VideoClass videoClass = new VideoClass();


            // return users;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(
                JsonConvert.SerializeObject(videoClass.getAllUserVideo(id), Formatting.Indented),
                Encoding.UTF8,
                "application/json"
                );

            return response;
        }

        public HttpResponseMessage PostVideo(Video userobj)
        {
            // Catch the properties

            VideoClass videoClass = new VideoClass();

            bool result = videoClass.AddVideo(userobj.VideoName,userobj.VideoDescption,userobj.UserId,userobj.SportID
                ,userobj.VideoFIleName);

            // examle { "Registered" : 1 }
            HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.OK);
            responseMessage.Content = new StringContent(
                "{\"" + "VideoAdded\" : " + result + "}",
                Encoding.UTF8,
                "application/json"
                );

            return responseMessage;
        }


        public HttpResponseMessage DeleteVideo(int id)
        {
            // Catch the properties

            VideoClass videoClass = new VideoClass();

            bool result = videoClass.DeleteByID(id);
            HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.OK);
            responseMessage.Content = new StringContent(
                "{\"" + "VideoDeleted\" : " + result + "}",
                Encoding.UTF8,
                "application/json"
                );

            return responseMessage;
        }



    }
}
