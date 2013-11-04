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
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;


namespace ReduOffline
{
    public class XMLWriter
    {

        public XMLWriter() { }

        private System.Xml.Serialization.XmlSerializer serializer;

        /// <summary>
        /// Stores the user data, including his timeline, into XML files
        /// </summary>
        /// <param name="user"></param>
        /// <param name="feed"></param>
        public void save_user_data(User user, List<Status> feed)
        {
            if (!File.Exists(String.Format(Constants.XML_USER_PATH, user.Login)))
            {
                serialize_and_save_xml<User>(user, String.Format(Constants.XML_USER_PATH, user.Login));
                //XmlNode xml_user_config_root = xml_user_config.CreateElement("config");
                //xml_user_config.AppendChild(declaration);
                //xml_user_config.AppendChild(xml_user_config_root);
                //xml_user_config.Save(path_info.InnerText);
            }
            if (!File.Exists(string.Format(Constants.XML_USER_TIMELINE_PATH, user.Login)))
            {
                feed = feed.OrderBy(p => p.Created_At).ToList();
                serialize_and_save_xml<List<Status>>(feed, string.Format(Constants.XML_USER_TIMELINE_PATH, user.Login));
            }
        }

        /// <summary>
        /// Stores every data from the ava until the lecture. It creates the folders if they don't exist. They save just the data
        /// that is not stored yet.
        /// </summary>
        /// <param name="ava">Redu AVA</param>
        public void save_ava_data(EnvironmentRedu ava)
        {
            EnvironmentRedu copy_ava = ava;
            List<Course> course_backup = ava.Courses;
            ava.Courses = null;            
            ava.Courses = course_backup;
            List<String> courses_ids = new List<string>();
            foreach (Course course in ava.Courses)
            {
                List<Space> space_backup = course.Spaces; 
                course.Spaces = null;                
                course.Spaces = space_backup;
                courses_ids.Add(course.Id);
                List<String> spaces_ids = new List<string>();
                foreach (Space space in course.Spaces)
                {
                    List<Subject> subject_backup = space.Subjects;
                    space.Subjects = null;
                    serialize_and_save_xml<List<Status>>(space.Timeline, string.Format(Constants.XML_SPACE_TIMELINE_PATH, space.Id));
                    space.Timeline = null;                    
                    space.Subjects = subject_backup;
                    spaces_ids.Add(space.Id);
                    List<String> subjects_ids = new List<string>();
                    foreach (Subject subject in space.Subjects)
                    {
                        List<Lecture> lecture_backup = subject.Lectures;
                        subject.Lectures = null;                        
                        subject.Lectures = lecture_backup;
                        subjects_ids.Add(subject.Id);
                        List<String> lectures_ids = new List<string>();
                        foreach (Lecture lecture in subject.Lectures)
                        {
                            serialize_and_save_xml<List<Status>>(lecture.Timeline, string.Format(Constants.XML_LECTURE_TIMELINE_PATH, lecture.Id));
                            lecture.Timeline = null;
                            serialize_and_save_xml<Lecture>(lecture, string.Format(Constants.XML_LECTURE_PATH, lecture.Id));
                            lectures_ids.Add(lecture.Id);
                        }
                        subject.Lecture_Ids = lectures_ids;
                        serialize_and_save_xml<Subject>(subject, string.Format(Constants.XML_SUJECT_PATH, subject.Id));
                    }
                    space.Subjects_Ids = subjects_ids;
                    serialize_and_save_xml<Space>(space, string.Format(Constants.XML_SPACE_PATH, space.Id));
                }
                course.Spaces_Ids = spaces_ids;
                serialize_and_save_xml<Course>(course, string.Format(Constants.XML_COURSE_PATH, course.Id));
            }
            ava.Courses_Ids = courses_ids;
            serialize_and_save_xml<EnvironmentRedu>(ava, string.Format(Constants.XML_AVA_PATH, ava.Initials));
        }


        /// <summary>
        /// Serializes the data into a XML formatted string and saves it into a XML file
        /// </summary>
        /// <typeparam name="T"> Type of the data to save</typeparam>
        /// <param name="data">Data to save</param>
        /// <param name="path">XML file path</param>
        private void serialize_and_save_xml<T>(T data, string path)
        {
            serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            XmlDocument doc = new XmlDocument();
            string xmldata;
            using (StringWriter writer = new Utf8StringWriter())
            {
                serializer.Serialize(writer, data);
                xmldata = writer.ToString();
            }
            doc.LoadXml(xmldata);
            doc.Save(path);
        }

        public void save_lecture_data()
        {
            //not at the moment
        }

        /// <summary>
        /// Save a list of new statuses onto the XML where the same status container are
        /// </summary>
        /// <param name="statuses">List of status</param>
        /// <param name="path">XML path of the status container</param>
        public void write_new_statuses(List<Status> statuses, string path)
        {
            serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Status>));
            XmlDocument doc_new_statuses = new XmlDocument();
            XmlDocument doc_old_statuses = new XmlDocument();
            string xmldata = "";
            
            using (StringWriter writer = new Utf8StringWriter())
            {
                serializer.Serialize(writer, statuses);
                xmldata = writer.ToString();
            }

            doc_old_statuses.Load(path);
            doc_new_statuses.LoadXml(xmldata);

            foreach (XmlNode node in doc_new_statuses.DocumentElement.ChildNodes)
            {
                var newNode = doc_old_statuses.ImportNode(node, true);
                doc_old_statuses.DocumentElement.AppendChild(newNode);
            }

            doc_old_statuses.Save(path);
        }
        
        /// <summary>
        /// Writes pending activities to the xml file
        /// </summary>
        /// <param name="pending_activities"></param>
        public void save_pending_activity(List<PendingActivity> pending_activities)
        {
            string path = Constants.XML_PENDING_ACTIVITY_PATH;

            if (File.Exists(path))
            {
                serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<PendingActivity>));
                XmlDocument doc_new_pa = new XmlDocument();
                XmlDocument doc_old_pa = new XmlDocument();
                string xmldata = "";

                using (StringWriter writer = new Utf8StringWriter())
                {
                    serializer.Serialize(writer, pending_activities);
                    xmldata = writer.ToString();
                }

                doc_old_pa.Load(path);
                doc_new_pa.LoadXml(xmldata);

                foreach (XmlNode node in doc_new_pa.DocumentElement.ChildNodes)
                {
                    var newNode = doc_old_pa.ImportNode(node, true);
                    doc_old_pa.DocumentElement.AppendChild(newNode);
                }

                doc_old_pa.Save(path);
            }
            else
            {
                serialize_and_save_xml<List<PendingActivity>>(pending_activities, path);
            }
        }

        /// <summary>
        /// Deletes from the correspondant xmls the statuses which were set as offline
        /// </summary>
        /// <param name="status_and_path">A Tuple where the First item is a Status and the second one is the path for its xml file</param>
        public void erase_pending_statuses(List<Tuple<Status,String>> status_and_path)
        {//could be faster if the status on the same xml are groupped together
            XDocument doc;
            foreach (Tuple<Status, String> tuple in status_and_path)
            {
                doc = XDocument.Load(tuple.Item2);
                var status = from node in doc.Descendants("Status") where node.Element("id").Value.Equals(tuple.Item1.Id) select node;
                status.ToList().ForEach(x => x.Remove());
                doc.Save(tuple.Item2);                
            }
        }

        /// <summary>
        /// Sets the pending activities as done and set up the synchronization time
        /// </summary>
        /// <param name="pending_activities"></param>
        /// <param name="id_user"></param>
        public void set_pending_activity_done(List<PendingActivity> pending_activities, string id_user)
        {
            XDocument xmlDoc = XDocument.Load(Constants.XML_PENDING_ACTIVITY_PATH);

            var items = from item in xmlDoc.Descendants("PendingActivity")
                        where item.Element("done").Value.Equals("false") && item.Element("id-user").Value.Equals(id_user)
                        select item;

            foreach (XElement itemElement in items)
            {
                itemElement.SetElementValue("done", "true");
                itemElement.SetElementValue("sync-time-stamp", pending_activities[0].Sync_Time_Stamp);
            }
            xmlDoc.Save(Constants.XML_PENDING_ACTIVITY_PATH);
        }

        /// <summary>
        /// Saves to a XML the next id to use upon creating a new pending activity
        /// </summary>
        /// <param name="id">id to save</param>
        public void save_pending_activities_max_id(int id)
        {
            XDocument xmlDoc = XDocument.Load(Constants.XML_CONFIG_PATH);

            var items = from item in xmlDoc.Descendants("peding-activities-id")
                        select item.Element("value");

            items.ToList().ForEach(x => x.Value = id.ToString());

            xmlDoc.Save(Constants.XML_CONFIG_PATH);
        }

        /// <summary>
        /// Saves a new answer into the XML where the answered status is
        /// </summary>
        /// <param name="answer">Answer status</param>
        /// <param name="status_answered">Status answered</param>
        public void save_status_answer(Status answer, Status status_answered)
        {
            string path = "";
            switch (status_answered.Post_Local)
            {
                case(Constants.STATUS_LECTURE):
                    path = string.Format(Constants.XML_LECTURE_TIMELINE_PATH, status_answered.Statusable_Id);
                    break;
                case(Constants.STATUS_USER):
                    path = string.Format(Constants.XML_USER_TIMELINE_PATH, answer.User.Login);
                    break;
                case(Constants.STATUS_SPACE):
                    path = string.Format(Constants.XML_SPACE_TIMELINE_PATH, status_answered.Statusable_Id);
                    break;
            }

            XDocument xmlDoc = XDocument.Load(path);

            serializer = new System.Xml.Serialization.XmlSerializer(typeof(Status));
            string xmldata;
            using (StringWriter writer = new Utf8StringWriter())
            {
                serializer.Serialize(writer, answer);
                xmldata = writer.ToString();
            }

            XDocument xml_doc_new_answer = XDocument.Parse(xmldata);
            XElement new_answer = xml_doc_new_answer.Element("Status");

            var items = from item in xmlDoc.Descendants("Status")
                        where item.Element("id").Value.Equals(status_answered.Id)
                        select item;

            XElement answers = items.ToList()[0].Element("answers");

            if (answers == null)
            {
                //var status = from s in xmlDoc.Descendants("Status")
                //             where s.Element("id").Value.Equals(status_answered.Id)
                //             select s;
                XElement answers_node = new XElement("answers");
                answers_node.Add(new_answer);
                items.ToList()[0].Add(answers_node);
            }
            else
            {
                answers.Add(new_answer);
                //items.Elements().ToList().Add(new_answer);
            }

            var answers_count = from item in xmlDoc.Descendants("Status")
                                where item.Element("id").Value.Equals(status_answered.Id)
                                select item.Element("answers-count");

            answers_count.ToList().ForEach(x => x.Value = (Int32.Parse(x.Value) + 1).ToString());

            xmlDoc.Save(path);
        }

        public void erase_pending_answer(List<Tuple<Status, String>> pending_answers)
        {
            XDocument doc;
            foreach (Tuple<Status, String> tuple in pending_answers)
            {
                doc = XDocument.Load(tuple.Item2);
                var status = from node in doc.Descendants("answers") 
                             where node.Element("status").Element("id").Value.Equals(tuple.Item1.Id) 
                             select node.Element("status");
                status.ToList().ForEach(x => x.Remove());
                doc.Save(tuple.Item2);
            }
        }

        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding
            {
                get { return Encoding.UTF8; }
            }
        }
    }
}
