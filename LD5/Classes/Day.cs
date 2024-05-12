using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace LD5.Classes
{
    /// <summary>
    /// class which shows information about the current day and server information
    /// </summary>
    public class Day : IEnumerable<Visit>
    {
        public DateTime Date { get; set; } // Date of the day
        public string IP { get; set; } // IP of the server
        public int Count => Visits.Count;
        private List<Visit> Visits = new List<Visit>();

        public Day(DateTime date, string iP, List<Visit> visits)
        {
            Date = date;
            IP = iP;
            foreach (Visit visit in visits)
            {
                Visits.Add(visit);
            }
        }
        public Visit Get(int index)
        {
            return Visits[index];
        }
        public void Add(Visit visit)
        {
            Visits.Add(visit);
        }
        public IEnumerator<Visit> GetEnumerator()
        {
            foreach (Visit v in Visits)
            {
                yield return v;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); // Reusing the generic GetEnumerator method
        }
        public IEnumerable<Visit> FilterVisits(Func<Visit, bool> contidion)
        {
            return Visits.Where(contidion);
        }

    }
}