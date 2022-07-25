using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiV5.DatabaseLinks;

namespace WebApiV5.Models
{

  
    public class SportClass
    {

        SportsDataContext db = new SportsDataContext();


        public SportClass()
        {

        }


        public List<Sport> getAllSports()
        {
            var getS = new List<Sport>();

            dynamic allS = from u in db.Sports  where u.isAvailable.Equals("true")select u;

            if( allS != null)
            {

                foreach (Sport s in allS)
                {
                    Sport newS = new Sport()
                    {
                        SportID = s.SportID,
                        isAvailable = s.isAvailable,
                        SportName = s.SportName
                    };
                    getS.Add(newS);
                }
                return getS;
            }


            return null;
        }

        public Sport getSport(int id)
        {  var getS = new Sport();

            var s = (from u in db.Sports where u.SportID.Equals(id ) && u.isAvailable.Equals("true")
                     select u).FirstOrDefault();

            if (s != null)
            {


                Sport newS = new Sport()
                {
                    SportID = s.SportID,
                    isAvailable = s.isAvailable,
                    SportName = s.SportName
                };
                return newS;
            
              
            }


            return null;
        }
        public bool addSport(string sportname)
        {
            dynamic sportName = from u in db.Sports where u.SportName.Equals(sportname) select u;

            if( sportName == null)
            {
                Sport sp = new Sport()
                {
                    SportName = sportname,
                    isAvailable = "true"
                };

                db.Sports.InsertOnSubmit(sp);

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
            return  false;

        }

        public bool DeleteSport(int id )
        {
             var sportName = (from u in db.Sports where u.SportID.Equals(id) select u).FirstOrDefault();

            if (sportName != null)
            {

                sportName.isAvailable = "false";
                try
                {
                    db.SubmitChanges();
                    return  true;
                }
                catch (Exception m)
                {
                    m.GetBaseException();

                    return  false;
                }
            }
            return false;

        }

    }


}