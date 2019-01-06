using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GordiansKnot;

namespace GordiansKnotTest {
    [TestClass]
    public class TestState {
        [TestMethod]
        public void TestInitialState() {
            State initialState = new State(BasePieces.CreatePieces());
            String name = Names.Orange;
            Translation right = new Translation(Direction.X, 1);
            for (int i = 0; i < initialState.Pieces.Length; i++) {
                Piece currentPiece = initialState.Pieces[i];
                bool[] pieces = new bool[initialState.Pieces.Length];
                pieces[i] = true;

                for (int j = 0; j < BaseTranslations.Values.Length; j++) {
                    Translation translation = BaseTranslations.Values[j];

                    State state = initialState.Move(pieces, translation);
                    bool isValid = state.IsValid();
                    if (currentPiece.Name == name && translation.Direction == Direction.X && translation.Distance == 1) {
                        Assert.IsTrue(isValid);
                    }
                    else {
                        Assert.IsFalse(isValid, "Moving piece {0} by {1} should be invalid!", currentPiece.Name, translation);
                    }
                }
            }
        }

        [TestMethod]
        public void TestEquals() {
            State initialState = new State(BasePieces.CreatePieces());
            bool[] pieces = new bool[6];
            pieces[2] = true;

            State state1 = initialState.Move(pieces, new Translation(Direction.X, 1));
            Assert.IsTrue(state1.IsValid());
            Assert.IsFalse(state1.Equals(initialState));

            State state2 = state1.Move(pieces, new Translation(Direction.X, -1));
            Assert.IsTrue(state2.IsValid());
            Assert.IsTrue(state2.Equals(initialState));
        }

        [TestMethod]
        public void TestMove() {
            Piece[] pieces = new Piece[] {
                BasePieces.CreateOrange(),
                BasePieces.CreateGreen()
            };

            State state = new State(pieces);
            Assert.IsTrue(state.IsValid());

            for ( int i = 0; i < 5; i++) {
                Assert.IsFalse(state.Pieces[0].IsRemoved);
                Assert.IsFalse(state.IsSolved);
                state = state.Move(new bool[] { true, false }, new Translation(Direction.X, 1));
                Assert.IsTrue(state.IsValid());
            }

            Assert.IsTrue(state.Pieces[0].IsRemoved);
            Assert.IsTrue(state.IsSolved);
        }

        [TestMethod]
        public void TestSolve() {
            State state = new State(BasePieces.CreatePieces());
            MoveAndTest(ref state, Direction.X, 2, Names.Orange);
            MoveAndTest(ref state, Direction.Z, 3, Names.Green);
            MoveAndTest(ref state, Direction.X, -2, Names.Orange);
            MoveAndTest(ref state, Direction.Y, -1, Names.Yellow);
            MoveAndTest(ref state, Direction.X, 2, Names.Yellow, Names.Orange, Names.Aqua);
            MoveAndTest(ref state, Direction.Y, 3, Names.Yellow);
            MoveAndTest(ref state, Direction.X, -2, Names.Yellow, Names.Orange);
            MoveAndTest(ref state, Direction.Y, 1, Names.Yellow);
            MoveAndTest(ref state, Direction.X, 2, Names.Orange);
            MoveAndTest(ref state, Direction.X, -2, Names.Yellow, Names.Aqua);
            MoveAndTest(ref state, Direction.Z, -3, Names.Green);
            MoveAndTest(ref state, Direction.X, -2, Names.Yellow, Names.Aqua);
            MoveAndTest(ref state, Direction.Y, -1, Names.Yellow);
            MoveAndTest(ref state, Direction.Z, 1, Names.Yellow);
            MoveAndTest(ref state, Direction.X, -1, Names.Orange, Names.Yellow);
            MoveAndTest(ref state, Direction.Z, 1, Names.Yellow);
            MoveAndTest(ref state, Direction.X, 1, Names.Aqua);
            MoveAndTest(ref state, Direction.Z, -2, Names.Red);
            MoveAndTest(ref state, Direction.X, 1, Names.Yellow, Names.Orange, Names.Aqua);
            MoveAndTest(ref state, Direction.Z, 4, Names.Green);
            MoveAndTest(ref state, Direction.X, 1, Names.Green);
            MoveAndTest(ref state, Direction.X, 2, Names.Red, Names.Blue);
            MoveAndTest(ref state, Direction.Y, -1, Names.Red);
            MoveAndTest(ref state, Direction.X, -2,Names.Blue);
            MoveAndTest(ref state, Direction.Y, 4, Names.Red);
            MoveAndTest(ref state, Direction.X, 1, Names.Orange);
            MoveAndTest(ref state, Direction.Z, 4, Names.Orange);
            MoveAndTest(ref state, Direction.X, 5, Names.Orange);
            Assert.IsTrue(state.Pieces[2].IsRemoved);
            Assert.AreEqual(5, state.Remaining);
            MoveAndTest(ref state, Direction.Y, -4, Names.Red);
            MoveAndTest(ref state, Direction.X, 2, Names.Blue);
            MoveAndTest(ref state, Direction.Y, 1, Names.Red);
            MoveAndTest(ref state, Direction.X, -2, Names.Red, Names.Blue);
            MoveAndTest(ref state, Direction.X, -1, Names.Green);
            MoveAndTest(ref state, Direction.Z, -4, Names.Green);
            MoveAndTest(ref state, Direction.X, -1, Names.Aqua, Names.Yellow);
            MoveAndTest(ref state, Direction.Z, 2, Names.Red);
            MoveAndTest(ref state, Direction.X, -1, Names.Aqua);
            MoveAndTest(ref state, Direction.Z, -1, Names.Yellow);
            MoveAndTest(ref state, Direction.X, 1, Names.Yellow);
            MoveAndTest(ref state, Direction.Z, -1, Names.Yellow);
            MoveAndTest(ref state, Direction.X, 2, Names.Yellow, Names.Aqua);
            MoveAndTest(ref state, Direction.Z, 4, Names.Green);
            MoveAndTest(ref state, Direction.X, 1, Names.Yellow, Names.Aqua);
            MoveAndTest(ref state, Direction.Z, -1, Names.Red);
            MoveAndTest(ref state, Direction.X, 2, Names.Green);
            MoveAndTest(ref state, Direction.Z, 1, Names.Red);
            MoveAndTest(ref state, Direction.X, 1, Names.Yellow, Names.Aqua);
            MoveAndTest(ref state, Direction.Z, -2, Names.Green);
            MoveAndTest(ref state, Direction.X, 3, Names.Green);
            Assert.IsTrue(state.Pieces[4].IsRemoved);
            Assert.AreEqual(4, state.Remaining);
            MoveAndTest(ref state, Direction.X, 2, Names.Yellow);
            MoveAndTest(ref state, Direction.Y, -3, Names.Yellow);
            MoveAndTest(ref state, Direction.X, 4, Names.Red, Names.Blue);
            MoveAndTest(ref state, Direction.Y, 1, Names.Yellow);
            MoveAndTest(ref state, Direction.Z, 2, Names.Blue);
            MoveAndTest(ref state, Direction.Y, -2, Names.Aqua);
            MoveAndTest(ref state, Direction.Y, -1, Names.Red);
            MoveAndTest(ref state, Direction.X, -1, Names.Yellow, Names.Blue);
            MoveAndTest(ref state, Direction.Z, -2, Names.Yellow);
            Assert.IsTrue(state.Pieces[1].IsRemoved);
            Assert.AreEqual(3, state.Remaining);
            MoveAndTest(ref state, Direction.X, 1, Names.Blue);
            MoveAndTest(ref state, Direction.Y, 1, Names.Red);
            MoveAndTest(ref state, Direction.Y, 2, Names.Aqua);
            MoveAndTest(ref state, Direction.Z, -2, Names.Blue);
            MoveAndTest(ref state, Direction.X, 2, Names.Aqua);
            MoveAndTest(ref state, Direction.Z, -2, Names.Red);
            MoveAndTest(ref state, Direction.Y, -1, Names.Red);
            MoveAndTest(ref state, Direction.X, -3, Names.Blue);
            Assert.IsTrue(state.Pieces[5].IsRemoved);
            Assert.AreEqual(2, state.Remaining);
            MoveAndTest(ref state, Direction.Y, 1, Names.Red);
            MoveAndTest(ref state, Direction.X, 1, Names.Red);
            MoveAndTest(ref state, Direction.Z, -2, Names.Red);
            Assert.IsTrue(state.Pieces[0].IsRemoved);
            Assert.AreEqual(1, state.Remaining);
            Assert.IsTrue(state.IsSolved);
        }

        private static void MoveAndTest(ref State state, Direction direction, int distance, params string[] names) {
            bool[] moves = new bool[state.Pieces.Length];
            for(int i = 0; i < moves.Length; i++) {
                for(int j = 0; j < names.Length; j++) {
                    if(state.Pieces[i].Name == names[j]) {
                        moves[i] = true;
                    }
                }
            }
            state = state.Move(moves, new Translation(direction, distance));
            Assert.IsTrue(state.IsValid());
        }
    }
}

