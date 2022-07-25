using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiV5.DatabaseLinks;

namespace WebApiV5.Models
{
    public class SoccerEventClass
    {
        SoccerEventsDataContext db = new SoccerEventsDataContext();

        public SoccerEventClass()
        {

        }


        public SoccerEvent GetSoccerEvent(int Eventid)
        {
            var getE = (from u in db.SoccerEvents where u.EventID.Equals(Eventid) select u).FirstOrDefault();


            if (getE != null)
            {
                SoccerEvent sce = new SoccerEvent()
                {
                    EventID = getE.EventID,
                    TeamA = getE.TeamA,
                    TeamB = getE.TeamB,
                     isAvailable = getE.isAvailable
                };

                return sce;

            }

            return null;

        }

        public List<SoccerEvent> GetSoccerEvent()
        {
            dynamic getE = (from u in db.SoccerEvents   select u);
            List<SoccerEvent> scR = new List<SoccerEvent>();

            if (getE != null)
            {
                foreach (SoccerEvent sci in getE)
                {
                    SoccerEvent sce = new SoccerEvent()
                    {
                        EventID = sci.EventID,
                        TeamA = sci.TeamA,
                        TeamB = sci.TeamB,
                        isAvailable = getE.isAvailable

                    };
                    scR.Add(sce);
                    return scR;
                }       

            }

            return null;

        }

        public bool addEvent(int  Eventid ,string teamA,string teamB)
        {
            var getE = (from u in db.SoccerEvents where u.EventID.Equals(Eventid) select u).FirstOrDefault();


            if(getE == null)
            {
                SoccerEvent sce = new SoccerEvent()
                {
                    EventID =Eventid,
                     TeamA =teamA,
                       TeamB = teamB,
                    isAvailable = "true"

                };

                db.SoccerEvents.InsertOnSubmit(sce);

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

        public bool DeleteEvent(int id)
        {

            var es = (from u in db.SoccerEvents
                      where u.isAvailable.Equals("true") && u.EventID.Equals(id)
                      select u).FirstOrDefault();

            if (es != null)
            {
                es.isAvailable = "false";

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



    }
}