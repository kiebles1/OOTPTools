using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPDraft
{
    class Player
    {
        public string mName;
        public double mPotentialAvg;
        public int mScoutPotential;
        public int mOOTPPotential;

        private const double SCOUT_WEIGHT = 0.75;
        private const double OOTP_WEIGHT = 0.25;

        public Player(string pName, int pScoutPotential, int pOOTPPotential)
        {
            mName = pName;
            mPotentialAvg = GetPotentialAvg(pScoutPotential, pOOTPPotential);
            mOOTPPotential = pOOTPPotential;
            mScoutPotential = pScoutPotential;
            
        }

        static double GetPotentialAvg(int pScoutPotential, int pOOTPPotential)
        {
            double potentialAvg = ((double)pScoutPotential * 0.75 + (double)pOOTPPotential * 0.25) / (2);
            return potentialAvg;
        }

    }
}
