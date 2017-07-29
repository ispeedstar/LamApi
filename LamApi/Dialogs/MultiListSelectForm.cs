using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace LamApi.Dialogs
{
    public partial class MultiListSelectForm : Form
    {
        // selected items
        public int[] selectedItems;
        
        /// <summary>
        /// MultiListSelectForm constructor
        /// </summary>
        /// <param name="title"></param>
        /// <param name="items"></param>
        public MultiListSelectForm(string title, string[] items)
        {
            InitializeComponent();
            this.Text = title;
            this.CenterToScreen();

            
            this.listBox1.Items.Clear();

            // populate listbox items
            if (items.Length > 1)
            {
                foreach (string item in items)
                {
                    this.listBox1.Items.Add(item);
                }
                this.listBox1.SetSelected(0, true);
            }
            this.ShowDialog();
        }

        /// <summary>
        /// Do selected items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDoSelected_Click(object sender, EventArgs e)
        {
            selectedItems = new int[this.listBox1.SelectedIndices.Count];
            for (int i = 0; i < this.listBox1.SelectedIndices.Count; ++i)
            {
                selectedItems[i] = this.listBox1.SelectedIndices[i];
            }
            if (selectedItems.Length != 0)
                this.Close();
        }

        /// <summary>
        /// Do all items in list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDoAll_Click(object sender, EventArgs e)
        {
            selectedItems = new int[this.listBox1.Items.Count];
            for (int i = 0; i < this.listBox1.Items.Count; ++i)
            {
                selectedItems[i] = i;
            }
            this.Close();
        }

        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            selectedItems = null;
            this.Close();
        }

       
    }
}
