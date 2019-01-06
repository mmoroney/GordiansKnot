using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GordiansKnot {
    public static class BaseVolumes {
        public static Volume[] Red = {
            new Volume(0, 0, 0, 1, 2, 1),
            new Volume(0, 3, 0, 1, 4, 1),
            new Volume(0, 5, 0, 1, 7, 1),

            new Volume(1, 0, 0, 2, 1, 1),
            new Volume(1, 3, 0, 2, 4, 1),
            new Volume(1, 6, 0, 2, 7, 1),

            new Volume(2, 0, 0, 3, 7, 1),

            new Volume(3, 0, 0, 4, 1, 1),
            new Volume(3, 6, 0, 4, 7, 1),

            new Volume(4, 0, 0, 5, 4, 1),
            new Volume(4, 5, 0, 5, 6, 1),
        };

        public static Volume[] Yellow = {
            new Volume(0, 0, 0, 1, 2, 1),
            new Volume(0, 3, 0, 1, 7, 1),

            new Volume(1, 0, 0, 2, 1, 1),
            new Volume(1, 6, 0, 2, 7, 1),

            new Volume(2, 0, 0, 3, 2, 1),
            new Volume(2, 3, 0, 3, 7, 1),

            new Volume(3, 0, 0, 4, 1, 1),
            new Volume(3, 6, 0, 4, 7, 1),

            new Volume(4, 0, 0, 5, 7, 1),
        };

        public static Volume[] Orange = {
            new Volume(0, 0, 0, 2, 1, 1),
            new Volume(3, 0, 0, 7, 1, 1),

            new Volume(0, 0, 1, 1, 1, 2),
            new Volume(6, 0, 1, 7, 1, 2),

            new Volume(0, 0, 2, 2, 1, 3),
            new Volume(5, 0, 2, 7, 1, 3),

            new Volume(0, 0, 3, 1, 1, 4),
            new Volume(6, 0, 3, 7, 1, 4),

            new Volume(0, 0, 4, 7, 1, 5),
        };

        public static Volume[] Aqua = {
            new Volume(0, 0, 0, 4, 1, 1),
            new Volume(5, 0, 0, 7, 1, 1),

            new Volume(0, 0, 1, 1, 1, 3),
            new Volume(2, 0, 1, 3, 1, 2),
            new Volume(6, 0, 1, 7, 1, 2),

            new Volume(0, 0, 2, 2, 1, 3),
            new Volume(5, 0, 2, 7, 1, 3),

            new Volume(0, 0, 3, 1, 1, 4),
            new Volume(6, 0, 3, 7, 1, 4),

            new Volume(0, 0, 4, 7, 1, 5),
        };

        public static Volume[] Green = {
            new Volume(0, 0, 0, 1, 1, 7),

            new Volume(0, 1, 0, 1, 2, 1),
            new Volume(0, 1, 6, 1, 2, 7),

            new Volume(0, 2, 0, 1, 3, 7),

            new Volume(0, 3, 0, 1, 4, 1),
            new Volume(0, 3, 6, 1, 4, 7),

            new Volume(0, 4, 0, 1, 5, 7),
        };

        public static Volume[] Blue = {
            new Volume(0, 0, 0, 1, 1, 7),

            new Volume(0, 1, 0, 1, 2, 1),
            new Volume(0, 1, 6, 1, 2, 7),

            new Volume(0, 2, 0, 1, 3, 2),
            new Volume(0, 2, 5, 1, 3, 7),

            new Volume(0, 3, 0, 1, 4, 1),
            new Volume(0, 3, 6, 1, 4, 7),

            new Volume(0, 4, 0, 1, 5, 2),
            new Volume(0, 4, 3, 1, 5, 7),
        };
    }
}
