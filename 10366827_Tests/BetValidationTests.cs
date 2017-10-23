using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _10366827;
using System.IO;
using System.Collections.Generic;

namespace _10366827_Tests
{
    [TestClass]
    public class BetValidationTests
    {
        #region TrackValidation

        [TestMethod]
        public void ConfirmValidTracksAreDeemedValid()
        {
            string validTrack1 = "Ainsley";
            string validTrack2 = "Horse Track";
            string validTrack3 = "Greyman's Horseplace";
            string validTrack4 = "Jusai's Master track";

            Assert.IsTrue(Bet.IsValidTrackName(validTrack1));
            Assert.IsTrue(Bet.IsValidTrackName(validTrack2));
            Assert.IsTrue(Bet.IsValidTrackName(validTrack3));
            Assert.IsTrue(Bet.IsValidTrackName(validTrack4));
        }

        [TestMethod]
        public void EmptyNullOrSpacesOnlyTrackShouldBeDeemedInvalid()
        {
            string invalidTrack1 = "";
            string invalidTrack2 = null;
            string invalidTrack3 = "         ";

            Assert.IsFalse(Bet.IsValidTrackName(invalidTrack1));
            Assert.IsFalse(Bet.IsValidTrackName(invalidTrack2));
            Assert.IsFalse(Bet.IsValidTrackName(invalidTrack3));
        }

        [TestMethod]
        public void TrackNamesOfOnlyNumbersOrContainingNumbersShouldBeInvalid()
        {
            string invalidTrack1 = string.Empty + 27831870190;
            string invalidTrack2 = "jdkiuewn 2138931";

            Assert.IsFalse(Bet.IsValidTrackName(invalidTrack1));
            Assert.IsFalse(Bet.IsValidTrackName(invalidTrack2));
        }

        [TestMethod]
        public void TrackNamesNotContainingAlphabeticalOrApostropheOrWhitespaceOnlyShouldBeInvalid()
        {
            string invalidTrack1 = "[]dd][d'#'][.,/./";
            string invalidTrack2 = "Hamley ']]/][] Jim";

            Assert.IsFalse(Bet.IsValidTrackName(invalidTrack1));
            Assert.IsFalse(Bet.IsValidTrackName(invalidTrack2));
        }

        [TestMethod]
        public void ConfirmCantHaveStartingOrTrailingWhitespacesOrMultipleSpaces()
        {
            string invalidTrack1 = " Greyman's Horseplace";
            string invalidTrack2 = "Greyman's Horseplace   ";
            string invalidTrack3 = "  Greyman   ";
            string invalidTrack4 = "Grey    man";

            Assert.IsFalse(Bet.IsValidTrackName(invalidTrack1));
            Assert.IsFalse(Bet.IsValidTrackName(invalidTrack2));
            Assert.IsFalse(Bet.IsValidTrackName(invalidTrack3));
            Assert.IsFalse(Bet.IsValidTrackName(invalidTrack4));
        }

        #endregion TrackValidation

        #region MoneyValidation

        [TestMethod]
        public void ValidMoneyValuesShouldValidate()
        {
            decimal validMoney1 = 1200.33m;
            decimal validMoney2 = 12m;
            decimal validMoney3 = 800.00m;
            decimal validMoney4 = 0.83m;
            decimal validMoney5 = 1.99m;


            Assert.IsTrue(Bet.IsValidMoney(validMoney1));
            Assert.IsTrue(Bet.IsValidMoney(validMoney2));
            Assert.IsTrue(Bet.IsValidMoney(validMoney3));
            Assert.IsTrue(Bet.IsValidMoney(validMoney4));
            Assert.IsTrue(Bet.IsValidMoney(validMoney5));
        }

        [TestMethod]
        public void DecimalPointButMoreOrLessThan2ShouldBeInvalid()
        {
            decimal invalidMoney1DecimalPoint = 70.1m;
            decimal invalidMoney3DecimalPoint = 70.333m;

            Assert.IsFalse(Bet.IsValidMoney(invalidMoney1DecimalPoint));
            Assert.IsFalse(Bet.IsValidMoney(invalidMoney3DecimalPoint));
        }

        [TestMethod]
        public void ABetOf0ShouldBeDeemedInvalid()
        {
            decimal invalidMoneyNothing = 0m;

            Assert.IsFalse(Bet.IsValidMoney(invalidMoneyNothing));
        }

        [TestMethod]
        public void ANegativeBetShouldBeInvalid()
        {
            decimal invalidMoneyNegative = -4.20m;

            Assert.IsFalse(Bet.IsValidMoney(invalidMoneyNegative));
        }

        #endregion MoneyValidation

        #region BetCreation
        [TestMethod]
        public void InvalidBetMissingInformation()
        {
            Bet testBetMissingEverything = new Bet() { };
            Bet testBetMissingEverythingButTrack = new Bet() { TrackName = "Name" };
            Bet testBetMissingMoneyAndDate = new Bet() { TrackName = "hsdj", Win = true };
            Bet testBetOnlyWin = new Bet() { Win = false };

            Assert.IsFalse(Bet.IsValid(testBetMissingEverything));
            Assert.IsFalse(Bet.IsValid(testBetMissingEverythingButTrack));
            Assert.IsFalse(Bet.IsValid(testBetMissingMoneyAndDate));
            Assert.IsFalse(Bet.IsValid(testBetOnlyWin));
        }
        #endregion
    }
}
