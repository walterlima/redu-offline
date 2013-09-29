using ReduOffline.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ReduOffline
{
    public class XMLReader
    {

        public XMLReader() { }

        private XmlSerializer serializer;

        public User read_user_data(string login)
        {
            string path = String.Format(Constants.XML_USER_PATH, login);
            User user = deserialize<User>(path);
            return user;
        }        

        public Tuple<EnvironmentRedu, List<Space>, List<Lecture>> read_ava_data(string ava_name)
        {
            string ava_folder_path = string.Format(Constants.XML_AVA_FOLDER, ava_name);
            string ava_xml_path = Directory.GetFiles(ava_folder_path)[0];
            EnvironmentRedu ava = deserialize<EnvironmentRedu>(ava_xml_path);
            List<Space> spaces = new List<Space>();
            List<Lecture> lectures = new List<Lecture>();

            string[] course_folder_paths = Directory.GetDirectories(ava_folder_path);
            ava.Courses = new List<Course>();
            foreach (string course_folder_path in course_folder_paths)
            {
                string course_xml_path = Directory.GetFiles(course_folder_path)[0];
                Course course = deserialize<Course>(course_xml_path);                
                
                string[] space_folder_paths = Directory.GetDirectories(course_folder_path);
                course.Spaces = new List<Space>();
                foreach (string space_folder_path in space_folder_paths)
                {
                    string[] paths = Directory.GetFiles(space_folder_path);
                    string space_xml_path = (from path in paths where path.Contains("space") select path).First();
                    string space_timeline_xml_path = (from path in paths where path.Contains("timeline") select path).First();
                    Space space = deserialize<Space>(space_xml_path);
                    space.Timeline = deserialize<List<Status>>(space_timeline_xml_path);

                    string[] subject_folder_paths = Directory.GetDirectories(space_folder_path);
                    space.Subjects = new List<Subject>();
                    foreach (string subject_folder_path in subject_folder_paths)
                    {
                        string subject_xml_path = Directory.GetFiles(subject_folder_path)[0];
                        string[] lecture_folder_paths = Directory.GetDirectories(subject_folder_path);

                        Subject subject = deserialize<Subject>(subject_xml_path);                        
                        subject.Lectures = new List<Lecture>();
                        foreach (string lecture_folder_path in lecture_folder_paths)
                        {
                            string[] lecture_paths = Directory.GetFiles(lecture_folder_path);
                            string lecture_xml_path = (from path in lecture_paths where path.Contains("lecture") select path).First();
                            string lecture_timeline_xml_path = (from path in lecture_paths where path.Contains("timeline") select path).First();

                            Lecture lecture = deserialize<Lecture>(lecture_xml_path);
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

        public List<Status> read_feed_data(string login)
        {
            string feed_path = string.Format(Constants.XML_USER_TIMELINE_PATH, login);
            List<Status> feed = deserialize<List<Status>>(feed_path);
            feed = feed.OrderByDescending(p => p.Created_At).ToList();
            return feed;
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
