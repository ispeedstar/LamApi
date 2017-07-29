using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LamApi
{
    public class CException
    {
        public void DoException()
        {
            try
            {
                DoDividedByZero();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception.Message");
                MessageBox.Show(ex.Source, "Exception.Source");
                MessageBox.Show(ex.StackTrace, "Exception.StackTrace");
                MessageBox.Show(ex.TargetSite.ToString(),"TargetSite");
                MessageBox.Show(ex.HelpLink, "HelpLink");
                StringBuilder sb = new StringBuilder();
                sb.Append("Error in ");
                sb.Append(ex.TargetSite.ToString());
                sb.Append(". ");
                sb.Append(ex.Message);
                MessageBox.Show(sb.ToString(), "Error");
            } // end try-catch

        } // end DoException

        /// <summary>
        /// Do divide by zero method
        /// </summary>
        public void DoDividedByZero()
        {
            int a = 2;
            double ans = a / (a - a);
        } // end DoDividedByZero

    } // end class CException
}
