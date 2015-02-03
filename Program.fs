open System;

let UsageMessage = "This utility takes 2 parameters: \n1) the required length of the Guid \n2) the required number of GUIDs";

let MakeGuid length =
    Guid.NewGuid().ToString().Replace("-", "").Substring(0, length);

let rec RecurseToCreate possition maximum length createFunction =
    printfn "%s" (createFunction length)
    let incrementedPossition = possition + 1;
    if incrementedPossition <= maximum then 
        RecurseToCreate incrementedPossition maximum length createFunction

[<EntryPoint>]
let main argv =
    match argv.Length with
    | 2 -> RecurseToCreate 1 (Int32.Parse(argv.[0])) (Int32.Parse(argv.[1])) MakeGuid
    | _ -> printfn "%s" UsageMessage
    0