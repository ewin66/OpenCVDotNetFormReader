namespace FormBuildHelper
{
    partial class FormRectangle
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OuterPanel = new System.Windows.Forms.Panel();
            this.RegionOfInterestImage = new System.Windows.Forms.PictureBox();
            this.Label = new System.Windows.Forms.Label();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.CheckBox = new System.Windows.Forms.CheckBox();
            this.InnerPanel = new System.Windows.Forms.Panel();
            this.OuterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RegionOfInterestImage)).BeginInit();
            // 
            // OuterPanel
            // 
            this.OuterPanel.Controls.Add(this.RegionOfInterestImage);
            this.OuterPanel.Controls.Add(this.Label);
            this.OuterPanel.Controls.Add(this.TextBox);
            this.OuterPanel.Controls.Add(this.CheckBox);
            this.OuterPanel.Controls.Add(this.InnerPanel);
            this.OuterPanel.Location = new System.Drawing.Point(0, 0);
            this.OuterPanel.Name = "OuterPanel";
            this.OuterPanel.Size = new System.Drawing.Size(200, 100);
            this.OuterPanel.TabIndex = 0;
            // 
            // RegionOfInterestImage
            // 
            this.RegionOfInterestImage.Location = new System.Drawing.Point(0, 0);
            this.RegionOfInterestImage.Name = "RegionOfInterestImage";
            this.RegionOfInterestImage.Size = new System.Drawing.Size(100, 50);
            this.RegionOfInterestImage.TabIndex = 0;
            this.RegionOfInterestImage.TabStop = false;
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Location = new System.Drawing.Point(0, 0);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(35, 13);
            this.Label.TabIndex = 0;
            this.Label.Text = "label1";
            // 
            // TextBox
            // 
            this.TextBox.Location = new System.Drawing.Point(0, 0);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(100, 20);
            this.TextBox.TabIndex = 0;
            // 
            // CheckBox
            // 
            this.CheckBox.AutoSize = true;
            this.CheckBox.Location = new System.Drawing.Point(0, 0);
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Size = new System.Drawing.Size(80, 17);
            this.CheckBox.TabIndex = 0;
            this.CheckBox.Text = "checkBox1";
            this.CheckBox.UseVisualStyleBackColor = true;
            // 
            // InnerPanel
            // 
            this.InnerPanel.Location = new System.Drawing.Point(0, 0);
            this.InnerPanel.Name = "InnerPanel";
            this.InnerPanel.Size = new System.Drawing.Size(200, 100);
            this.InnerPanel.TabIndex = 1;
            this.InnerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.InnerPanel_Paint);
            this.OuterPanel.ResumeLayout(false);
            this.OuterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RegionOfInterestImage)).EndInit();

        }

        #endregion

        private System.Windows.Forms.Panel OuterPanel;
        private System.Windows.Forms.Panel InnerPanel;
        private System.Windows.Forms.PictureBox RegionOfInterestImage;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.CheckBox CheckBox;
        private System.Windows.Forms.TextBox TextBox;
    }
}
