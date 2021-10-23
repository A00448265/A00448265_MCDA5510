using System;
using System.IO;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace Assignment1
{
    public class SimpleCSVParser
    {
        public void parse(String fileName, String sPrintPath, ref int iHeader, ref StringBuilder sOutput, ref int counter, ref int counterworking)
        {
            StringBuilder sTemp = new StringBuilder();
            int flag = 0;

            try
            {
                int i = 0;
                using (TextFieldParser parser = new TextFieldParser(fileName))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    #region while

                    while (!parser.EndOfData)
                    {
                        #region Add CSV fields to Temp variable
                        //Process row
                        flag = 0;
                        sTemp.Length = 0;
                        sTemp = new StringBuilder();
                        string[] fields = parser.ReadFields();


                        #region Headers
                        if (fields[0] == "First Name")
                        {
                            if (iHeader == 0)
                            {
                                iHeader = 1;
                                foreach (string field in fields)
                                {
                                    sOutput.Append(field + ",");
                                }
                                sOutput.Length--;
                                sOutput.Append("," + sPrintPath + Environment.NewLine);
                            }
                            
                            continue;
                        }
                        #endregion

                        foreach (string field in fields)
                        {
                            if (!String.IsNullOrEmpty(field))
                            {
                                sTemp.Append(field + ",");
                            }
                            else
                            {
                                flag = 1;
                                break;
                            }
                        }

                        if (flag == 0)
                        {
                            counterworking++;
                            sTemp.Length--;
                            sTemp.Append("," + sPrintPath + Environment.NewLine);
                            sOutput.Append(sTemp);
                        }
                        else
                            counter++;
                        #endregion

                    }
                    #endregion
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.StackTrace);
            }

        }


    }
}
