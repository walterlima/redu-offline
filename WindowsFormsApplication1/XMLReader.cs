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

        public User read_user_data()
        {
            
            return null;
        }

        public List<EnvironmentRedu> read_user_avas()
        {
            return null;
        }

        public EnvironmentRedu read_ava_data()
        {
            return null;
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
