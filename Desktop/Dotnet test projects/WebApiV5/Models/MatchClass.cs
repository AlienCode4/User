using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiV5.DatabaseLinks;

namespace WebApiV5.Models
{
    public class MatchClass
    {
        MatchesDataContext db = new MatchesDataContext();
        public MatchClass()
        {
        }

        public bool DeleteMatchStats(int matchid)
        {

            var mat = (from u in db.Matches
                       where u.MatchID.Equals(matchid)

                       select u).FirstOrDefault();

            if (mat != null)
            {
                mat.IsAvailable = "false";

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

        public bool AddMatchStats(int eventid, int talentid, int fouls, int goalAssit, int goals, int goalsSaved
            , string position, int redcards, string Stated, int tacklesMade, int yellowcards, int timeplayed,int passes
            ,int shortOnTarget, int NumsuccessfulPasses)
        {
            var mat = from u in db.Matches
                      where u.EventID.Equals(eventid)
                      && u.TalentID.Equals(talentid)
                      select u;

            if (mat == null)
            {
                Match newM = new Match()
                {
                    EventID = eventid,
                    Fouls = fouls,
                    GoalAssits = goalAssit,
                    goals = goals,
                    GoalsSaved = goalsSaved,
                    Position = position,
                    RedCards = redcards,
                    Start = Stated,
                    TacklesMade = tacklesMade,
                    TalentID = talentid,
                    Yellowcards = yellowcards,
                    Timeplayed = timeplayed,
                    IsAvailable = "true",
                    Passes = passes,
                    ShotONTarget = shortOnTarget,
                    SuccessfulPasses = NumsuccessfulPasses
                };

                db.Matches.InsertOnSubmit(newM);

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

        public List<Match> getAllTalentMatchStats(int talentid)
        {
            dynamic mat = from u in db.Matches
                          where u.TalentID.Equals(talentid)

                          select u;

            var talentMaches = new List<Match>();

            if (mat == null)
            {

                foreach (Match m in mat)
                {
                    Match newM = new Match()
                    {
                        EventID = m.EventID,
                        Fouls = m.Fouls,
                        GoalAssits = m.GoalAssits,
                        goals = m.goals,
                        GoalsSaved = m.GoalsSaved,
                        Position = m.Position,
                        RedCards = m.RedCards,
                        Start = m.Start,
                        TacklesMade = m.TacklesMade,
                        TalentID = m.TalentID,
                        Yellowcards = m.Yellowcards,
                        Timeplayed = m.Timeplayed,
                        IsAvailable = m.IsAvailable,
                        MatchID = m.MatchID,
                        Passes = m.Passes,
                        ShotONTarget = m.ShotONTarget,
                        SuccessfulPasses = m.SuccessfulPasses
                    };
                    talentMaches.Add(newM);

                }
                return talentMaches;

            }
            return null;

        }

        public List<Match> getAllMatchStats()
        {
            dynamic mat = from u in db.Matches
 
                          select u;

            var talentMaches = new List<Match>();

            if (mat == null)
            {

                foreach (Match m in mat)
                {
                    Match newM = new Match()
                    {
                        EventID = m.EventID,
                        Fouls = m.Fouls,
                        GoalAssits = m.GoalAssits,
                        goals = m.goals,
                        GoalsSaved = m.GoalsSaved,
                        Position = m.Position,
                        RedCards = m.RedCards,
                        Start = m.Start,
                        TacklesMade = m.TacklesMade,
                        TalentID = m.TalentID,
                        Yellowcards = m.Yellowcards,
                        Timeplayed = m.Timeplayed,
                        IsAvailable = m.IsAvailable,
                        MatchID = m.MatchID,
                         Passes = m.Passes,
                        ShotONTarget = m.ShotONTarget,
                        SuccessfulPasses = m.SuccessfulPasses

                    };
                    talentMaches.Add(newM);

                }
                return talentMaches;

            }
            return null;

        }

        public List<Match> getAllMatchStats(int eventid)
        {
            dynamic mat = from u in db.Matches
                          where u.EventID.Equals(eventid)
                          select u;

            var talentMaches = new List<Match>();

            if (mat == null)
            {

                foreach (Match m in mat)
                {
                    Match newM = new Match()
                    {
                        EventID = m.EventID,
                        Fouls = m.Fouls,
                        GoalAssits = m.GoalAssits,
                        goals = m.goals,
                        GoalsSaved = m.GoalsSaved,
                        Position = m.Position,
                        RedCards = m.RedCards,
                        Start = m.Start,
                        TacklesMade = m.TacklesMade,
                        TalentID = m.TalentID,
                        Yellowcards = m.Yellowcards,
                        Timeplayed = m.Timeplayed,
                        IsAvailable = m.IsAvailable,
                        MatchID = m.MatchID,
                        Passes = m.Passes,
                        ShotONTarget = m.ShotONTarget,
                        SuccessfulPasses = m.SuccessfulPasses

                    };
                    talentMaches.Add(newM);

                }
                return talentMaches;

            }
            return null;

        }



        public Match getTalentMatchStats(int talentid,int eventid)
        {
            var m = (from u in db.Matches
                          where u.TalentID.Equals(talentid)
                          && u.EventID.Equals(eventid)
                          select u).FirstOrDefault();

          

            if (m == null)
            {
               
                    Match newM = new Match()
                    {
                        EventID = m.EventID,
                        Fouls = m.Fouls,
                        GoalAssits = m.GoalAssits,
                        goals = m.goals,
                        GoalsSaved = m.GoalsSaved,
                        Position = m.Position,
                        RedCards = m.RedCards,
                        Start = m.Start,
                        TacklesMade = m.TacklesMade,
                        TalentID = m.TalentID,
                        Yellowcards = m.Yellowcards,
                        Timeplayed = m.Timeplayed,
                        IsAvailable = m.IsAvailable,
                        MatchID =m.MatchID ,
                        Passes = m.Passes,
                        ShotONTarget = m.ShotONTarget,
                        SuccessfulPasses = m.SuccessfulPasses

                    };
                   

                
                return newM;

            }
            return null;

        }
    }
}