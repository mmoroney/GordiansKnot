using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GordiansKnot {
    [DebuggerDisplay("({x}, {y}, {z})")]
    public class Point {
        public static Point Zero = new Point(0, 0, 0);

        public int x { get; private set; }
        public int y { get; private set; }
        public int z { get; private set; }

        public Point(int x, int y, int z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString() {
            return string.Format("({0}, {1}, {2})", this.x, this.y, this.z);
        }

        public override bool Equals(object obj) {
            Point other = obj as Point;
            if (other == null) {
                return false;
            }

            return this.x == other.x && this.y == other.y && this.z == other.z;
        }

        public override int GetHashCode() {
            return x ^ y ^ z;
        }

        public Point Translate(Translation translation) {
            int x = 0;
            int y = 0;
            int z = 0;

            if (translation.Direction == Direction.X) {
                x = translation.Distance;
            }
            else if (translation.Direction == Direction.Y) {
                y = translation.Distance;
            }
            else if (translation.Direction == Direction.Z) {
                z = translation.Distance;
            }

            return new Point(this.x + x, this.y + y, this.z + z);
        }
    }
}
