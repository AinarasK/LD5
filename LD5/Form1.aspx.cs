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

    public partial class Form1 : System.Web.UI.Page
    {
        string daysFolder;
        string serverFolder;
        string resultFolder;
        protected void Page_Load(object sender, EventArgs e)
        {
            daysFolder = Server.MapPath("App_Data/Data/days/");
            serverFolder = Server.MapPath("App_Data/Data/serveris/");
            resultFolder = Server.MapPath("App_Data/Data/result/");
            if (Session["days"] as List<Day> != null)
            {
                CreateTable((List<Day>)Session["days"], PlaceHolder1);
                CreateTableTwo((List<Server>)Session["servers"], PlaceHolder1);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (hasProperFiles(FileUpload1) && hasProperFiles(FileUpload2))
            {
                if (Directory.Exists(daysFolder))
                {
                    Directory.Delete(daysFolder, true);
                }
                Directory.CreateDirectory(daysFolder);
                if (Directory.Exists(serverFolder))
                {
                    Directory.Delete(serverFolder, true);
                }
                Directory.CreateDirectory(serverFolder);
                CopyFilesToServer(FileUpload1, daysFolder);
                CopyFilesToServer(FileUpload2, serverFolder);
                Session["days"] = InOut.ReadDays(daysFolder);
                Session["servers"] = InOut.ReadServer(serverFolder);
                CreateTable((List<Day>)Session["days"], PlaceHolder1);
                CreateTableTwo((List<Server>)Session["servers"], PlaceHolder1);
                AddOptionsToDrowDownList((List<Server>)Session["servers"], DropDownList1);
                AddOptionsToDrowDownList((List<Day>)Session["days"], DropDownList2);
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            List<Day> days = (List<Day>)Session["days"];
            List<Server> servers = (List<Server>)Session["servers"];
            string selected = DropDownList1.SelectedValue;
            string selected2 = DropDownList2.SelectedValue;
            var selectedVisits = days
    .SelectMany(d => (List<Visit>)typeof(Day)
        .GetField("Visits", BindingFlags.NonPublic | BindingFlags.Instance)
        .GetValue(d))
    .Where(v => v.URl.Contains(selected)).Distinct()
    .ToList();
            selectedVisits.OrderBy(s => s.IP).ThenBy(s => s.Time).ToList();
            CreateTableThree(selectedVisits, Table1);
            var bigComputer = days.Where(d => d.Date.ToString("yyyy/MM/dd").Contains(selected2)).ToList().Max(p => p.Count);
            var bigComputers = days.Where(d => d.Count.Equals(bigComputer)).ToList();
            CreateTableThree(bigComputers, Table2);


        }
    }
}