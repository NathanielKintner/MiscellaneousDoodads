namespace LookForLines
{
    partial class Form1
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
            this.comboBoxFiles = new System.Windows.Forms.ComboBox();
            this.buttonLookForLine = new System.Windows.Forms.Button();
            this.panelToDrawOn = new System.Windows.Forms.Panel();
            this.comboBoxDrawOptions = new System.Windows.Forms.ComboBox();
            this.labelDataQuality = new System.Windows.Forms.Label();
            this.buttonNewData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxFiles
            // 
            this.comboBoxFiles.FormattingEnabled = true;
            this.comboBoxFiles.Location = new System.Drawing.Point(12, 12);
            this.comboBoxFiles.Name = "comboBoxFiles";
            this.comboBoxFiles.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFiles.TabIndex = 0;
            // 
            // buttonLookForLine
            // 
            this.buttonLookForLine.Location = new System.Drawing.Point(12, 66);
            this.buttonLookForLine.Name = "buttonLookForLine";
            this.buttonLookForLine.Size = new System.Drawing.Size(75, 23);
            this.buttonLookForLine.TabIndex = 1;
            this.buttonLookForLine.Text = "Draw";
            this.buttonLookForLine.UseVisualStyleBackColor = true;
            this.buttonLookForLine.Click += new System.EventHandler(this.buttonLookForLine_Click);
            // 
            // panelToDrawOn
            // 
            this.panelToDrawOn.Location = new System.Drawing.Point(151, 12);
            this.panelToDrawOn.Name = "panelToDrawOn";
            this.panelToDrawOn.Size = new System.Drawing.Size(762, 395);
            this.panelToDrawOn.TabIndex = 2;
            // 
            // comboBoxDrawOptions
            // 
            this.comboBoxDrawOptions.FormattingEnabled = true;
            this.comboBoxDrawOptions.Location = new System.Drawing.Point(12, 39);
            this.comboBoxDrawOptions.Name = "comboBoxDrawOptions";
            this.comboBoxDrawOptions.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDrawOptions.TabIndex = 3;
            // 
            // labelDataQuality
            // 
            this.labelDataQuality.AutoSize = true;
            this.labelDataQuality.Location = new System.Drawing.Point(12, 96);
            this.labelDataQuality.Name = "labelDataQuality";
            this.labelDataQuality.Size = new System.Drawing.Size(74, 13);
            this.labelDataQuality.TabIndex = 4;
            this.labelDataQuality.Text = "labelDataQual";
            // 
            // buttonNewData
            // 
            this.buttonNewData.Location = new System.Drawing.Point(11, 185);
            this.buttonNewData.Name = "buttonNewData";
            this.buttonNewData.Size = new System.Drawing.Size(75, 23);
            this.buttonNewData.TabIndex = 5;
            this.buttonNewData.Text = "NewDataset";
            this.buttonNewData.UseVisualStyleBackColor = true;
            this.buttonNewData.Click += new System.EventHandler(this.buttonNewData_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 419);
            this.Controls.Add(this.buttonNewData);
            this.Controls.Add(this.labelDataQuality);
            this.Controls.Add(this.comboBoxDrawOptions);
            this.Controls.Add(this.panelToDrawOn);
            this.Controls.Add(this.buttonLookForLine);
            this.Controls.Add(this.comboBoxFiles);
            this.Name = "Form1";
            this.Text = "Bump Finder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxFiles;
        private System.Windows.Forms.Button buttonLookForLine;
        private System.Windows.Forms.Panel panelToDrawOn;
        private System.Windows.Forms.ComboBox comboBoxDrawOptions;
        private System.Windows.Forms.Label labelDataQuality;
        private System.Windows.Forms.Button buttonNewData;
    }
}

