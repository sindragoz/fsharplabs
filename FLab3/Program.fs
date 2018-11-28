// Дополнительные сведения о F# см. на http://fsharp.org
// Дополнительную справку см. в проекте "Учебник по F#".

let mas=[|8;6;2;9;3;5;6;1|] 
let mutable max=(-1)
let mutable maxIndex=0
for i=0 to mas.Length-1 do 
if mas.[i]>max then 
   max<-mas.[i]
   maxIndex<-i
;;


for i=maxIndex+1 to mas.Length-1 do 
mas.[i]<-mas.[i]*10
;;
printfn "%A" mas
let delay=System.Console.ReadLine()