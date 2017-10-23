using _10366827;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using GUI.interfaces;

namespace GUI
{
    public partial class MainForm : Form, AddBetListener
    {
        private BetDataHandler betHandler;

        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (AddBetForm addBetForm = new AddBetForm(this))
            {
                addBetForm.ShowDialog();
            }
        }

        private void btnRemoveBet_Click(object sender, EventArgs e)
        {
            if (betHandler.Count == 0)
                return;

            DialogResult result = MessageBox.Show("Are you sure you want to remove the selected bet?", "Remove Bet", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                Int32 selectedRowCount = dgvBets.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount > 0)
                {
                    for (int i = 0; i < selectedRowCount; i++)
                    {
                        if (dgvBets.SelectedRows[0].Cells.Count > 1)
                            dgvBets.Rows.RemoveAt(dgvBets.SelectedRows[0].Index);
                    }
                    dgvBets.DataSource = null;
                    dgvBets.DataSource = betHandler;
                }
            }
        }

        //  AddBetListener
        public void AddBet(Bet newBet)
        {
            betHandler.Add(newBet);
            dgvBets.DataSource = null;
            dgvBets.DataSource = betHandler;
        }

        private void dgvBets_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (betHandler == null || betHandler.Count == 0)
                return;

            //  Trackname Column Header
            if(e.ColumnIndex == 0)
            {
                betHandler.SortByTrackName();
                dgvBets.DataSource = null;
                dgvBets.DataSource = betHandler;
            }

            //  Date Column Header
            else if(e.ColumnIndex == 1)
            {
                betHandler.SortByDate();
                dgvBets.DataSource = null;
                dgvBets.DataSource = betHandler;
            }

            //  Money Column Header
            else if(e.ColumnIndex == 2)
            {
                betHandler.SortByMoney();
                dgvBets.DataSource = null;
                dgvBets.DataSource = betHandler;
            }

            //  Win / Lose Column Header
            else
            {
                betHandler.SortByWins();
                dgvBets.DataSource = null;
                dgvBets.DataSource = betHandler;
            }
        }

        private void resetDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to load test data? This will " +
                "delete all current data.", "Load test data", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                dgvBets.DataSource = null;
                betHandler.Clear();
                dgvBets.DataSource = betHandler;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            betHandler = new BetDataHandler();
            dgvBets.DataSource = betHandler;
        }

        private void loadTestDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to load test data? This will " +
                "delete all current data.", "Load test data", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                dgvBets.DataSource = null;
                betHandler = new BetDataHandler(BetTestData.GetHotTipsterTestData().ToList());
                dgvBets.DataSource = betHandler;
            }
        }

        private void radioYearlyStats_CheckedChanged(object sender, EventArgs e)
        {
            if (betHandler.Count == 0)
                return;

            dgvReport.DataSource = null;
            dgvReport.DataSource = ReportGenerator.GenerateYearlyStatisticsReport(
                    betHandler
                );
        }

        private void radioPopularTrack_CheckedChanged(object sender, EventArgs e)
        {
            if (betHandler.Count == 0)
                return;

            dgvReport.DataSource = null;
            dgvReport.DataSource = new List<MostPopularRaceTrackReport>{ ReportGenerator.FindMostPopularRaceTrack(
                    betHandler
                ) };
        }

        private void radioOrderByDate_CheckedChanged(object sender, EventArgs e)
        {
            if (betHandler.Count == 0)
                return;

            dgvReport.DataSource = null;
            dgvReport.DataSource = new List<Bet>(ReportGenerator.GetBetsOrderedByDate(
                    betHandler
                ));
        }

        private void radioHighWon_CheckedChanged(object sender, EventArgs e)
        {
            if (betHandler.Count == 0)
                return;

            dgvReport.DataSource = null;
            dgvReport.DataSource = new List<Bet> { ReportGenerator.GetLargestBetWon(
                    betHandler
                ) };
        }

        private void radioHighLost_CheckedChanged(object sender, EventArgs e)
        {
            if (betHandler.Count == 0)
                return;

            dgvReport.DataSource = null;
            dgvReport.DataSource = new List<Bet> { ReportGenerator.GetLargestBetLost(
                    betHandler
                ) };
        }

        private void radioSuccessRate_CheckedChanged(object sender, EventArgs e)
        {
            if (betHandler.Count == 0)
                return;

            dgvReport.DataSource = null;
            dgvReport.DataSource = new List<SuccessRateReport> { ReportGenerator.GenerateSuccessRateReport(
                    betHandler.ToList()
                ) };
        }
    }
}
