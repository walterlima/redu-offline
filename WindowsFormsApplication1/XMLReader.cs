/*
    Copyright 2013 Walter Ferreira de Lima Filho
    
    This file is part of ReduOffline.

    ReduOffline is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    ReduOffline is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with ReduOffline.  If not, see <http://www.gnu.org/licenses/>. 

*/
using ReduOffline.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ReduOffline
{
    /// <summary>
    /// XMLReader is in charge of reading the Offline data and return the ontime object for the application.
    /// </summary>
    public class XMLReader
    {

        public XMLReader() { }

        private XmlSerializer serializer;

        /// <summary>
        /// Reads the user data according to a login.
        /// TODO: check if the login is available
        /// </summary>
        /// <param name="login">User's login</param>
        /// <returns>User data as a User objectt</returns>
        public User read_user_data(string login)
        {
            string path = String.Format(Constants.XML_USER_PATH, login);
            User user = deserialize<User>(path);
            return user;
        }        

        /// <summary>
        /// Reads all the data from the AVA according to the stablished architecture.
        /// Architecute
        /// AVA
        /// > Courses
        /// >> Spaces
        /// >>> Subjects
        /// >>>> Lectures
        /// </summary>
        /// <param name="ava_name">AVA name</param>
        /// <returns>Ava as an EnvironmentRedu object</returns>
        public Tuple<EnvironmentRedu, List<Space>, List<Lecture>> read_ava_data(string ava_name)
        {
            string ava_xml_path = string.Format(Constants.XML_AVA_PATH, ava_name);
            EnvironmentRedu ava = deserialize<EnvironmentRedu>(ava_xml_path);
            List<Space> spaces = new List<Space>();
            List<Lecture> lectures = new List<Lecture>();
            
            ava.Courses = new List<Course>();
            foreach (string course_id in ava.Courses_Ids)
            {
                string course_xml_path = string.Format(Constants.XML_COURSE_PATH, course_id);
                Course course = deserialize<Course>(course_xml_path);                                                
                course.Spaces = new List<Space>();
                foreach (string space_id in course.Spaces_Ids)
                {
                    string space_xml_path = string.Format(Constants.XML_SPACE_PATH, space_id);
                    Space space = deserialize<Space>(space_xml_path);
                    string space_timeline_xml_path = string.Format(Constants.XML_SPACE_TIMELINE_PATH, space.Id);
                    space.Timeline = deserialize<List<Status>>(space_timeline_xml_path);                    
                    space.Subjects = new List<Subject>();
                    foreach (string subject_id in space.Subjects_Ids)
                    {
                        string subject_xml_path = string.Format(Constants.XML_SUJECT_PATH, subject_id);                        
                        Subject subject = deserialize<Subject>(subject_xml_path);                        
                        subject.Lectures = new List<Lecture>();
                        foreach (string lecture_id in subject.Lecture_Ids)
                        {
                            string lecture_xml_path = string.Format(Constants.XML_LECTURE_PATH, lecture_id);
                            Lecture lecture = deserialize<Lecture>(lecture_xml_path);
                            string lecture_timeline_xml_path = string.Format(Constants.XML_LECTURE_TIMELINE_PATH, lecture.Id);
                            lecture.Timeline = deserialize<List<Status>>(lecture_timeline_xml_path);
                            subject.Lectures.Add(lecture);
                            lectures.Add(lecture);
                        }
                        space.Subjects.Add(subject);
                    }
                    spaces.Add(space);
                    course.Spaces.Add(space);
                }
                ava.Courses.Add(course);
            }

            return new Tuple<EnvironmentRedu,List<Space>,List<Lecture>>(ava, spaces, lectures);
        }

        /// <summary>
        /// Reads the feed data for the current user.
        /// </summary>
        /// <param name="login">Current user login</param>
        /// <returns>A list of Status objects</returns>
        public List<Status> read_feed_data(string login)
        {
            string feed_path = string.Format(Constants.XML_USER_TIMELINE_PATH, login);
            List<Status> feed = deserialize<List<Status>>(feed_path);
            feed = feed.OrderByDescending(p => p.Created_At).ToList();
            return feed;
        }

        /// <summary>
        /// Reads the pending activies (offline activities)
        /// </summary>
        /// <param name="used_id"></param>
        /// <returns></returns>
        public List<PendingActivity> read_pending_activities(string used_id)
        {
            List<PendingActivity> all_pa = deserialize<List<PendingActivity>>(Constants.XML_PENDING_ACTIVITY_PATH);
            List<PendingActivity> filtered_pa = (from pa in all_pa where pa.Id_User.Equals(used_id) && !pa.Done select pa).ToList();
            return filtered_pa;
        }

        /// <summary>
        /// Auxiliar function for setting the id for each pending activity
        /// </summary>
        /// <returns></returns>
        public int read_pending_activities_max_id()
        {
            XDocument xmlDoc = XDocument.Load(Constants.XML_CONFIG_PATH);

            var items = from item in xmlDoc.Descendants("peding-activities-id")                        
                        select item.Element("value").Value;

            int id = Int32.Parse(items.ToList()[0]);

            return id;
        }
        

        private T deserialize<T>(string path)
        {
            serializer = new XmlSerializer(typeof(T));
            StreamReader reader = new StreamReader(path);
            T return_object = (T)serializer.Deserialize(reader);
            reader.Close();
            return return_object;
        }
    }
}
