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
        public const String _consumerKey = "iXL5orXjX9VOP6DW7c9xvqJ74kkMNh7mFQcCB0Rp";
        public const String _consumerSecret = "depNX2Ypp1bpFG7x5BeBGxNc9QRHN4metGuCBR35";
        public const String _grant_type = "authorization_code";

        public static String XML_CONFIG_FOLDER = Path.GetDirectoryName(Application.ExecutablePath) + "\\config";
        public static String XML_USER_CONFIG_FOLDER = XML_CONFIG_FOLDER + "\\user_config.xml";
        public static String XML_USER_FOLDER = XML_CONFIG_FOLDER + "\\users";
        public static String XML_AVAS_FOLDER = XML_CONFIG_FOLDER + "\\avas";
        public static String XML_USER_THUMBNAIL_FOLDER = XML_USER_FOLDER + "\\{0}-thumbnails";
        public static String XML_AVA_THUMBNAIL_FOLDER = XML_AVAS_FOLDER + "\\{0}-thumbnails";
        
        public const String AUTHORIZE_URL = "http://www.redu.com.br/oauth/authorize?client_id={0}";
        public const String ACCESS_TOKEN_URL = "http://www.redu.com.br/oauth/token?code={0}&client_id={1}&client_secret={2}&grant_type={3}";

        public static String XML_AVA_FOLDER = XML_AVAS_FOLDER + "\\{0}";
        public static String XML_COURSE_FOLDER = XML_AVA_FOLDER + "\\{1}";
        public static String XML_SPACE_FOLDER = XML_COURSE_FOLDER + "\\{2}";
        public static String XML_SUBJECT_FOLDER = XML_SPACE_FOLDER + "\\{3}";
        public static String XML_LECTURE_FOLDER = XML_SUBJECT_FOLDER + "\\{4}";

        public static String XML_USER_PATH = XML_USER_FOLDER + "\\{0}.xml"; //login.xml
        public static String XML_AVA_PATH = XML_AVA_FOLDER + "\\ava-{1}.xml";//ava_name\ava_id.xml
        public static String XML_COURSE_PATH = XML_COURSE_FOLDER + "\\course-{2}.xml";//ava_name\course_name\course_id.xml
        public static String XML_SPACE_PATH = XML_SPACE_FOLDER + "\\space-{3}.xml";//ava_name\course_name\space_name\space_id.xml
        public static String XML_SUJECT_PATH = XML_SUBJECT_FOLDER + "\\subject-{4}.xml"; //ava_name\course_name\space_name\suject_id\suject_id.xml
        public static String XML_LECTURE_PATH = XML_LECTURE_FOLDER + "\\lecture-{5}.xml";//ava_name\course_name\space_name\suject_id\lecture_id\lecture_id.xml
        //public  const String XML_LECTURE_DATA_PATH = XML_LECTURES_FOLDER + 

        public static String XML_USER_TIMELINE_FOLDER = XML_USER_FOLDER + "\\timeline";
        public static String XML_USER_TIMELINE_PATH = XML_USER_TIMELINE_FOLDER + "\\{0}-timeline.xml";
        public static String XML_SPACE_TIMELINE_PATH = XML_SPACE_FOLDER + "\\{3}-timeline.xml";
        public static String XML_LECTURE_TIMELINE_PATH = XML_LECTURE_FOLDER + "\\{5}-timeline.xml";

        public const String URL_FEED_USER = "/users/{0}/statuses/timeline?types[]=Activity&types[]=Help";
        public const String URL_UPDATE_FEED_USER = "/users/{0}/statuses/timeline?types[]=Activity&types[]=Help&page={1}";
        public const String POST_USER_FEED_URL = "/users/{0}/statuses";
        public const String POST_SPACE_FEED_URL = "/spaces/{0}/statuses";
        public const String POST_LECTURE_FEED_URL = "/lectures/{0}/statuses";
        public const String POST_STATUS_ANSWER_URL = "/statuses/{0}/answers";

        public static String URL_DEFAULT_THUMBNAIL_USER_32 = XML_CONFIG_FOLDER + "\\" + "missing_users_thumb_32.png";

        public const String BASE_URL = "http://www.redu.com.br/api/";
        public const String USER_URL = "user/";

        public const String REL_ENVIRONMENT = "environment";
        public const String REL_COURSES = "courses";
        public const String REL_COURSE = "course";
        public const String REL_SPACE = "spaces";
        public const String REL_SUBJECT = "subjects";
        public const String REL_LECTURE = "lectures";
        public const String REL_IN_RESPONSE_TO = "in_response_to";
        public const String REL_STATUSABLE = "statusable";
        public const String REL_ENROLLMENTS = "enrollments";
        public const String REL_TIMELINE = "timeline";
        public const String REL_SELF = "self";

        public const String TYPE_CANVAS = "Canvas";
        public const String TYPE_DOCUMENT = "Document";
        public const String TYPE_MEDIA = "Media";
        public const String TYPE_PAGE = "Page";
        public const String TYPE_EXERCISE = "Exercise";

        public const String REL_RAW = "raw";
        public const String REL_SCRIBD = "scribd";

        public const String STATUS_ACTIVITY = "Activity";
        public const String STATUS_HELP = "Help";
        public const String STATUS_ANSWER = "Answer";
        public const String STATUS_LOG = "Log";

        public const String STATUS_LECTURE = "Lecture";
        public const String STATUS_SPACE = "Space";
        public const String STATUS_USER = "User";

        public const String LINK_USER = "user";
        public const String LINK_ANSWERS = "answers";
        public const String LINK_STATUSABLE = "statusable";
        public const String LINK_IN_RESPONSE_TO = "in_response_to";
        public const String LINK_SELF = "self";
    }
}
