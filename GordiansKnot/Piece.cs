using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GordiansKnot {
    public class Piece {
        public string Name { get; set; }
        public Volume[] BaseVolumes { get; }
        public Point Offset { get; private set; }
        public bool IsRemoved { get; private set; }

        private Volume extent;

        public Piece(string name, Volume[] baseVolumes, Point offset) {
            this.Name = name;
            this.BaseVolumes = baseVolumes;
            this.Offset = offset;

            int minx = int.MaxValue;
            int miny = int.MaxValue;
            int minz = int.MaxValue;
            int maxx = int.MinValue;
            int maxy = int.MinValue;
            int maxz = int.MinValue;

            foreach (Volume baseVolume in this.BaseVolumes) {
                minx = Math.Min(minx, baseVolume.Min.x);
                miny = Math.Min(miny, baseVolume.Min.y);
                minz = Math.Min(minz, baseVolume.Min.z);
                maxx = Math.Max(maxx, baseVolume.Max.x);
                maxy = Math.Max(maxy, baseVolume.Max.y);
                maxz = Math.Max(maxz, baseVolume.Max.z);
            }

            this.extent = new Volume(minx, miny, minz, maxx, maxy, maxz);
        }

        public void Remove() {
            this.IsRemoved = true;
        }

        public bool Intersects(Piece piece) {
            if (this.IsRemoved || piece.IsRemoved) {
                return false;
            }

            if(!Volume.Overlaps(this.extent, piece.extent, this.Offset, piece.Offset)) {
                return false;
            }

            for (int i = 0; i < this.BaseVolumes.Length; i++) {
                for (int j = 0; j < piece.BaseVolumes.Length; j++) {
                    if (Volume.Overlaps(this.BaseVolumes[i], piece.BaseVolumes[j], this.Offset, piece.Offset)) {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool Overlaps(Piece piece) {
            if (this.IsRemoved || piece.IsRemoved) {
                return false;
            }

            return Volume.Overlaps(this.extent, piece.extent, this.Offset, piece.Offset);
        }

        public Piece Move(Translation translation) {
            return this.IsRemoved ? this : new Piece(this.Name, this.BaseVolumes, this.Offset.Translate(translation));
        }

        public override string ToString() {
            return string.Format("{0}: {1}", this.Name, this.IsRemoved ? "Removed" : this.Offset.ToString());
        }

        public override bool Equals(object obj) {
            Piece piece = obj as Piece;
            if(obj == null) {
                return false;
            }

            return this.Name == piece.Name && this.Offset.Equals(piece.Offset);
        }

        public override int GetHashCode() {
            return this.Name.GetHashCode() ^ this.Offset.GetHashCode();
        }
    }
}
