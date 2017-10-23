using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _10366827
{
    [Serializable]
    public class Bet: IEquatable<Bet>
    {
        private static Regex _trackRegex, _moneyRegex;
        
        public string TrackName { get; set; }
        public DateTime Date { get; set; }
        public decimal Money { get; set; }
        public bool Win { get; set; }

        public Bet()
        {
        }

        public Bet(string track, DateTime date, decimal money, bool _win)
        {
            TrackName = track;
            Date = date;
            Money = money;
            Win = _win;
        }

        public static bool IsValidMoney(decimal money)
        {
            if (money <= 0)
                return false;

            if (_moneyRegex == null)
                _moneyRegex = new Regex(@"^[0-9]+([.][0-9]{2})?$");

            return _moneyRegex.IsMatch(money.ToString());
        }
        
        public static bool IsValidTrackName(string track)
        {
            if (string.IsNullOrWhiteSpace(track))
                return false;

            if (_trackRegex == null)
                _trackRegex = new Regex(@"^([A-Za-z\b]+[\'\,]?[\s]?[\.]?)+$");
            //_trackRegex = new Regex(@"^([A-Za-z\']+[\s]?[A-Za-z\']+)+$");

            return _trackRegex.IsMatch(track);
        }

        public static bool IsValid(Bet b)
        {
            if (b.TrackName == null || b.Money <= 0 || b.Date == null)
                return false;

            return IsValidTrackName(b.TrackName);
        }

        public override string ToString()
        {
            return $"Track: {TrackName, -20} Amount: {Money, -20} Won: {Win, -20} Date: {Date.ToShortDateString(), -20}";
        }

        public bool Equals(Bet other)
        {
            if (other == null)
                return false;

            return TrackName == other.TrackName && Date == other.Date && Win == other.Win && Money == other.Money;
        }
    }
}
