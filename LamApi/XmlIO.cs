using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace LamApi
{
    /// <summary>
    /// Class to perform reading and writing an XML file
    /// </summary>
    public class XmlIO
    {
        private String inputFilename;
        private String outputFilename;

        public String InputFilename
        {
            get
            {
                return (inputFilename);
            }
            set
            {
                inputFilename = value;
            }

        }

        public String OutputFilename
        {
            get
            {
                return (outputFilename);
            }
            set
            {
                outputFilename = value;
            }
        }

        public void ReadFile()
        {
            String value;

            if (File.Exists(inputFilename))
            {
                XmlTextReader reader = new XmlTextReader(inputFilename);
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name.ToLower())
                        {
                            case "lastname":
                                reader.Read();
                                value = reader.Value.ToString();
                                Console.WriteLine("lastname = " + value);
                                break;
                            case "firstname":
                                reader.Read();
                                value = reader.Value.ToString();
                                Console.WriteLine("firstname = " + value);
                                break;
                            case "title":
                                reader.Read();
                                value = reader.Value.ToString();
                                Console.WriteLine("title = " + value);
                                break;
                            default:
                                break;
                        } // end switch     

                    } // end if
                } // end while
                reader.Close();

            } // end if
            else
            {
                Console.WriteLine("Error: unable to open file " + inputFilename);
            }
        } // end ReadFile


        /// <summary>
        /// Write an XML file
        /// </summary>
        public void WriteFile()
        {
            if (File.Exists(outputFilename))
            {
                File.Delete(outputFilename);
            }

            try
            {
                XmlTextWriter writer = new XmlTextWriter(outputFilename,null);
                // set the formatting
                writer.Formatting = Formatting.Indented;

                // write XML declaration
                writer.WriteStartDocument(true);

                // write a comment line
                writer.WriteComment("This is a user XML file");

                // write the root element
                writer.WriteStartElement("USERINFO");
                writer.WriteAttributeString("Version", "1");

                // write the user element
                writer.WriteStartElement("USER");
                writer.WriteElementString("LASTNAME", "Lam");
                writer.WriteElementString("FIRSTNAME", "Stanley");
                writer.WriteElementString("TITLE", "Software Engineer");

                // write root end document
                writer.WriteEndElement();
                writer.Flush();
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: unable to writeFile " + ex.Message);
            }
        } // end WriteFile



        /// <summary>
        /// Navigate XMl document using XPath
        /// </summary>
        public void NavXPath()
        {
            if (File.Exists(inputFilename))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(inputFilename);

                String xPathStr = @"//USERINFO/USER";
                XmlNodeList userList = doc.SelectNodes(xPathStr);

                foreach (XmlElement user in userList)
                {
                    foreach (XmlElement child in user.ChildNodes)
                    {
                        Console.WriteLine(child.Name + " = " + child.InnerText);
                    }
                } // end foreach

            } // end if
        } // end NavXPath


        /// <summary>
        /// Read a XML file using XmlTextReader
        /// </summary>
        public void TextReadFile()
        {
            if (File.Exists(inputFilename))
            {
                XmlReader reader = new XmlTextReader(inputFilename);
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.LocalName)
                        {
                            case "USER":
                                PrintUser(reader);
                                break;
                            default:
                                break;
                        }
                    }
                } // end while
                reader.Close();
            }
            else
            {
                Console.WriteLine("Error: unable to TextReadFile " + inputFilename);
            }
        }



        /// <summary>
        /// Write a XML file using XmlTextWriter
        /// </summary>
        public void TextWriteFile()
        {
            if (File.Exists(outputFilename))
            {
                File.Delete(outputFilename);
            }

            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = ("\t");
                settings.OmitXmlDeclaration = true;

                XmlWriter writer = XmlWriter.Create(outputFilename, settings);
                writer.WriteStartDocument();
                writer.WriteStartElement("USERINFO");
                writer.WriteAttributeString("Version", "1.0");
                writer.WriteStartElement("USER");
                writer.WriteElementString("LASTNAME", "Lam");
                writer.WriteElementString("FIRSTNAME", "Stanley");
                writer.WriteElementString("TITLE", "Software Engineer");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.Flush();
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: unable to TextWriteFile " + ex.Message);
            }
        } // end TextWriteFile


        /// <summary>
        /// Display a XML node
        /// </summary>
        /// <param name="reader"></param>
        public void PrintUser(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "LASTNAME":
                            Console.WriteLine("Lastname = " + reader.ReadString());
                            break;
                        case "FIRSTNAME":
                            Console.WriteLine("Firstname = " + reader.ReadString());
                            break;
                        case "TITLE":
                            Console.WriteLine("Title = " + reader.ReadString());
                            break;
                        default:
                            break;
                    } // end switch
                }
            }
        } // end PrintUser

    } // end class XmlIO
}
