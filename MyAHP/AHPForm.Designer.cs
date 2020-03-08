namespace MyAHP
{
    partial class AHPForm
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
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Goal");
            this.AvailableRasters = new System.Windows.Forms.Label();
            this.SelectedCriteria = new System.Windows.Forms.Label();
            this.About = new System.Windows.Forms.Button();
            this.AddToRight = new System.Windows.Forms.Button();
            this.Goal = new System.Windows.Forms.TreeView();
            this.Cancel = new System.Windows.Forms.Button();
            this.List = new System.Windows.Forms.ListBox();
            this.AddToLeft = new System.Windows.Forms.Button();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource5 = new System.Windows.Forms.BindingSource(this.components);
            this.ratingMatrix = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Map = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Enter = new System.Windows.Forms.Button();
            this.AddMulti = new System.Windows.Forms.Button();
            this.Cal = new System.Windows.Forms.Button();
            this.sensitivity = new System.Windows.Forms.Button();
            this.combo1 = new System.Windows.Forms.ComboBox();
            this.Result = new System.Windows.Forms.Label();
            this.ChoosingCriterion = new System.Windows.Forms.Label();
            this.combo2 = new System.Windows.Forms.ComboBox();
            this.Simulations = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Note = new System.Windows.Forms.Label();
            this.progressLabel = new System.Windows.Forms.Label();
            this.clearMatrix = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AvailableRasters
            // 
            this.AvailableRasters.AutoSize = true;
            this.AvailableRasters.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvailableRasters.Location = new System.Drawing.Point(31, 41);
            this.AvailableRasters.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AvailableRasters.Name = "AvailableRasters";
            this.AvailableRasters.Size = new System.Drawing.Size(293, 24);
            this.AvailableRasters.TabIndex = 0;
            this.AvailableRasters.Text = "Available Rasters for Selection";
            // 
            // SelectedCriteria
            // 
            this.SelectedCriteria.AutoSize = true;
            this.SelectedCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedCriteria.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SelectedCriteria.Location = new System.Drawing.Point(475, 40);
            this.SelectedCriteria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SelectedCriteria.Name = "SelectedCriteria";
            this.SelectedCriteria.Size = new System.Drawing.Size(276, 24);
            this.SelectedCriteria.TabIndex = 1;
            this.SelectedCriteria.Text = "Selected Criteria - (Atleast 3)\r\n";
            // 
            // About
            // 
            this.About.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.About.Location = new System.Drawing.Point(32, 604);
            this.About.Margin = new System.Windows.Forms.Padding(4);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(189, 39);
            this.About.TabIndex = 2;
            this.About.Text = "About";
            this.About.UseVisualStyleBackColor = true;
            this.About.Click += new System.EventHandler(this.About_Click);
            // 
            // AddToRight
            // 
            this.AddToRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddToRight.Location = new System.Drawing.Point(352, 107);
            this.AddToRight.Margin = new System.Windows.Forms.Padding(4);
            this.AddToRight.Name = "AddToRight";
            this.AddToRight.Size = new System.Drawing.Size(107, 98);
            this.AddToRight.TabIndex = 3;
            this.AddToRight.Text = "Click to add a raster to selected criteria >";
            this.AddToRight.UseVisualStyleBackColor = true;
            this.AddToRight.Click += new System.EventHandler(this.AddToRight_Click);
            // 
            // Goal
            // 
            this.Goal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Goal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Goal.Location = new System.Drawing.Point(480, 75);
            this.Goal.Margin = new System.Windows.Forms.Padding(4);
            this.Goal.Name = "Goal";
            treeNode2.Name = "Goal";
            treeNode2.Text = "Goal";
            this.Goal.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.Goal.Size = new System.Drawing.Size(315, 502);
            this.Goal.TabIndex = 7;
            // 
            // Cancel
            // 
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel.Location = new System.Drawing.Point(19, 494);
            this.Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(230, 35);
            this.Cancel.TabIndex = 9;
            this.Cancel.Text = "Close";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // List
            // 
            this.List.BackColor = System.Drawing.SystemColors.ControlLight;
            this.List.ColumnWidth = 2;
            this.List.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.List.FormattingEnabled = true;
            this.List.ItemHeight = 20;
            this.List.Location = new System.Drawing.Point(32, 72);
            this.List.Margin = new System.Windows.Forms.Padding(4);
            this.List.Name = "List";
            this.List.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.List.Size = new System.Drawing.Size(294, 504);
            this.List.TabIndex = 8;
            // 
            // AddToLeft
            // 
            this.AddToLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddToLeft.Location = new System.Drawing.Point(352, 440);
            this.AddToLeft.Margin = new System.Windows.Forms.Padding(4);
            this.AddToLeft.Name = "AddToLeft";
            this.AddToLeft.Size = new System.Drawing.Size(107, 99);
            this.AddToLeft.TabIndex = 10;
            this.AddToLeft.Text = "Click to remove a selected criteria <\r\n";
            this.AddToLeft.UseVisualStyleBackColor = true;
            this.AddToLeft.Click += new System.EventHandler(this.AddToLeft_Click);
            // 
            // bindingSource2
            // 
            this.bindingSource2.CurrentChanged += new System.EventHandler(this.bindingSource2_CurrentChanged);
            // 
            // ratingMatrix
            // 
            this.ratingMatrix.AutoSize = true;
            this.ratingMatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ratingMatrix.Location = new System.Drawing.Point(938, 29);
            this.ratingMatrix.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ratingMatrix.Name = "ratingMatrix";
            this.ratingMatrix.Size = new System.Drawing.Size(316, 24);
            this.ratingMatrix.TabIndex = 11;
            this.ratingMatrix.Text = "Pairwise Comparison AHP Matrix";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(941, 139);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(581, 279);
            this.dataGridView.TabIndex = 12;
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            this.dataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_ColumnHeaderMouseClick);
            // 
            // Map
            // 
            this.Map.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Map.Location = new System.Drawing.Point(1189, 535);
            this.Map.Margin = new System.Windows.Forms.Padding(4);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(321, 40);
            this.Map.TabIndex = 17;
            this.Map.Text = "Create Suitability Map";
            this.Map.UseVisualStyleBackColor = true;
            this.Map.Click += new System.EventHandler(this.Map_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(941, 470);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(218, 106);
            this.textBox1.TabIndex = 15;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Enter
            // 
            this.Enter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Enter.Location = new System.Drawing.Point(819, 155);
            this.Enter.Margin = new System.Windows.Forms.Padding(4);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(96, 132);
            this.Enter.TabIndex = 18;
            this.Enter.Text = "Add Selected Criteria for AHP Analysis Matrix >>\r\n";
            this.Enter.UseVisualStyleBackColor = true;
            this.Enter.Click += new System.EventHandler(this.Enter_Click);
            // 
            // AddMulti
            // 
            this.AddMulti.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddMulti.Location = new System.Drawing.Point(352, 261);
            this.AddMulti.Margin = new System.Windows.Forms.Padding(4);
            this.AddMulti.Name = "AddMulti";
            this.AddMulti.Size = new System.Drawing.Size(107, 115);
            this.AddMulti.TabIndex = 19;
            this.AddMulti.Text = " Add multiple rasters to selected criteria >>>";
            this.AddMulti.UseVisualStyleBackColor = true;
            this.AddMulti.Click += new System.EventHandler(this.AddMulti_Click);
            // 
            // Cal
            // 
            this.Cal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cal.Location = new System.Drawing.Point(1189, 470);
            this.Cal.Margin = new System.Windows.Forms.Padding(4);
            this.Cal.Name = "Cal";
            this.Cal.Size = new System.Drawing.Size(321, 40);
            this.Cal.TabIndex = 21;
            this.Cal.Text = "Calculate Weights";
            this.Cal.UseVisualStyleBackColor = true;
            this.Cal.Click += new System.EventHandler(this.Cal_Click_1);
            // 
            // sensitivity
            // 
            this.sensitivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sensitivity.Location = new System.Drawing.Point(19, 392);
            this.sensitivity.Margin = new System.Windows.Forms.Padding(4);
            this.sensitivity.Name = "sensitivity";
            this.sensitivity.Size = new System.Drawing.Size(241, 62);
            this.sensitivity.TabIndex = 22;
            this.sensitivity.Text = "Perform SA &&\r\n Save your weights";
            this.sensitivity.UseVisualStyleBackColor = true;
            this.sensitivity.Click += new System.EventHandler(this.sensitivity_Click);
            // 
            // combo1
            // 
            this.combo1.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo1.FormattingEnabled = true;
            this.combo1.Location = new System.Drawing.Point(15, 86);
            this.combo1.Margin = new System.Windows.Forms.Padding(4);
            this.combo1.Name = "combo1";
            this.combo1.Size = new System.Drawing.Size(233, 28);
            this.combo1.TabIndex = 23;
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result.Location = new System.Drawing.Point(938, 434);
            this.Result.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(224, 24);
            this.Result.TabIndex = 24;
            this.Result.Text = "Consistency Ratio (CR)";
            // 
            // ChoosingCriterion
            // 
            this.ChoosingCriterion.AutoSize = true;
            this.ChoosingCriterion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChoosingCriterion.Location = new System.Drawing.Point(14, 52);
            this.ChoosingCriterion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ChoosingCriterion.Name = "ChoosingCriterion";
            this.ChoosingCriterion.Size = new System.Drawing.Size(181, 20);
            this.ChoosingCriterion.TabIndex = 25;
            this.ChoosingCriterion.Text = "Choose Main Criterion:";
            // 
            // combo2
            // 
            this.combo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo2.FormattingEnabled = true;
            this.combo2.Location = new System.Drawing.Point(16, 195);
            this.combo2.Margin = new System.Windows.Forms.Padding(4);
            this.combo2.Name = "combo2";
            this.combo2.Size = new System.Drawing.Size(232, 28);
            this.combo2.TabIndex = 26;
            // 
            // Simulations
            // 
            this.Simulations.AutoSize = true;
            this.Simulations.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Simulations.Location = new System.Drawing.Point(14, 156);
            this.Simulations.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Simulations.Name = "Simulations";
            this.Simulations.Size = new System.Drawing.Size(145, 20);
            this.Simulations.TabIndex = 27;
            this.Simulations.Text = "No. of Simulations";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.groupBox1.Controls.Add(this.combo1);
            this.groupBox1.Controls.Add(this.ChoosingCriterion);
            this.groupBox1.Controls.Add(this.combo2);
            this.groupBox1.Controls.Add(this.sensitivity);
            this.groupBox1.Controls.Add(this.Simulations);
            this.groupBox1.Controls.Add(this.Cancel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1549, 41);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(268, 536);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sensitivity Analysis (SA)";
            // 
            // Note
            // 
            this.Note.AutoEllipsis = true;
            this.Note.AutoSize = true;
            this.Note.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Note.CausesValidation = false;
            this.Note.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Note.ForeColor = System.Drawing.Color.Maroon;
            this.Note.Location = new System.Drawing.Point(939, 64);
            this.Note.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Note.Name = "Note";
            this.Note.Size = new System.Drawing.Size(571, 71);
            this.Note.TabIndex = 30;
            this.Note.Text = "1) Enter values between 1 (equal preference) and  9 (very strong preference). \r\n2" +
    ") Pairwise comparison is done row against the column. \r\n3) Inverse values are au" +
    "tomatically computed and displayed.\r\n";
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressLabel.ForeColor = System.Drawing.Color.Maroon;
            this.progressLabel.Location = new System.Drawing.Point(939, 611);
            this.progressLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(357, 23);
            this.progressLabel.TabIndex = 31;
            this.progressLabel.Text = "Geoprocessing status will be displayed here !!";
            // 
            // clearMatrix
            // 
            this.clearMatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearMatrix.Location = new System.Drawing.Point(819, 336);
            this.clearMatrix.Name = "clearMatrix";
            this.clearMatrix.Size = new System.Drawing.Size(96, 71);
            this.clearMatrix.TabIndex = 32;
            this.clearMatrix.Text = "Clear AHP Matrix";
            this.clearMatrix.UseVisualStyleBackColor = true;
            this.clearMatrix.Click += new System.EventHandler(this.clearMatrix_Click);
            // 
            // AHPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(1828, 681);
            this.Controls.Add(this.clearMatrix);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.Note);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.Cal);
            this.Controls.Add(this.AddMulti);
            this.Controls.Add(this.Enter);
            this.Controls.Add(this.Map);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.ratingMatrix);
            this.Controls.Add(this.AddToLeft);
            this.Controls.Add(this.List);
            this.Controls.Add(this.Goal);
            this.Controls.Add(this.AddToRight);
            this.Controls.Add(this.About);
            this.Controls.Add(this.SelectedCriteria);
            this.Controls.Add(this.AvailableRasters);
            this.Font = new System.Drawing.Font("Calibri", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AHPForm";
            this.Text = "The AHP Add-in for ArcGIS Pro";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AHPForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AvailableRasters;
        private System.Windows.Forms.Label SelectedCriteria;
        private System.Windows.Forms.Button About;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.ListBox List;
        private System.Windows.Forms.Button AddToLeft;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.BindingSource bindingSource3;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSource4;
        private System.Windows.Forms.BindingSource bindingSource5;
        public System.Windows.Forms.TreeView Goal;
        private System.Windows.Forms.Label ratingMatrix;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button Map;
        private System.Windows.Forms.TextBox textBox1;
        private new System.Windows.Forms.Button Enter;
        public System.Windows.Forms.Button AddToRight;
        private System.Windows.Forms.Button AddMulti;
        private System.Windows.Forms.Button Cal;
        private System.Windows.Forms.Button sensitivity;
        private System.Windows.Forms.ComboBox combo1;
        private System.Windows.Forms.Label Result;
        private System.Windows.Forms.Label ChoosingCriterion;
        private System.Windows.Forms.ComboBox combo2;
        private System.Windows.Forms.Label Simulations;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Note;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Button clearMatrix;
    }
}