using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Mvc;
using WebApiV5.DatabaseLinks;
using WebApiV5.Models;
using System.Web.Http;

namespace WebApiV5.Controllers  
{
    //[System.Web.Http.Route("api/controller")]

    public class UserController : ApiController
    {
        // GET: api/User

        public UserController()
        {

        }


        public HttpResponseMessage GetUser(int id)
        {
            UserClass userClass = new UserClass();



            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(
                JsonConvert.SerializeObject(userClass.getUserFromID(id), Formatting.Indented),
                Encoding.UTF8,
                "application/json"
                );

            return response;
        }
        public HttpResponseMessage GetUsers()
        {
            UserClass userClass = new UserClass();

            // return users;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(
                JsonConvert.SerializeObject(userClass.getAllusers(), Formatting.Indented),
                Encoding.UTF8,
                "application/json"
                );

            return response;
        }

        public HttpResponseMessage PostUser(User userobj)
        {
            // Catch the properties
            string email = userobj.UserEmail;


            UserClass userClass = new UserClass();


            // make sure the email is an email
            if (!email.Contains("@"))
            {
                HttpResponseMessage responseErrorMessage = Request.CreateResponse(HttpStatusCode.OK);
                responseErrorMessage.Content = new StringContent(
                    "{\"" + "UserRegistered\" : " + -1 + "}",
                    Encoding.UTF8,
                    "application/json"
                    );

                return responseErrorMessage;
            }

            bool result = userClass.AddUser(userobj.UserEmail, userobj.UserPassword,
                userobj.location, userobj.UserType, userobj.Country,
                userobj.ContactNumber, userobj.Picture);

            // examle { "Registered" : 1 }
            HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.OK);
            responseMessage.Content = new StringContent(
                "{\"" + "UserRegistered\" : " + result + "}",
                Encoding.UTF8,
                "application/json"
                );

            return responseMessage;
        }




        public HttpResponseMessage GetUserLogs(int MyLogs)
        {
            UserClass userClass = new UserClass();


            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(
                JsonConvert.SerializeObject(userClass.getAllUserLogs(MyLogs), Formatting.Indented),
                Encoding.UTF8,
                "application/json"
                );

            return response;
        }

        public HttpResponseMessage GetUserID(string emailToID)
        {
            UserClass userClass = new UserClass();




            HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.OK);
            responseMessage.Content = new StringContent(
                "{\"" + "UserID\" : " + userClass.getID(emailToID) + "}",
                Encoding.UTF8,
                "application/json"
                );

            return responseMessage;
        }

        public HttpResponseMessage GetUsersByType(string type)
        {
            UserClass userClass = new UserClass();


            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(
                JsonConvert.SerializeObject(userClass.getAllUsersByType(type), Formatting.Indented),
                Encoding.UTF8,
                "application/json"
                );

            return response;
        }

        public HttpResponseMessage GetLogin(string email, string password)
        {
            UserClass userClass = new UserClass();




            HttpResponseMessage responseErrorMessage = Request.CreateResponse(HttpStatusCode.OK);
            responseErrorMessage.Content = new StringContent(
                "{\"" + "LoginStatus\" : " + userClass.Login(email, password) + "}",
                Encoding.UTF8,
                "application/json"
                );


            return responseErrorMessage;
        }

        public HttpResponseMessage logUser(string emailz)
        {
            UserClass userClass = new UserClass();
            int userid = userClass.getID(emailz);



            HttpResponseMessage responseErrorMessage = Request.CreateResponse(HttpStatusCode.OK);
            responseErrorMessage.Content = new StringContent(
                "{\"" + "log\" : " + userClass.logUser(userid) + "}",
                Encoding.UTF8,
                "application/json"
                );


            return responseErrorMessage;
        }


        public HttpResponseMessage GetCheckForEmail(string Checkemail)
        {
            UserClass userClass = new UserClass();




            HttpResponseMessage responseErrorMessage = Request.CreateResponse(HttpStatusCode.OK);
            responseErrorMessage.Content = new StringContent(
                "{\"" + "EmailStatus\" : " + userClass.CheckForEmail(Checkemail) + "}",
                Encoding.UTF8,
                "application/json"
                );


            return responseErrorMessage;
        }
        public HttpResponseMessage GetUserFromEmail(string email)
        {
            UserClass userClass = new UserClass();



            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(
                JsonConvert.SerializeObject(userClass.getUserFromEmail(email), Formatting.Indented),
                Encoding.UTF8,
                "application/json"
                );

            return response;
        }

       

        public HttpResponseMessage GetImagGet(int imaid)
        {
            UserClass userClass = new UserClass();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);


            string img = "~Images/" + userClass.getImageNAme(imaid);
            img = System.Web.Hosting.HostingEnvironment.MapPath(img);
            var ext = System.IO.Path.GetExtension(img);

            var content = System.IO.File.ReadAllBytes(img);
            
            System.IO.MemoryStream ms = new System.IO.MemoryStream(content);

            response.Content = new StreamContent(ms);

            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("Images/"+ext);
            return response;
        }


        public HttpResponseMessage AllLog(int logID, string zop, int df)
        {


            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            UserClass userClass = new UserClass();


            response.Content = new StringContent(
               JsonConvert.SerializeObject(userClass.getAllLog(), Formatting.Indented),
               Encoding.UTF8,
               "application/json"
               );




            return response;
        }
        


    }
}
