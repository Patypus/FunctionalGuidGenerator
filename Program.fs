open System;
open System.Reflection;
open System.Resources;

let Assembly = Assembly.GetExecutingAssembly()
let Resources = new ResourceManager("Resources", Assembly);

let UsageMessage = Resources.GetString("UsageMessage");

let MakeGuidWithNoDashes length =
    Guid.NewGuid().ToString().Replace("-", "").Substring(0, length);

let MakeGuid length =
    Guid.NewGuid().ToString().Substring(0, length);

let GetGuidCreateFunction dashesRequiredArgument =
    let dashesRequired = String.Equals("Y", dashesRequiredArgument, StringComparison.InvariantCultureIgnoreCase);
    match dashesRequired with
    | true -> fun length -> MakeGuid length
    | false -> fun length -> MakeGuidWithNoDashes length

let rec RecurseToCreate createdGuids totalGuidsToCreate guidLength createFunction =
    printfn "%s" (createFunction guidLength)
    let incrementedPosition = createdGuids + 1;
    if incrementedPosition <= totalGuidsToCreate then 
        RecurseToCreate incrementedPosition totalGuidsToCreate guidLength createFunction

let CreateGuids totalGuidsRequired guidLength dashesRequired = 
    let guidCreateFunction = GetGuidCreateFunction dashesRequired;
    RecurseToCreate 1 totalGuidsRequired guidLength guidCreateFunction

[<EntryPoint>]
let main argv =
    match argv.Length with
    | 3 -> CreateGuids (Int32.Parse(argv.[1])) (Int32.Parse(argv.[0])) argv.[2]
    | 2 -> CreateGuids (Int32.Parse(argv.[1])) (Int32.Parse(argv.[0])) "N"
    | _ -> printfn "%s" UsageMessage
    0