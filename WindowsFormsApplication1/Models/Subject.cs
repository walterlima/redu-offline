using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduOffline.Models
{
    public class Subject
    {

        public Subject() { }

        private String _id;
        private String _name;
        private String _description;
        private String _created_at;
        private List<Link> _links;
        private List<Lecture> _lectures;
        private Space _parent_space;

        public Space Parent_Space
        {
            get { return _parent_space; }
            set { _parent_space = value; }
        }

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
        
        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }
        
        public String Created_At
        {
            get { return _created_at; }
            set { _created_at = value; }
        }
        
        public List<Link> Links
        {
            get { return _links; }
            set { _links = value; }
        }        

        public List<Lecture> Lectures
        {
            get { return _lectures; }
            set { _lectures = value; }
        }

    }
}
