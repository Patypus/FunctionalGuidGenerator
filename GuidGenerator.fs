module GuidGenerator

open System;
open GuidGenerationFunctions;

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
