namespace GUI
{
    partial class AddBetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBetForm));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.inputTrackName = new System.Windows.Forms.TextBox();
            this.inputAmount = new System.Windows.Forms.TextBox();
            this.inputDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radioWin = new System.Windows.Forms.RadioButton();
            this.radioLose = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Lime;
            this.btnAdd.Location = new System.Drawing.Point(12, 183);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(109, 35);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(131, 183);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // inputTrackName
            // 
            this.inputTrackName.AccessibleDescription = "Name of track";
            this.inputTrackName.AccessibleName = "Trackname";
            this.inputTrackName.Location = new System.Drawing.Point(79, 24);
            this.inputTrackName.Name = "inputTrackName";
            this.inputTrackName.Size = new System.Drawing.Size(136, 20);
            this.inputTrackName.TabIndex = 2;
            this.inputTrackName.Tag = "";
            this.inputTrackName.TextChanged += new System.EventHandler(this.inputTrackName_TextChanged);
            this.inputTrackName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputTrackName_KeyPress);
            this.inputTrackName.Leave += new System.EventHandler(this.inputTrackName_Leave);
            // 
            // inputAmount
            // 
            this.inputAmount.Location = new System.Drawing.Point(79, 61);
            this.inputAmount.Name = "inputAmount";
            this.inputAmount.Size = new System.Drawing.Size(136, 20);
            this.inputAmount.TabIndex = 3;
            this.inputAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputAmount_KeyPress);
            this.inputAmount.Leave += new System.EventHandler(this.inputAmount_Leave);
            // 
            // inputDate
            // 
            this.inputDate.AccessibleDescription = "Date of bet";
            this.inputDate.AccessibleName = "Date";
            this.inputDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.inputDate.Location = new System.Drawing.Point(79, 100);
            this.inputDate.Name = "inputDate";
            this.inputDate.Size = new System.Drawing.Size(95, 20);
            this.inputDate.TabIndex = 5;
            this.inputDate.Value = new System.DateTime(2017, 9, 19, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Trackname:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Amount:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Date Placed:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Result:";
            // 
            // radioWin
            // 
            this.radioWin.AutoSize = true;
            this.radioWin.Checked = true;
            this.radioWin.Location = new System.Drawing.Point(61, 160);
            this.radioWin.Name = "radioWin";
            this.radioWin.Size = new System.Drawing.Size(44, 17);
            this.radioWin.TabIndex = 10;
            this.radioWin.TabStop = true;
            this.radioWin.Text = "Win";
            this.radioWin.UseVisualStyleBackColor = true;
            // 
            // radioLose
            // 
            this.radioLose.AutoSize = true;
            this.radioLose.Location = new System.Drawing.Point(111, 160);
            this.radioLose.Name = "radioLose";
            this.radioLose.Size = new System.Drawing.Size(48, 17);
            this.radioLose.TabIndex = 11;
            this.radioLose.Text = "Lose";
            this.radioLose.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "€";
            // 
            // AddBetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(252, 228);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.radioLose);
            this.Controls.Add(this.radioWin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputDate);
            this.Controls.Add(this.inputAmount);
            this.Controls.Add(this.inputTrackName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddBetForm";
            this.Text = "Add Bet";
            this.Load += new System.EventHandler(this.AddBetForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox inputTrackName;
        private System.Windows.Forms.TextBox inputAmount;
        private System.Windows.Forms.DateTimePicker inputDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioWin;
        private System.Windows.Forms.RadioButton radioLose;
        private System.Windows.Forms.Label label5;
    }
}