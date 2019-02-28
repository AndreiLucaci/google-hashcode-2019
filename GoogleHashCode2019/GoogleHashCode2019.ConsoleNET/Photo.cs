using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleHashCode2019.ConsoleNET
{
    public enum Orientation
    {
        Horizontal,
        Vertical
    }

    public class Photo
    {
        public Orientation Orientation { get; set; }
        public int NumberOfTags { get; set; }
        public HashSet<string> Tags { get; set; }
    }
}
