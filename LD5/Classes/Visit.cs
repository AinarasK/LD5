using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD5.Classes
{
    /// <summary>
    /// class for handling information about the visit of the day
    /// </summary>
    public class Visit : IComparable<Visit>, IEquatable<Visit>
    {
        public TimeSpan Time { get; set; } // When was connection to the server made
        public string IP { get; set; } // IP of the user computer
        public string URl { get; set; } // Full url request
        public Visit(TimeSpan time, string IP, string URL)
        {
            Time = time;
            this.IP = IP;
            this.URl = URL;
        }
        public int CompareTo(Visit other)
        {
            if(this.IP.CompareTo(other.IP) == 0)
            {
                return this.Time.CompareTo(other.Time);
            }
            else
            {
                return this.IP.CompareTo(other.IP);                
            }
        }
        public override string ToString()
        {
            return string.Format($"|{Time,-20}|{IP,-20}|{URl,-20}|");
        }

        public bool Equals(Visit other)
        {
            if(other == null) return false;
            return this.IP == other.IP;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Visit);
        }
        public override int GetHashCode()
        {
            return URl.GetHashCode();
        }
        
    }
}