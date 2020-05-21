module ICPC
open System

let commaSprinkler (input:string) =
    let words : string [] = input.ToString().Split(' ')
    let list = Array.toList words
    let seq = Seq.ofList list 
    
    let validWord (text:string) = 
        let strings = List.ofSeq text 
        
        let rec checkChar str =
            match str with 
            |[] -> Some 0 
            | i :: rest -> match i >= 'a' && i <= 'z' || i = ' ' || i = ',' || i = ';' || i = '.' with 
                           | true -> checkChar rest 
                           | false -> None
        checkChar strings
        
   

    let rec validationInput (input:string list) = 
      match input with 
      | i::rest -> match i.Length <= 1 with 
                   | false -> match validWord i with 
                              | Some 0 -> validationInput rest 
                              | _ -> None 
                   | _ -> None 
        | [] -> None 
   
   //validationInput list 

    //let lastElement input =
      //let lst = List.last input 
      //match List.contains (".") lst with
      //| true -> None 
      //| false -> Some input

    let containsComma word =
        match List.contains "," word with 
        | true -> true 
        | false -> false 

    let findWord list = 
        List.find (fun i -> List.contains "," i) list
     

    let removeComma (word:string) =
        word.Trim(',');
    
    let update (input:string) =
        match input.Contains(",")  with 
        | true -> match (removeComma input) + "," =  input with 
                  | true -> Some "before comma"
                  | false -> match "," + (removeComma input) = input with 
                             | true -> Some "after comma"
                             | false -> None
        |false -> None 
                                         
    

    let rec createNewlist (input:string list) (lst:string list) =
        match input with 
        | [] -> None 
        | i :: rest -> match update i = Some "after comma" with 
                       | true-> createNewlist (rest) ((i + ","):: lst)
                       | _ -> createNewlist rest ((","+ i)::lst)
    createNewlist list []

    

        
                       
 

    

     
     

   

    //failwith "Not implemented"



let rivers input =
    let words : string [] = input.ToString().Split(' ')
    let list = Array.toList words


    let validWord (text:string) = 
        let strings = List.ofSeq text 
        
        let rec checkChar str =
            match str with 
            |[] -> Some 0 
            | i :: rest -> match i >= 'a' && i <= 'z' || i >= 'A' && i <= 'Z' with 
                           | true -> checkChar rest 
                           | false -> None
        checkChar strings
    validWord input 



[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    0 // return an integer exit code
