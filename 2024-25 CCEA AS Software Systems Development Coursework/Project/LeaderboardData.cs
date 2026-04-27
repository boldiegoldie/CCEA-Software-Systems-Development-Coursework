using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_25_CCEA_AS_Software_Systems_Development_Coursework
{
    [Serializable]
    internal class LeaderboardData
    {
        private string username;
        private double score;
        private int lifetimecorrect;
        private int lifetimeincorrect;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public double Score
        {
            get { return score; }
            set { score = value; }
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

        public LeaderboardData(string user_id_input, double score_input, int lifetimecorrect_input, int lifetimeincorrect_input)
        {
            this.username = user_id_input;
            this.score = score_input;
            this.lifetimecorrect = lifetimecorrect_input;
            this.lifetimeincorrect = lifetimeincorrect_input;
        }
    }
}
