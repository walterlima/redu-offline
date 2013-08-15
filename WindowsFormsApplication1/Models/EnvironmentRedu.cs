using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduOffline.Models
{
    public class EnvironmentRedu
    {

        public EnvironmentRedu() { }

        private String _id;
        private String _name;
        private String _initials;
        private String _path;
        private String _description;
        private String _course_count;
        private String _created_at;
        private List<Thumbnail> _thumbnails;
        private List<Link> _links;
        private List<Course> _courses;

        public String Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public String Initials
        {
            get { return _initials; }
            set { _initials = value; }
        }
        
        public String Path
        {
            get { return _path; }
            set { _path = value; }
        }

        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }
        
        public String Course_Count
        {
            get { return _course_count; }
            set { _course_count = value; }
        }
        
        public String Created_At
        {
            get { return _created_at; }
            set { _created_at = value; }
        }

        public List<Thumbnail> Thumbnails
        {
            get { return _thumbnails; }
            set { _thumbnails = value; }
        }
        
        public List<Link> Links
        {
            get { return _links; }
            set { _links = value; }
        }
        
        public List<Course> Courses
        {
            get { return _courses; }
            set { _courses = value; }
        }
    }
}
