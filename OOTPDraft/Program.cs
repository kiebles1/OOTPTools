using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OOTPDraft
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader fStream = File.OpenText(@".\DraftData.csv");
            fStream.ReadLine();
            fStream.ReadLine();
            List <Player> lDraftList = new List<Player>();
            string[] lPlayerString = fStream.ReadLine().Split(',');
            while(!lPlayerString[14].Equals("")) {
                int lScoutPotential = int.Parse(lPlayerString[13][0].ToString());
                int lOOTPPotential = int.Parse(lPlayerString[14][0].ToString());
                lDraftList.Add(new Player(lPlayerString[3], lScoutPotential, lOOTPPotential));
                lPlayerString = fStream.ReadLine().Split(',');
            }
            lDraftList = lDraftList.OrderByDescending(p => p.mPotentialAvg).
                ThenByDescending(p => p.mScoutPotential).ToList();
            StreamWriter fOutStream = new StreamWriter(@".\DraftOutput.csv");
            foreach (Player p in lDraftList) {
                fOutStream.WriteLine(p.mName + "," + p.mPotentialAvg.ToString() + "," +
                    p.mScoutPotential.ToString() + "," + p.mOOTPPotential);
            }
            Console.Read();
            fStream.Close();
            fOutStream.Close();
        }
    }
}
