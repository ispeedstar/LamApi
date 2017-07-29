using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LamApi
{
    /// <summary>
    /// Class to show test dialog
    /// </summary>
    public class CDialog
    {
        public int[] ShowDialog(String title, String[] items)
        {
            Dialog.MultiListSelectForm dlg = new Dialog.MultiListSelectForm(title, items);
            return (dlg.selectedItems);
        } // end ShowDialog

    } // end class CDialog
}
