
using System;
using System.IO;
using System.Text;

namespace Assignment1
{
  

    public class DirWalker
    {
        public void walk(String path,String destinationPath, ref StringBuilder sOutput, ref int counter, ref int counterworking)
        {
            string[] sFilePath;
            string sPrintPath = String.Empty;
            string[] list = Directory.GetDirectories(path);

            if (list == null) return;

            foreach (string dirpath in list)
            {
                if (Directory.Exists(dirpath))
                {
                    walk(dirpath, destinationPath,ref sOutput, ref counter, ref counterworking);
                    //Console.WriteLine("Dir:" + dirpath);
                }
            }
            string[] fileList = Directory.GetFiles(path,"*.csv");
            foreach (string filepath in fileList)
            {
                #region Add Date for bonus points
                try
                {
                    sFilePath = filepath.Split("\\");
                    sPrintPath = sFilePath[sFilePath.Length - 4] + "/" + sFilePath[sFilePath.Length - 3] + "/" + sFilePath[sFilePath.Length - 2];
                    //Console.WriteLine("Entered Date folder :" + sPrintPath);
                }
                catch (Exception ex)
                {
                    sPrintPath = "";
                }
                #endregion

                SimpleCSVParser obj = new SimpleCSVParser();
                obj.parse(filepath, sPrintPath,ref sOutput, ref counter, ref counterworking);

            }
            if (sOutput.Length!=0)
            {
                File.AppendAllText(destinationPath, sOutput.ToString());
                sOutput.Length = 0;
                sOutput = new StringBuilder();
            }
            
        }

    }
}
