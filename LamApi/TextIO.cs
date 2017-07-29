using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.IO;

namespace LamApi
{
    /// <summary>
    /// Class to perform reading and writing a text file
    /// </summary>
    public class TextIO
    {
        private string inputFilename;
        private string outputFilename;

        public string InputFilename
        {
            get
            {
                return inputFilename;
            }
            set
            {
                inputFilename = value;
            }
        }


        public string OutputFilename
        {
            get
            {
                return outputFilename;
            }
            set
            {
                outputFilename = value;
            }
        }

        /// <summary>
        /// Read a text file
        /// </summary>
        public void ReadFile()
        {
            String line;

            if (File.Exists(inputFilename))
            {
                try
                {
                    FileStream fs = new FileStream(inputFilename, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);
                    while ((line = sr.ReadLine()) != null)
                    {
                        line.Trim();
                        if (!line.StartsWith("#"))
                        {
                            // output fields if text is not a comment line
                            string[] elements = line.Split(';');
                            foreach (string element in elements)
                            {
                                Console.WriteLine(element);
                            }
                            Console.WriteLine("");
                        }
                    } // end while
                    sr.Close();
                    fs.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: Unable to read file " + inputFilename + " " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Error: " + inputFilename + " does not exist.");
            }
        } // end ReadFile



        /// <summary>
        /// Write a text file
        /// </summary>
        public void WriteFile()
        {
            // remove file if file already exist
            if (File.Exists(outputFilename))
            {
                File.Delete(outputFilename);
            }

            try
            {
                FileStream fs = new FileStream(outputFilename, FileMode.CreateNew, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine("LastName = Lam");
                sw.WriteLine("FirstName = Stanley");
                sw.WriteLine("Title = Software Engineer");
                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: unable to write to file " + outputFilename + " " + ex.Message);
            }  // end try-catch
        } // end WriteFile

    } // end class TextIO
} // end namespace
