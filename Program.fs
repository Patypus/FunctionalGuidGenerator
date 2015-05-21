open System;

let UsageMessage = "This utility takes 2 parameters: \n1) the required length of each guid \n2) the required number of guids";

let MakeGuid length =
    Guid.NewGuid().ToString().Replace("-", "").Substring(0, length);

let rec RecurseToCreate createdGuids totalGuidsToCreate guidLength createFunction =
    printfn "%s" (createFunction guidLength)
    let incrementedPosition = createdGuids + 1;
    if incrementedPosition <= totalGuidsToCreate then 
        RecurseToCreate incrementedPosition totalGuidsToCreate guidLength createFunction

[<EntryPoint>]
let main argv =
    match argv.Length with
    | 2 -> RecurseToCreate 1 (Int32.Parse(argv.[0])) (Int32.Parse(argv.[1])) MakeGuid
    | _ -> printfn "%s" UsageMessage
    0