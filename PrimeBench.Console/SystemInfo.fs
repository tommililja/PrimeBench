namespace PrimeBench.Console

open System
open System.Diagnostics
open Microsoft.FSharp.Core

[<Measure>]
type Megabytes

[<Measure>]
type Bytes

module SystemInfo =

    let private currentProcess = Process.GetCurrentProcess ()
    
    let private bytesPerMegabyte = 1000000L<Bytes/Megabytes>
    
    let private convertBytesToMegaBytes (bytes:int64<Bytes>) = bytes / bytesPerMegabyte
        
    let processorCount = Environment.ProcessorCount
        
    let getMemoryUsage () =
        currentProcess.PeakWorkingSet64
        |> LanguagePrimitives.Int64WithMeasure
        |> convertBytesToMegaBytes