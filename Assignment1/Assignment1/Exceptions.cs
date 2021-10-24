using System;
using System.IO;

namespace Assignment1
{



    public class Exceptions
    {

        //static void Main()
        //{
        //     var sw = OpenStream(@".\sampleFile.csv");
        //    if (sw is null)
        //        return;
        //    sw.WriteLine("This is the first line.");
        //    sw.WriteLine("This is the second line.");
        //    sw.Close();
        //}

        public static string OpenStream(string path, string pathCSV)
        {
            Log objLogger = new Log();

            if (pathCSV is null)
            {
                objLogger.WriteErrorLog("You did not supply a file path.");
                return null;
            }

            try
            {
                //var fs = new FileStream(path, FileMode.CreateNew);
                //return new StreamWriter(fs);

                if(!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    
                }

                //Delete existing file
                if (File.Exists(pathCSV))
                    File.Delete(pathCSV);
                //Create New file
                File.WriteAllText(pathCSV, "First Name, Last Name, Street Number, Street, City, Province, Country, Postal Code, Phone Number, email Address\n");
                objLogger.WriteInfoLog("Creating file :" + pathCSV);

                return "SUCCESS";
            }
            catch (FileNotFoundException)
            {
                objLogger.WriteErrorLog("The file or directory cannot be found.");
            }
            catch (DirectoryNotFoundException)
            {
                objLogger.WriteErrorLog("The file or directory cannot be found.");
            }
            catch (DriveNotFoundException)
            {
                objLogger.WriteErrorLog("The drive specified in 'path' is invalid.");
            }
            catch (PathTooLongException)
            {
                objLogger.WriteErrorLog("'path' exceeds the maxium supported path length.");
            }
            catch (UnauthorizedAccessException)
            {
                objLogger.WriteErrorLog("You do not have permission to create this file.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
            {
                objLogger.WriteErrorLog("There is a sharing violation.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 80)
            {
                objLogger.WriteErrorLog("The file already exists.");
            }
            catch (IOException e)
            {
                objLogger.WriteErrorLog($"An exception occurred:\nError code: " +
                                  $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
            }
            return null;
        }

    }




}
