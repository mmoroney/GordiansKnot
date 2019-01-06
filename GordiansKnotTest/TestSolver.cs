using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GordiansKnot;

namespace GordiansKnotTest {
    [TestClass]
    public class TestSolver {
        [TestMethod]
        public void TestTwoPieces() {
            Piece[] pieces = new Piece[] {
                BasePieces.CreateRed(new Point(5, -1, 2)),
                BasePieces.CreateAqua(new Point(4, 4, 1))
            };

            Solve(pieces);
        }

        [TestMethod]
        public void TestThreePieces() {
            Piece[] pieces = new Piece[] {
                BasePieces.CreateRed(new Point(5, -1, 4)),
                BasePieces.CreateAqua(new Point(2, 2, 1)),
                BasePieces.CreateBlue(new Point(5, 1, 2))
            };

            Solve(pieces);
        }

        [TestMethod]
        public void TestFourPieces() {
            Piece[] pieces = new Piece[] {
                BasePieces.CreateRed(new Point(1, 0, 4)),
                BasePieces.CreateYellow(new Point(1, 2, 2)),
                BasePieces.CreateAqua(new Point(2, 4, 1)),
                BasePieces.CreateBlue(new Point(2, 1, 0))
            };

            Solve(pieces);
        }

        [TestMethod]
        public void TestFivePieces() {
            Piece[] pieces = new Piece[] {
                BasePieces.CreateRed(new Point(3, 3, 2)),
                BasePieces.CreateYellow(new Point(-3, 2, 4)),
                BasePieces.CreateAqua(new Point(0, 4, 1)),
                BasePieces.CreateGreen(new Point(5, 1, 4)),
                BasePieces.CreateBlue(new Point(2, 1, 0))
            };

            Solve(pieces);
        }

        [TestMethod]
        public void TestSixPieces() {
            Piece[] pieces = new Piece[] {
                BasePieces.CreateRed(),
                BasePieces.CreateYellow(),
                BasePieces.CreateOrange(),
                BasePieces.CreateAqua(),
                BasePieces.CreateGreen(),
                BasePieces.CreateBlue()
            };

            Solve(pieces);
        }

        private static void Solve(Piece[] pieces) {
            State state = new State(pieces);
            State solved = Solver.Solve(state);
            Assert.IsNotNull(solved);
            Debug.Write(solved.History);
        }
    }
}
