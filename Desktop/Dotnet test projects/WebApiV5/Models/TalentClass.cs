using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiV5.DatabaseLinks;

namespace WebApiV5.Models
{
    public class TalentClass
    {

        TalentsDataContext db = new TalentsDataContext();
        UsersDataContext db2 = new UsersDataContext();
        public TalentClass()
        {


        }

        public bool AddTalent(string email, string name, string surname, DateTime DOB, string gender, int height)
        {
            var Registereduser = (from u in db2.Users where u.UserEmail.Equals(email) select u).FirstOrDefault();



            if (Registereduser != null)
            {
                var new_talent = new Talent()
                {
                    TalentID = Registereduser.UserId,
                    TalentName = name,
                    TalentSurname = surname,
                    TalentDOB = DOB,
                    TalentGender = gender,
                    TalentHeight = height


                };
                db.Talents.InsertOnSubmit(new_talent);
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
        public Talent GetTalentByID(int id)
        {

            var te = (from u in db.Talents where u.TalentID.Equals(id) select u).FirstOrDefault();
            var te2 = (from u in db2.Users where u.UserId.Equals(id) && u.isActive.Equals("true") select u).FirstOrDefault();

            if (te != null && te2 !=null)
            {
                Talent newTalent = new Talent()
                {
                    TalentDOB = te.TalentDOB,
                    TalentHeight = te.TalentHeight,
                    TalentID = te.TalentID,
                    TalentName = te.TalentName,
                    TalentGender = te.TalentGender,
                    TalentSurname = te.TalentSurname

                };
                return newTalent;
            }
            return null;
        }

        public bool DeleteByID(int id)
        {

            var te = (from u in db2.Users where u.UserId.Equals(id) select u).FirstOrDefault();

            if (te != null)
            {
                te.isActive = "false";
                 
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
        public List<Talent> GetAllTalents()
        {
            List<Talent> Tlist = new List<Talent>();

            dynamic getT = (from u in db.Talents select u);

            if (getT != null)
            {
                foreach (Talent te in getT)
                {
                    Talent newTalent = new Talent()
                    {
                        TalentDOB = te.TalentDOB,
                        TalentHeight = te.TalentHeight,
                        TalentID = te.TalentID,
                        TalentName = te.TalentName,
                        TalentGender = te.TalentGender,
                        TalentSurname = te.TalentSurname

                    };

                    Tlist.Add(newTalent);

                }

                return Tlist;
            }
            return null;
        }

        public List<Talent> GetTalentsByHeight(int height)
        {
            List<Talent> Tlist = new List<Talent>();

            dynamic getT = (from u in db.Talents where u.TalentHeight > height select u);

            if (getT != null)
            {
                foreach (Talent te in getT)
                {
                    Talent newTalent = new Talent()
                    {
                        TalentDOB = te.TalentDOB,
                        TalentHeight = te.TalentHeight,
                        TalentID = te.TalentID,
                        TalentName = te.TalentName,
                        TalentGender = te.TalentGender,
                        TalentSurname = te.TalentSurname

                    };

                    Tlist.Add(newTalent);

                }


                return Tlist;
            }
            return null;
        }
        public List<Talent> GetAllTalentByAge(int min, int max)
        {
            List<Talent> Tlist = new List<Talent>();



            dynamic getT = (from u in db.Talents where u.TalentDOB.Year >= min && u.TalentDOB.Year < max select u);

            if (getT != null)
            {
                foreach (Talent te in getT)
                {
                    Talent newTalent = new Talent()
                    {
                        TalentDOB = te.TalentDOB,
                        TalentHeight = te.TalentHeight,
                        TalentID = te.TalentID,
                        TalentName = te.TalentName,
                        TalentGender = te.TalentGender,
                        TalentSurname = te.TalentSurname

                    };

                    Tlist.Add(newTalent);

                }

                return Tlist;
            }
            return null;
        }

        public List<Talent> GetAllTalentsAgeHeightGender(int min, int max, int height, string gender)
        {
            List<Talent> Tlist = new List<Talent>();



            dynamic getT = (from u in db.Talents
                            where u.TalentDOB.Year >= min && u.TalentDOB.Year < max
       && u.TalentHeight >= height && u.TalentGender.Equals(gender)
                            select u);

            if (getT != null)
            {
                foreach (Talent te in getT)
                {
                    Talent newTalent = new Talent()
                    {
                        TalentDOB = te.TalentDOB,
                        TalentHeight = te.TalentHeight,
                        TalentID = te.TalentID,
                        TalentName = te.TalentName,
                        TalentGender = te.TalentGender,
                        TalentSurname = te.TalentSurname, 
                         

                    };

                    Tlist.Add(newTalent);

                }

                return Tlist;
            }
            return null;
        }

        public double ProfileCompletePercentageTalent(int id)
        {
            var userR = (from u in db.Talents
                         where u.TalentID.Equals(id)
                         select u).FirstOrDefault();
            int countv = 0;

            if (userR != null)
            {
                if (userR.TalentDOB.Equals(""))
                {
                    countv++;
                }
                if (userR.TalentHeight.Equals(""))
                {
                    countv++;
                }
                if (userR.TalentName.Equals(""))
                {
                    countv++;
                }
                if (userR.TalentSurname.Equals(""))
                {
                    countv++;
                }
                if (userR.TalentGender.Equals(""))
                {
                    countv++;
                }
 
                double peercentageR = (countv / 5) * 50;
                return peercentageR;
            }
            return -1;
        }
    }


}