using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    internal class Assembler
    {
        private readonly bool partTwo;
        private readonly List<DuetInstruction> program;
        private readonly Dictionary<string, long> registers = new Dictionary<string, long>();
        private int instructionPointer = 0;
        public bool Halted { get; set; }
        public Queue<long> Input { get; set; } = new Queue<long>();
        public Queue<long> Output { get; set; } = new Queue<long>();
        public int ValuesSent { get; set; }

        public Assembler(long programId, List<DuetInstruction> program, bool partTwo)
        {
            this.program = program;
            this.partTwo = partTwo;
            foreach (var r in program.Where(p => char.IsLetter(p.A[0])).Select(p => p.A).Distinct()) { registers.Add(r, 0); }
            registers["p"] = programId;
        }

        public void Run()
        {
            while (true)
            {
                Execute(program[instructionPointer]);

                if (Halted)
                {
                    return;
                }
            }
        }

        private void Execute(DuetInstruction instruction)
        {
            switch (instruction.Name, partTwo)
            {
                case ("snd", false): Sound(instruction); break;
                case ("snd", true): Send(instruction); break;
                case ("rcv", false): Recover(instruction); break;
                case ("rcv", true): Receive(instruction); break;
                case ("set", _): Set(instruction); break;
                case ("add", _): Add(instruction); break;
                case ("mul", _): Multiply(instruction); break;
                case ("mod", _): Modulo(instruction); break;
                case ("jgz", _): JumpGreaterThanZero(instruction); return;
                case (_, _): break;
            }

            if (!Halted)
            {
                instructionPointer++;
            }
        }

        private long GetValue(string a)
        {
            var value = 0L;
            if (!long.TryParse(a, out value)) { value = registers[a]; }
            return value;
        }

        private void Add(DuetInstruction instruction) => registers[instruction.A] += GetValue(instruction.B);

        private void JumpGreaterThanZero(DuetInstruction instruction) => instructionPointer += (GetValue(instruction.A) > 0 ? (int)GetValue(instruction.B) : 1);

        private void Modulo(DuetInstruction instruction) => registers[instruction.A] %= GetValue(instruction.B);

        private void Multiply(DuetInstruction instruction) => registers[instruction.A] *= GetValue(instruction.B);

        private void Receive(DuetInstruction instruction)
        {
            if (Input.Any()) { registers[instruction.A] = Input.Dequeue(); Halted = false; }
            else { Halted = true; }
        }

        private void Recover(DuetInstruction instruction)
        {
            if (GetValue(instruction.A) != 0)
            {
                Output.Enqueue(Input.Dequeue());
                Halted = true;
            }
        }

        private void Send(DuetInstruction instruction)
        {
            Output.Enqueue(GetValue(instruction.A));
            ValuesSent++;
        }

        private void Set(DuetInstruction instruction) => registers[instruction.A] = GetValue(instruction.B);

        private void Sound(DuetInstruction instruction)
        {
            Input.TryDequeue(out var _);
            Input.Enqueue(registers[instruction.A]);
        }
    }
}
