using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Assignment1;
using System.Configuration;

namespace ConsoleAssignment
{
    class Program
    {
       
        /// <summary>
        /// Main Method to traverse directories, read CSVs and display output in a single csv 
        /// </summary>
        /// <Author>Rohan Vashist A00448265</Author>
        /// <Date>22/10/2021</Date>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int counter = 0;
            int counterworking = 0;
            Assignment1.DirWalker dir = new Assignment1.DirWalker();
            StringBuilder sOutput = new StringBuilder();
            var timer = new Stopwatch();

            Console.WriteLine("Program has started. Please wait..");

            Log objLogger = new Log();

            string filePath = ConfigurationManager.AppSettings["filename"].ToString();
            objLogger.WriteInfoLog("Path to read the sample data :" + filePath);

            string DestPath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin")) + "\\Output";
            objLogger.WriteInfoLog("Path to write the output data :" + DestPath);

            string filePathCSV = DestPath + @"\\output.csv";
           // string filePathTXT = sPath + @"\\Output\\output.txt";

            #region Check if rights exist for writing files

            string sResult = Exceptions.OpenStream(DestPath,filePathCSV);
            if(String.IsNullOrEmpty(sResult))
            {
                return;
            }

            #endregion

            #region Traverse and read CSV files

            timer.Start();
            dir.walk(filePath, filePathCSV, ref sOutput, ref counter, ref counterworking);
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            string timeElapsed = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");

            #endregion

            //System.IO.File.Move(filePathTXT, filePathCSV);
            objLogger.WriteInfoLog("Total execution time – " + timeElapsed + " Total number of valid rows – " + counterworking + " Total number of skipped rows - " + counter);
            File.AppendAllText(filePathCSV, "Total execution time – " + timeElapsed + " Total number of valid rows – " + counterworking + " Total number of skipped rows - " + counter);

            Console.WriteLine("Done! Please check logs and output");
            Console.ReadKey();
        }
    }
}
