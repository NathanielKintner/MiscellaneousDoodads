namespace MagicTestingWare
{
    partial class CardListForm
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
            this.buttonHand = new System.Windows.Forms.Button();
            this.buttonDeckTop = new System.Windows.Forms.Button();
            this.buttonExile = new System.Windows.Forms.Button();
            this.buttonTapped = new System.Windows.Forms.Button();
            this.buttonUntapped = new System.Windows.Forms.Button();
            this.buttonGraveyard = new System.Windows.Forms.Button();
            this.listBoxCards = new System.Windows.Forms.ListBox();
            this.RadioButtonHand = new System.Windows.Forms.RadioButton();
            this.RadioButtonTapped = new System.Windows.Forms.RadioButton();
            this.RadioButtonUntapped = new System.Windows.Forms.RadioButton();
            this.RadioButtonExile = new System.Windows.Forms.RadioButton();
            this.RadioButtonGraveyard = new System.Windows.Forms.RadioButton();
            this.RadioButtonDeckTop = new System.Windows.Forms.RadioButton();
            this.checkBoxAllCards = new System.Windows.Forms.CheckBox();
            this.panelCardImage = new System.Windows.Forms.Panel();
            this.flowLayoutPanelCards = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxDesc = new System.Windows.Forms.TextBox();
            this.panelCardImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonHand
            // 
            this.buttonHand.Location = new System.Drawing.Point(1, 2);
            this.buttonHand.Name = "buttonHand";
            this.buttonHand.Size = new System.Drawing.Size(75, 23);
            this.buttonHand.TabIndex = 0;
            this.buttonHand.Text = "Hand";
            this.buttonHand.UseVisualStyleBackColor = true;
            this.buttonHand.Click += new System.EventHandler(this.buttonHand_Click);
            // 
            // buttonDeckTop
            // 
            this.buttonDeckTop.Location = new System.Drawing.Point(1, 112);
            this.buttonDeckTop.Name = "buttonDeckTop";
            this.buttonDeckTop.Size = new System.Drawing.Size(75, 23);
            this.buttonDeckTop.TabIndex = 1;
            this.buttonDeckTop.Text = "Deck Top";
            this.buttonDeckTop.UseVisualStyleBackColor = true;
            this.buttonDeckTop.Click += new System.EventHandler(this.buttonDeckTop_Click);
            // 
            // buttonExile
            // 
            this.buttonExile.Location = new System.Drawing.Point(1, 68);
            this.buttonExile.Name = "buttonExile";
            this.buttonExile.Size = new System.Drawing.Size(75, 23);
            this.buttonExile.TabIndex = 3;
            this.buttonExile.Text = "Exile";
            this.buttonExile.UseVisualStyleBackColor = true;
            this.buttonExile.Click += new System.EventHandler(this.buttonExile_Click);
            // 
            // buttonTapped
            // 
            this.buttonTapped.Location = new System.Drawing.Point(1, 24);
            this.buttonTapped.Name = "buttonTapped";
            this.buttonTapped.Size = new System.Drawing.Size(75, 23);
            this.buttonTapped.TabIndex = 4;
            this.buttonTapped.Text = "Tapped";
            this.buttonTapped.UseVisualStyleBackColor = true;
            this.buttonTapped.Click += new System.EventHandler(this.buttonTapped_Click);
            // 
            // buttonUntapped
            // 
            this.buttonUntapped.Location = new System.Drawing.Point(1, 46);
            this.buttonUntapped.Name = "buttonUntapped";
            this.buttonUntapped.Size = new System.Drawing.Size(75, 23);
            this.buttonUntapped.TabIndex = 5;
            this.buttonUntapped.Text = "Untapped";
            this.buttonUntapped.UseVisualStyleBackColor = true;
            this.buttonUntapped.Click += new System.EventHandler(this.buttonUntapped_Click);
            // 
            // buttonGraveyard
            // 
            this.buttonGraveyard.Location = new System.Drawing.Point(1, 90);
            this.buttonGraveyard.Name = "buttonGraveyard";
            this.buttonGraveyard.Size = new System.Drawing.Size(75, 23);
            this.buttonGraveyard.TabIndex = 6;
            this.buttonGraveyard.Text = "Graveyard";
            this.buttonGraveyard.UseVisualStyleBackColor = true;
            this.buttonGraveyard.Click += new System.EventHandler(this.buttonGraveyard_Click);
            // 
            // listBoxCards
            // 
            this.listBoxCards.FormattingEnabled = true;
            this.listBoxCards.Location = new System.Drawing.Point(3, 2);
            this.listBoxCards.Name = "listBoxCards";
            this.listBoxCards.Size = new System.Drawing.Size(104, 134);
            this.listBoxCards.TabIndex = 7;
            this.listBoxCards.Visible = false;
            this.listBoxCards.SelectedIndexChanged += new System.EventHandler(this.listBoxCards_SelectedIndexChanged);
            this.listBoxCards.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxCards_MouseDoubleClick);
            // 
            // RadioButtonHand
            // 
            this.RadioButtonHand.AutoSize = true;
            this.RadioButtonHand.Location = new System.Drawing.Point(79, 7);
            this.RadioButtonHand.Name = "RadioButtonHand";
            this.RadioButtonHand.Size = new System.Drawing.Size(14, 13);
            this.RadioButtonHand.TabIndex = 8;
            this.RadioButtonHand.TabStop = true;
            this.RadioButtonHand.UseVisualStyleBackColor = true;
            // 
            // RadioButtonTapped
            // 
            this.RadioButtonTapped.AutoSize = true;
            this.RadioButtonTapped.Location = new System.Drawing.Point(79, 29);
            this.RadioButtonTapped.Name = "RadioButtonTapped";
            this.RadioButtonTapped.Size = new System.Drawing.Size(14, 13);
            this.RadioButtonTapped.TabIndex = 9;
            this.RadioButtonTapped.TabStop = true;
            this.RadioButtonTapped.UseVisualStyleBackColor = true;
            // 
            // RadioButtonUntapped
            // 
            this.RadioButtonUntapped.AutoSize = true;
            this.RadioButtonUntapped.Location = new System.Drawing.Point(79, 51);
            this.RadioButtonUntapped.Name = "RadioButtonUntapped";
            this.RadioButtonUntapped.Size = new System.Drawing.Size(14, 13);
            this.RadioButtonUntapped.TabIndex = 10;
            this.RadioButtonUntapped.TabStop = true;
            this.RadioButtonUntapped.UseVisualStyleBackColor = true;
            // 
            // RadioButtonExile
            // 
            this.RadioButtonExile.AutoSize = true;
            this.RadioButtonExile.Location = new System.Drawing.Point(79, 73);
            this.RadioButtonExile.Name = "RadioButtonExile";
            this.RadioButtonExile.Size = new System.Drawing.Size(14, 13);
            this.RadioButtonExile.TabIndex = 11;
            this.RadioButtonExile.TabStop = true;
            this.RadioButtonExile.UseVisualStyleBackColor = true;
            // 
            // RadioButtonGraveyard
            // 
            this.RadioButtonGraveyard.AutoSize = true;
            this.RadioButtonGraveyard.Location = new System.Drawing.Point(79, 95);
            this.RadioButtonGraveyard.Name = "RadioButtonGraveyard";
            this.RadioButtonGraveyard.Size = new System.Drawing.Size(14, 13);
            this.RadioButtonGraveyard.TabIndex = 12;
            this.RadioButtonGraveyard.TabStop = true;
            this.RadioButtonGraveyard.UseVisualStyleBackColor = true;
            // 
            // RadioButtonDeckTop
            // 
            this.RadioButtonDeckTop.AutoSize = true;
            this.RadioButtonDeckTop.Location = new System.Drawing.Point(79, 117);
            this.RadioButtonDeckTop.Name = "RadioButtonDeckTop";
            this.RadioButtonDeckTop.Size = new System.Drawing.Size(14, 13);
            this.RadioButtonDeckTop.TabIndex = 13;
            this.RadioButtonDeckTop.TabStop = true;
            this.RadioButtonDeckTop.UseVisualStyleBackColor = true;
            // 
            // checkBoxAllCards
            // 
            this.checkBoxAllCards.AutoSize = true;
            this.checkBoxAllCards.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBoxAllCards.Location = new System.Drawing.Point(9, 135);
            this.checkBoxAllCards.Name = "checkBoxAllCards";
            this.checkBoxAllCards.Size = new System.Drawing.Size(67, 17);
            this.checkBoxAllCards.TabIndex = 15;
            this.checkBoxAllCards.Text = "All Cards";
            this.checkBoxAllCards.UseVisualStyleBackColor = true;
            // 
            // panelCardImage
            // 
            this.panelCardImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelCardImage.Controls.Add(this.listBoxCards);
            this.panelCardImage.Location = new System.Drawing.Point(547, 2);
            this.panelCardImage.Name = "panelCardImage";
            this.panelCardImage.Size = new System.Drawing.Size(132, 183);
            this.panelCardImage.TabIndex = 17;
            // 
            // flowLayoutPanelCards
            // 
            this.flowLayoutPanelCards.AutoScroll = true;
            this.flowLayoutPanelCards.AutoScrollMinSize = new System.Drawing.Size(5000, 0);
            this.flowLayoutPanelCards.Location = new System.Drawing.Point(96, 2);
            this.flowLayoutPanelCards.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanelCards.Name = "flowLayoutPanelCards";
            this.flowLayoutPanelCards.Size = new System.Drawing.Size(448, 168);
            this.flowLayoutPanelCards.TabIndex = 18;
            this.flowLayoutPanelCards.WrapContents = false;
            // 
            // textBoxDesc
            // 
            this.textBoxDesc.Location = new System.Drawing.Point(1, 158);
            this.textBoxDesc.Name = "textBoxDesc";
            this.textBoxDesc.Size = new System.Drawing.Size(90, 20);
            this.textBoxDesc.TabIndex = 19;
            this.textBoxDesc.TextChanged += new System.EventHandler(this.textBoxDesc_TextChanged);
            // 
            // CardListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuText;
            this.ClientSize = new System.Drawing.Size(681, 186);
            this.Controls.Add(this.textBoxDesc);
            this.Controls.Add(this.flowLayoutPanelCards);
            this.Controls.Add(this.panelCardImage);
            this.Controls.Add(this.checkBoxAllCards);
            this.Controls.Add(this.RadioButtonDeckTop);
            this.Controls.Add(this.RadioButtonGraveyard);
            this.Controls.Add(this.RadioButtonExile);
            this.Controls.Add(this.RadioButtonUntapped);
            this.Controls.Add(this.RadioButtonTapped);
            this.Controls.Add(this.RadioButtonHand);
            this.Controls.Add(this.buttonGraveyard);
            this.Controls.Add(this.buttonUntapped);
            this.Controls.Add(this.buttonTapped);
            this.Controls.Add(this.buttonExile);
            this.Controls.Add(this.buttonDeckTop);
            this.Controls.Add(this.buttonHand);
            this.Name = "CardListForm";
            this.Text = "CardListForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CardListForm_FormClosed);
            this.panelCardImage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonHand;
        private System.Windows.Forms.Button buttonDeckTop;
        private System.Windows.Forms.Button buttonExile;
        private System.Windows.Forms.Button buttonTapped;
        private System.Windows.Forms.Button buttonUntapped;
        private System.Windows.Forms.Button buttonGraveyard;
        private System.Windows.Forms.ListBox listBoxCards;
        private System.Windows.Forms.RadioButton RadioButtonHand;
        private System.Windows.Forms.RadioButton RadioButtonTapped;
        private System.Windows.Forms.RadioButton RadioButtonUntapped;
        private System.Windows.Forms.RadioButton RadioButtonExile;
        private System.Windows.Forms.RadioButton RadioButtonGraveyard;
        private System.Windows.Forms.RadioButton RadioButtonDeckTop;
        private System.Windows.Forms.CheckBox checkBoxAllCards;
        private System.Windows.Forms.Panel panelCardImage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCards;
        private System.Windows.Forms.TextBox textBoxDesc;
    }
}