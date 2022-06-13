using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Data
{
    internal class CircleInformation
    {
        public double PositionX { get; }
        public double PositionY { get; }
        public double SpeedX { get; }
        public double SpeedY { get; }
        public int Hash { get; }
        public string Date { get; }
        public CircleInformation(double XPos, double YPos, double XSpeed, double YSpeed, int Hash)
        {
            this.PositionX = XPos;
            this.PositionY = YPos;
            this.SpeedX = XSpeed;
            this.SpeedY = YSpeed;
            this.Hash = Hash;
            string millisecondFormat = $"{NumberFormatInfo.CurrentInfo.NumberDecimalSeparator}fff";
            string fullPattern = DateTimeFormatInfo.CurrentInfo.FullDateTimePattern;
            fullPattern = Regex.Replace(fullPattern, "(:ss|:s)", $"$1{millisecondFormat}");
            Date = DateTime.Now.ToString(fullPattern);
        }

        public string ToString()
        {
            string toWrite = "circle:" + "\n";
            toWrite += "  - Hash: " + Hash + "\n";
            toWrite += "  - XPos: " + PositionX + "\n";
            toWrite += "  - Ypos: " + PositionY + "\n";
            toWrite += "  - XSpeed: " + SpeedX + "\n";
            toWrite += "  - YSpeed: " + SpeedY + "\n";
            toWrite += "  - Date: " + Date + "\n";
            return toWrite;
        }
    }
}
