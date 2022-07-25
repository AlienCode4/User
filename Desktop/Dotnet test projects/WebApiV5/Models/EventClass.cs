using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiV5.DatabaseLinks;

namespace WebApiV5.Models
{
    public class EventClass
    {
        EventsDataContext db = new EventsDataContext();
        public EventClass()
        {

        }

        public List<Event> getAllEvents()
        {
            var getE = new List<Event>();

            dynamic allevents = (from u in db.Events where u.isAvailable.Equals("true") select u);

            if(allevents != null)
            {
                foreach ( Event es in allevents)
                {
                    Event newEvent = new Event()
                    {      
                           EventDate =es.EventDate,
                            Type =es.Type,
                             Eventime=es.Eventime,
                                 Id=es.Id,
                                  isAvailable= es.isAvailable,
                                   Location =es.Location
 
                    };
                    getE.Add(newEvent);

                }
                return getE;
            }
            return null;
           
        }

        public List<Event> getAllEvenFromToday()
        {
            var getE = new List<Event>();

            dynamic allevents = (from u in db.Events where u.isAvailable.Equals("true") && 
                                 u.EventDate >DateTime.Today select u);

            if (allevents != null)
            {
                foreach (Event es in allevents)
                {
                    Event newEvent = new Event()
                    {
                        EventDate = es.EventDate,
                        Type = es.Type,
                        Eventime = es.Eventime,
                        Id = es.Id,
                        isAvailable = es.isAvailable,
                        Location = es.Location


                    };
                    getE.Add(newEvent);

                }
                return getE;
            }
            return null;

        }

        public List<Event> getAllEvenByDate( DateTime date)
        {
            var getE = new List<Event>();

            dynamic allevents = (from u in db.Events
                                 where u.isAvailable.Equals("true") &&
             u.EventDate.Date.Equals(date.Date) 
                                 select u);

            if (allevents != null)
            {
                foreach (Event es in allevents)
                {
                    Event newEvent = new Event()
                    {
                        EventDate = es.EventDate,
                        Type = es.Type,
                        Eventime = es.Eventime,
                        Id = es.Id,
                        isAvailable = es.isAvailable,
                        Location = es.Location


                    };
                    getE.Add(newEvent);

                }
                return getE;
            }
            return null;

        }
        public List<Event> getAllEventsByName(string type)
        {
            var getE = new List<Event>();

            dynamic allevents = (from u in db.Events
                                 where u.isAvailable.Equals("true") &&
             u.Type.Contains(type) && u.EventDate > DateTime.Today
                                 select u);

            if (allevents != null)
            {
                foreach (Event es in allevents)
                {
                    Event newEvent = new Event()
                    {
                        EventDate = es.EventDate,
                        Type = es.Type,
                        Eventime = es.Eventime,
                        Id = es.Id,
                        isAvailable = es.isAvailable,
                        Location = es.Location
                    };
                    getE.Add(newEvent);
                }
                return getE;
            }
            return null;
        }

        public Event getEvent(int id)
        {           
                 
            var es = (from u in db.Events where u.isAvailable.Equals("true") 
                      && u.Id.Equals(id) select u).FirstOrDefault();

            if (es != null)
            {
                
                    Event newEvent = new Event()
                    {
                        EventDate = es.EventDate,
                        Type = es.Type,
                        Eventime = es.Eventime,
                        Id = es.Id,
                        isAvailable = es.isAvailable,
                        Location = es.Location

                    };
                return newEvent;           
               
            }
            return null;
        }
        public bool addEvent(string Eventname,DateTime date,string location,DateTime times)
        {

            var es = (from u in db.Events
                      where u.isAvailable.Equals("true") && u.Type.Equals(Eventname)==false
                      select u).FirstOrDefault();

            if (es != null)
            {

                Event newEvent = new Event()
                {
                    EventDate = date.Date,
                    Type = es.Type,
                    Eventime = times.TimeOfDay,
                    Id = es.Id,
                    isAvailable = es.isAvailable,
                    Location = es.Location

                };
              

                db.Events.InsertOnSubmit(newEvent);

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

            var es = (from u in db.Events
                      where u.isAvailable.Equals("true") && u.Id.Equals(id)
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