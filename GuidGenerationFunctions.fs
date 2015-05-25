module GuidGenerationFunctions

open System;

let MakeGuidWithNoDashes length =
    Guid.NewGuid().ToString().Replace("-", "").Substring(0, length);

let MakeGuid length =
    Guid.NewGuid().ToString().Substring(0, length);