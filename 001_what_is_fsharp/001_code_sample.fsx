open System

// Defins a list of names
let names = [ "Peter"; "Julia"; "Xi" ]

// Defines a function that takes a name and produces a greeting
let getGreeting name = $"Hello, {name}"
// Nice string interpolation in F# too !

// Prints a greeting for each name
names
|> List.map getGreeting
|> List.iter (fun greeting -> printfn $"{greeting} ! Enjoy your F#")

// Ok intellisense seems to work ... even if lot of errors in the F# output log.