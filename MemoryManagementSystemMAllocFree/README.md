Memory Management System (malloc/free-like Implementation)
Project Description: The goal is to create a small memory management system in C# that mimics the behavior of malloc and free in C/C++. In this project, you'll implement a basic memory allocation and deallocation system, where memory is dynamically allocated and freed using custom methods. This system will simulate a memory heap, and you’ll be able to manage blocks of memory, track their usage, and reclaim unused memory.

Project Structure:
Memory Block Representation: You will represent each block of memory with a MemoryBlock class that holds information about its size and whether it’s allocated or free.
Memory Manager: The MemoryManager class will manage the memory blocks, handle allocation and deallocation, and keep track of the free and used blocks.
Operations: Implement basic operations like Malloc(size), Free(pointer), and a method to display the memory status.
