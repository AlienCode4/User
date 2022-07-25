using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiV5.DatabaseLinks;

namespace WebApiV5.Models
{
    public class TeamEventClass
    {
        TeamEventsDataContext db = new TeamEventsDataContext();


        public TeamEventClass()
        {

        }


        public List<TeamEvent> getAllTeamEvents()
        {
            var getS = new List<TeamEvent>();

            dynamic allS = from u in db.TeamEvents where u.isAvailable.Equals("true") select u;

            if (allS != null)
            {

                foreach (TeamEvent s in allS)
                {
                    TeamEvent newS = new TeamEvent()
                    {
                         EventID=s.EventID,
                        isAvailable = s.isAvailable,
                        TeamId =s.TeamId
                    };
                    getS.Add(newS);
                }
                return getS;
            }


            return null;
        }

        public TeamEvent getTeamEvent(int teamid,int eventid)
        {
            
            var s = (from u in db.TeamEvents
                     where u.TeamId.Equals(teamid) && u.EventID.Equals(eventid) && u.isAvailable.Equals("true")
                     select u).FirstOrDefault();

            if (s != null)
            {


                TeamEvent newS = new TeamEvent()
                {
                    EventID = s.EventID,
                    isAvailable = s.isAvailable,
                    TeamId = s.TeamId
                };
                return newS;

            }
            return null;
        }

        public bool addTeamEvent(int teamid, int eventid)
        {
            var s = (from u in db.TeamEvents
                             where u.TeamId.Equals(teamid) &&
                             u.EventID.Equals(eventid) && u.isAvailable.Equals("true")
                             select u).FirstOrDefault();

            if ( s == null)
            {
                TeamEvent newS = new TeamEvent()
                {
                    EventID = s.EventID,
                    isAvailable = s.isAvailable,
                    TeamId = s.TeamId
                };
                db.TeamEvents.InsertOnSubmit(newS);

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

        public bool DeleteTeamEvent(int teamid, int eventid)
        {
            var events = (from u in db.TeamEvents where u.TeamId.Equals(teamid) &&
                             u.EventID.Equals(eventid) && u.isAvailable.Equals("true") select u).FirstOrDefault();

            if (events != null)
            {

                events.isAvailable = "false";
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