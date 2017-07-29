namespace LamApi.Dialogs
{
    partial class MultiListSelectForm
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
            this.buttonDoSelected = new System.Windows.Forms.Button();
            this.buttonDoAll = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonDoSelected
            // 
            this.buttonDoSelected.Location = new System.Drawing.Point(44, 393);
            this.buttonDoSelected.Name = "buttonDoSelected";
            this.buttonDoSelected.Size = new System.Drawing.Size(100, 25);
            this.buttonDoSelected.TabIndex = 0;
            this.buttonDoSelected.Text = "Do Selected";
            this.buttonDoSelected.UseVisualStyleBackColor = true;
            this.buttonDoSelected.Click += new System.EventHandler(this.buttonDoSelected_Click);
            // 
            // buttonDoAll
            // 
            this.buttonDoAll.Location = new System.Drawing.Point(229, 393);
            this.buttonDoAll.Name = "buttonDoAll";
            this.buttonDoAll.Size = new System.Drawing.Size(100, 25);
            this.buttonDoAll.TabIndex = 1;
            this.buttonDoAll.Text = "Do All";
            this.buttonDoAll.UseVisualStyleBackColor = true;
            this.buttonDoAll.Click += new System.EventHandler(this.buttonDoAll_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.buttonCancel.Location = new System.Drawing.Point(437, 393);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 25);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(36, 22);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(514, 355);
            this.listBox1.TabIndex = 3;
            // 
            // MultiListSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 428);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonDoAll);
            this.Controls.Add(this.buttonDoSelected);
            this.Name = "MultiListSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MultiListSelectForm";
            this.ResumeLayout(false);
           
        }

        #endregion

        private System.Windows.Forms.Button buttonDoSelected;
        private System.Windows.Forms.Button buttonDoAll;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ListBox listBox1;
    }
}