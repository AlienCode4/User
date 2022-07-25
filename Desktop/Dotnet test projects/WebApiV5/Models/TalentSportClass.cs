using System;
using System.Collections.Generic;
using System.Linq;
using WebApiV5.DatabaseLinks;

namespace WebApiV5.Models
{
    public class TalentSportClass
    {


        TalentSportsDataContext db = new TalentSportsDataContext();
        public TalentSportClass()
        {

        }

        public bool DeleteTalentSport(int sportid, int talentid, string talentPosition)
        {
            var ts = (from u in db.TalentSports
                      where u.SportID.Equals(sportid) &&
                       u.TalentID.Equals(talentid) && u.TalentPosition.Equals(talentPosition)
                      select u).FirstOrDefault();

             
            if(ts != null)
            {
                ts.isAvailable = "false";
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception m)
                {
                    m.GetBaseException();

                    return  false;
                }

            }
            return  false;
           

        }

        public bool addTalentSport(int sportid, int talentid, string talentPosition)
        {
            var NewUser = new TalentSport()
            {
                SportID = sportid,
                TalentID = talentid,
                TalentPosition = talentPosition,
                isAvailable = "true"
            };

            db.TalentSports.InsertOnSubmit(NewUser);
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception m)
            {
                m.GetBaseException();

                return  true;
            }

        }

        public List<TalentSport> getTalentByPosition(string position,int id)
        {
            List<TalentSport> idList = new List<TalentSport>();

            dynamic t = (from u in db.TalentSports where u.TalentPosition.Equals(position)
                         && u.SportID.Equals(id)
                         select u);

            if (t != null)
            {
                foreach (TalentSport ts in t)
                {

                    var NewUser = new TalentSport()
                    {
                        SportID = ts.SportID,
                        TalentID = ts.TalentID,
                        TalentPosition = ts.TalentPosition,
                        isAvailable = ts.isAvailable
                    };
                    idList.Add(NewUser);

                }
                return idList;

            }
            return null;
        }

        public List<TalentSport> getAllTalents()
        {
            List<TalentSport> idList = new List<TalentSport>();

            dynamic t = (from u in db.TalentSports
                         
                         select u);

            if (t != null)
            {
                foreach (TalentSport ts in t)
                {

                    var NewUser = new TalentSport()
                    {
                        SportID = ts.SportID,
                        TalentID = ts.TalentID,
                        TalentPosition = ts.TalentPosition,
                        isAvailable = ts.isAvailable
                    };
                    idList.Add(NewUser);

                }
                return idList;

            }
            return null;
        }

        public List<TalentSport> getAllTalentSports(int id)
        {
            List<TalentSport> idList = new List<TalentSport>();

            dynamic t = (from u in db.TalentSports
                         where  u.SportID.Equals(id)

                         select u);

            if (t != null)
            {
                foreach (TalentSport ts in t)
                {

                    var NewUser = new TalentSport()
                    {
                        SportID = ts.SportID,
                        TalentID = ts.TalentID,
                        TalentPosition = ts.TalentPosition,
                        isAvailable = ts.isAvailable
                    };
                    idList.Add(NewUser);

                }
                return idList;

            }
            return null;
        }
    }
}