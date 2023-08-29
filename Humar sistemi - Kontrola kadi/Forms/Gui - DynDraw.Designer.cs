namespace KontrolaKadi
{
    public partial class Gui
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.propBindingSource = new System.Windows.Forms.BindingSource(this.components);            
            ((System.ComponentModel.ISupportInitialize)(this.propBindingSource)).BeginInit();
            this.SuspendLayout();            
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(410, 172);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 1;            
            // 
            // TestGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 885);
            this.Name = "GUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;            
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestGui_FormClosing);
            this.Load += new System.EventHandler(this.Gui_Load);           
            ((System.ComponentModel.ISupportInitialize)(this.propBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion        
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.BindingSource propBindingSource;
    }
}