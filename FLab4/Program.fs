// Learn more about F# at http://fsharp.org

open System

//[<EntryPoint>]
//let main argv =
//    printfn "Hello World from F#!"
//    0 // return an integer exit code

type IWorker =
     abstract serveTheClient : unit-> unit
      

type Worker =
    val name : string
    val stage : int
    val mutable isFree : bool

    new(n, st, f)={name=n; stage=st; isFree=f}
    new(n, st)={name=n; stage=st; isFree=true}

    member this.setFree f =
        this.isFree<-f
        ()

    member this.getFree =
        if(this.isFree=true) then
           printfn "Работник %s свободен" this.name
        else 
           printfn "Работник %s обслуживает клиента" this.name
    member this.serveTheClient() = (this :> IWorker).serveTheClient()
    interface IWorker with   
        member this.serveTheClient () =
            printfn "Работник %s обслуживает клиента ..." this.name

type Client =
    val name : string
    val id : int
    val dealName : string
    val mutable isActive : bool
    new(n, i, d,isa)={name=n; id=i; dealName = d; isActive=isa}
 
    member this.goToBankWithDeal =
        printfn "Клиент № %i пришел в банк по вопросу %s" this.id this.dealName
    member this.setActive a =
           this.isActive <- a

type ClientService =
    val client : Client 
    val worker : Worker 
    //val desiredService : string
    new(c:Client byref,w:Worker byref)={client=c; worker=w;}
    member this.startServing = 
           this.client.goToBankWithDeal
           this.worker.setFree false
    member this.Serving=
           (this.worker :> IWorker).serveTheClient
    member this.Sign=
              this.worker.setFree true
              this.client.setActive false
              printfn "Сделка с клиентом №%i по вопросу %s успешно завершена работником %s!" this.client.id this.client.dealName this.worker.name

type Banks =
    val name : string
    new(n)={name=n}

type Bank (name, addr) =
    inherit Banks(name)
    let address = addr
    let mutable worker1 = new Worker("Иван", 5, true)
    let mutable worker2 = new Worker("Анастасия", 8, true)
    let mutable worker3 = new Worker("Антон", 1, true)
    let mutable client1 = new Client("Николай", 1, "Открыть вклад",true)
    let mutable client2 = new Client("Юлия", 2, "Взять кредит",true)
    member this.organizeService =       
          let serviceProcess1= new ClientService(&client1, &worker1)
          let serviceProcess2= new ClientService(&client2, &worker2)
          serviceProcess1.startServing
          serviceProcess2.startServing
          worker1.getFree
          worker2.getFree
          worker3.getFree
          serviceProcess1.Sign
          serviceProcess2.Sign
          worker1.getFree
          worker2.getFree
          worker3.getFree
    member this.startWorking = 
          printfn "Банк %s по адресу %s начал работу." this.name address
          this.organizeService
          

let bank = new Bank ("Binbank", "Goncharova 22")
bank.startWorking
let delay=System.Console.ReadLine()
//// Learn more about F# at http://fsharp.org
//
//// Learn more about F# at http://fsharp.org
//
//open System
//
////[<EntryPoint>]
////let main argv =
////    printfn "Hello World from F#!"
////    0 // return an integer exit code
//
//type ISale =
//    abstract saleOfGoods : unit -> unit
//type IDisposable = interface 
//    abstract member Dispose : unit -> unit
//    end
//
//type Worker =
//    val woman : bool
//    val mutable salary : int
//    val age : int
//
//    new(w, s, a)={woman=w; salary=s; age=a}
//    new(w)={woman=w; salary=0; age=0}
//
//    member this.setSalary (s) =
//        this.salary <- s
//    
//    member this.getWoman =
//        this.woman
//    
//    interface ISale with   
//        member this.saleOfGoods() = printfn "This employee sold the goods "
//
//    member this.workerWait () =
//        printfn "The employee is waiting  "
//
//type Product =
//    val name : string
//    val mutable price : int
//    val color : string
//
//    new(n, p, c)={name=n; price=p; color=c}
//
//    member this.setPrice (p) =
//        this.price <- p
//    member this.getColor =
//        this.color
//    member this.getPrice =
//        this.price
//    interface ISale with   
//        member this.saleOfGoods () =
//            printfn "Product was sold "
//    member this.viewProduct () =
//        printfn "Product viewed  "
//
//type NetworkOfShops =
//    val name : string
//
//    new(n)={name=n}
//    
//    member this.getName =
//        this.name
//
//type Shop (name, address) =
//    inherit NetworkOfShops(name)
//    let addressShop = address
//
//    let worker1 = new Worker(true, 30000, 23)
//    let worker2 = new Worker(true, 21000, 19)
//    let product1 = new Product("jacket", 1500, "red")
//    let product2 = new Product("shirt", 3700, "green")
//    let product3 = new Product("shoes", 2500, "blue")
//    
//    member this.setAddress (addr) =
//        addressShop = addr
//    member this.messageShop =
//        worker2.workerWait()
//        printfn "Price - %A " product1.getPrice
//        worker1.setSalary(10000)
//        product1.setPrice(124124)
//        printfn "Price - %A " product1.getPrice
//        printfn "Color - %A " product3.getColor
//        product2.viewProduct()
//        printfn "The shop works "
//    interface IDisposable with
//        member this.Dispose() =
//            printfn "Cleaning up"
//
//
//let shop1 = new Shop ("Citilink", "Federacii 23")
//shop1.messageShop
//printfn "Name shop - %s" shop1.name
//
//let delay=System.Console.ReadLine()