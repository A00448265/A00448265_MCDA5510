
This Assignment project consists of a DLL (Assignment1) and Console Application (ConsoleAssignment). The program traverses a folder structure, skips the records with any blank value and writes the data into Output/Output.csv.
It also logs the skipped records (Folder,file name, row number) in logs folder. (Used log4net for logging)
Execution time, counted and skipped records have been logged in both csv file as well as logs.

To change the destination: 
1. Go to ConsoleAssignment\App.Config and change key value of filename. (in case code will be compiled)
2. Go to ConsoleAssignment\bin\Debug\net5.0\App.config and change the key value of filename (in case need to run without compiling the code)

For logging, Log4net has been used.