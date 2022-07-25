using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiV5.DatabaseLinks;

namespace WebApiV5.Models
{
    public class UserClass
    {

        UsersDataContext db = new UsersDataContext();
        LogAllUsersDataContext db2 = new LogAllUsersDataContext();
        AllUserTypesDataContext db3 = new AllUserTypesDataContext();

        public UserClass()
        {

        }
        public int getID(string email)
        {
            var userR = (from u in db.Users where u.UserEmail.Equals(email) select u).FirstOrDefault();
            
            if(userR != null)
            {
                return userR.UserId;
            }
            return -1;
        }


        public string getUserType(string email)
        {
            var userR = (from u in db.Users where u.UserEmail.Equals(email) select u).FirstOrDefault();

            if (userR != null)
            {
                return userR.UserType;
            }
            return null;
        }

        public string getEmail(int id)
        {
            var userR = (from u in db.Users where u.UserId.Equals(id) select u).FirstOrDefault();
           

            if (userR != null)
            {
                return userR.UserEmail;
            }
            return null;
        }
        public bool AddUser(string email, string password, string Location, string usertyrpe, string country, string phoneNumber,
            string picture)
        {

            bool check = CheckForEmail(email);

            if (check == false)
            {
                User newUser = new User()
                {
                    UserEmail = email,
                    UserPassword = password,
                    Country = country,
                    location = Location,
                    UserType = usertyrpe,
                    ContactNumber = phoneNumber,
                    Picture = picture,
                    DateRegistered = DateTime.Today,
                    isActive = "true",
                    IsVerified = "false",
                    User_warnings = 0
                };


                db.Users.InsertOnSubmit(newUser);
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception m)
                {
                    m.GetBaseException();

                    return false;
                }


            }
            return false;


        }


        public bool UpDataeUser(string email, string password, string Location, string country, string phoneNumber,
          string picture)
        {
            var uset = (from u in db.Users where u.UserEmail.Equals(email) && u.isActive.Equals("true")
                        select u).FirstOrDefault();

           

            if (uset !=null)
            {

                uset.UserPassword = password;
                uset.Country = country;
                uset.location = Location;
                uset.ContactNumber = phoneNumber;
                uset.Picture = picture;
                
 
                 try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception m)
                {
                    m.GetBaseException();

                    return false;
                }


            }
            return false;


        }

        public bool CreateUser(string email, string password, string usertyrpe  )
        {

            bool check = CheckForEmail(email);

            if (check == false)
            {
                User newUser = new User()
                {
                    UserEmail = email,
                    UserPassword = password,
                    Country = "",
                    location = "",
                    UserType = usertyrpe,
                    ContactNumber = "",
                    Picture = "",
                    DateRegistered = DateTime.Today,
                    isActive = "true",
                    IsVerified = "false",
                    User_warnings = 0
                };


                db.Users.InsertOnSubmit(newUser);
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception m)
                {
                    m.GetBaseException();

                    return false;
                }


            }
            return false;

        }

        public List<User> getAllUsersByType(string type)
        {
            var allu = new List<User>();

            dynamic userz = (from u in db.Users where u.UserType.Equals(type) select u);

            if (userz != null)
            {
                foreach (User ct in userz)
                {

                    var new_user = new User()
                    {
                        UserId = ct.UserId,
                        UserEmail = ct.UserEmail,
                        UserPassword = ct.UserPassword,
                        UserType = ct.UserType,
                        location = ct.location,
                        ContactNumber = ct.ContactNumber,
                        User_warnings = ct.User_warnings,
                        DateRegistered = ct.DateRegistered,
                        IsVerified = ct.IsVerified,
                        isActive = ct.isActive,
                        Picture = ct.Picture,
                        Country = ct.Country

                    };
                    allu.Add(new_user);
                }

                return allu;
            }

            return null;
        }

        public List<User> getAllusers()
        {
            var allu = new List<User>();

            dynamic userz = (from u in db.Users where u.isActive.Equals("true") select u);

            if (userz != null)
            {
                foreach (User ct in userz)
                {

                    var new_user = new User()
                    {
                        UserId = ct.UserId,
                        UserEmail = ct.UserEmail,
                        UserPassword = ct.UserPassword,
                        UserType = ct.UserType,
                        location = ct.location,
                        ContactNumber = ct.ContactNumber,
                        User_warnings = ct.User_warnings,
                        DateRegistered = ct.DateRegistered,
                        IsVerified = ct.IsVerified,
                        isActive = ct.isActive,
                        Picture = ct.Picture,
                        Country = ct.Country

                    };
                    allu.Add(new_user);
                }

                return allu;
            }
            return null;
        }

        public User getUserFromID(int id)
        {
            var userR = (from u in db.Users where u.UserId.Equals(id) && 
                         u.isActive.Equals("true") select u).FirstOrDefault();

            if (userR != null)
            {
                var newt = new User()
                {
                    UserId = userR.UserId,
                    UserEmail = userR.UserEmail,
                    UserPassword = userR.UserPassword,
                    UserType = userR.UserType,
                    location = userR.location,
                    ContactNumber = userR.ContactNumber,
                    User_warnings = userR.User_warnings,
                    DateRegistered = userR.DateRegistered,
                    IsVerified = userR.IsVerified,
                    isActive = userR.isActive,
                    Picture = userR.Picture,
                    Country = userR.Country


                };
                return newt;

            }

            return null;
        }
        public User getUserFromEmail(string email)
        {
            var userR = (from u in db.Users where u.UserEmail.Equals(email) &&
                         u.isActive.Equals("true")select u).FirstOrDefault();

            if (userR != null)
            {
                var newt = new User()
                {
                    UserId = userR.UserId,
                    UserEmail = userR.UserEmail,
                    UserPassword = userR.UserPassword,
                    UserType = userR.UserType,
                    location = userR.location,
                    ContactNumber = userR.ContactNumber,
                    User_warnings = userR.User_warnings,
                    DateRegistered = userR.DateRegistered,
                    IsVerified = userR.IsVerified,
                    isActive = userR.isActive,
                    Picture = userR.Picture,
                    Country = userR.Country


                };
                return newt;

            }

            return null;

        }
        public bool CheckForEmail(string email)
        {
            var user = (from u in db.Users where u.UserEmail.Equals(email) select u).FirstOrDefault();

            if (user != null)
            {
                return true;
            }
            else
                return false;
        }

        public List<LogAllUser> getAllLog()
        {
            dynamic logcall = from u in db2.LogAllUsers select u;

            var allogs = new List<LogAllUser>();


            if (logcall != null)
            {
                foreach (LogAllUser usl in logcall)
                {
                    LogAllUser usTemp = new LogAllUser()
                    {
                        Logdate = usl.Logdate,
                        LogID = usl.LogID,
                        UserID = usl.UserID,
                        UserType = usl.UserType
                    };
                    allogs.Add(usTemp);
                }
                return allogs;
            }
            return null;

        }
        public List<LogAllUser> getAllUserLogs(int id)
        {
            dynamic logcall = from u in db2.LogAllUsers where u.UserID.Equals(id) select u;

            var allogs = new List<LogAllUser>();


            if (logcall != null)
            {
                foreach (LogAllUser usl in logcall)
                {
                    LogAllUser usTemp = new LogAllUser()
                    {
                        Logdate = usl.Logdate,
                        LogID = usl.LogID,
                        UserID = usl.UserID,
                        UserType = usl.UserType
                    };
                    allogs.Add(usTemp);
                }
                return allogs;
            }
            return null;
        }

        public bool logUser(int id)
        {

            var getType = getUserFromID(id);
            string type = getType.UserType;

            var NewUser = new LogAllUser()
            {
                UserID = id,
                UserType = type,
                Logdate = DateTime.Today
            };

            db2.LogAllUsers.InsertOnSubmit(NewUser);
            try
            {
                db2.SubmitChanges();
                return true;
            }
            catch (Exception m)
            {
                m.GetBaseException();

                return false;
            }

        }

        public bool Login(string email, string password)
        {
            var userR = (from u in db.Users where u.UserEmail.Equals(email) && u.isActive.Equals("true") 
                         && u.UserPassword.Equals(password)
                         select u).FirstOrDefault();

            if (userR != null)
            {
                return true;
            }
            return false;   
        }

        public int ProfileCompletePercentageUser(string email)
        {
            var userR = (from u in db.Users
                         where u.UserEmail.Equals(email) && u.isActive.Equals("true") select u).FirstOrDefault();
            int countv = 0;
           
            if (userR != null)
            {
                if (userR.ContactNumber.Equals(""))
                {
                    countv++;
                }
                if (userR.Country.Equals(""))
                {
                    countv++;
                }
                if (userR.Picture.Equals(""))
                {
                    countv++;
                }
                if (userR.location.Equals(""))
                {
                    countv++;
                }

                int peercentageR = (countv );
                return peercentageR;
            }
            return -1;
        }

        public bool DeleteUser(int id)
        {
            var userR = (from u in db.Users where u.UserId.Equals(id) select u).FirstOrDefault();

            if (userR != null)
            {

                userR.isActive = "false";
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception m)
                {
                    m.GetBaseException();
                    
                    return false;   
                }

            }
            return false;  // user not found
        }

        public string getImageNAme(int id)
        {
            var userR = (from u in db.Users
                         where u.UserId.Equals(id)
                         select u).FirstOrDefault();

            if (userR != null)
            {
                return userR.Picture;
 
            }
            return "";  // user not found
        }

        public List<AllUserType> getAllUserTypes()
        {
            var allu = new List<AllUserType>();

            dynamic alltypes = (from u in db3.AllUserTypes where u.isAvailable.Equals("true") select u);

            if (alltypes != null)
            {
                foreach (AllUserType ct in alltypes)
                {

                    var types = new AllUserType()
                    {
                         Id = ct.Id,
                         Usertype= ct.Usertype,
                         isAvailable = ct.isAvailable
                    };
                    allu.Add(types);
                }

                return allu;
            }

            return null;
        }

    }
}