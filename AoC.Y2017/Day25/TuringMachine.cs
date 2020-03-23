using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    internal class TuringMachine
    {
        private readonly int diagnosticStep;
        private readonly Dictionary<string, TuringState> states = new Dictionary<string, TuringState>();
        private string currentState;
        private int cursor = 0;
        private Dictionary<int, int> tape = new Dictionary<int, int>();
        public int DiagnosticValue { get; set; }

        public TuringMachine(List<TuringState> states, string startState, int diagnosticStep)
        {
            foreach (var state in states)
            {
                this.states.Add(state.Name, state);
            }

            currentState = startState;
            this.diagnosticStep = diagnosticStep;
        }

        public void Run()
        {
            for (int i = 0; i < diagnosticStep; i++)
            {
                var state = states[currentState];

                if (!tape.ContainsKey(cursor))
                {
                    tape.Add(cursor, 0);
                }

                var currentValue = tape[cursor];

                var (nextValue, nextCursorOffset, nextState) = state.GetValues(currentValue);
                tape[cursor] = nextValue;
                cursor += nextCursorOffset;
                currentState = nextState;
            }

            DiagnosticValue = tape.Sum(t => t.Value);
        }
    }
}
