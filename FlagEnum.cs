using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_kindergarten
{
    static public class GrabbarnasIP
    {
        public const string ipAddress = "172.20.1.59";
    }
        static public class Flags
        {
            public const string LOGIN_REQUEST =                 "A";
            public const string REGISTER_REQUEST =              "B";
            public const string VERIFY_REQUEST =                "C";
            public const string HOST_REQUEST =                  "D";
            public const string VIEW_HOSTS =                    "E";
            public const string LOGIN_SUCCESSFUL =              "F";
            public const string LOGIN_FAILED =                  "G";
            public const string LOGIN_ALREADY_CONNECTED =       "H";
            public const string LOGIN_WRONG_PASSWORD =          "I";
            public const string USER_NOT_REGISTERED =           "J";
            public const string USER_NOT_VERIFIED =             "K";
            public const string USER_VERIFICATION_SUCCESS =     "L";
            public const string USER_VERIFICATION_FAILED =      "M";
            public const string FIND_SERVER_REQUEST =           "N";
            public const string CREATE_SERVER_REQUEST =         "O";
            public const string USER_REGISTRATION_SUCCESS =     "P";
            public const string USER_REGISTRATION_FAILED =      "Q";
            public const string USER_NAME_NOT_AVAILABLE =       "R";
        }
}
