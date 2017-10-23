using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _10366827
{
    public class BetTestData
    {
        private static Regex betTestDataRegex = null;

        //  Used for parsing a line from the test data resource
        private static Bet ParseTestDataLine(string s)
        {
            if (betTestDataRegex == null)
                betTestDataRegex = new Regex(ConfigurationManager.AppSettings["testBetDataValuePattern"]);

            MatchCollection matches = betTestDataRegex.Matches(s);
            if (matches.Count != 6)
                return null;

            return
                new Bet()
                {
                    TrackName = matches[0].Value,
                    Date = new DateTime(int.Parse(matches[1].Value), int.Parse(matches[2].Value), int.Parse(matches[3].Value)),
                    Money = decimal.Parse(matches[4].Value.TrimEnd('m')),
                    Win = bool.Parse(matches[5].Value)
                };
        }

        //  Get Test Data
        public static IList<Bet> GetHotTipsterTestData()
        {
            List<Bet> bets = new List<Bet>();

            //  Parse demo data into Bet objects
            using (StringReader reader = new StringReader(Properties.Resources.init_data))
            {
                while (reader.Peek() != -1)
                {
                    Bet bet = ParseTestDataLine(reader.ReadLine());
                    if (bet != null)
                        bets.Add(bet);
                }

                betTestDataRegex = null;
            }

            return bets;
        }
    }
}
