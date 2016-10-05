using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MunzeeInMap.MunzeeAppObjects
{
    public class AuthorizeObject
    {
        public TokenWrapper data;
        public int status_code;
        public string status_text;
        public double executed_in;
        public string authenticated_entity;
        public string authenticated_entity_type;
        public List<string> allowed_scopes;
        public string server;
    }

    public class TokenWrapper
    {
        public Token token;
        public int user_id;
    }

    public class Token
    {
        public string access_token;
        public string token_type;
        public long expires;
        public long expires_in;
        public string refresh_token;
    }

    public class MunzeeById
    {
        public Data data;
        public int status_code;
        public string status_text;
        public double executed_in;
        public string authenticated_entity;
        public string authenticated_entity_type;
        public List<string> allowed_scopes;
        public string server;
    }

    public class MunzeeLogs
    {
        public List<Log> data;
    }

    public class Log
    {
        public string username;
        public string user_id;
        public string created_at;
        public string notes;
        public string type_name;
        public string type_id;
        public string entry_at; //: "2013-12-29T15:00:37-06:00",
        public string entry_id;
        public long entry_at_unix;
        public string type;
    }

    public class PlayerInfo
    {
        public Player data;
    }

    public class Player
    {
        public string username;
        public int user_id;
        public int number_of_captures;
        public int number_of_deployments;
        public int number_of_undeployments;
        public int number_of_archived;
        public int number_of_badges;
        public string hash;
        public int premium;
        public int level;
        public int rank;
        public int points;
        public string join_time; //": "2011-04-10T23:11:33-05:00",
        public int days_old;
        public string premium_expires;
        public PlayerClan clan;
        public string location;
    }

    public class PlayerClan
    {

        public int id;
        public string name;
        public string url;
        public string logo;
        public int rank;
        public int total_clans;
    }

    public class DailyPlayerStats
    {
        public PlayerStats data;
    }

    public class PlayerStats
    {
        public List<Capture> captures;
        public List<CaptureOn> captures_on;
        public List<Deploy> deploys;
        public List<Archive> archived; // todo
        public long total_points;
        public int level;
    }

    public class Capture
    {
        public string captured_at;
        public string points;
        public string code;
        public string friendly_name;
        public string capture_type_id;
        public string username;
        public string pin;
    }

    public class CaptureOn
    {
        public string captured_at;
        public string points_for_creator;
        public string points;
        public string code;
        public string friendly_name;
        public string capture_type_id;
        public string username;
        public string pin;
    }

    public class Deploy
    {
        public string deployed_at;
        public string points;
        public string code;
        public string friendly_name;
        public string capture_type_id;
        public string pin;
    }

    public class Archive
    {
        public string code;
        public string friendly_name;
        public string archived_at;
    }

    public class Data
    {
        // datumy ve formátu : "2015-02-02T00:50:12-06:00"
        public int munzee_id;
        public string friendly_name;
        public int number_of_captures;
        public int points;
        public string latitude;
        public string longitude;
        public int deployed;
        public int archived;
        public string archived_at;
        public string deployed_at;
        public string notes;
        public string motel_id;
        public string hotel_id;
        public List<Rovers> rovers;
        public int creator_user_id;
        public string creator_username;
        public string creator_userhash;
        public string url;
        public string code;
        public string generic_code;
        public int has_user_captured_munzee;
        public int has_user_subscribed_munzee;
        public string last_updated_at;
        public int number_of_entries;
        public string pin_icon;
        public string capture_type_id;
        public List<Closest> closest;
    }

    public class Closest
    {
        public string munzee_id;
        public string friendly_name;
        public string capture_type_id;
        public string code;
        public string munzee_logo; //": null,
        public string distance;
        public string pin_icon;
    }

    public class Rovers
    {
    }

    public class TypesStats
    {
        public TypesStatsInfo data;

    }

    public class TypesStatsInfo
    {
        public List<MunzeeTypes> types;
        public int total_points;

    }

    public class MunzeeTypes
    {
        public string captures;
        public string points;
        public string average;
        public string capture_type_id;
        public string name;
    }

    public class TypesDeployStats
    {
        public TypesDeployStatsInfo data;
    }

    public class TypesDeployStatsInfo
    {
        public List<MunzeeTypes> types;
        public int total_points;

    }

    public class MunzeeDeployTypes
    {
        public string munzees;
        public string points;
        public string capture_type_id;
        public string name;
        public string captures;
        public string cap_on_points;
        public string combined_points;
    }

    public class GlobalLeader
    {
        public List<Global> data;
    }

    public class Global
    {
        public string user_id;
        public string username;
        public string score;
        public int global_rank;
        public string hash;
        public string user_image;
        public int level;
        public int number_of_first_to_captured;
        public int number_of_captured;
        public int number_of_deployed;
        public int number_of_special_munzees_captured;
    }

    public class DayStats
    {
        public DateTime Day;
        public int Number;
    }

    public class RangeLeader
    {
        public List<SimplePlayerStats> data;
    }

    public class SimplePlayerStats
    {
        public int userid;
        public string username;
        public string score_in_range;
        public string hash;
    }

    public class BoundingObjects
    {
        public List<BoundingBox> data;
    }

    public class BoundingBox
    {
        public string key;
        public List<BoxMunzee> munzees;
        public long last_updated_at;
        public int count;
    }

    public class BoxMunzee
    {
        public string munzee_id; //
        public string friendly_name; // //
        public string notes; //
        public int creator_user_id;
        public string creator_username; // //
        public int number_of_captures; //
        public int has_user_captured_munzee; //
        public int owned_by_user;
        public int maintenance; //
        public string latitude; //
        public string longitude; //
        public int deployed; //
        public string deployed_at; //
        public int archived; //
        public string last_captured_at; //
        public string original_pin_image;
        public string proximity_radius_ft; //
        public string last_updated_at; //
        public string capture_type_id; //
        public int is_virtual; //
        public string code; //

        public string type_name //
        {
            get { return GetMunzeeTypeName(); }
        }

        private string GetMunzeeTypeName()
        {
            int i;
            int.TryParse(capture_type_id, out i);

            switch (i)
            {
                case 0:
                    return "Normal Munzee";
                case 1:
                    return "Mystery Munzee";
                case 2:
                    return "Business Munzee";
                case 3:
                    return "Virtual Munzee";
                case 4:
                    return "Premium Munzee";
                case 6:
                    return "NFC Munzee";
                case 32:
                    return "Social Munzee";
                case 40:
                    return "Diamond Munzee";
                case 52:
                    return "Mace Munzee";
                case 53:
                    return "Longsword Munzee";
                case 70:
                    return "Motel Munzee";
                case 71:
                    return "Motel Room";
                case 76:
                    return "Mustache";
                case 80:
                    return "Mystery Virtual";
                case 103:
                    return "Virtual Red";
                case 104:
                    return "Virtual Orange";
                case 105:
                    return "Virtual Yellow";
                case 106:
                    return "Virtual Green";
                case 107:
                    return "Virtual Blue";
                case 108:
                    return "Virtual Indigo";
                case 109:
                    return "Virtual Violet";
                case 110:
                    return "Virtual Black";
                case 111:
                    return "Virtual Brown";
                case 112:
                    return "Virtual Rainbow";
                case 113:
                    return "Virtual Mystery Red";
                case 114:
                    return "Virtual Mystery Orange";
                case 115:
                    return "Virtual Mystery Yellow";
                case 116:
                    return "Virtual Mystery Green";
                case 117:
                    return "Virtual Mystery Indigo";
                case 118:
                    return "Virtual Mystery Violet";
                case 119:
                    return "Virtual Mystery Black";
                case 120:
                    return "Virtual Mystery Brown";
                case 121:
                    return "Virtual Mystery Rainbow";
                case 123:
                    return "RMH Virtual";
                case 131:
                    return "Ruby Munzee";
                case 140:
                    return "Battle Axe Munzee";
                case 146:
                    return "Ice Bucket";
                case 148:
                    return "Virtual Emerald";
                case 170:
                    return "Hotel Munzee";
                case 171:
                    return "Hotel Room";
                case 190:
                    return "Trail Munzee";
                case 196:
                    return "2015 Heart yellow";
                case 197:
                    return "2015 Heart green";
                case 198:
                    return "2015 Heart orange";
                case 199:
                    return "2015 Heart pink";
                case 218:
                    return "Aquamarine";
                case 220:
                    return "Sillyman";
                case 242:
                    return "Topaz Munzee";
                case 250:
                    return "Accessibility Munzee";
                default :
                    return "Unknown";
            }
        }
    }
}