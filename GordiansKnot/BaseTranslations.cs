using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GordiansKnot {
    public class BaseTranslations {
        public static Translation[] Values = {
            new Translation(Direction.X, 1),
            new Translation(Direction.X, -1),
            new Translation(Direction.Y, 1),
            new Translation(Direction.Y, -1),
            new Translation(Direction.Z, 1),
            new Translation(Direction.Z, -1),
        };
    }
}
