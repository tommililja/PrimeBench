namespace PrimeBench.Console

open System.Threading
open Microsoft.FSharp.Core

type Counter = {
    Count : int ref
    Increment : unit -> unit
}

module Counter =
    
    // Atomically incremented counter

    let create count = {
        Count = count
        Increment = fun () ->
            count
            |> Interlocked.Increment
            |> ignore
    }
    
    let getCount counter = counter.Count.Value