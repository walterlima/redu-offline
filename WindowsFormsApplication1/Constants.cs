using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReduOffline
{
    public class Constants
    {
        public static String _consumerKey = "iXL5orXjX9VOP6DW7c9xvqJ74kkMNh7mFQcCB0Rp";
        public static String _consumerSecret = "depNX2Ypp1bpFG7x5BeBGxNc9QRHN4metGuCBR35";
        public static String _grant_type = "authorization_code";
        public static String XML_CONFIG_FOLDER = Path.GetDirectoryName(Application.ExecutablePath) + "\\config";
        public static String XML_USER_CONFIG_FOLDER = XML_CONFIG_FOLDER + "\\user_config.xml";
        public static String XML_USER_FOLDER = XML_CONFIG_FOLDER + "\\users";
        public static String XML_TIMELINE_FOLDER = XML_USER_FOLDER + "\\timeline";
        public static String XML_AVAS_FOLDER = XML_CONFIG_FOLDER + "\\avas";                
        public static String XML_USER_THUMBNAIL_FOLDER = XML_USER_FOLDER + "\\{0}-thumbnails";
        public static String XML_AVA_THUMBNAIL_FOLDER = XML_AVAS_FOLDER + "\\{0}-thumbnails";
        public static String XML_USER_TIMELINE_PATH = XML_TIMELINE_FOLDER + "\\{0}-timeline.xml";
        public static String AUTHORIZE_URL = "http://www.redu.com.br/oauth/authorize?client_id={0}";
        public static String ACCESS_TOKEN_URL = "http://www.redu.com.br/oauth/token?code={0}&client_id={1}&client_secret={2}&grant_type={3}";

        public static String XML_AVA_FOLDER = XML_AVAS_FOLDER + "\\{0}";
        public static String XML_COURSE_FOLDER = XML_AVA_FOLDER + "\\{1}";
        public static String XML_SPACE_FOLDER = XML_COURSE_FOLDER + "\\{2}";
        public static String XML_SUBJECT_FOLDER = XML_SPACE_FOLDER + "\\{3}";
        public static String XML_LECTURE_FOLDER = XML_SUBJECT_FOLDER;

        public static String XML_AVA_PATH = XML_AVA_FOLDER + "\\ava-{1}.xml";//ava_name\ava_id.xml
        public static String XML_COURSE_PATH = XML_COURSE_FOLDER + "\\course-{2}.xml";//ava_name\course_name\course_id.xml
        public static String XML_SPACE_PATH = XML_SPACE_FOLDER + "\\space-{3}.xml";//ava_name\course_name\space_name\space_id.xml
        public static String XML_SUJECT_PATH = XML_SUBJECT_FOLDER + "\\subject-{4}.xml"; //ava_name\course_name\space_name\suject_name\suject_name.xml
        public static String XML_LECTURE_PATH = XML_LECTURE_FOLDER + "\\lecture-{4}.xml";//ava_name\course_name\space_name\suject_name\lecture_id.xml
        //public static String XML_LECTURE_DATA_PATH = XML_LECTURES_FOLDER + 

        public static String URL_FEED_USER = "/users/{0}/statuses/timeline?types[]=Activity&types[]=Help";

        public static String BASE_URL = "http://www.redu.com.br/api/";
        public static String USER_URL = "user/";

        public static String REL_ENVIRONMENT = "environment";
        public static String REL_COURSES = "courses";
        public static String REL_COURSE = "course";
        public static String REL_SPACE = "spaces";
        public static String REL_SUBJECT = "subjects";
        public static String REL_LECTURE = "lectures";
        public static String REL_IN_RESPONSE_TO = "in_response_to";
        public static String REL_STATUSABLE = "statusable";
        public static String REL_ENROLLMENTS = "enrollments";
        public static String REL_TIMELINE = "timeline";
        public static String REL_SELF = "self";

        public static String TYPE_CANVAS = "Canvas";
        public static String TYPE_DOCUMENT = "Document";
        public static String TYPE_MEDIA = "Media";
        public static String TYPE_PAGE = "Page";
        public static String TYPE_EXERCISE = "Exercise";

        public static String REL_RAW = "raw";
        public static String REL_SCRIBD = "scribd";

        public static String STATUS_ACTIVITY = "Activity";
        public static String STATUS_HELP = "Help";
        public static String STATUS_ANSWER = "Answer";
        public static String STATUS_LOG = "Log";

        public static String LINK_USER = "user";
        public static String LINK_ANSWERS = "answers";
        public static String LINK_STATUSABLE = "statusable";
        public static String LINK_IN_RESPONSE_TO = "in_response_to";
        public static String LINK_SELF = "self";
    }
}
