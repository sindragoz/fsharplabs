

let splitOnWords (s:string) = 
    s.Split(" ,/:-.!?;()\t\r\n".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries) 
let reverseWordSequence (s:string) = 
    splitOnWords s 
    |> Seq.rev 
let str = System.IO.File.ReadAllText("1.txt") 

let reversedSeq=reverseWordSequence str
for x in reversedSeq do
    printf "%s" (x+" ")
let delay=System.Console.ReadLine()

