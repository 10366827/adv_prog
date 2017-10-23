namespace GUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvBets = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.radioYearlyStats = new System.Windows.Forms.RadioButton();
            this.radioPopularTrack = new System.Windows.Forms.RadioButton();
            this.radioOrderByDate = new System.Windows.Forms.RadioButton();
            this.radioHighWon = new System.Windows.Forms.RadioButton();
            this.radioSuccessRate = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRemoveBet = new System.Windows.Forms.Button();
            this.btnAddBet = new System.Windows.Forms.Button();
            this.betDataHandlerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.trackNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moneyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.winDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.betBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.betDataHandlerBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.loadTestDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radioHighLost = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.betDataHandlerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.betBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.betDataHandlerBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(745, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.Gray;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetDataToolStripMenuItem,
            this.loadTestDataToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.ToolTipText = "File Menu";
            // 
            // resetDataToolStripMenuItem
            // 
            this.resetDataToolStripMenuItem.Name = "resetDataToolStripMenuItem";
            this.resetDataToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.resetDataToolStripMenuItem.Text = "clear all data";
            this.resetDataToolStripMenuItem.Click += new System.EventHandler(this.resetDataToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // dgvBets
            // 
            this.dgvBets.AllowUserToAddRows = false;
            this.dgvBets.AutoGenerateColumns = false;
            this.dgvBets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.trackNameDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.moneyDataGridViewTextBoxColumn,
            this.winDataGridViewCheckBoxColumn});
            this.dgvBets.DataSource = this.betDataHandlerBindingSource1;
            this.dgvBets.Location = new System.Drawing.Point(12, 43);
            this.dgvBets.MultiSelect = false;
            this.dgvBets.Name = "dgvBets";
            this.dgvBets.ReadOnly = true;
            this.dgvBets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBets.Size = new System.Drawing.Size(562, 165);
            this.dgvBets.TabIndex = 1;
            this.dgvBets.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBets_ColumnHeaderMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bets ( click column heading to change sort )";
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(12, 238);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReport.Size = new System.Drawing.Size(597, 191);
            this.dgvReport.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Report";
            // 
            // radioYearlyStats
            // 
            this.radioYearlyStats.AutoSize = true;
            this.radioYearlyStats.Location = new System.Drawing.Point(617, 279);
            this.radioYearlyStats.Name = "radioYearlyStats";
            this.radioYearlyStats.Size = new System.Drawing.Size(99, 17);
            this.radioYearlyStats.TabIndex = 7;
            this.radioYearlyStats.TabStop = true;
            this.radioYearlyStats.Text = "Yearly Statistics";
            this.radioYearlyStats.UseVisualStyleBackColor = true;
            this.radioYearlyStats.CheckedChanged += new System.EventHandler(this.radioYearlyStats_CheckedChanged);
            // 
            // radioPopularTrack
            // 
            this.radioPopularTrack.AutoSize = true;
            this.radioPopularTrack.Location = new System.Drawing.Point(617, 302);
            this.radioPopularTrack.Name = "radioPopularTrack";
            this.radioPopularTrack.Size = new System.Drawing.Size(118, 17);
            this.radioPopularTrack.TabIndex = 8;
            this.radioPopularTrack.TabStop = true;
            this.radioPopularTrack.Text = "Most Popular Track";
            this.radioPopularTrack.UseVisualStyleBackColor = true;
            this.radioPopularTrack.CheckedChanged += new System.EventHandler(this.radioPopularTrack_CheckedChanged);
            // 
            // radioOrderByDate
            // 
            this.radioOrderByDate.AutoSize = true;
            this.radioOrderByDate.Location = new System.Drawing.Point(617, 325);
            this.radioOrderByDate.Name = "radioOrderByDate";
            this.radioOrderByDate.Size = new System.Drawing.Size(92, 17);
            this.radioOrderByDate.TabIndex = 9;
            this.radioOrderByDate.TabStop = true;
            this.radioOrderByDate.Text = "Order By Date";
            this.radioOrderByDate.UseVisualStyleBackColor = true;
            this.radioOrderByDate.CheckedChanged += new System.EventHandler(this.radioOrderByDate_CheckedChanged);
            // 
            // radioHighWon
            // 
            this.radioHighWon.AutoSize = true;
            this.radioHighWon.Location = new System.Drawing.Point(617, 348);
            this.radioHighWon.Name = "radioHighWon";
            this.radioHighWon.Size = new System.Drawing.Size(126, 17);
            this.radioHighWon.TabIndex = 10;
            this.radioHighWon.TabStop = true;
            this.radioHighWon.Text = "Highest Amount Won";
            this.radioHighWon.UseVisualStyleBackColor = true;
            this.radioHighWon.CheckedChanged += new System.EventHandler(this.radioHighWon_CheckedChanged);
            // 
            // radioSuccessRate
            // 
            this.radioSuccessRate.AutoSize = true;
            this.radioSuccessRate.Location = new System.Drawing.Point(617, 394);
            this.radioSuccessRate.Name = "radioSuccessRate";
            this.radioSuccessRate.Size = new System.Drawing.Size(92, 17);
            this.radioSuccessRate.TabIndex = 11;
            this.radioSuccessRate.TabStop = true;
            this.radioSuccessRate.Text = "Success Rate";
            this.radioSuccessRate.UseVisualStyleBackColor = true;
            this.radioSuccessRate.CheckedChanged += new System.EventHandler(this.radioSuccessRate_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(614, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Report Options";
            // 
            // btnRemoveBet
            // 
            this.btnRemoveBet.Location = new System.Drawing.Point(591, 127);
            this.btnRemoveBet.Name = "btnRemoveBet";
            this.btnRemoveBet.Size = new System.Drawing.Size(142, 60);
            this.btnRemoveBet.TabIndex = 13;
            this.btnRemoveBet.Text = "Remove Bet";
            this.btnRemoveBet.UseVisualStyleBackColor = true;
            this.btnRemoveBet.Click += new System.EventHandler(this.btnRemoveBet_Click);
            // 
            // btnAddBet
            // 
            this.btnAddBet.Location = new System.Drawing.Point(591, 43);
            this.btnAddBet.Name = "btnAddBet";
            this.btnAddBet.Size = new System.Drawing.Size(142, 60);
            this.btnAddBet.TabIndex = 13;
            this.btnAddBet.Text = "Add Bet";
            this.btnAddBet.UseVisualStyleBackColor = true;
            this.btnAddBet.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // betDataHandlerBindingSource
            // 
            this.betDataHandlerBindingSource.DataSource = typeof(_10366827.BetDataHandler);
            // 
            // trackNameDataGridViewTextBoxColumn
            // 
            this.trackNameDataGridViewTextBoxColumn.DataPropertyName = "TrackName";
            this.trackNameDataGridViewTextBoxColumn.HeaderText = "TrackName";
            this.trackNameDataGridViewTextBoxColumn.Name = "trackNameDataGridViewTextBoxColumn";
            this.trackNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // moneyDataGridViewTextBoxColumn
            // 
            this.moneyDataGridViewTextBoxColumn.DataPropertyName = "Money";
            this.moneyDataGridViewTextBoxColumn.HeaderText = "Money";
            this.moneyDataGridViewTextBoxColumn.Name = "moneyDataGridViewTextBoxColumn";
            this.moneyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // winDataGridViewCheckBoxColumn
            // 
            this.winDataGridViewCheckBoxColumn.DataPropertyName = "Win";
            this.winDataGridViewCheckBoxColumn.HeaderText = "Win";
            this.winDataGridViewCheckBoxColumn.Name = "winDataGridViewCheckBoxColumn";
            this.winDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // betBindingSource
            // 
            this.betBindingSource.DataSource = typeof(_10366827.Bet);
            // 
            // betDataHandlerBindingSource1
            // 
            this.betDataHandlerBindingSource1.DataSource = typeof(_10366827.BetDataHandler);
            // 
            // loadTestDataToolStripMenuItem
            // 
            this.loadTestDataToolStripMenuItem.Name = "loadTestDataToolStripMenuItem";
            this.loadTestDataToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadTestDataToolStripMenuItem.Text = "load test data";
            this.loadTestDataToolStripMenuItem.Click += new System.EventHandler(this.loadTestDataToolStripMenuItem_Click);
            // 
            // radioHighLost
            // 
            this.radioHighLost.AutoSize = true;
            this.radioHighLost.Location = new System.Drawing.Point(617, 371);
            this.radioHighLost.Name = "radioHighLost";
            this.radioHighLost.Size = new System.Drawing.Size(123, 17);
            this.radioHighLost.TabIndex = 14;
            this.radioHighLost.TabStop = true;
            this.radioHighLost.Text = "Highest Amount Lost";
            this.radioHighLost.UseVisualStyleBackColor = true;
            this.radioHighLost.CheckedChanged += new System.EventHandler(this.radioHighLost_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(745, 439);
            this.Controls.Add(this.radioHighLost);
            this.Controls.Add(this.btnAddBet);
            this.Controls.Add(this.btnRemoveBet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.radioSuccessRate);
            this.Controls.Add(this.radioHighWon);
            this.Controls.Add(this.radioOrderByDate);
            this.Controls.Add(this.radioPopularTrack);
            this.Controls.Add(this.radioYearlyStats);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvBets);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HOT TIPSTER  version 10366827";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.betDataHandlerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.betBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.betDataHandlerBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvBets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioYearlyStats;
        private System.Windows.Forms.RadioButton radioPopularTrack;
        private System.Windows.Forms.RadioButton radioOrderByDate;
        private System.Windows.Forms.RadioButton radioHighWon;
        private System.Windows.Forms.RadioButton radioSuccessRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRemoveBet;
        private System.Windows.Forms.Button btnAddBet;
        private System.Windows.Forms.DataGridViewTextBoxColumn trackNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moneyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn winDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource betDataHandlerBindingSource;
        private System.Windows.Forms.BindingSource betBindingSource;
        private System.Windows.Forms.BindingSource betDataHandlerBindingSource1;
        private System.Windows.Forms.ToolStripMenuItem loadTestDataToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioHighLost;
    }
}

