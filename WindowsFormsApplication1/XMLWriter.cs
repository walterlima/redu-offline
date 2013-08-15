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


namespace ReduOffline
{
    public class XMLWriter
    {

        public XMLWriter() { }

        private System.Xml.Serialization.XmlSerializer serializer;

        public void save_user_data(User user, List<Status> feed)
        {
            if (!File.Exists(Constants.XML_USER_FOLDER + "\\" + user.Login + ".xml"))
            {
                serialize_and_save_xml<List<Status>>(feed, Constants.XML_USER_FOLDER + "\\" + user.Login + ".xml");
                //XmlNode xml_user_config_root = xml_user_config.CreateElement("config");
                //xml_user_config.AppendChild(declaration);
                //xml_user_config.AppendChild(xml_user_config_root);
                //xml_user_config.Save(path_info.InnerText);
            }
            if (!File.Exists(string.Format(Constants.XML_USER_TIMELINE_PATH, user.Login)))
            {
                feed.OrderByDescending(p => p.Created_At);
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
            if (!Directory.Exists(string.Format(Constants.XML_AVA_FOLDER, ava.Initials)))
            {
                Directory.CreateDirectory(string.Format(Constants.XML_AVA_FOLDER, ava.Initials));
                List<Course> course_backup = ava.Courses;
                ava.Courses = null;
                serialize_and_save_xml<EnvironmentRedu>(ava, string.Format(Constants.XML_AVA_PATH, ava.Initials, ava.Id));
                ava.Courses = course_backup;
            }
            foreach (Course course in ava.Courses)
            {
                if (!Directory.Exists(string.Format(Constants.XML_COURSE_FOLDER, ava.Initials, course.Name)))
                {
                    Directory.CreateDirectory(string.Format(Constants.XML_COURSE_FOLDER, ava.Initials, course.Name));
                    List<Space> space_backup = course.Spaces; 
                    course.Spaces = null;
                    serialize_and_save_xml<Course>(course, string.Format(Constants.XML_COURSE_PATH, ava.Initials, course.Name, course.Id));
                    course.Spaces = space_backup;
                }
                foreach (Space space in course.Spaces)
                {
                    if (!Directory.Exists(string.Format(Constants.XML_SPACE_FOLDER, ava.Initials, course.Name, space.Name)))
                    {
                        Directory.CreateDirectory(string.Format(Constants.XML_SPACE_FOLDER, ava.Initials, course.Name, space.Name));
                        List<Subject> subject_backup = space.Subjects;
                        space.Subjects = null;
                        serialize_and_save_xml<Space>(space, string.Format(Constants.XML_SPACE_PATH, ava.Initials, course.Name, space.Name, space.Id));
                        space.Subjects = subject_backup;
                    }
                    foreach (Subject subject in space.Subjects)
                    {
                        if (!Directory.Exists(string.Format(Constants.XML_SUBJECT_FOLDER, ava.Initials, course.Name, space.Name, subject.Id)))
                        {
                            Directory.CreateDirectory(string.Format(Constants.XML_SUBJECT_FOLDER, ava.Initials, course.Name, space.Name, subject.Id));
                            List<Lecture> lecture_backup = subject.Lectures;
                            subject.Lectures = null;
                            serialize_and_save_xml<Subject>(subject, string.Format(Constants.XML_SUJECT_PATH, ava.Initials, course.Name, space.Name, subject.Id, subject.Id));
                            subject.Lectures = lecture_backup;
                        }
                        foreach (Lecture lecture in subject.Lectures)
                        {
                            if (!File.Exists(string.Format(Constants.XML_LECTURE_PATH, ava.Initials, course.Name, space.Name, subject.Id, lecture.Id)))
                            {
                                serialize_and_save_xml<Lecture>(lecture, string.Format(Constants.XML_LECTURE_PATH, ava.Initials, course.Name, space.Name, subject.Id, lecture.Id));
                            }
                        }
                    }
                }
            }            
        }

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

        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding
            {
                get { return Encoding.UTF8; }
            }
        }
    }
}
