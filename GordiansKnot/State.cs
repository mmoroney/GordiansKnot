using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GordiansKnot {
    public class State {
        public Piece[] Pieces { get; private set; }
        public State Parent { get; private set; }
        public String Description { get; private set; }
        public int Depth { get; private set; }

        public State(Piece[] pieces, State parent, string description) {
            this.Pieces = pieces;
            this.Parent = parent;
            this.Description = description;
            this.Depth = parent == null ? 0 : parent.Depth + 1;
        }

        public State(Piece[] pieces) : this(pieces, null, "Root") {
        }

        public bool IsSolved {
            get => this.Remaining < 2;
        }

        public int Remaining {
            get => Pieces.Count(p => !p.IsRemoved);
        }

        public bool IsValid() {
            for (int i = 0; i < this.Pieces.Length; i++) {
                for (int j = i + 1; j < this.Pieces.Length; j++) {
                    if (this.Pieces[i].Intersects(this.Pieces[j])) {
                        return false;
                    }
                }
            }

            return true;
        }

        public State Move(bool[] pieces, Translation translation) {
            Piece[] newPieces = new Piece[this.Pieces.Length];
            for (int i = 0; i < newPieces.Length; i++) {
                newPieces[i] = pieces[i] ? this.Pieces[i].Move(translation) : this.Pieces[i];
            }

            bool removed = false;
            for (int i = 0; i < newPieces.Length; i++) {
                if (pieces[i]) {
                    bool overLaps = false;
                    for(int j = 0; j < newPieces.Length; j++) {
                        if(i != j && newPieces[i].Overlaps(newPieces[j])) {
                            overLaps = true;
                            break;
                        }
                    }

                    if (!overLaps) {
                        newPieces[i].Remove();
                        removed = true;
                    }
                };
            }

            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < pieces.Length; i++) {
                if(!pieces[i]) {
                    continue;
                }

                if(sb.Length > 0) {
                    sb.Append(", ");
                }

                sb.Append(this.Pieces[i].Name);
            }

            sb.Append(": " + translation.ToString());
            if(removed) {
                sb.Append(" (Removed)");
            }

            return new State(newPieces, this, sb.ToString());
        }

        public override bool Equals(object obj) {
            State other = obj as State;
            if (other == null) {
                return false;
            }

            for (int i = 0; i < Pieces.Length; i++) {
                if(!this.Pieces[i].Equals(other.Pieces[i])) {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode() {
            int hashCode = 0;
            foreach (Piece p in this.Pieces) {
                hashCode ^= p.GetHashCode();
            }
            return hashCode;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Depth = " + this.Depth.ToString());
            foreach(Piece piece in this.Pieces) {
                sb.AppendLine(piece.ToString());
            }

            return sb.ToString();
        }

        public string History {
            get {
                StringBuilder sb = new StringBuilder();
                State current = this;

                while (current != null) {
                    sb.Insert(0, current.Description + "\n");
                    current = current.Parent;
                }

                return sb.ToString();
            }
        }
    }
}
