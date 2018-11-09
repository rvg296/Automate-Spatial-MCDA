namespace MyAHP
{
    partial class Calculate
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
            this.Criteria = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ratingMatrix = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.vScrollBar2 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar2 = new System.Windows.Forms.HScrollBar();
            this.Map = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.module1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aHPFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aHPFormBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.module1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aHPFormBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aHPFormBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // Criteria
            // 
            this.Criteria.AutoSize = true;
            this.Criteria.Location = new System.Drawing.Point(35, 22);
            this.Criteria.Name = "Criteria";
            this.Criteria.Size = new System.Drawing.Size(112, 17);
            this.Criteria.TabIndex = 0;
            this.Criteria.Text = "Selected Criteria";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(26, 46);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(289, 371);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(364, 60);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(436, 219);
            this.dataGridView.TabIndex = 2;
            // 
            // ratingMatrix
            // 
            this.ratingMatrix.AutoSize = true;
            this.ratingMatrix.Location = new System.Drawing.Point(361, 26);
            this.ratingMatrix.Name = "ratingMatrix";
            this.ratingMatrix.Size = new System.Drawing.Size(73, 17);
            this.ratingMatrix.TabIndex = 3;
            this.ratingMatrix.Text = "AHPMatrix";
            this.ratingMatrix.Click += new System.EventHandler(this.ratingMatrix_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(364, 318);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(268, 129);
            this.textBox1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(667, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "Calculate CR and CI";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(605, 320);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(27, 128);
            this.vScrollBar1.TabIndex = 6;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(364, 426);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(241, 21);
            this.hScrollBar1.TabIndex = 7;
            // 
            // vScrollBar2
            // 
            this.vScrollBar2.Location = new System.Drawing.Point(800, 60);
            this.vScrollBar2.Name = "vScrollBar2";
            this.vScrollBar2.Size = new System.Drawing.Size(27, 220);
            this.vScrollBar2.TabIndex = 8;
            // 
            // hScrollBar2
            // 
            this.hScrollBar2.Location = new System.Drawing.Point(364, 280);
            this.hScrollBar2.Name = "hScrollBar2";
            this.hScrollBar2.Size = new System.Drawing.Size(436, 21);
            this.hScrollBar2.TabIndex = 9;
            // 
            // Map
            // 
            this.Map.Location = new System.Drawing.Point(670, 381);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(157, 36);
            this.Map.TabIndex = 10;
            this.Map.Text = "Create Suitability Map";
            this.Map.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(717, 455);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 36);
            this.button2.TabIndex = 11;
            this.button2.Text = "Finish";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(538, 455);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(157, 36);
            this.button3.TabIndex = 12;
            this.button3.Text = "<< Previous ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(262, 455);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(157, 36);
            this.button4.TabIndex = 13;
            this.button4.Text = "Cancel";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(38, 451);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(157, 36);
            this.button5.TabIndex = 14;
            this.button5.Text = "About";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // module1BindingSource
            // 
            this.module1BindingSource.DataSource = typeof(MyAHP.Module1);
            // 
            // aHPFormBindingSource
            // 
            this.aHPFormBindingSource.DataSource = typeof(MyAHP.AHPForm);
            // 
            // aHPFormBindingSource1
            // 
            this.aHPFormBindingSource1.DataSource = typeof(MyAHP.AHPForm);
            // 
            // Calculate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 499);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Map);
            this.Controls.Add(this.hScrollBar2);
            this.Controls.Add(this.vScrollBar2);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ratingMatrix);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.Criteria);
            this.Name = "Calculate";
            this.Text = "Assign Weights";
            this.Load += new System.EventHandler(this.Calculate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.module1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aHPFormBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aHPFormBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Criteria;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label ratingMatrix;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.VScrollBar vScrollBar2;
        private System.Windows.Forms.HScrollBar hScrollBar2;
        private System.Windows.Forms.Button Map;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.BindingSource module1BindingSource;
        private System.Windows.Forms.BindingSource aHPFormBindingSource;
        private System.Windows.Forms.BindingSource aHPFormBindingSource1;
        public System.Windows.Forms.TreeView treeView1;
    }
}