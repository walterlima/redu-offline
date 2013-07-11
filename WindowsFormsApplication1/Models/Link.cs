using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduOffline.Models
{
    class Link
    {
        public static String REL_ENVIRONMENT = "environment";
	    public static String REL_COURSE = "course";
	    public static String REL_SPACE = "space";
	    public static String REL_SUBJECT = "subject";
	    public static String REL_LECTURE = "lecture";
	    public static String REL_IN_RESPONSE_TO = "in_response_to";
	    public static String REL_STATUSABLE = "statusable";

        public String Rel { get; set; }
        public String Href { get; set; }
        public String Name { get; set; }
        public String Permalink { get; set; }

    }
}
