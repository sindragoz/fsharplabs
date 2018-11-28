// Дополнительные сведения о F# см. на http://fsharp.org
// Дополнительную справку см. в проекте "Учебник по F#".

[<EntryPoint>]
let main argv = 
    let wordList=["топор","ботаник","лист","слово","ортопедическое"]
    let countChars (word:string) =
        let mutable count_O=0
        let mutable count_T=0
        for i in 0..word.Length-1 do
           if word.[i]='о' then
             count_O <- count_O + 1
           elif word.[i]='т' then
                count_T <- count_T + 1
        count_T>=1&&count_O<=2
    let filteredList = List.filter (fun word -> countChars word) ["топор";"ботаник";"лист";"слово";"ортопедическое"]
    printfn "Words match: %A" filteredList
    let delay=System.Console.ReadLine()
    0 // возвращение целочисленного кода выхода
