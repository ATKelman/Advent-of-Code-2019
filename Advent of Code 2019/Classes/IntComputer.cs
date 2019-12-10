using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2019
{
    public class IntComputer
    {
        public Queue<int> Inputs { get; set; }
        public Queue<int> Outputs { get; set; }

        private int[] values;
        private int op;

        public IntComputer(int[] input)
        {
            Inputs = new Queue<int>();
            Outputs = new Queue<int>();
            values = new int[input.Length];
            input.CopyTo(values, 0);
            op = 0;
        }

        public void Reset(int[] input)
        {
            Inputs.Clear();
            Outputs.Clear();
            values = new int[input.Length];
            input.CopyTo(values, 0);
            op = 0;
        }

        public bool RunProgram()
        {
            while (true)
            {
                var opcode = values[op] % 100;
                var modeA = ((values[op] / 100) % 10);
                var modeB = ((values[op] / 1000) % 10);

                var a = (modeA > 0) ? values[op + 1] : values[values[op + 1]];
                var b = (modeB > 0) ? values[Math.Min((op + 2), (values.Count() - 1))] : values[Math.Min(values[Math.Min((op + 2), (values.Count() - 1))], (values.Count() - 1))];

                switch (opcode)
                {
                    case 1:
                        values[values[op + 3]] = a + b;
                        op += 4;
                        continue;
                    case 2:
                        values[values[op + 3]] = a * b;
                        op += 4;
                        continue;
                    case 3:
                        if (Inputs.Count == 0)
                            return true;
                        values[values[op + 1]] = Inputs.Dequeue();
                        op += 2;
                        continue;
                    case 4:
                        Outputs.Enqueue(values[values[op + 1]]);
                        op += 2;
                        continue;
                    case 5:
                        op = (a != 0) ? b : op + 3;
                        continue;
                    case 6:
                        op = (a == 0) ? b : op + 3;
                        continue;
                    case 7:
                        values[values[op + 3]] = (a < b) ? 1 : 0;
                        op += 4;
                        continue;
                    case 8:
                        values[values[op + 3]] = (a == b) ? 1 : 0;
                        op += 4;
                        continue;
                    case 99:
                        return false;
                    default:
                        throw new Exception($"Unknown Opcode Encountered: {opcode}.");
                }
            }
        }
    }
}
