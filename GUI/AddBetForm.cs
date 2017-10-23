using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _10366827;
using GUI.interfaces;
using System.Text.RegularExpressions;
using System.Configuration;

namespace GUI
{
    public partial class AddBetForm : Form
    {
        private AddBetListener listener;
        private Regex trackNameInput;
        private Regex moneyInput;

        public AddBetForm(AddBetListener _listener)
        {
            listener = _listener;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal amount = decimal.Parse(inputAmount.Text);
            if (!Bet.IsValidMoney(amount))
            {
                MessageBox.Show("Bet amount invalid. Cannot be 0 or negative.");
                return;
            }
            if (string.IsNullOrWhiteSpace(inputTrackName.Text) || inputTrackName.Text.Length == 0)
            {
                MessageBox.Show("Trackname is required.");
                return;
            }

            listener.AddBet(new Bet() {
                TrackName = inputTrackName.Text,
                Money = Math.Round(amount, 2),
                Win = radioWin.Checked,
                Date = inputDate.Value
            });
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void inputTrackName_TextChanged(object sender, EventArgs e)
        {
            //string input = inputTrackName.Text;
            //if (!Bet.IsValidTrackName(input))
            //{
            //    if (input.Length > 1)
            //    {
            //        inputTrackName.Text = input.Substring(0, input.Length - 1);
            //    }
            //    else
            //        inputTrackName.Text = string.Empty;
            //}
        }

        private void inputTrackName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!trackNameInput.IsMatch(e.KeyChar.ToString()))
                e.Handled = true;
        }

        private void inputAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!moneyInput.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
            else if(e.KeyChar == '.' && (inputAmount.Text.Contains(".") || inputAmount.Text.Length == 0))
            {
                e.Handled = true;
            }
        }

        private void AddBetForm_Load(object sender, EventArgs e)
        {
            trackNameInput = new Regex(ConfigurationManager.AppSettings["legalTracknameKeys"]);
            moneyInput = new Regex(ConfigurationManager.AppSettings["legalMoneyKeys"]);
            
            inputTrackName.Select();

            //if (inputTrackName.CanFocus)
            //{
            //    inputTrackName.Focus();
            //}
        }

        private void inputAmount_TextChanged(object sender, EventArgs e)
        {
            //inputAmount.Text = string.Format("{0:0.00}", decimal.Parse(inputAmount.Text));
        }

        private void inputAmount_Leave(object sender, EventArgs e)
        {
            if (inputAmount.Text.Length == 0 || (inputAmount.Text.Length == 1 && inputAmount.Text[0] == '.'))
                inputAmount.Text = ""+0;
            else
                inputAmount.Text = string.Format("{0:0.00}", decimal.Parse(inputAmount.Text));
        }

        private void inputTrackName_Leave(object sender, EventArgs e)
        {
            if(inputTrackName.Text.Length > 0)
                inputTrackName.Text = Regex.Replace(inputTrackName.Text, @"\s+", " ");
        }
    }
}
