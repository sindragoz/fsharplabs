// Дополнительные сведения о F# см. на http://fsharp.org
// Дополнительную справку см. в проекте "Учебник по F#".

[<EntryPoint>]
let main argv = 
    let wordList=["топор","ботаник","лист","слово","ортопедическое"]
    let accFunc (countT, countO) letter =
        if   letter = 'о' then (countT, countO+1)
        elif letter = 'т' then (countT+1, countO)
        else                   (countT, countO)

    let countChars (word:string) =
        let charList = List.ofSeq word
        let (countT,countO) = List.fold accFunc (0, 0) charList
        countT>=1&&countO<=2
        
    let filteredList = List.filter (fun word -> countChars word) ["топор";"ботаник";"лист";"слово";"ортопедическое"]
    printfn "Words match: %A" filteredList
    let delay=System.Console.ReadLine()
    0 // возвращение целочисленного кода выхода
