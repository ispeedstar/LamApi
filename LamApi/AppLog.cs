using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace LamApi
{
    /// <summary>
    /// Class to log application execution
    /// </summary>
    public class AppLog
    {
        private String filename;


        public AppLog(String file)
        {
            filename = file;
        }


        public String Filename
        {
            get
            {
                return (filename);
            }
        }


        /// <summary>
        /// Add message to log file
        /// </summary>
        /// <param name="message"></param>
        public void AddToFile(String message)
        {
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(SetLogMessage(message));
                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: unable to AddToFile " + ex.Message);
            }
        } // end AddToFile



        /// <summary>
        /// Add message to console
        /// </summary>
        /// <param name="message"></param>
        public void AddToConsole(String message)
        {
            Console.WriteLine(SetLogMessage(message));
        } // end AddToConsole



        /// <summary>
        /// Add message to log file and console
        /// </summary>
        /// <param name="message"></param>
        public void AddToFileAndConsole(String message)
        {
            AddToFile(message);
            AddToConsole(message);
        } // end AddToFileAndConsole



        /// <summary>
        /// Set output log message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public String SetLogMessage(String message)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetDateAndTime());
            sb.Append(", ");
            sb.Append(message);
            return (sb.ToString());
        } // end SetLogMessage



        /// <summary>
        /// Get date and time string
        /// </summary>
        /// <returns></returns>
        public String GetDateAndTime()
        {
            String dateFormat = @"yyyy-MM-dd HH:mm:ss";
            DateTime date = DateTime.Now;
            return (date.ToString(dateFormat));
        } // end GetDateAndTime

    } // end clas AppLog
}
