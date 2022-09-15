namespace PrimeBench.Console

open System
open System.Threading.Tasks

module Benchmark =
    
    type BenchmarkResult = {
        Primes : int
        MemoryUsage : int64<Megabytes>
        Duration : TimeSpan
    }

    module BenchmarkResult =
        
        let create startTime counter result = {
            Primes = Counter.getCount counter
            MemoryUsage = SystemInfo.getMemoryUsage ()
            Duration = DateTime.Now - startTime
        }
    
    let run minRange maxRange =
        let startTime = DateTime.Now
        
        let counter =
            Number.Zero
            |> Number.asRef
            |> Counter.create

        let handler =
            Number.isPrime
            >> Boolean.isTrue counter.Increment
        
        let parameters = (minRange, maxRange, handler)
            
        parameters
        |> Parallel.For
        |> BenchmarkResult.create startTime counter