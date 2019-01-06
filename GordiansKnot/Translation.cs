using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GordiansKnot {
    public class Translation {
        private static int[] offsets = { 1, 0, 0 };
        public Direction Direction { get; private set; }
        public int Distance { get; private set; }

        public Translation(Direction direction, int distance) {
            this.Direction = direction;
            this.Distance = distance;
        }

        public override string ToString() {
            return string.Format("{0} {1}{2}", this.Direction.ToString(), this.Distance > 0 ? "+" : "", this.Distance);
        }
    }
}
