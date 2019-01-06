using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GordiansKnot {
    public class Solver {
        public static State Solve(State state) {
            while(state != null && !state.IsSolved) {
                state = FindRemove(state);
            }

            return state;
        }

        private static State FindRemove(State state) {
            HashSet<State> visited = new HashSet<State>();
            visited.Add(state);

            Queue<State> queue = new Queue<State>();
            queue.Enqueue(state);

            int remainingCount = state.Remaining;

            while (queue.Count != 0) {
                State current = queue.Dequeue();

                foreach (bool[] selected in SelectPieces(current)) {
                    foreach (Translation baseTranslation in BaseTranslations.Values) {
                        Translation translation = baseTranslation;
                        State next = current.Move(selected, translation);
                        while(next.IsValid()) {
                            if(next.Remaining < remainingCount) {
                                return next;
                            }

                            if (!visited.Contains(next)) {
                                visited.Add(next);
                                queue.Enqueue(next);
                            }
                            translation = new Translation(translation.Direction, translation.Distance + baseTranslation.Distance);
                            next = current.Move(selected, translation);
                        }
                    }
                }
            }

            return null;
        }

        private static IEnumerable<bool[]> SelectPieces(State state) {
            return Select(state, new bool[state.Pieces.Length], 0, state.Remaining / 2);
        }

        private static IEnumerable<bool[]> Select(State state, bool[] data, int start, int count) {
            for (int i = 1; i <= count; i++) {
                for (int j = start; j < data.Length - i + 1; j++) {
                    if(state.Pieces[j].IsRemoved) {
                        continue;
                    }

                    data[j] = true;
                    if (i == 1) {
                        yield return data;
                    }
                    else {
                        foreach (bool[] next in Select(state, data, j + 1, i - 1)) {
                            yield return next;
                        }
                    }
                    data[j] = false;
                }
            }
        }
    }
}
