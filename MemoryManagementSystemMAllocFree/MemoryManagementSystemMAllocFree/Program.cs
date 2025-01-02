using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagementSystemMAllocFree
{
    public class MemoryBlock
    {
        public int Size { get; set; }  // Size of the block in bytes
        public bool IsAllocated { get; set; }  // Whether the block is allocated or free
        public int StartAddress { get; set; }  // Simulated address for the memory block

        public MemoryBlock(int size, int startAddress)
        {
            Size = size;
            StartAddress = startAddress;
            IsAllocated = false;
        }
    }

    public class MemoryManager
    {
        private List<MemoryBlock> memoryPool;
        private const int TotalMemory = 1024; // Simulating a heap of 1024 bytes
        private int nextAvailableAddress;

        public MemoryManager()
        {
            memoryPool = new List<MemoryBlock>();
            nextAvailableAddress = 0;
            InitializeMemory();
        }

        // Initialize the memory pool with one large free block
        private void InitializeMemory()
        {
            memoryPool.Add(new MemoryBlock(TotalMemory, nextAvailableAddress));
            nextAvailableAddress += TotalMemory;
        }

        // Simulate the malloc function
        public int Malloc(int size)
        {
            foreach (var block in memoryPool)
            {
                if (!block.IsAllocated && block.Size >= size)
                {
                    block.IsAllocated = true;

                    // If the block is larger than requested size, split it
                    if (block.Size > size)
                    {
                        MemoryBlock newBlock = new MemoryBlock(block.Size - size, block.StartAddress + size);
                        memoryPool.Add(newBlock);
                        block.Size = size;
                    }

                    return block.StartAddress;
                }
            }

            Console.WriteLine("Memory allocation failed: Not enough memory.");
            return -1;
        }

        // Simulate the free function
        public void Free(int startAddress)
        {
            foreach (var block in memoryPool)
            {
                if (block.StartAddress == startAddress && block.IsAllocated)
                {
                    block.IsAllocated = false;
                    Console.WriteLine($"Memory block at address {startAddress} has been freed.");
                    return;
                }
            }

            Console.WriteLine("Free failed: No allocated block found at the given address.");
        }

        // Display the current status of the memory pool
        public void DisplayMemoryStatus()
        {
            Console.WriteLine("\nMemory Pool Status:");
            foreach (var block in memoryPool)
            {
                string status = block.IsAllocated ? "Allocated" : "Free";
                Console.WriteLine($"Address: {block.StartAddress}, Size: {block.Size}, Status: {status}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MemoryManager memoryManager = new MemoryManager();
            int choice;

            do
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Allocate memory");
                Console.WriteLine("2. Free memory");
                Console.WriteLine("3. Display memory status");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter the size of memory to allocate: ");
                        int size = int.Parse(Console.ReadLine());
                        int address = memoryManager.Malloc(size);
                        if (address != -1)
                            Console.WriteLine($"Memory allocated at address: {address}");
                        break;

                    case 2:
                        Console.Write("Enter the start address of the memory block to free: ");
                        int startAddress = int.Parse(Console.ReadLine());
                        memoryManager.Free(startAddress);
                        break;

                    case 3:
                        memoryManager.DisplayMemoryStatus();
                        break;

                    case 4:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 4);
        }
    }
}
