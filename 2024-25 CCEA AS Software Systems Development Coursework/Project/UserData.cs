using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    [Serializable]
    internal class UserData
    {
        private string user_id;
        private string passcode;
        private int lifetimecorrect;
        private int lifetimeincorrect;
        private int droplifecorrect;
        private int droplifeincorrect;
        private int torflifecorrect;
        private int torflifeincorrect;
        private int multilifecorrect;
        private int multilifeincorrect;
        private int checklifecorrect;
        private int checklifeincorrect;
        private int blanklifecorrect;
        private int blanklifeincorrect;
        private bool isAdmin;
        private bool readQuestions;
        private bool skipEnd;
        private bool dyslexia;

        public bool IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }

        public bool ReadQuestions
        {
            get { return readQuestions; }
            set { readQuestions = value; }
        }

        public bool SkipEnd
        {
            get { return skipEnd; }
            set { skipEnd = value; }
        }

        public bool Dyslexia
        {
            get { return dyslexia; }
            set { dyslexia = value; }
        }

        public string User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }
        public string Passcode
        {
            get { return passcode; }
            set { passcode = value; }
        }

        public int LifetimeCorrect
        {
            get { return lifetimecorrect; }
            set { lifetimecorrect = value; }
        }

        public int LifetimeIncorrect
        {
            get { return lifetimeincorrect; }
            set { lifetimeincorrect = value; }
        }

        public int DropLifeCorrect
        {
            get { return droplifecorrect; }
            set { droplifecorrect = value; }
        }

        public int DropLifeIncorrect
        {
            get { return droplifeincorrect; }
            set { droplifeincorrect = value; }
        }

        public int TorfLifeCorrect
        {
            get { return torflifecorrect; }
            set { torflifecorrect = value; }
        }

        public int TorfLifeIncorrect
        {
            get { return torflifeincorrect; }
            set { torflifeincorrect = value; }
        }

        public int MultiLifeCorrect
        {
            get { return multilifecorrect; }
            set { multilifecorrect = value; }
        }

        public int MultiLifeIncorrect
        {
            get { return multilifeincorrect; }
            set { multilifeincorrect = value; }
        }

        public int CheckLifeCorrect
        {
            get { return checklifecorrect; }
            set { checklifecorrect = value; }
        }

        public int CheckLifeIncorrect
        {
            get { return checklifeincorrect; }
            set { checklifeincorrect = value; }
        }

        public int BlankLifeCorrect
        {
            get { return blanklifecorrect; }
            set { blanklifecorrect = value; }
        }

        public int BlankLifeIncorrect
        {
            get { return blanklifeincorrect; }
            set { blanklifeincorrect = value; }
        }

        public string FileName = "UserData.dat";

        public UserData()
        {

        }

        public UserData(string user_id_input, string passcode_input, int lifetimecorrect_input, int lifetimeincorrect_input, int droplifecorrect_input, int droplifeincorrect_input, int torflifecorrect_input, int torflifeincorrect_input, int multilifecorrect_input, int multilifeincorrect_input, int checklifecorrect_input, int checklifeincorrect_input, int blanklifecorrect_input, int blanklifeincorrect_input)
        {
            this.user_id = user_id_input;
            this.passcode = passcode_input;
            this.lifetimecorrect = lifetimecorrect_input;
            this.lifetimeincorrect = lifetimeincorrect_input;
            this.droplifecorrect = droplifecorrect_input;
            this.droplifeincorrect = droplifeincorrect_input;
            this.torflifecorrect = torflifecorrect_input;
            this.torflifeincorrect = torflifeincorrect_input;
            this.multilifecorrect = multilifecorrect_input;
            this.multilifeincorrect = multilifeincorrect_input;
            this.checklifecorrect = checklifecorrect_input;
            this.checklifeincorrect = checklifeincorrect_input;
            this.blanklifecorrect = blanklifecorrect_input;
            this.blanklifeincorrect = blanklifeincorrect_input;
        }

        public UserData(string user_id_input, string passcode_input)
        {
            this.user_id = user_id_input;
            this.passcode = passcode_input;
            this.lifetimecorrect = 0;
            this.lifetimeincorrect = 0;
            this.droplifecorrect = 0;
            this.droplifeincorrect = 0;
            this.torflifecorrect = 0;
            this.torflifeincorrect = 0;
            this.multilifecorrect = 0;
            this.multilifeincorrect = 0;
            this.checklifecorrect = 0;
            this.checklifeincorrect = 0;
            this.blanklifecorrect = 0;
            this.blanklifeincorrect = 0;
            this.skipEnd = false;
            this.isAdmin = false;
            this.readQuestions = false;
            this.dyslexia = false;
        }

        public class NoNumberEx : Exception
        {
            public NoNumberEx(string message) : base(message) { }
        }

        public class NotMixedEx : Exception
        {
            public NotMixedEx(string message) : base(message) { }
        }

        public class NoSpecialEx : Exception
        {
            public NoSpecialEx(string message) : base(message) { }
        }

        public class TooShortEx : Exception
        {
            public TooShortEx(string message) : base(message) { }
        }

        public class NoPasswordEx : Exception
        {
            public NoPasswordEx(string message) : base(message) { }
        }

        public class NoUsernameEx : Exception
        {
            public NoUsernameEx(string message) : base(message) { }
        }

        public class UsrSymbolEx : Exception
        {
            public UsrSymbolEx(string message) : base(message) { }
        }

        public class UsrTooShortEx : Exception
        {
            public UsrTooShortEx(string message) : base(message) { }
        }

        public class NoConfirmEx : Exception 
        {
            public NoConfirmEx(string message) : base(message) { }
        }

        public class UsrnameTakenEx : Exception
        {
            public UsrnameTakenEx(string message) : base(message) { }
        }

        private static readonly Regex sWhitespace = new Regex(@"\s+");
        public static string ReplaceWhitespace(string input)
        {
            return sWhitespace.Replace(input, string.Empty);
        }
    }
}
