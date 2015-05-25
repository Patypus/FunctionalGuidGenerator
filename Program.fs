open System;
open System.Reflection;
open System.Resources;
open GuidGenerator;

let Assembly = Assembly.GetExecutingAssembly()
let Resources = new ResourceManager("Resources", Assembly)

let UsageMessage = Resources.GetString("UsageMessage")
let InvalidLengthMessage = Resources.GetString("InvalidLengthMessage")

let CheckRequestedGuidLength length = 
    length > 0 && length <= 36

let MakeGuidsForUser totalRequestedGuids guidLength dashesRequired = 
    if CheckRequestedGuidLength guidLength then
        CreateGuids totalRequestedGuids guidLength dashesRequired
    else
        printfn "%s" InvalidLengthMessage

[<EntryPoint>]
let main argv =
    match argv.Length with
    | 3 -> MakeGuidsForUser (Int32.Parse(argv.[1])) (Int32.Parse(argv.[0])) argv.[2]
    | 2 -> MakeGuidsForUser (Int32.Parse(argv.[1])) (Int32.Parse(argv.[0])) "N"
    | _ -> printfn "%s" UsageMessage
    0