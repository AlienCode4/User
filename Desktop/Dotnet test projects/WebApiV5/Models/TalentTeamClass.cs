using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiV5.DatabaseLinks;

namespace WebApiV5.Models
{
    public class TalentTeamClass
    {
        TalentTeamsDataContext db = new TalentTeamsDataContext();


        public TalentTeamClass()
        {
            

        }


        public List<TalentTeam> getAllTeamEventsz()
        {   
            var getS = new List<TalentTeam>();

            dynamic allS = from u in db.TalentTeams where u.isAvailable.Equals("true") select u;

            if (allS != null)
            {

                foreach (TalentTeam s in allS)
                {
                    TalentTeam newS = new TalentTeam()
                    {
                        TalentID =s.TalentID,
                        isAvailable = s.isAvailable,
                         TeamID = s.TeamID
                    };
                    getS.Add(newS);
                }
                return getS;
            }


            return null;
        }

        public TalentTeam getTeamEvent(int talentid)
        {

            var s = (from u in db.TalentTeams
                     where  u.TalentID.Equals(talentid) && u.isAvailable.Equals("true")
                     select u).FirstOrDefault();

            if (s != null)
            {


                TalentTeam newS = new TalentTeam()
                {
                    TalentID = s.TalentID,
                    isAvailable = s.isAvailable,
                    TeamID = s.TeamID
                };
                return newS;

            }
            return null;
        }

        public bool addTalentTeamTeamEvent(int talentid, int teamid)
        {
            var s = (from u in db.TalentTeams
                     where u.TalentID.Equals(teamid) 
                      && u.isAvailable.Equals("true")
                     select u).FirstOrDefault();

            if (s == null)
            {
                TalentTeam newS = new TalentTeam()
                {
                    TalentID = s.TalentID,
                    isAvailable = s.isAvailable,
                    TeamID = s.TeamID
                };
                db.TalentTeams.InsertOnSubmit(newS);

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

        public bool DeleteTeamEvent(int teamid, int talent)
        {
            var events = (from u in db.TalentTeams
                          where u.TeamID.Equals(teamid) &&
     u.TalentID.Equals(talent) && u.isAvailable.Equals("true")
                          select u).FirstOrDefault();

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


