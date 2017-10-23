using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Threading;

namespace _10366827
{
    public class PrototypeIgnore
    {
        static string _betsFilePath = null;

        static List<Bet> _bets = null;
        static Regex _betRegex = null;


        static readonly string OutputSeperator =
            $"{Environment.NewLine}======================================================================================================{Environment.NewLine}";

        static void Main(string[] args)
        {
            try
            {
                string _dataDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "data");
                _betsFilePath = Path.Combine(_dataDirectoryPath, "bets.bin");

                if (!Directory.Exists(_dataDirectoryPath))
                {
                    Directory.CreateDirectory(_dataDirectoryPath);
                    InitializeBinaryFile();
                }
                else if (!File.Exists(_betsFilePath))
                {
                    InitializeBinaryFile();
                }

                _dataDirectoryPath = null;
                _bets = DeserializeBinaryFile();

                Console.WriteLine($"Welcome to HotTipster!{Environment.NewLine}Total Recorded Bets: {_bets.Count}");
                PrintSeperator();

                do
                {
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1. Record a bet");
                    Console.WriteLine("2. Generate a report");
                    Console.WriteLine("3. Quit");
                    int choice;
                    while (!int.TryParse(Console.ReadLine(), out choice) || !(choice > 0 && choice < 4))
                        Console.WriteLine("Please enter a valid numerical value between 1 and 3.");
                    PrintSeperator();
                    switch (choice)
                    {
                        case 1:
                            Bet newBet = CreateNewBetFromUserInput();
                            AddBet(newBet);
                            PrintSeperator();
                            break;
                        case 2:
                            Console.WriteLine("What report would you like to display?");
                            Console.WriteLine("1. Yearly Statistics");
                            Console.WriteLine("2. Most Popular Track");
                            Console.WriteLine("3. Bets Ordered By Date");
                            Console.WriteLine("4. Show Highest Amount Won, and Highest Amount Lost");
                            Console.WriteLine("5. BetTipster Success Rate");
                            Console.WriteLine("6. Return To Main Menu");
                            while (!int.TryParse(Console.ReadLine(), out choice) || !(choice >= 1 && choice <= 6))
                                Console.WriteLine("Please enter a valid numerical value between 1 and 6.");

                            PrintSeperator();
                            switch (choice)
                            {
                                case 1:
                                    DisplayYearlyStatisticsReport();
                                    break;
                                case 2:
                                    DisplayMostPopularRaceTrackReport();
                                    break;
                                case 3:
                                    DisplayBetsOrderedByDateReport();
                                    break;
                                case 4:
                                    DisplayHighestAmountWonAndLostReport();
                                    break;
                                case 5:
                                    DisplayHotTipsterSuccessRateReport();
                                    break;
                                case 6:
                                    break;

                                default:
                                    break;
                            }
                            PrintSeperator();

                            break;
                        case 3:
                            Console.WriteLine("Goodbye...");
                            Thread.Sleep(1000);
                            return;

                        default:
                            break;
                    }
                } while (true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static int CountTotalWins()
        {
            int totalWins =
                (from bet in _bets
                 where bet.Win == true
                 select bet).Count();

            return totalWins;
        }

        private static void DisplayHotTipsterSuccessRateReport()
        {
            if (_bets.Count == 0)
            {
                Console.WriteLine("No bets recorded.");
                return;
            }

            int totalWins = CountTotalWins();

            double successRate = Math.Round((((double)totalWins / _bets.Count)*100), 2);

            Console.WriteLine($"Total Bets: {_bets.Count}{Environment.NewLine}Total Successes: {totalWins}{Environment.NewLine}Success Rate: {successRate}%");
        }

        public static Bet GetLargestBetWin()
        {
            Bet largestWin =
                (from bet in _bets
                 where bet.Win == true
                 orderby bet.Money descending
                 select bet).FirstOrDefault();

            return largestWin;
        }

        public static Bet GetLargestBetLoss()
        {
            Bet largestLoss =
                (from bet in _bets
                 where bet.Win == false
                 orderby bet.Money descending
                 select bet).FirstOrDefault();

            return largestLoss;
        }

        static void DisplayHighestAmountWonAndLostReport()
        {
            if(_bets.Count == 0)
            {
                Console.WriteLine("No bets recorded.");
                return;
            }

            var largestWin = GetLargestBetWin();
            var largestLoss = GetLargestBetLoss();
            
            Console.WriteLine(largestWin.ToString());
            Console.WriteLine(largestLoss.ToString());
        }

        public static IEnumerable<Bet> GetBetsOrderedByDate()
        {
            IEnumerable<Bet> result =
                from bet in _bets
                orderby bet.Date descending
                select bet;

            return result;
        }

        private static void DisplayBetsOrderedByDateReport()
        {
            var result = GetBetsOrderedByDate();

            foreach(var bet in result)
            {
                Console.WriteLine(bet.ToString());
            }
        }

        static void DisplayMostPopularRaceTrackReport()
        {
            //var result = _bets.GroupBy(x => x.Track).OrderByDescending(x => x.Count());
            //var result =

            //    _bets.OrderBy(x => x.Track).Select(x => new
            //    {
            //        TrackName = x.
            //    });


            //    (from bet in _bets
            //     orderby bet.Track).Select(x => new
            //     {
            //         TrackName = x.Key,
            //         Count = x.Select(b => b.Track).Distinct().Count()
            //     });

            //select new(
            //{
            //    Trackname = bet.Track,
            //    Count = x.Select(b => b.Track).Distinct().Count()
            //});

            //var result =
            //    //_bets.GroupBy(x => x.Track)
            //    _bets.Select(x => new
            //    {
            //        TrackName = x.Key,
            //        Count = x.Select(b => b.Track).Distinct().Count()
            //    });


            //group bet by bet.Track into trackGroup
            //select new
            //{
            //    Trackname = trackGroup.Key
            //};

            var trackCounts = from bet in _bets
                              group bet by new { TrackName = bet.TrackName } into betGroup
                              select new { TrackName = betGroup.Key.TrackName, Count = betGroup.Count() };

            var result = trackCounts.OrderByDescending(x => x.Count).FirstOrDefault();

            if (result != null)
                Console.WriteLine("Most popular track: " + result.TrackName + Environment.NewLine + "Total Bets Placed: " + result.Count);
            else
                Console.WriteLine("No Tracks Recorded.");
        }

        static void DisplayYearlyStatisticsReport()
        {
            var yearlyStats =
                from bet in _bets
                orderby bet.Date.Year
                group bet by bet.Date.Year into betGroup
                select new
                {
                    Year = betGroup.Key,
                    TotalWon = betGroup.Where(x => x.Win).Sum(x => x.Money),
                    TotalLost = betGroup.Where(x => !x.Win).Sum(x => x.Money)
                };

            //char euro = '€';
            //string e = Encoding.Default.GetString(new byte[] { 128 });
            //Console.OutputEncoding = Encoding.Default;
            //Console.WriteLine(e);
            //Console.OutputEncoding = Encoding.UTF32;
            //string euro = Char.ConvertFromUtf32(8364);
            //string euro = "€";
            //  Can't be done in application; console font must be changed by user.
            Console.WriteLine($"{"Year", -20}{"Total Won(euro)", -20}{"Total Lost(euro)", -20}");
            foreach (var yearStats in yearlyStats)
                Console.WriteLine($"{yearStats.Year, -20}{yearStats.TotalWon, -20}{yearStats.TotalLost, -20}");
        }

        //delegate bool UserInputValidationDelegate(string input);
        
        static void ValidateUserInput<T>(string output_text, string error_output_text, Func<string, bool> validationCondition)
        {
            Console.Write(output_text);
            string input = ReadInputAndTrim();
            while (!validationCondition(input))
            {
                Console.Write(error_output_text);
                input = ReadInputAndTrim();
            }
        }

        static Bet CreateNewBetFromUserInput()
        {
            Bet newBet = new Bet();
            string trackName = default(string);
            ValidateUserInput<string>(
                    "Enter Trackname: ",
                    $"Input  invalid. Letters, apostrophe, and single spaces only.Leading and trailing whitespace will be trimmed.{Environment.NewLine}Enter trackname: ",
                    input =>
                    {
                        if (!Bet.IsValidTrackName(input))
                            return false;
                        trackName = input;
                        return true;
                    }
                );

            DateTime date = default(DateTime);
            ValidateUserInput<DateTime>(
                    "Enter date (dd/MM/yyyy): ",
                    $"Input invalid. Please provide the correct input format: dd/MM/yyyy{Environment.NewLine}Enter date: ",
                    input => DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out date)
                );

            decimal amount = default(decimal);
            ValidateUserInput<decimal>(
                    "Enter bet amount (decimal value at 2 decimal places, or without e.g. 35.50, 35): ",
                    $"Input invalid. Please enter a decimal value representing bet amount e.g. 30.75 or 500{Environment.NewLine}Enter amount: ",
                    input => decimal.TryParse(input, out amount) && Bet.IsValidMoney(amount) 
                );

            bool won = default(bool);
            ValidateUserInput<bool>(
                    "Bet successful ('true' / 'false'): ",
                    $"Input invalid. Enter either 'true' or 'false'{Environment.NewLine}Bet successful: ",
                    input => {
                        //if (string.Equals(input, "y", StringComparison.OrdinalIgnoreCase))
                        //{
                        //    won = true;
                        //    return true;
                        //}

                        //if (string.Equals(input, "n", StringComparison.OrdinalIgnoreCase))
                        //{
                        //    won = false;
                        //    return true;
                        //}

                        return bool.TryParse(input, out won);
                    }
                );

            return new Bet(trackName, date, amount, won);
        }

        static void AddBet(Bet bet)
        {
            using (Stream stream = File.Open(_betsFilePath, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                _bets.Add(bet);
                formatter.Serialize(stream, _bets);
                Console.WriteLine("Bet stored succesfully.");
            }
        }

        static string ReadInputAndTrim()
        {
            return Console.ReadLine().Trim();
        }

        /*  
         *  This should only ever run once, unless the user for some reason decides to move/delete/rename the bin file or data directory.
         *  Initializes the file with the default start values from text file resource.
         */
        static void InitializeBinaryFile()
        {
            List<Bet> bets = new List<Bet>();
            using (StringReader reader = new StringReader(Properties.Resources.init_data))
            {
                while (reader.Peek() != -1)
                {
                    Bet bet = ParseInitialProvidedBetData(reader.ReadLine());
                    if (bet != null)
                        bets.Add(bet);
                }
                
                //  Should no longer need this Regex; set to null allowing garbage collector to clear the allocated memory
                _betRegex = null;
            }

            Console.WriteLine(bets.Count);

            using (Stream stream = File.Open(_betsFilePath, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, bets);
            }
        }

        static List<Bet> DeserializeBinaryFile()
        {
            List<Bet> bets = null;

            using (Stream stream = File.OpenRead(_betsFilePath))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                bets = (formatter.Deserialize(stream) as List<Bet>) ?? new List<Bet>();
            }

            return bets != null ? bets : new List<Bet>();
        }

        static Bet ParseInitialProvidedBetData(string s)
        {
            if(_betRegex == null)
                _betRegex = new Regex(@"[A-Za-z\.0-9]+");
            //betRegex = new Regex(@"([A-Za-z\.0-9]+[\s]?)+");

            MatchCollection matches = _betRegex.Matches(s);
            if (matches.Count != 6)
                return null;

            return
                new Bet(
                    matches[0].Value,
                    new DateTime(int.Parse(matches[1].Value), int.Parse(matches[2].Value), int.Parse(matches[3].Value)),
                    decimal.Parse(matches[4].Value.TrimEnd('m')),
                    bool.Parse(matches[5].Value)
                );
        }

        static void PrintSeperator()
        {
            Console.Write(OutputSeperator);
        }

        //static string ParseDate(string s)
        //{
        //    if(dateParser == null)
        //        dateParser = new Regex("[(].*?[)]");
        //    return dateParser.Match(s).Value;
        //}

        //static DateTime ParseDate(string s)
        //{
        //    string[] date = s.Substring(1, s.Length - 1).Split(',');
        //    return new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]));
        //}

        //static bool ValidBetString(string bet)
        //{
        //    Regex regex = new Regex("", RegexOptions.IgnoreCase);
        //    int count = 0;
        //    foreach (string f in files)
        //    {
        //        Match match = regex.Match(f);

        //        if (match.Success)
        //        {
        //            Console.WriteLine($"Matched on: {f} Match index: {match.Index}. Filetype: {match.Value}");
        //            count++;
        //        }
        //    }
        //    Console.WriteLine($"Count: {count}");
        //}

        //static bool BetStringIsValid(string s)
        //{
        //    if(validBetString == null)
        //        validBetString = new Regex("[A-Za-z]+[,][(][0-9]{1,2},[0-9]{1,2},[0-9]{4}[)][,][0-9]+[.][0-9]+[m][,](true|false)");
        //    return validBetString.IsMatch(s);

        //}

        //static string RemoveWhitespace(string s)
        //{
        //    if (whitespace == null)
        //        whitespace = new Regex(@"\s+");
        //    return whitespace.Replace(s, "");
        //}

        //static string ParseLocation(string s)
        //{
        //    Regex regex = new Regex("^[A-Za-z]+");
        //    //return s.Substring(0, s.IndexOf(','));
        //    return regex.Match(s).Value;
        //}


        //string input = string.Empty;

        //Console.Write("Enter trackname: ");
        //input = ReadInputAndTrim();
        //while (!Bet.IsValidTrack(input))
        //{
        //    Console.Write($"Input trackname '{input}' is not valid. Alphabetical characters(a-z), apostrophes('), and single spaces are accepted only." +
        //        $"{Environment.NewLine}Enter trackname: ");
        //    input = ReadInputAndTrim();
        //}
        //string trackName = input;

        //Console.Write("Enter date (dd/MM/yyyy): ");
        //input = ReadInputAndTrim();
        //DateTime date;
        //while (!DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out date))
        //{
        //    Console.Write($"'{input}' invalid. Please provide the correct input format: dd/MM/yyyy" +
        //        $"{Environment.NewLine}Enter date: ");
        //    input = ReadInputAndTrim();
        //}

        //Console.Write("Enter bet amount (decimal value at 2 decimal places, or without e.g. 35.50, 35): ");
        //input = ReadInputAndTrim();
        //decimal amount;
        //while(!decimal.TryParse(input, out amount) || !Bet.IsValidMoney(amount))
        //{
        //    Console.Write($"{input} invalid. Please enter a decimal value representing bet amount e.g. 30.75 or 500" +
        //        $"{Environment.NewLine}Enter amount: ");
        //    input = ReadInputAndTrim();
        //}

        //Console.Write("Bet successful ('true' or 'false'): ");
        //input = ReadInputAndTrim();
        //bool won;
        //while (!bool.TryParse(input, out won))
        //{
        //    Console.Write($"{input} invalid. Enter either 'true' or 'false'{Environment.NewLine}Bet successful: ");
        //    input = ReadInputAndTrim();
        //}
    }
}
