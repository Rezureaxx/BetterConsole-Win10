using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.IO;
using System.Net.NetworkInformation;

namespace NewCommandLine
{
    class Program
    {

        static void Main(string[] args)
        {
            var defaultDirectory = @"c:\";
            var currentDirectory = "C:";
            var gopath = "C:\\";
            var pathbackup = "C:\\";
            string userwantpath = "";
            int moveanzahl = 0;
            bool nothingmoved = true;

            

            Console.WriteLine(currentDirectory);
            Console.WriteLine("BETTER COMMAND LINE MADE BY REZUREAX ");
            while (true)
            {
                Console.Write(currentDirectory + ">");
                string commandinput = Console.ReadLine();
                string userinput = commandinput.ToLower();

                char[] delim = new char[] { ' ' };
                string[] splitted = userinput.Split(delim);

                string userinput1 = splitted[0];
                string userinput2 = string.Empty;
                if (splitted.Length > 1)
                {
                    userinput2 = splitted[1];
                }



                //Befehle
                if (userinput == "help" || userinput == "Help")
                {
                    Console.WriteLine("Befehle: ");
                    //Befehle
                    Console.WriteLine("Pinger   : Ping a Website ");
                    Console.WriteLine("Clear    : Clear the Console ");
                    Console.WriteLine("Title    : Change the Console Title ");
                    Console.WriteLine("Echo     : Simple Echo");
                    Console.WriteLine("Shutdown : Turn off your Pc");
                    Console.WriteLine("Restart  : Restart your Pc ");
                    Console.WriteLine("Version  : Show current version");
                    Console.WriteLine("where    : Show Current Path");
                    Console.WriteLine("ls/list  : List files in Path");
                    Console.WriteLine("move     : Move File");
                    Console.WriteLine("go       : Go to Folder");
                    Console.WriteLine("cd..     : Move one folder back");
                    Console.WriteLine("start    : Start Programm");
                    Console.WriteLine("default  : Go to Default Path");
                    Console.WriteLine("bug      : Report Bug");
                    Console.WriteLine("exit     : close console");
                    



                }

                //Pinger
                if (userinput1 == "pinger" || userinput1 == "ping")
                {
                    bool pingable = false;
                    Ping pinger = null;
                    if (userinput2 == "")
                    {
                        Console.WriteLine("PING HILFE:");
                        Console.WriteLine("Du hast die Addresse vergessen.");
                        Console.WriteLine("Bsp: ping google.com");


                    }
                    else
                    {
                        try
                        {
                            pinger = new Ping();
                            PingReply reply = pinger.Send(userinput2);
                            pingable = reply.Status == IPStatus.Success;
                        }
                        catch (PingException)
                        {
                            // Discard PingExceptions and return false;
                        }
                        finally
                        {
                            if (pinger != null)
                            {
                                pinger.Dispose();
                            }
                        }

                        if (pingable == true)
                        {
                            Console.WriteLine(userinput2 + " ist online!");
                        }
                        else if (pingable == false)
                        {
                            Console.WriteLine(userinput2 + " ist offline!");
                        }


                    }
                    
                }

                //Clearen
                if (userinput1 == "clear" || userinput1 == "cls")
                {
                    Console.Clear();
                }


                if (userinput1 == "title"  || userinput1 == "Title" )
                {
                    if (userinput2 == "")
                    {
                        Console.WriteLine("Title:");
                        string newtitle = Console.ReadLine();
                        Console.Title = newtitle;


                    }
                    else
                    {
                        Console.Title = userinput2;


                    }

                }

                //Echo
                if (userinput1 == "echo")
                {
                    Console.WriteLine(userinput2);
                }

                //Shutdown
                if (userinput1 == "shutdown")
                {
                    Console.Write("Dein Pc wird heruntergefahren. Bist du sicher J/N: ");
                    string shutdownaccept = Console.ReadLine();
                    string converttolower = shutdownaccept.ToLower();
                    if (converttolower == "j")
                    {
                        Process.Start("shutdown.exe", "-s -t 00");
                    }
                    if (converttolower == "n")
                    {
                        Console.WriteLine("Pc wird nicht heruntergefahren");
                    }
                    else
                    {
                        Console.WriteLine("Keine richtige Antwort: Abbruch");


                    }
                }

                if (userinput1 == "restart")
                {
                    Console.Write("Dein Pc wirdneugestartet. Bist du sicher J/N: ");
                    string restartaccept = Console.ReadLine();
                    string converttolowerzwei = restartaccept.ToLower();
                    if (converttolowerzwei == "j")
                    {
                        Process.Start("shutdown.exe", "-r -t 00");
                    }
                    if (converttolowerzwei == "n")
                    {
                        Console.WriteLine("Pc wird nicht neugestartet");
                    }
                    else
                    {
                        Console.WriteLine("Keine richtige Antwort: Abbruch");



                    }
                }
                if (userinput1 == "version" || userinput1 == "ver")
                {
                    Console.WriteLine("Deine Windows Version ist: ");
                    Console.WriteLine(System.Environment.OSVersion);
                }

                if (userinput1 == "bit")
                {
                    if (Environment.Is64BitOperatingSystem)
                    {
                        Console.WriteLine("Du hast ein 64 Bit System");
                    }
                    else
                    {
                        Console.WriteLine("Du hast ein 32 Bit System");
                    }
                }
                if (userinput1 == "whereami" || userinput1 == "where")
                {
                    try
                    {
                        // Get the current directory.
                        string path1 = Directory.GetCurrentDirectory();
                        string target = @"c:\temp";
                        Console.WriteLine("The current directory is {0}", currentDirectory);
                        if (!Directory.Exists(target))
                        {
                            Directory.CreateDirectory(target);
                        }

                        // Change the current directory.
                        Environment.CurrentDirectory = (target);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("The process failed: {0}", e.ToString());
                    }

                }

                if (userinput1 == "list" || userinput1 == "ls")
                {
                    if (nothingmoved == true)
                    {
                        string currentDirectorycopy = "c:\\";
                        foreach (var path in Directory.GetFiles(currentDirectorycopy))
                        {
                            Console.WriteLine(System.IO.Path.GetFileName(path)); // file name
                            string[] fileArray = Directory.GetDirectories(currentDirectorycopy);
                            for (int i = 0; i < fileArray.Length; i++)
                            {

                                Console.WriteLine(fileArray[i]);
                                Console.WriteLine(" ");
                            }

                        }
                    }
                    else
                    {
                        foreach (var path in Directory.GetFiles(currentDirectory))
                        {
                            Console.WriteLine(System.IO.Path.GetFileName(path)); // file name
                            string[] fileArray = Directory.GetDirectories(currentDirectory);
                            for (int i = 0; i < fileArray.Length; i++)
                            {

                                Console.WriteLine(fileArray[i]);
                                Console.WriteLine(" ");
                            }

                        }
                    }



                }


                

                if (userinput1 == "move")
                {
                    if (userinput2 == "")
                    {
                        Console.WriteLine("Welche Datei wollen sie kopieren?");
                        Console.Write(":");
                        string sourceFilePath = Console.ReadLine();
                        if (File.Exists(sourceFilePath))
                        {
                            Console.WriteLine("Wohin soll die Datei kopiert werden?");
                            Console.Write(":");
                            string destinationFilePath = Console.ReadLine();
                            if (Directory.Exists(userinput2))
                            {
                                File.Copy(destinationFilePath, sourceFilePath, true);
                                File.SetAttributes(destinationFilePath, FileAttributes.Normal);
                            }
                            else
                            {
                                Console.WriteLine("Diesen Pfad gibt es nicht!");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Diese Datei gibt es nicht!");
                        }


                    }
                    else
                    {
                        if (File.Exists(userinput2))
                        {
                            Console.WriteLine("Wohin soll die Datei kopiert werden?");
                            Console.Write(":");
                            string destinationFilPath = Console.ReadLine();
                            if (Directory.Exists(userinput2))
                            {
                                File.Copy(destinationFilPath, userinput2, true);
                                File.SetAttributes(destinationFilPath, FileAttributes.Normal);
                            }
                            else
                            {
                                Console.WriteLine("Diesen Pfad gibt es nicht!");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Diese Datei gibt es nicht!");
                        }
                        


                    }




                }

                if (userinput1 == "del" || userinput1 == "delete" || userinput1 == "remove")
                {


                
                    if(userinput2 == "none")
                    {
                        Console.WriteLine("Vorgang wurde abgebrochen");
                    }
                    if (File.Exists(currentDirectory + "\\" +userinput2))
                    {
                        Console.WriteLine("Sind sie Sicher, dass sie die Datei löschen wollen? J/N: ");
                        string acceptdelete = Console.ReadLine();
                        string acceptdeletelower = acceptdelete.ToLower();
                        if (acceptdeletelower == "j")
                        {
                            File.Delete(currentDirectory + "\\" + userinput2);
                            Console.WriteLine("Datei wurde gelöscht");


                        }
                        else if (acceptdeletelower == "n")
                        {
                            Console.WriteLine("Datei wurde nicht gelöscht");


                        }

                        else
                        {
                            Console.WriteLine("unbekannte Antwort: Abbruch");


                        }
                    }
                    else
                    {
                        Console.WriteLine("Diese Datei gibt es nicht");
                    }


                }

                if (userinput1 == "go")
                {
                    
                    if (Directory.Exists(currentDirectory + "\\" + userinput2))
                    {
                        bool check = false;
                        pathbackup = currentDirectory;
                        currentDirectory = gopath   + userinput2;
                        moveanzahl += 1;
                        nothingmoved = false;
                    }
                    else
                    {
                        Console.WriteLine("Diesen Pfad gibt es nicht");
                    }

                }

                if (userinput1 == "cd..")
                {
                    string newPath = Path.GetFullPath(Path.Combine(currentDirectory, @"..\"));
                    currentDirectory = newPath;
                }

                if (userinput1 == "cd")
                {
                    if (Directory.Exists(userinput2))
                    {

                        currentDirectory = userinput2;
                        moveanzahl -= 1;
                        nothingmoved = false;
                    }
                    else
                    {
                        Console.WriteLine("Diesen Pfad gibt es nicht");
                    }

                }
                if (userinput1 == "exit" || userinput1 == "bye" || userinput1 == "close")
                {
                    Console.WriteLine("bye!");
                    System.Environment.Exit(1);
                }


                if (userinput1 == "start" || userinput1 == "open" || userinput1 == "openfile")
                {
                    if (File.Exists(userinput2))
                    {
                        Process.Start(userinput2);
                    }
                    else
                    {
                        Console.WriteLine("Diese Datei gibt es nicht");
                    }

                }

                if (userinput1 == "default")
                {
                    currentDirectory = "C:\\";

                }

                if (userinput1 == "bug")
                {
                    if (userinput2 == "-y")
                    {
                        try
                        {
                            Process myProcess = new Process();
                            // true is the default, but it is important not to set it to false
                            myProcess.StartInfo.UseShellExecute = true;
                            myProcess.StartInfo.FileName = "https://github.com/Rezureaxx";
                            myProcess.Start();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }


                    }
                    else
                    {
                        Console.WriteLine("Willst du ein Bug reporten?");
                        Console.WriteLine("J/N: ");
                        string bugreportinput = Console.ReadLine();
                        string bugreportinputlower = bugreportinput.ToLower();
                        if (bugreportinput == "j")
                        {
                            try
                            {
                                Process myProcess = new Process();
                                // true is the default, but it is important not to set it to false
                                myProcess.StartInfo.UseShellExecute = true;
                                myProcess.StartInfo.FileName = "https://github.com/Rezureaxx";
                                myProcess.Start();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }


                        }
                        else
                        {
                            Console.WriteLine("Abbruch");


                        }


                    }





                }

                if (userinput1 == "disk" || userinput1 == "getdisk")
                {
                    DriveInfo[] allDrives = DriveInfo.GetDrives();

                    foreach (DriveInfo d in allDrives)
                    {
                        Console.WriteLine("Drive {0}", d.Name);
                        Console.WriteLine("  Drive type: {0}", d.DriveType);
                        if (d.IsReady == true)
                        {
                            Console.WriteLine("  Volume label: {0}", d.VolumeLabel);
                            Console.WriteLine("  File system: {0}", d.DriveFormat);
                            Console.WriteLine(
                                "  Available space to current user:{0, 15} bytes",
                                d.AvailableFreeSpace);

                            Console.WriteLine(
                                "  Total available space:          {0, 15} bytes",
                                d.TotalFreeSpace);

                            Console.WriteLine(
                                "  Total size of drive:            {0, 15} bytes ",
                                d.TotalSize);
                        }


                    }
                    


                }
                else
                {
                    Console.WriteLine("Befehl nicht gefunden");

                }
            }




        }

    }
}
