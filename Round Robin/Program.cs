using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round_Robin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Process> processes = new List<Process>
                {
                    new Process ("P1", 5),
                    new Process ("P2", 3),
                    new Process ("P3", 2),
                    new Process ("P4", 4 ),
                };
            Console.WriteLine("\n");
            int quantum = 2;
            RunRoundRobin(processes, quantum);
        }

        static void RunRoundRobin(List<Process> processes, int quantum)
        {
            Queue<Process> queue = new Queue<Process>(processes);
            while (queue.Count > 0)
            {
                Process currentProcess = queue.Dequeue();
                int remainingTime = Math.Min(quantum, currentProcess.BurstTime);
                Console.WriteLine($"Ejecutando proceso {currentProcess.Name} por {remainingTime} unidades de tiempo.");

                currentProcess.BurstTime -= remainingTime;
                if (currentProcess.BurstTime > 0)
                {
                    queue.Enqueue(currentProcess);
                }
            }

            Console.WriteLine("Todos los procesos han sido completados con exito");
            Console.ReadKey();
        }


        class Process
        {
            public string Name { get; set; }
            public int BurstTime { get; set; }

            public Process(string name, int burstTime)
            {
                Name = name;
                BurstTime = burstTime;
            }
        }
    }
}
