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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReduOffline
{
    /// <summary>
    /// Holds all the constants used in the program
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// OAuth consumer key
        /// </summary>
        public const String _consumerKey = "iXL5orXjX9VOP6DW7c9xvqJ74kkMNh7mFQcCB0Rp";
        /// <summary>
        /// OAuth consumer secret
        /// </summary>
        public const String _consumerSecret = "depNX2Ypp1bpFG7x5BeBGxNc9QRHN4metGuCBR35";
        public const String _grant_type = "authorization_code";

        //XML folders
        public static String XML_CONFIG_FOLDER = Path.GetDirectoryName(Application.ExecutablePath) + "\\config";
        public static String XML_CONFIG_PATH = XML_CONFIG_FOLDER + "\\app_config.xml";
        public static String XML_USER_CONFIG_FOLDER = XML_CONFIG_FOLDER + "\\user_config.xml";        
        public static String XML_USER_FOLDER = XML_CONFIG_FOLDER + "\\users";
        public static String XML_AVAS_FOLDER = XML_CONFIG_FOLDER + "\\avas";
        public static String XML_COURSES_FOLDER = XML_CONFIG_FOLDER + "\\courses";
        public static String XML_SPACES_FOLDER = XML_CONFIG_FOLDER + "\\spaces";
        public static String XML_SUBJECTS_FOLDER = XML_CONFIG_FOLDER + "\\subjects";
        public static String XML_LECTURES_FOLDER = XML_CONFIG_FOLDER + "\\lectures";
        public static String XML_USER_THUMBNAIL_FOLDER = XML_USER_FOLDER + "\\{0}-thumbnails";
        public static String XML_AVA_THUMBNAIL_FOLDER = XML_AVAS_FOLDER + "\\{0}-thumbnails";
        public static String XML_PENDING_ACTIVITY_PATH = XML_CONFIG_FOLDER + "\\pending_activities.xml";
        
        //URLs for authorization
        public const String AUTHORIZE_URL = "http://www.redu.com.br/oauth/authorize?client_id={0}";
        public const String ACCESS_TOKEN_URL = "http://www.redu.com.br/oauth/token?code={0}&client_id={1}&client_secret={2}&grant_type={3}";

        //XML paths for querying database
        public static String XML_USER_PATH = XML_USER_FOLDER + "\\{0}.xml";
        public static String XML_AVA_PATH = XML_AVAS_FOLDER + "\\{0}.xml";
        public static String XML_COURSE_PATH = XML_COURSES_FOLDER + "\\{0}.xml";
        public static String XML_SPACE_PATH = XML_SPACES_FOLDER + "\\{0}.xml";
        public static String XML_SUJECT_PATH = XML_SUBJECTS_FOLDER + "\\{0}.xml";
        public static String XML_LECTURE_PATH = XML_LECTURES_FOLDER + "\\{0}.xml";
        //public  const String XML_LECTURE_DATA_PATH = XML_LECTURES_FOLDER + 

        public static String XML_USER_TIMELINE_FOLDER = XML_USER_FOLDER + "\\timeline";
        public static String XML_USER_TIMELINE_PATH = XML_USER_TIMELINE_FOLDER + "\\{0}-timeline.xml";
        public static String XML_SPACE_TIMELINE_PATH = XML_SPACES_FOLDER + "\\{0}-timeline.xml";
        public static String XML_LECTURE_TIMELINE_PATH = XML_LECTURES_FOLDER + "\\{0}-timeline.xml";

        //API URLs for interacting with Redu
        public const String URL_FEED_USER = "/users/{0}/statuses/timeline?types[]=Activity&types[]=Help";
        public const String URL_UPDATE_FEED_USER = "/users/{0}/statuses/timeline?types[]=Activity&types[]=Help&page={1}";
        public const String POST_USER_FEED_URL = "/users/{0}/statuses";
        public const String POST_SPACE_FEED_URL = "/spaces/{0}/statuses";
        public const String POST_LECTURE_FEED_URL = "/lectures/{0}/statuses";
        public const String POST_STATUS_ANSWER_URL = "/statuses/{0}/answers";

        public static String URL_DEFAULT_THUMBNAIL_USER_32 = XML_CONFIG_FOLDER + "\\" + "missing_users_thumb_32.png";

        public const String BASE_URL = "http://www.redu.com.br/api/";
        public const String USER_URL = "user/";

        //General data keyword for ensuring proper standards
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
