namespace PrimeBench.Console

module Boolean =
    
    let isTrue func = function
        | true -> func ()
        | false -> ()