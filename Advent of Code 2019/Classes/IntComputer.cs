using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_of_Code_2019
{
    public class IntComputer
    {
        public Queue<long> Inputs { get; set; }
        public Queue<long> Outputs { get; set; }

        private long[] values;
        private long offset;
        private long op;

        public IntComputer(long[] input)
        {
            Inputs = new Queue<long>();
            Outputs = new Queue<long>();

            values = new long[5000];
            input.CopyTo(values, 0);

            offset = 0;
            op = 0;
        }

        public void Reset(long[] input)
        {
            Inputs.Clear();
            Outputs.Clear();

            values = new long[5000];
            input.CopyTo(values, 0);

            offset = 0;
            op = 0;
        }

        public bool RunProgram()
        {
            while (true)
            {
                var opcode = values[op] % 100;
                var modeA = ((values[op] / 100) % 10);
                var modeB = ((values[op] / 1000) % 10);
                var modeC = ((values[op] / 10000) % 10);

                long a;
                long b;
                switch ((int)opcode)
                {
                    case 1:
                        a = Read(modeA);
                        b = Read(modeB);
                        Write(modeC, (a + b));
                        op++;
                        continue;
                    case 2:
                        a = Read(modeA);
                        b = Read(modeB);
                        Write(modeC, (a * b));
                        op++;
                        continue;
                    case 3:
                        if (Inputs.Count == 0)
                            return true;
                        Write(modeA, Inputs.Dequeue());
                        op++;
                        continue;
                    case 4:
                        Outputs.Enqueue(Read(modeA));
                        op++;
                        continue;
                    case 5:
                        a = Read(modeA);
                        b = Read(modeB);
                        //op = (a != 0) ? b : op + 1;
                        if (a == 0)
                            op++;
                        else
                            op = b;
                        continue;
                    case 6:
                        a = Read(modeA);
                        b = Read(modeB);
                        //op = (a == 0) ? b : op + 1;
                        if (a == 0)
                            op = b;
                        else
                            op++;
                        continue;
                    case 7:
                        a = Read(modeA);
                        b = Read(modeB);
                        Write(modeC, ((a < b) ? 1 : 0));
                        op++;
                        continue;
                    case 8:
                        a = Read(modeA);
                        b = Read(modeB);
                        Write(modeC, ((a == b) ? 1 : 0));
                        op++;
                        continue;
                    case 9:
                        a = Read(modeA);
                        offset += a;
                        op++;
                        continue;
                    case 99:
                        return false;
                    default:
                        throw new Exception($"Unknown Opcode Encountered: {opcode}.");
                }
            }
        }

        private long Read(long mode)
        {
            op++;
            switch (mode)
            {
                case 0:
                    return ReadPosition();
                case 1:
                    return ReadImmediate();
                case 2:
                    return ReadOffset();
                default:
                    throw new Exception($"Invalid mode {mode} when attempting Read.");
            }
        }

        private long ReadPosition()
        {
            return values[values[op]];
        }

        private long ReadImmediate()
        {
            return values[op];
        }

        private long ReadOffset()
        {
            var position = values[op] + offset;
            return values[position];
        }

        private void Write(long mode, long value)
        {
            op++;
            switch (mode)
            {
                case 0:
                    WriteToPosition(value);
                    break;
                case 1:
                    WriteToImmediate(value);
                    break;
                case 2:
                    WriteToOffset(value);
                    break;
                default:
                    throw new Exception($"Invalid mode {mode} when attempting Write.");
            }
        }

        private void WriteToPosition(long value)
        {
            values[values[op]] = value;
        }

        private void WriteToImmediate(long value)
        {
            values[op] = value;
        }

        private void WriteToOffset(long value)
        {
            var position = values[op] + offset;
            values[position] = value;
        }
    }
}
