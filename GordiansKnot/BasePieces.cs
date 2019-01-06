using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GordiansKnot {
    public static class BasePieces {
        public static Piece[] CreatePieces() {
            return new Piece[] {
                new Piece("Red", BaseVolumes.Red, BaseOffsets.Red),
                new Piece("Yellow", BaseVolumes.Yellow, BaseOffsets.Yellow),
                new Piece("Orange", BaseVolumes.Orange, BaseOffsets.Orange),
                new Piece("Aqua", BaseVolumes.Aqua, BaseOffsets.Aqua),
                new Piece("Green", BaseVolumes.Green, BaseOffsets.Green),
                new Piece("Blue", BaseVolumes.Blue, BaseOffsets.Blue)
            };
        }

        public static Piece CreateRed() {
            return CreateRed(BaseOffsets.Red);
        }

        public static Piece CreateRed(Point offset) {
            return new Piece(Names.Red, BaseVolumes.Red, offset);
        }

        public static Piece CreateYellow() {
            return CreateYellow(BaseOffsets.Yellow);
        }

        public static Piece CreateYellow(Point offset) {
            return new Piece(Names.Yellow, BaseVolumes.Yellow, offset);
        }

        public static Piece CreateOrange() {
            return CreateOrange(BaseOffsets.Orange);
        }

        public static Piece CreateOrange(Point offset) {
            return new Piece(Names.Orange, BaseVolumes.Orange, offset);
        }

        public static Piece CreateAqua() {
            return CreateAqua(BaseOffsets.Aqua);
        }

        public static Piece CreateAqua(Point offset) {
            return new Piece(Names.Aqua, BaseVolumes.Aqua, offset);
        }

        public static Piece CreateGreen() {
            return CreateGreen(BaseOffsets.Green);
        }

        public static Piece CreateGreen(Point offset) {
            return new Piece(Names.Green, BaseVolumes.Green, offset);
        }

        public static Piece CreateBlue() {
            return CreateBlue(BaseOffsets.Blue);
        }

        public static Piece CreateBlue(Point offset) {
            return new Piece(Names.Blue, BaseVolumes.Blue, offset);
        }
    }
}
