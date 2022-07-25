using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiV5.DatabaseLinks;

namespace WebApiV5.Models
{
    public class VideoClass
    {


         VideosDataContext db2 = new VideosDataContext();

        public VideoClass()
        {

        }
        public bool LikeVideo(int videoID)
        {
           
            var vid = (from u in db2.Videos where u.VideoID.Equals(videoID) select u).FirstOrDefault();

            vid.VideoLikes += 1;
            try

            {
                db2.SubmitChanges();
                return true;
            }
            catch (Exception s)
            {
                s.GetBaseException();
                return false;
            }

        }

        public bool ViewVideo(int videoID)
        {
            var vid = (from u in db2.Videos where u.VideoID.Equals(videoID) select u).FirstOrDefault();

           
            vid.VideoViews += 1;
            try

            {
                db2.SubmitChanges();
                return true;
            }
            catch (Exception s)
            {
                s.GetBaseException();
                return false;
            }
        }

        public bool DeleteByID(int id)
        {

            var te = (from u in db2.Videos where u.VideoID.Equals(id) select u).FirstOrDefault();

            if (te != null)
            {
                te.isAvailable = "false";

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
            return false;
        }


        public Video getVideo(int videoID)
        {
 
            var vid = (from u in db2.Videos where u.VideoID.Equals(videoID) && u.isAvailable.Equals("true")
                       select u).FirstOrDefault();


            if (vid != null)
            {

                var newVideo = new Video()
                {
                    VideoID = vid.VideoID,
                    VideoName = vid.VideoName,
                    VideoDescption = vid.VideoDescption,
                    VideoFIleName = vid.VideoFIleName,
                    UserId = vid.UserId,
                    SportID = vid.SportID,
                    VideoLikes = vid.VideoLikes,
                    VideoViews = vid.VideoViews,
                    isAvailable = vid.isAvailable,
                    DatePosted = vid.DatePosted

                };
                return newVideo;

            }

            return null;

        }



        public List<Video> getAllUserVideo(int UserId)
        {

            var getV = new List<Video>();

            dynamic vid1 = (from u in db2.Videos where u.UserId.Equals(UserId) && u.isAvailable.Equals("true")
                            select u);


            if (vid1 != null)
            {
                foreach (Video vid in vid1)
                {

                    var newVideo = new Video()
                    {
                        VideoID = vid.VideoID,
                        VideoName = vid.VideoName,
                        VideoDescption = vid.VideoDescption,
                        VideoFIleName = vid.VideoFIleName,
                        UserId = vid.UserId,
                        SportID = vid.SportID,
                        VideoLikes = vid.VideoLikes,
                        VideoViews = vid.VideoViews,
                        isAvailable = vid.isAvailable,
                        DatePosted = vid.DatePosted

                    };
                    getV.Add(newVideo);

                }

                return getV;
            }


            return null;
        }

        public List<Video> getAllVideo()
        {

            var getV = new List<Video>();

            dynamic vid1 = (from u in db2.Videos
                            where  u.isAvailable.Equals("true")
                            select u);


            if (vid1 != null)
            {
                foreach (Video vid in vid1)
                {

                    var newVideo = new Video()
                    {
                        VideoID = vid.VideoID,
                        VideoName = vid.VideoName,
                        VideoDescption = vid.VideoDescption,
                        VideoFIleName = vid.VideoFIleName,
                        UserId = vid.UserId,
                        SportID = vid.SportID,
                        VideoLikes = vid.VideoLikes,
                        VideoViews = vid.VideoViews,
                        isAvailable = vid.isAvailable,
                        DatePosted = vid.DatePosted

                    };
                    getV.Add(newVideo);

                }

                return getV;
            }


            return null;
        }

        public bool AddVideo(string name, string description, int userid, int sportid, string filename)
        {

            var newVideo = new Video()
            {
                VideoName = name,
                VideoDescption = description,
                VideoFIleName = filename,
                UserId = userid,
                SportID = sportid,
                VideoLikes = 0,
                VideoViews = 0,
                isAvailable = "true",
                DatePosted = DateTime.Today

            };

            db2.Videos.InsertOnSubmit(newVideo);

            try
            {
                db2.SubmitChanges();
                return true;
            }
            catch (Exception s)
            {
                s.GetBaseException();
                return false;
            }

        }

    }
}