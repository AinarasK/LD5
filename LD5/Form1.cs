using LD5.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LD5
{
    /// <summary>
    /// class for keepint it tidy in the real form1 class
    /// </summary>
    public partial class Form1 : System.Web.UI.Page
    {
        /// <summary>
        /// checks if the fileupload has proper files
        /// </summary>
        /// <param name="fileUpload">the fileupload</param>
        /// <returns>wether the files are proper or not</returns>
        public bool hasProperFiles(FileUpload fileUpload)
        {
            foreach (HttpPostedFile file in fileUpload.PostedFiles)
            {
                if (!(file.FileName.EndsWith(".txt")))
                {
                    return false;
                }
            }
            return fileUpload.HasFiles;
        }
        /// <summary>
        /// copies the files to the server that were uploaded in the fileuplaod
        /// </summary>
        /// <param name="fileUplaod"></param>
        /// <param name="path"></param>
        public void CopyFilesToServer(FileUpload fileUplaod, string path)
        {
            IList<HttpPostedFile> files = fileUplaod.PostedFiles;
            for (int i = 0; i < fileUplaod.PostedFiles.Count; i++)
            {
                files[i].SaveAs(path + files[i].FileName);
            }
        }
        /// <summary>
        /// add options to the dropdown list
        /// </summary>
        /// <param name="servers">servers to add</param>
        /// <param name="dropDownList">dropdown list where everything is going to be stored</param>
        public void AddOptionsToDrowDownList(List<Server> servers, DropDownList dropDownList)
        {
            HashSet<string> set = new HashSet<string>();
            foreach (Server server in servers)
            {
                set.Add(server.URL);
            }
            foreach (string server in set)
            {
                dropDownList.Items.Add(server);
            }
        }
        /// <summary>
        /// add options to the dropdown list
        /// </summary>
        /// <param name="servers">servers to add</param>
        /// <param name="dropDownList">dropdown list where everything is going to be stored</param>
        public void AddOptionsToDrowDownList(List<Day> days, DropDownList dropDownList)
        {
            HashSet<DateTime> set = new HashSet<DateTime>();
            foreach (Day day in days)
            {
                set.Add(day.Date);
            }
            foreach (DateTime date in set)
            {
                dropDownList.Items.Add(date.ToString("yyyy/MM/dd"));
            }
        }
        /// <summary>
        /// Creates table for the days 
        /// </summary>
        /// <param name="days">days visited</param>
        /// <param name="placeHolder">Placeholder for storing the informations</param>
        public void CreateTable(List<Day> days, PlaceHolder placeHolder)
        {
            foreach (Day day in days)
            {
                Label label = new Label() { Text = $"{day.Date.ToString("yyyy/MM/dd")} dienos duomenys {day.IP}" };
                Table table = new Table();
                TableCell title1 = new TableCell() { Text = "Laikas" };
                TableCell title2 = new TableCell() { Text = "Komputerio IP" };
                TableCell title3 = new TableCell() { Text = "Puslapio pavadinimas" };
                TableRow titleRow = new TableRow() { Cells = { title1, title2, title3 } };
                table.Rows.Add(titleRow);

                foreach (Visit v in day)
                {
                    TableCell cell1 = new TableCell() { Text = v.Time.ToString() };
                    TableCell cell2 = new TableCell() { Text = v.IP };
                    TableCell cell3 = new TableCell() { Text = v.URl };
                    TableRow dataRow = new TableRow() { Cells = { cell1, cell2, cell3 } };
                    table.Rows.Add(dataRow);
                }

                // Add controls to the placeholder
                placeHolder.Controls.Add(label);
                placeHolder.Controls.Add(table);
            }
        }
        /// <summary>
        /// Creates table for the days 
        /// </summary>
        /// <param name="days">days visited</param>
        /// <param name="placeHolder">Placeholder for storing the informations</param>
        public void CreateTableTwo(List<Server> servers, PlaceHolder placeHolder)
        {
            Label label1 = new Label() { Text = "Serveriai" };
            Table table = new Table();
            TableCell Title1 = new TableCell() { Text = "Severio IP" };
            TableCell Title2 = new TableCell() { Text = "Serverio simbolinis adresas" };
            TableRow row1 = new TableRow() { Cells = { Title1, Title2 } };
            table.Rows.Add(row1);
            foreach (Server server in servers)
            {
                TableCell cell1 = new TableCell() { Text = server.IP };
                TableCell cell2 = new TableCell() { Text = server.URL };
                TableRow row2 = new TableRow() { Cells = { cell1, cell2 } };
                table.Rows.Add(row2);
            }
            PlaceHolder1.Controls.Add(label1);
            PlaceHolder1.Controls.Add(table);
        }
        /// <summary>
        /// Creates table for the days 
        /// </summary>
        /// <param name="days">days visited</param>
        /// <param name="placeHolder">Placeholder for storing the informations</param>
        public void CreateTableThree(List<Visit> visits, Table table)
        {
            
            TableCell titleA = new TableCell() { Text = "Laikas" };
            TableCell Title1 = new TableCell() { Text = "Severio IP" };
            TableCell Title2 = new TableCell() { Text = "Puslapio adresas" };
            TableRow row1 = new TableRow() { Cells = { titleA, Title1, Title2 } };
            table.Rows.Add(row1);
            foreach (Visit visit in visits)
            {
                TableCell cell1 = new TableCell() { Text = visit.Time.ToString() };
                TableCell cell2 = new TableCell() { Text = visit.IP };
                TableCell cell3 = new TableCell() { Text = visit.URl.ToString() };
                TableRow row2 = new TableRow() { Cells = { cell1, cell2, cell3 } };
                table.Rows.Add(row2);
            }

        }
        /// <summary>
        /// Creates table for the days 
        /// </summary>
        /// <param name="days">days visited</param>
        /// <param name="placeHolder">Placeholder for storing the informations</param>
        public void CreateTableThree(List<Day> days, Table table)
        {

            TableCell titleA = new TableCell() { Text = "IP" };
            TableCell Title1 = new TableCell() { Text = "Kiek kartų prisijungta" };
            
            TableRow row1 = new TableRow() { Cells = { titleA, Title1} };
            table.Rows.Add(row1);
            foreach (Day day in days)
            {
                TableCell cell1 = new TableCell() { Text = day.IP};
                TableCell cell2 = new TableCell() { Text = day.Count.ToString() };
                
                TableRow row2 = new TableRow() { Cells = { cell1, cell2 } };
                table.Rows.Add(row2);
            }

        }
    }
}