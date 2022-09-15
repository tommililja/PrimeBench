namespace PrimeBench.Console

open System

module Number =
    
    [<Literal>]
    let Zero = 0
    
    let asRef n = ref n
    
    let sqrt = double >> Math.Sqrt >> int
    
    let isPrime n =
        { 2 .. sqrt n }
        |> Seq.forall (fun i -> n % i <> 0)