// Yeah strong static Types (had hard time with Python)
// 

// Group data with Records
type SuccessfulWithdrawal = { 
    Amount: decimal 
    Balance: decimal 
}

type FailledWithdrawal = {
    Amount: decimal
    Balance: decimal
    IsOverdraft: bool
}

// Discriminated unions to represent data of one or more forms
type WithdrawalResult =
    | Success of SuccessfulWithdrawal
    | InsufficientFunds of FailledWithdrawal
    | CardExpired of System.DateTime
    | UndisclosedFailure
 
 // Returns a WithdrawalResult
let withdrawMoney amount = // Implementation elided
    let balance = 1000.m
    let expire = System.DateTime(2030,1,1)
    if System.DateTime.Today > expire then
        CardExpired expire
    elif balance < amount then
        InsufficientFunds {Amount = amount; Balance=balance; IsOverdraft=true}
    elif balance >= amount then
        Success {Amount = amount; Balance=balance - amount}
    else
        UndisclosedFailure

let handleWithdrawal amount =
    let w = withdrawMoney amount

    // The F# compiler enforces accounting for each case!
    match w with
    | Success s -> printfn "Successfully withdrew %M{s.Amount}"
    | InsufficientFunds f -> printfn "Failed: balance is %M{f.Balance}"
    | CardExpired d -> printfn "Failed: card expired on %A{d}"
    | UndisclosedFailure -> printfn "Failed: unknown :("
 