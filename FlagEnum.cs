using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_kindergarten
{
    static public class GrabbarnasIP
    {
        public const string ipAddress = "172.20.1.10";
    }

    static public class LobbyFlags
    {
        public const string ADD_USER = "!";
        public const string REMOVE_USER = "@";
        public const string SERVER_STARTING = "#";
    }

    static public class Flags
    {
        // Requests
        public const string LOGIN_REQUEST =                 "A";
        public const string REGISTER_REQUEST =              "B";
        public const string VERIFY_REQUEST =                "C";
        public const string HOST_REQUEST =                  "D";
        public const string VIEW_HOSTS =                    "E";

        // Login
        public const string LOGIN_SUCCESSFUL =              "F";
        public const string LOGIN_FAILED =                  "G";
        public const string LOGIN_ALREADY_CONNECTED =       "H";
        public const string LOGIN_WRONG_PASSWORD =          "I";
        public const string USER_NOT_REGISTERED =           "J";
        public const string USER_NOT_VERIFIED =             "K";

        // Verification
        public const string USER_VERIFICATION_SUCCESS =     "L";
        public const string USER_VERIFICATION_FAILED =      "M";
            
            
        // Registration
        public const string USER_REGISTRATION_SUCCESS =     "P";
        public const string USER_REGISTRATION_FAILED =      "Q";
        public const string USER_NAME_NOT_AVAILABLE =       "R";

        // Hosting and serverfinding
        public const string HOST_SUCCESSFUL_REMOVE =        "S";
        public const string HOST_CREATION_SUCCESS =         "O";
        public const string FIND_SERVER_REQUEST =           "N";
    }
}
