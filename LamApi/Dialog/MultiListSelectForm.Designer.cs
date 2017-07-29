namespace LamApi.Dialog
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonDoSelected = new System.Windows.Forms.Button();
            this.buttonDoAll = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(28, 28);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(514, 355);
            this.listBox1.TabIndex = 4;
            // 
            // buttonDoSelected
            // 
            this.buttonDoSelected.Location = new System.Drawing.Point(41, 416);
            this.buttonDoSelected.Name = "buttonDoSelected";
            this.buttonDoSelected.Size = new System.Drawing.Size(100, 25);
            this.buttonDoSelected.TabIndex = 5;
            this.buttonDoSelected.Text = "Do Selected";
            this.buttonDoSelected.UseVisualStyleBackColor = true;
            this.buttonDoSelected.Click += new System.EventHandler(this.buttonDoSelected_Click);
            // 
            // buttonDoAll
            // 
            this.buttonDoAll.Location = new System.Drawing.Point(242, 416);
            this.buttonDoAll.Name = "buttonDoAll";
            this.buttonDoAll.Size = new System.Drawing.Size(100, 25);
            this.buttonDoAll.TabIndex = 6;
            this.buttonDoAll.Text = "Do All";
            this.buttonDoAll.UseVisualStyleBackColor = true;
            this.buttonDoAll.Click += new System.EventHandler(this.buttonDoAll_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.buttonCancel.Location = new System.Drawing.Point(419, 416);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 25);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // MultiListSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 469);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonDoAll);
            this.Controls.Add(this.buttonDoSelected);
            this.Controls.Add(this.listBox1);
            this.Name = "MultiListSelectForm";
            this.Text = "MultiListSelectForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonDoSelected;
        private System.Windows.Forms.Button buttonDoAll;
        private System.Windows.Forms.Button buttonCancel;
    }
}