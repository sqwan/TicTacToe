namespace ToeTacTic
{
    partial class TicTacToeForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.playername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.looses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Button = new System.Windows.Forms.Button();
            this.control = new ToeTacTic.GameBoardControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Button);
            this.groupBox1.Location = new System.Drawing.Point(264, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 238);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Spiel Informationen";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.playername,
            this.Wins,
            this.looses,
            this.symbol});
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(10, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(254, 82);
            this.dataGridView1.TabIndex = 3;
            // 
            // playername
            // 
            this.playername.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.playername.HeaderText = "Spieler";
            this.playername.Name = "playername";
            this.playername.ReadOnly = true;
            // 
            // Wins
            // 
            this.Wins.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Wins.HeaderText = "Gewonnen";
            this.Wins.Name = "Wins";
            this.Wins.ReadOnly = true;
            // 
            // looses
            // 
            this.looses.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.looses.HeaderText = "Verloren";
            this.looses.Name = "looses";
            this.looses.ReadOnly = true;
            // 
            // symbol
            // 
            this.symbol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.symbol.HeaderText = "Symbol";
            this.symbol.Name = "symbol";
            this.symbol.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "SPIELERNAME";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Spieler am Zug: ";
            // 
            // Button
            // 
            this.Button.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Button.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.Button.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Button.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ScrollBar;
            this.Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button.Location = new System.Drawing.Point(6, 170);
            this.Button.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(258, 62);
            this.Button.TabIndex = 0;
            this.Button.Text = "Aufgeben";
            this.Button.UseVisualStyleBackColor = false;
            this.Button.Click += new System.EventHandler(this.Button_Click);
            this.Button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // control
            // 
            this.control.Location = new System.Drawing.Point(12, 12);
            this.control.Name = "control";
            this.control.Size = new System.Drawing.Size(235, 238);
            this.control.TabIndex = 0;
            // 
            // TicTacToeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 262);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.control);
            this.MinimumSize = new System.Drawing.Size(370, 160);
            this.Name = "TicTacToeForm";
            this.Text = "TicTacToe";
            this.Load += new System.EventHandler(this.TicTacToeForm_Load);
            this.Resize += new System.EventHandler(this.TicTacToeForm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GameBoardControl control;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn playername;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wins;
        private System.Windows.Forms.DataGridViewTextBoxColumn looses;
        private System.Windows.Forms.DataGridViewTextBoxColumn symbol;
    }
}

