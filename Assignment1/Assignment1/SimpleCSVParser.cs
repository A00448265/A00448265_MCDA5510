using System;
using System.IO;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace Assignment1
{
    public class SimpleCSVParser
    {
        public void parse(String fileName, String sPrintPath, ref StringBuilder sOutput, ref int counter, ref int counterworking)
        {
            Log objLogger = new Log();   
            StringBuilder sTemp = new StringBuilder();
            int flag = 0;
            int i = 0;
            int row = 0;

            try
            {
                string[] Headers = { "First Name", "Last Name", "Street Number", "Street", "City", "Province", "Country", "Postal Code","Phone Number","email Address" };

                //First Name, Last Name, Street Number, Street, City, Province, Country, Postal Code, Phone Number, email Address

                using (TextFieldParser parser = new TextFieldParser(fileName))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    #region while

                    while (!parser.EndOfData)
                    {
                        row++;

                        #region Add CSV fields to Temp variable
                        //Process row
                        flag = 0;
                        sTemp.Length = 0;
                        sTemp = new StringBuilder();
                        string[] fields = parser.ReadFields();

                        #region Headers
                        if (fields[0] == "First Name")
                        {
                            //if (iHeader == 0)
                            //{
                            //    iHeader = 1;
                            //    foreach (string field in fields)
                            //    {
                            //        sOutput.Append(field + ",");
                            //    }
                            //    sOutput.Length--;
                            //    sOutput.Append(Environment.NewLine);
                            //}
                            continue;
                        }
                        #endregion
                        i = 0;
                        foreach (string field in fields)
                        {
                            if (!String.IsNullOrEmpty(field))
                            {
                                sTemp.Append(field + ",");
                                i++;
                            }
                            else
                            {
                                flag = 1;
                                objLogger.WriteErrorLog("Skipped row of file name: " + fileName + " and row number " + row +" because of missing column " + Headers[i]);
                                i++;
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
                objLogger.WriteErrorLog(ioe.Message + ioe.StackTrace);
                //Console.WriteLine(ioe.StackTrace);
            }

        }


    }
}
