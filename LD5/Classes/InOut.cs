using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.UI;

namespace LD5.Classes
{
    /// <summary>
    /// Class for handlind inputs and outputs
    /// </summary>
    public static class InOut
    {
        /// <summary>
        /// Method that reads days of the server
        /// </summary>
        /// <param name="path">path of directory</param>
        /// <returns>List of days were servers was visited</returns>
        /// <exception cref="Exception">Handles exceptiosn</exception>
        public static List<Day> ReadDays(string path)
        {
            List<Day> days = new List<Day>();
            try
            {
                foreach (string fileName in Directory.GetFiles(path))
                {
                    try
                    {
                        string[] lines = File.ReadAllLines(fileName);


                        if (lines.Length < 3)
                        {
                            throw new Exception($"Faile {fileName} nėra pakankamai eilučių.");
                        }

                        List<Visit> visits = new List<Visit>();
                        for (int i = 2; i < lines.Length; i++)
                        {
                            string[] values = lines[i].Split(';');
                            if (values.Length < 3)
                            {
                                throw new Exception($"Trūkstamos reikšmės failo {fileName} eilutėje {i + 1}.");
                            }

                            try
                            {
                                Visit viist = new Visit(TimeSpan.Parse(values[0]), values[1], values[2]);
                                visits.Add(viist);
                            }
                            catch (FormatException)
                            {
                                throw new Exception($"Netinkamas formatas failo {i + 1} eilutėje {fileName}.");
                            }
                            catch (Exception ex)
                            {
                                throw new Exception($"Netiketa klaida ivyko failo {i + 1} faile {fileName}: {ex.Message}");
                            }
                        }
                        days.Add(new Day(DateTime.Parse(lines[0]), lines[1], visits));
                    }
                    catch (IOException ex)
                    {
                        throw new Exception($"Neimanoma perskaityti {fileName}: {ex.Message}");
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new Exception($"Prie {path} direktyvos neimanoma prieiti {ex.Message}");
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new Exception($"Direktyva {path} nerasta: {ex.Message}");
            }
            catch (Exception ex)
            {

                string errorMessage = ex.Message.Replace("\"", "\\\"").Replace("\r\n", "\\n");
                string script = $"<script>alert(\"{errorMessage}\");</script>";
                Page page = HttpContext.Current.CurrentHandler as Page;
                if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("ErrorMessage"))
                {
                    page.ClientScript.RegisterClientScriptBlock(page.GetType(), "ErrorMessage", script);
                }
            }

            return days;
        }
        /// <summary>
        /// Read the informations about the servers
        /// </summary>
        /// <param name="path">the directory of the files</param>
        /// <returns>the list of servers</returns>
        /// <exception cref="Exception">handles the exceptions</exception>
        public static List<Server> ReadServer(string path)
        {
            List<Server> servers = new List<Server>();
            try
            {
                foreach (string fileName in Directory.GetFiles(path))
                {
                    try
                    {
                        string[] lines = File.ReadAllLines(fileName);


                        if (lines.Length < 1)
                        {
                            throw new Exception($"Faile {fileName} nėra pakankamai eilučių.");
                        }

                        foreach (string line in lines)
                        {
                            string[] values = line.Split(';');
                            servers.Add(new Server(values[0], values[1]));
                        }

                    }
                    catch (IOException ex)
                    {
                        throw new Exception($"Neimanoma perskaityti {fileName}: {ex.Message}");
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new Exception($"Prie {path} direktyvos neimanoma prieiti {ex.Message}");
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new Exception($"Direktyva {path} nerasta: {ex.Message}");
            }
            catch (Exception ex)
            {

                string errorMessage = ex.Message.Replace("\"", "\\\"").Replace("\r\n", "\\n");
                string script = $"<script>alert(\"{errorMessage}\");</script>";
                Page page = HttpContext.Current.CurrentHandler as Page;
                if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("ErrorMessage"))
                {
                    page.ClientScript.RegisterClientScriptBlock(page.GetType(), "ErrorMessage", script);
                }
            }

            return servers;
        }
        public static void PrintDays(List<Day> days, string fileName)
        {
            using (var writer = new StreamWriter(fileName, true))
            {

                foreach (var day in days)
                {
                    writer.WriteLine(day.Date.ToString("yyyy/MM/dd"));
                    writer.WriteLine(day.IP);
                    
                    string lul = string.Format("|{0,-20}|{1,-20}|{2,-20}|", "Laikas", "IP", "URL");
                    foreach(var v in day)
                    {
                        writer.WriteLine(v.ToString());
                    }
                }
            }
        }

    }
}