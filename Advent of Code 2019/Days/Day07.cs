using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2019.Days
{
    public class Day07 : IDay
    {
        public string PartOne()
        {
            var input = System.IO.File.ReadAllText("Day07.txt").Split(',').Select(x => int.Parse(x)).ToArray();

            var phaseSettings = Enumerable.Range(0, 5).Permutate().ToList();
            var maxThruster = 0;

            foreach (var setting in phaseSettings)
            {
                var amplifierOutput = 0;
                foreach (var phase in setting.ToArray())
                {
                    Queue<int> inputs = new Queue<int>();
                    inputs.Enqueue(phase);
                    inputs.Enqueue(amplifierOutput);

                    amplifierOutput = IntComputerGetResult(input, inputs);
                }

                if (amplifierOutput > maxThruster)
                    maxThruster = amplifierOutput;
            }

            return $"Day 7 Part 1: {maxThruster}";
        }

        public string PartTwo()
        {
            var input = System.IO.File.ReadAllText("Day07.txt").Split(',').Select(x => long.Parse(x)).ToArray();

            var intComputers = new IntComputer[5];
            for (int i = 0; i < 5; i++)
                intComputers[i] = new IntComputer(input);

            var phaseSettings = Enumerable.Range(5, 5).Permutate().ToList();
            var maxThruster = 0;

            foreach (var setting in phaseSettings)
            {                 
                var phase = setting.ToArray();
                for (int i = 0; i < 5; i++)
                {
                    intComputers[i].Reset(input);
                    intComputers[i].Inputs.Enqueue(phase[i]);
                }

                var amplifierOutput = 0;
                var stillRunning = new Queue<IntComputer>(intComputers);
                while (stillRunning.Count > 0)
                {
                    var instance = stillRunning.Dequeue();
                    instance.Inputs.Enqueue(amplifierOutput);                   
                    if (instance.RunProgram())
                    {
                        stillRunning.Enqueue(instance);
                    }                 
                    amplifierOutput = (int)instance.Outputs.Dequeue();
                }

                if (amplifierOutput > maxThruster)
                    maxThruster = amplifierOutput;
            }

            return $"Day 7 Part 2: {maxThruster}";
        }

        private int IntComputerGetResult(int[] values, Queue<int> inputs)
        {
            var op = 0;
            var lastEcho = 0;
            while (values[op] != 99)
            {
                var opcode = values[op] % 10;
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
                        values[values[op + 1]] = inputs.Dequeue();
                        op += 2;
                        continue;
                    case 4:
                        lastEcho = values[values[op + 1]];
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
                    default:
                        throw new Exception($"Unknown Opcode Encountered: {opcode}.");
                }
            }

            return lastEcho;
        }
    }
}
