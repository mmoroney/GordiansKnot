using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GordiansKnot {
    public class Volume {
        public Point Min { get; private set; }
        public Point Max { get; private set; }

        public Volume(int minx, int miny, int minz, int maxx, int maxy, int maxz) {
            this.Min = new Point(minx, miny, minz);
            this.Max = new Point(maxx, maxy, maxz);
        }

        public static bool Overlaps(Volume v1, Volume v2, Point offset1, Point offset2) {
            return v1.Max.x + offset1.x > v2.Min.x + offset2.x
                && v1.Max.y + offset1.y > v2.Min.y + offset2.y
                && v1.Max.z + offset1.z > v2.Min.z + offset2.z
                && v1.Min.x + offset1.x < v2.Max.x + offset2.x
                && v1.Min.y + offset1.y < v2.Max.y + offset2.y
                && v1.Min.z + offset1.z < v2.Max.z + offset2.z;
        }
    }
}
