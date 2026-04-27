using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    public class Common_Variables
    {
        public static bool muted;
        public static string username = "";
        public static string difficulty = "n"; 
        public static int q_number = 1;
        public static double score = 0;
        public static int LifetimeCorrect = 0;
        public static int LifetimeIncorrect = 0;
        public static int DropLifeCorrect = 0;
        public static int DropLifeIncorrect = 0;
        public static int TorfLifeCorrect = 0;
        public static int TorfLifeIncorrect = 0;
        public static int MultiLifeCorrect = 0;
        public static int MultiLifeIncorrect = 0;
        public static int CheckLifeCorrect = 0;
        public static int CheckLifeIncorrect = 0;
        public static int BlankLifeCorrect = 0;
        public static int BlankLifeIncorrect = 0;
        public static List<string> UsedQuestions = new List<string>();
        public static string path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
        public static string UserData = (path + @"\assets\dat\UserData.dat");
        public static string LeaderboardData = (path + @"\assets\dat\LeaderboardData.dat");
        public static string ErrorLog = (path + @"\ErrorLogs\ErrorLog.txt");
        public static bool isAdmin = false;
        public static bool ReadQuestions = false;
        public static bool SkipEnd = false;
        public static bool dyslexia = false;
        public static string CurrentSection = "";
        public static string FileToBeViewed = "";
        public static string CurrentPage = "Multi";
        public static bool ExitEnd = false;
    }

    public class User_Settings
    {

    }
}