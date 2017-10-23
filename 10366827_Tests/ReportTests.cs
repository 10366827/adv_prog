using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _10366827;
using System.IO;
using System.Collections.Generic;

namespace _10366827_Tests
{
    [TestClass]
    public class ReportTests
    {
        [TestMethod]
        public void TestOrderByDateReport()
        {
            Bet second = new Bet() { Date = DateTime.Now.AddDays(1) };
            Bet third = new Bet() { Date = DateTime.Now };
            Bet first = new Bet() { Date = DateTime.Now.AddDays(2) };
            Bet fourth = new Bet() { Date = DateTime.Now.AddDays(-5) };

            List<Bet> bets = new List<Bet> { second, third, first, fourth };
            bets = new List<Bet>(ReportGenerator.GetBetsOrderedByDate(bets));

            Assert.IsTrue(bets[0].Date.CompareTo(first.Date) == 0);

            Assert.IsTrue(bets[1].Date.CompareTo(second.Date) == 0);

            Assert.IsTrue(bets[2].Date.CompareTo(third.Date) == 0);

            Assert.IsTrue(bets[3].Date.CompareTo(fourth.Date) == 0);
        }

        [TestMethod]
        public void TestCountTotalWinsReport()
        {
            Bet win1 = new Bet() { Win = true };
            Bet loss1 = new Bet() { Win = false };
            Bet win2 = new Bet() { Win = true };
            Bet win3 = new Bet() { Win = true };
            Bet loss2 = new Bet() { Win = false };

            int numberOfWinsShouldBeThree = ReportGenerator.CountTotalWins(new List<Bet> { win1, loss1, win2, win3, loss2 });

            Assert.IsTrue(numberOfWinsShouldBeThree == 3);
        }

        [TestMethod]
        public void TestSuccessRateReport()
        {
            Bet win1 = new Bet() { Win = true };
            Bet loss1 = new Bet() { Win = false };
            Bet win2 = new Bet() { Win = true };
            Bet win3 = new Bet() { Win = true };
            Bet loss2 = new Bet() { Win = false };

            SuccessRateReport result = ReportGenerator.GenerateSuccessRateReport(new List<Bet> { win1, loss1, win2, win3, loss2 });

            Assert.IsTrue(result.TotalBets == 5);
            Assert.IsTrue(result.TotalWins == 3);
            Assert.IsTrue(result.SuccessRate == "60%");
        }

        [TestMethod]
        public void TestLargetsBetWon()
        {
            Bet _200 = new Bet() { Money = 200, Win = true };
            Bet _199 = new Bet() { Money = 199, Win = true };
            Bet _100 = new Bet() { Money = 100, Win = true };
            Bet _500_loss = new Bet() { Money = 500, Win = false };

            Bet resultShouldBe_200 = ReportGenerator.GetLargestBetWon(new List<Bet> { _200, _199, _100, _500_loss });

            Assert.IsTrue(resultShouldBe_200.Money == 200);
        }

        [TestMethod]
        public void TestLargestBetLoss()
        {
            Bet _200 = new Bet() { Money = 200, Win = false };
            Bet _199 = new Bet() { Money = 199, Win = false };
            Bet _100 = new Bet() { Money = 100, Win = false };
            Bet _500_Win = new Bet() { Money = 500, Win = true };

            Bet resultShouldBe_200 = ReportGenerator.GetLargestBetLost(new List<Bet> { _200, _199, _100, _500_Win });

            Assert.IsTrue(resultShouldBe_200.Money == 200);
        }
        
        [TestMethod]
        public void TestOrderByTracknameReport()
        {
            Bet second = new Bet() { TrackName = "AB" };
            Bet first = new Bet() { TrackName = "AA" };
            Bet fourth = new Bet() { TrackName = "BA" };
            Bet third = new Bet() { TrackName = "B" };

            List<Bet> result = new List<Bet>(ReportGenerator.GetBetsOrderedByTrackName(new List<Bet> { second, first, fourth, third }));

            Assert.IsTrue(result[0].TrackName == first.TrackName);
            Assert.IsTrue(result[1].TrackName == second.TrackName);
            Assert.IsTrue(result[2].TrackName == third.TrackName);
            Assert.IsTrue(result[3].TrackName == fourth.TrackName);
        }
        
        [TestMethod]
        public void TestOrderByMoney()
        {
            Bet second = new Bet() { Money = 200 };
            Bet first = new Bet() { Money = 500 };
            Bet fourth = new Bet() { Money = 100 };
            Bet third = new Bet() { Money = 150 };

            List<Bet> result = new List<Bet>(ReportGenerator.GetBetsOrdersByMoney(new List<Bet> { second, first, fourth, third }));

            Assert.IsTrue(result[0].Money == first.Money);
            Assert.IsTrue(result[1].Money == second.Money);
            Assert.IsTrue(result[2].Money == third.Money);
            Assert.IsTrue(result[3].Money == fourth.Money);
        }



        [TestMethod]
        public void TestOrderByWin()
        {
            Bet second = new Bet() { Win = true };
            Bet fourth = new Bet() { Win = false };
            Bet third = new Bet() { Win = false };
            Bet first = new Bet() { Win = true };
            Bet fifth = new Bet() { Win = false };

            List<Bet> result = new List<Bet>(ReportGenerator.GetBetsOrdersByWinning(new List<Bet> { second, fourth, first, third, fifth }));

            Assert.IsTrue(result[0].Win == true);
            Assert.IsTrue(result[1].Win == true);
            Assert.IsTrue(result[2].Win == false);
            Assert.IsTrue(result[3].Win == false);
            Assert.IsTrue(result[4].Win == false);
        }
    }
}
