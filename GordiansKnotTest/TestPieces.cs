using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GordiansKnot;

namespace GordiansKnotTest {
    [TestClass]
    public class TestPieces {
        [TestMethod]
        public void TestIntersect() {
            Piece[] pieces = BasePieces.CreatePieces();

            for (int i = 0; i < pieces.Length; i++) {
                for (int j = 0; j < pieces.Length; j++) {
                    bool intersects = pieces[i].Intersects(pieces[j]);
                    Assert.AreEqual(i == j, intersects, string.Format("{0} intersects {1} : {2}", pieces[i].Name, pieces[j].Name, intersects));
                }
            }
        }

        [TestMethod]
        public void TestOverlap() {
            Piece[] pieces = BasePieces.CreatePieces();

            for (int i = 0; i < pieces.Length; i++) {
                for (int j = 0; j < pieces.Length; j++) {
                    bool overlaps = pieces[i].Overlaps(pieces[j]);
                    bool expected = !(i % 2 == 0 && j == i + 1) && !(j % 2 == 0 && i == j + 1);
                    Assert.AreEqual(expected, overlaps, string.Format("{0} overlaps {1} : {2}", pieces[i].Name, pieces[j].Name, overlaps));
                }
            }
        }
    }
}
