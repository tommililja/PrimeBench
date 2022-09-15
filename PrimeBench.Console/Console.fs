namespace PrimeBench.Console

open System

module Console =

    [<Literal>]
    let MinRange = 2
    
    [<Literal>]
    let MaxRange = 50000000
    
    Console.WriteLine $"Processing numbers between {MinRange} and {MaxRange} on {SystemInfo.processorCount} threads..."

    let result =
        Benchmark.run
            MinRange MaxRange

    Console.WriteLine "Result\t | Memory Usage\t | Duration"
    Console.WriteLine $"{result.Primes}\t | {result.MemoryUsage} MB\t | {result.Duration}"