using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10366827
{
    public class ReportGenerator
    {
        public static int CountTotalWins(IEnumerable<Bet> bets)
        {
            if (NullOrEmpty(bets))
                return 0;

            int totalWins =
                (from bet in bets
                 where bet.Win == true
                 select bet).Count();

            return totalWins;
        }

        public static SuccessRateReport GenerateSuccessRateReport(ICollection<Bet> bets)
        {
            if (NullOrEmpty(bets))
                return new SuccessRateReport() { TotalWins = 0, TotalBets = 0, SuccessRate = "" };

            int totalWins = CountTotalWins(bets);
            double successRate = Math.Round((((double)totalWins / bets.Count) * 100), 2);

            return new SuccessRateReport()
                        {
                            TotalWins = totalWins,
                            TotalBets = bets.Count,
                            SuccessRate = successRate + "%"
                        };
        }
        
        public static Bet GetLargestBetWon(IEnumerable<Bet> bets)
        {
            if (NullOrEmpty(bets))
                return null;

            return
                (from bet in bets
                 where bet.Win == true
                 orderby bet.Money descending
                 select bet).FirstOrDefault();
        }

        public static Bet GetLargestBetLost(IEnumerable<Bet> bets)
        {
            if (NullOrEmpty(bets))
                return null;

            return
                (from bet in bets
                 where bet.Win == false
                 orderby bet.Money descending
                 select bet).FirstOrDefault();
        }

        public static IEnumerable<Bet> GetBetsOrderedByDate(IEnumerable<Bet> bets)
        {
            if (NullOrEmpty(bets))
                return null;

            return
                (from bet in bets
                 orderby bet.Date descending
                 select bet);
        }

        public static IEnumerable<Bet> GetBetsOrderedByTrackName(IEnumerable<Bet> bets)
        {
            if (NullOrEmpty(bets))
                return null;

            return
                (from bet in bets
                 orderby bet.TrackName ascending
                 select bet);
        }

        public static IEnumerable<Bet> GetBetsOrdersByMoney(IEnumerable<Bet> bets)
        {
            if (NullOrEmpty(bets))
                return null;

            return
                (from bet in bets
                 orderby bet.Money descending
                 select bet);
        }

        public static IEnumerable<Bet> GetBetsOrdersByWinning(IEnumerable<Bet> bets)
        {
            if (NullOrEmpty(bets))
                return null;

            return
                (from bet in bets
                 orderby bet.Win descending
                 select bet);
        }

        public static MostPopularRaceTrackReport FindMostPopularRaceTrack(IEnumerable<Bet> bets)
        {
            if (NullOrEmpty(bets))
                return null;

            var trackCounts = from bet in bets
                              group bet by new { TrackName = bet.TrackName } into betGroup
                              select new { TrackName = betGroup.Key.TrackName, Count = betGroup.Count() };

            var result = trackCounts.OrderByDescending(x => x.Count).FirstOrDefault();


            return new MostPopularRaceTrackReport(){
                TrackName = result.TrackName,
                NumberOfBetsPlaced = result.Count
            };
        }

        public static List<YearStatistics> GenerateYearlyStatisticsReport(IEnumerable<Bet> bets)
        {
            if (NullOrEmpty(bets))
                return new List<YearStatistics>();

            return
                (from bet in bets
                 orderby bet.Date.Year
                 group bet by bet.Date.Year into betGroup
                 select new YearStatistics()
                 {
                     Year = betGroup.Key,
                     TotalWon = betGroup.Where(x => x.Win).Sum(x => x.Money),
                     TotalLost = betGroup.Where(x => !x.Win).Sum(x => x.Money)
                 }).ToList();
        }
        
        //  Check if enumeration is null or empty
        private static bool NullOrEmpty<Bet>(IEnumerable<Bet> bets)
        {
            return bets == null || !bets.Any();
        }
    }
}
