open System;
open System.Reflection;
open System.Resources;
open GuidGenerator;

let Assembly = Assembly.GetExecutingAssembly()
let Resources = new ResourceManager("Resources", Assembly);

let UsageMessage = Resources.GetString("UsageMessage");

[<EntryPoint>]
let main argv =
    match argv.Length with
    | 3 -> CreateGuids (Int32.Parse(argv.[1])) (Int32.Parse(argv.[0])) argv.[2]
    | 2 -> CreateGuids (Int32.Parse(argv.[1])) (Int32.Parse(argv.[0])) "N"
    | _ -> printfn "%s" UsageMessage
    0