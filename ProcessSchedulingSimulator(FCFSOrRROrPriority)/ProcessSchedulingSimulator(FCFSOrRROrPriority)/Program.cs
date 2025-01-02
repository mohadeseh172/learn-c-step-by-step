using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSchedulingSimulator_FCFSOrRROrPriority_
{
    public class Process
    {
        public int Id { get; set; }
        public int ArrivalTime { get; set; }
        public int BurstTime { get; set; }
        public int RemainingTime { get; set; }
        public int Priority { get; set; }
        public int CompletionTime { get; set; }
        public int TurnaroundTime { get; set; }
        public int WaitingTime { get; set; }

        public Process(int id, int arrivalTime, int burstTime, int priority)
        {
            Id = id;
            ArrivalTime = arrivalTime;
            BurstTime = burstTime;
            RemainingTime = burstTime;
            Priority = priority;
        }
    }

    public class Scheduler
    {
        private List<Process> processes;

        public Scheduler()
        {
            processes = new List<Process>();
        }

        public void AddProcess(Process process)
        {
            processes.Add(process);
        }

        public void FCFS()
        {
            processes.Sort((p1, p2) => p1.ArrivalTime.CompareTo(p2.ArrivalTime));

            int currentTime = 0;
            foreach (var process in processes)
            {
                currentTime = Math.Max(currentTime, process.ArrivalTime);
                process.CompletionTime = currentTime + process.BurstTime;
                process.TurnaroundTime = process.CompletionTime - process.ArrivalTime;
                process.WaitingTime = process.TurnaroundTime - process.BurstTime;
                currentTime = process.CompletionTime;
            }

            DisplayResults("First-Come-First-Served (FCFS)");
        }

        public void RoundRobin(int quantum)
        {
            Queue<Process> queue = new Queue<Process>();
            int currentTime = 0;

            foreach (var process in processes)
                process.RemainingTime = process.BurstTime;

            processes.Sort((p1, p2) => p1.ArrivalTime.CompareTo(p2.ArrivalTime));
            queue.Enqueue(processes[0]);

            while (queue.Count > 0)
            {
                var process = queue.Dequeue();

                currentTime = Math.Max(currentTime, process.ArrivalTime);
                if (process.RemainingTime > quantum)
                {
                    process.RemainingTime -= quantum;
                    currentTime += quantum;
                    queue.Enqueue(process);
                }
                else
                {
                    currentTime += process.RemainingTime;
                    process.RemainingTime = 0;
                    process.CompletionTime = currentTime;
                    process.TurnaroundTime = process.CompletionTime - process.ArrivalTime;
                    process.WaitingTime = process.TurnaroundTime - process.BurstTime;
                }

                foreach (var proc in processes)
                {
                    if (proc.ArrivalTime <= currentTime && proc.RemainingTime > 0 && !queue.Contains(proc))
                    {
                        queue.Enqueue(proc);
                    }
                }
            }

            DisplayResults("Round Robin (RR)");
        }

        public void PriorityScheduling()
        {
            processes.Sort((p1, p2) => p1.Priority.CompareTo(p2.Priority));

            int currentTime = 0;
            foreach (var process in processes)
            {
                currentTime = Math.Max(currentTime, process.ArrivalTime);
                process.CompletionTime = currentTime + process.BurstTime;
                process.TurnaroundTime = process.CompletionTime - process.ArrivalTime;
                process.WaitingTime = process.TurnaroundTime - process.BurstTime;
                currentTime = process.CompletionTime;
            }

            DisplayResults("Priority Scheduling");
        }

        private void DisplayResults(string algorithmName)
        {
            Console.WriteLine($"\n{algorithmName} Results:");
            Console.WriteLine($"{"ID",-5}{"Arrival",-10}{"Burst",-8}{"Priority",-10}{"Completion",-12}{"Turnaround",-12}{"Waiting",-10}");
            foreach (var process in processes)
            {
                Console.WriteLine($"{process.Id,-5}{process.ArrivalTime,-10}{process.BurstTime,-8}{process.Priority,-10}{process.CompletionTime,-12}{process.TurnaroundTime,-12}{process.WaitingTime,-10}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Scheduler scheduler = new Scheduler();
            Console.WriteLine("Process Scheduling Simulator");
            int choice;

            do
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Process");
                Console.WriteLine("2. Run FCFS");
                Console.WriteLine("3. Run Round Robin");
                Console.WriteLine("4. Run Priority Scheduling");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Process ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Arrival Time: ");
                        int arrival = int.Parse(Console.ReadLine());
                        Console.Write("Enter Burst Time: ");
                        int burst = int.Parse(Console.ReadLine());
                        Console.Write("Enter Priority: ");
                        int priority = int.Parse(Console.ReadLine());
                        scheduler.AddProcess(new Process(id, arrival, burst, priority));
                        break;

                    case 2:
                        scheduler.FCFS();
                        break;

                    case 3:
                        Console.Write("Enter Quantum: ");
                        int quantum = int.Parse(Console.ReadLine());
                        scheduler.RoundRobin(quantum);
                        break;

                    case 4:
                        scheduler.PriorityScheduling();
                        break;

                    case 5:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            } while (choice != 5);
        }
    }
}
