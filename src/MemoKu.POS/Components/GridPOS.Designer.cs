namespace MemoKu.POS.Components
{
    partial class GridPOS
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
            this.itemPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.posGridFooter = new MemoKu.POS.Components.POSGridFooter();
            this.posGridHeader = new MemoKu.POS.Components.POSGridHeader();
            this.SuspendLayout();
            // 
            // itemPanel
            // 
            this.itemPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel.Location = new System.Drawing.Point(0, 37);
            this.itemPanel.Name = "itemPanel";
            this.itemPanel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.itemPanel.Size = new System.Drawing.Size(528, 196);
            this.itemPanel.TabIndex = 2;
            // 
            // posGridFooter
            // 
            //this.posGridFooter.CanvasColor = System.Drawing.SystemColors.Control;
            this.posGridFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.posGridFooter.Location = new System.Drawing.Point(0, 233);
            this.posGridFooter.Margin = new System.Windows.Forms.Padding(1);
            this.posGridFooter.Name = "posGridFooter";
            this.posGridFooter.Size = new System.Drawing.Size(528, 33);
            this.posGridFooter.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.posGridFooter.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(86)))));
            this.posGridFooter.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(53)))), ((int)(((byte)(58)))));
            this.posGridFooter.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.posGridFooter.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.posGridFooter.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.posGridFooter.Style.GradientAngle = 90;
            this.posGridFooter.TabIndex = 1;
            // 
            // posGridHeader
            // 
            this.posGridHeader.CanvasColor = System.Drawing.SystemColors.Control;
            this.posGridHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.posGridHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posGridHeader.Location = new System.Drawing.Point(0, 0);
            this.posGridHeader.Margin = new System.Windows.Forms.Padding(1);
            this.posGridHeader.Name = "posGridHeader";
            this.posGridHeader.Size = new System.Drawing.Size(528, 37);
            this.posGridHeader.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.posGridHeader.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(86)))));
            this.posGridHeader.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(53)))), ((int)(((byte)(58)))));
            this.posGridHeader.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.posGridHeader.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.posGridHeader.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.posGridHeader.Style.GradientAngle = 90;
            this.posGridHeader.TabIndex = 0;
            // 
            // GridPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.itemPanel);
            this.Controls.Add(this.posGridFooter);
            this.Controls.Add(this.posGridHeader);
            this.Name = "GridPOS";
            this.Size = new System.Drawing.Size(528, 266);
            this.ResumeLayout(false);

        }

        #endregion

        private POSGridHeader posGridHeader;
        private POSGridFooter posGridFooter;
        private System.Windows.Forms.FlowLayoutPanel itemPanel;
    }
}
