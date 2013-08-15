using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduOffline.Models
{
    public class Lecture
    {

        public Lecture() { }       

        private String _created_at;
        private String _name;
        private int _position;
        private String _type;
        private String _id;
        private int _rating;
        private int _view_count;
        private String _updated_at;
        private List<Link> _links;
        private String _content;
        private String _raw;
        private String _mimetype;
        private List<Status> _timeline;
        private Subject _parent_subject;

        public String Created_At
        {
            get { return _created_at; }
            set { _created_at = value; }
        }
        
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        public int Position
        {
            get { return _position; }
            set { _position = value; }
        }
        
        public String Type
        {
            get { return _type; }
            set { _type = value; }
        }
        
        public String Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        public int Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }
        
        public int View_count
        {
            get { return _view_count; }
            set { _view_count = value; }
        }
        
        public String Updated_at
        {
            get { return _updated_at; }
            set { _updated_at = value; }
        }
        
        public List<Link> Links
        {
            get { return _links; }
            set { _links = value; }
        }
        
        public String Content
        {
            get { return _content; }
            set { _content = value; }
        }
        
        public String Raw
        {
            get { return _raw; }
            set { _raw = value; }
        }

        public String Mimetype
        {
            get { return _mimetype; }
            set { _mimetype = value; }
        }

        public List<Status> Timeline
        {
            get { return _timeline; }
            set { _timeline = value; }
        }
    }
}
