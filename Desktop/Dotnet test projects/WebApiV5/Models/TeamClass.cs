using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiV5.DatabaseLinks;

namespace WebApiV5.Models
{
    public class TeamClass
    {

        TeamsDataContext db = new TeamsDataContext();


        public TeamClass()
        {

        }


        public List<Team> getAllTeams()
        {
            var getS = new List<Team>();

            dynamic allS = from u in db.Teams where u.isAvailable.Equals("true") select u;

            if (allS != null)
            {

                foreach (Team s in allS)
                {
                    Team newS = new Team()
                    {
                        Id = s.Id,
                         isAvailable= s.isAvailable,
                          TeamName =s.TeamName
                    };
                    getS.Add(newS);
                }
                return getS;
            }


            return null;
        }

        public Team getTeam(int id)
        {
            var getS = new Team();

            var s = (from u in db.Teams
                     where u.Id.Equals(id) && u.isAvailable.Equals("true")
                     select u).FirstOrDefault();

            if (s != null)
            {


                Team newS = new Team()
                {
                    Id = s.Id,
                    isAvailable = s.isAvailable,
                    TeamName = s.TeamName
                };
                return newS;


            }


            return null;
        }
        public bool addTeam(string teamNAme)
        {
            var te= (from u in db.Teams where u.TeamName.Equals(teamNAme) && u.isAvailable.Equals("true")
                             select u).FirstOrDefault();

            if (te == null)
            {
                Team sp = new Team()
                {
                    TeamName = teamNAme,
                    isAvailable = "true"
                };

                db.Teams.InsertOnSubmit(sp);

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

        public bool DeleteTeam(int id)
        {
            var sportName = (from u in db.Teams where u.Id.Equals(id) select u).FirstOrDefault();

            if (sportName != null)
            {

                sportName.isAvailable = "false";
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