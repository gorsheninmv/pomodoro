open System
open System.Threading

let c = '█'
let e = ' '

// https://github.com/bencao/terminal-block-fonts/blob/master/index.js

type block = char[,]

let blocks = readOnlyDict[
    '?', array2D [
        [e; c; c; c; c; c; e];
        [c; c; e; e; e; e; c];
        [e; e; e; c; c; c; e];
        [e; e; c; c; e; e; e];
        [e; e; e; e; e; e; e];
        [e; e; c; c; e; e; e];
        [e; e; c; c; e; e; e];
    ];
    '!', array2D [
        [e; e; e; c; c; e; e];
        [e; e; e; c; c; e; e];
        [e; e; e; c; c; e; e];
        [e; e; e; c; c; e; e];
        [e; e; e; e; e; e; e];
        [e; e; e; c; c; e; e];
        [e; e; e; c; c; e; e];
    ]
    '#', array2D [
        [e; e; e; e; e; e; e];
        [e; e; c; e; c; e; e];
        [e; c; c; c; c; c; e];
        [e; e; c; e; c; e; e];
        [e; c; c; c; c; c; e];
        [e; e; c; e; c; e; e];
        [e; e; e; e; e; e; e];
    ];
    ':', array2D [
        [e; e; e; e; e; e; e];
        [e; e; c; c; e; e; e];
        [e; e; c; c; e; e; e];
        [e; e; e; e; e; e; e];
        [e; e; e; e; e; e; e];
        [e; e; c; c; e; e; e];
        [e; e; c; c; e; e; e];
    ];
    '+', array2D [
        [e; e; e; e; e; e; e];
        [e; e; e; c; e; e; e];
        [e; e; e; c; e; e; e];
        [e; c; c; c; c; c; e];
        [e; e; e; c; e; e; e];
        [e; e; e; c; e; e; e];
        [e; e; e; e; e; e; e];
    ];
    '-',  array2D [
        [e; e; e; e; e; e; e];
        [e; e; e; e; e; e; e];
        [e; e; e; e; e; e; e];
        [e; c; c; c; c; c; e];
        [e; e; e; e; e; e; e];
        [e; e; e; e; e; e; e];
        [e; e; e; e; e; e; e];
    ];
   '*', array2D [
         [e; e; e; e; e; e; e];
         [e; e; e; c; e; e; e];
         [e; c; e; c; e; c; e];
         [e; e; c; c; c; e; e];
         [e; c; e; c; e; c; e];
         [e; e; e; c; e; e; e];
         [e; e; e; e; e; e; e];
   ];
   '/', array2D [
        [e; e; e; e; e; e; c];
        [e; e; e; e; e; c; e];
        [e; e; e; e; c; e; e];
        [e; e; e; c; e; e; e];
        [e; e; c; e; e; e; e];
        [e; c; e; e; e; e; e];
        [c; e; e; e; e; e; e];
   ];
   '=', array2D [
        [e; e; e; e; e; e; e];
        [e; e; e; e; e; e; e];
        [e; c; c; c; c; c; e];
        [e; e; e; e; e; e; e];
        [e; c; c; c; c; c; e];
        [e; e; e; e; e; e; e];
        [e; e; e; e; e; e; e];
   ];
   ' ', array2D [
    [e; e; e; e; e; e; e];
    [e; e; e; e; e; e; e];
    [e; e; e; e; e; e; e];
    [e; e; e; e; e; e; e];
    [e; e; e; e; e; e; e];
    [e; e; e; e; e; e; e];
    [e; e; e; e; e; e; e];
   ];
   '0', array2D [
    [e; e; c; c; c; e; e];
    [e; c; e; e; c; c; e];
    [c; c; e; e; e; c; c];
    [c; c; e; e; e; c; c];
    [c; c; e; e; e; c; c];
    [e; c; c; e; e; c; e];
    [e; e; c; c; c; e; e];
   ];
   '1', array2D [
    [e; e; e; c; c; e; e];
    [e; e; c; c; c; e; e];
    [e; e; e; c; c; e; e];
    [e; e; e; c; c; e; e];
    [e; e; e; c; c; e; e];
    [e; e; e; c; c; e; e];
    [e; c; c; c; c; c; c];
   ];
   '2', array2D [
    [e; c; c; c; c; c; e];
    [c; c; e; e; e; c; c];
    [e; e; e; e; c; c; c];
    [e; e; c; c; c; c; e];
    [e; c; c; c; c; e; e];
    [c; c; c; e; e; e; e];
    [c; c; c; c; c; c; c];
   ];
   '3', array2D [
    [e; c; c; c; c; c; c];
    [e; e; e; e; c; c; e];
    [e; e; e; c; c; e; e];
    [e; e; c; c; c; c; e];
    [e; e; e; e; e; c; c];
    [c; c; e; e; e; c; c];
    [e; c; c; c; c; c; e];
   ];
   '4', array2D [
    [e; e; e; c; c; c; e];
    [e; e; c; c; c; c; e];
    [e; c; c; e; c; c; e];
    [c; c; e; e; c; c; e];
    [c; c; c; c; c; c; c];
    [e; e; e; e; c; c; e];
    [e; e; e; e; c; c; e];
   ];
   '5', array2D [
    [c; c; c; c; c; c; e];
    [c; c; e; e; e; e; e];
    [c; c; c; c; c; c; e];
    [e; e; e; e; e; c; c];
    [e; e; e; e; e; c; c];
    [c; c; e; e; e; c; c];
    [e; c; c; c; c; c; e];
   ];
   '6', array2D [
    [e; e; c; c; c; c; e];
    [e; c; c; e; e; e; e];
    [c; c; e; e; e; e; e];
    [c; c; c; c; c; c; e];
    [c; c; e; e; e; c; c];
    [c; c; e; e; e; c; c];
    [e; c; c; c; c; c; e];
   ];
   '7', array2D [
    [c; c; c; c; c; c; c];
    [c; c; e; e; e; c; c];
    [e; e; e; e; c; c; e];
    [e; e; e; c; c; e; e];
    [e; e; c; c; e; e; e];
    [e; e; c; c; e; e; e];
    [e; e; c; c; e; e; e];
   ];
   '8', array2D [
    [e; c; c; c; c; e; e];
    [c; c; e; e; e; c; e];
    [c; c; c; e; e; c; e];
    [e; c; c; c; c; e; e];
    [c; e; e; c; c; c; c];
    [c; e; e; e; e; c; c];
    [e; c; c; c; c; c; e];
   ];
   '9', array2D [
    [e; c; c; c; c; c; e];
    [c; c; e; e; e; c; c];
    [c; c; e; e; e; c; c];
    [e; c; c; c; c; c; c];
    [e; e; e; e; e; c; c];
    [e; e; e; e; c; c; e];
    [e; c; c; c; c; e; e];
   ]
    ]

let splitter = array2D [
    [e;];
    [e;];
    [e;];
    [e;];
    [e;];
    [e;];
    [e;];
]
let concat (block': block) (block'': block) =
    let lines = seq { for x in [0..(Array2D.length1 block') - 1] do
                yield [| yield! block'[x, *]; yield! block''[x, *] |] } |> Seq.toArray
    let block = Array2D.zeroCreate (Array2D.length1 block') ((Array2D.length2 block') + (Array2D.length2 block''))
    for x in [0..Array2D.length1 block' - 1] do
            block[x, *] <- lines[x]
    block

let splitConcat block' block'' =
    let block = concat block' splitter
    concat block block''

let get symbol =
    blocks[symbol]

let fromString (s: string) =
    s.ToCharArray() |> Seq.map (fun c -> get c) |> Seq.reduce splitConcat

let asRows block =
    seq { for x in [0..(Array2D.length1 block) - 1] do
             yield block[x, *] }

let asStrings block =
    block |> asRows |> Seq.map (fun row -> row |> String)

let printBlock block =
    block |> asStrings |> Seq.iter (fun s -> printfn "%s" s)
    printfn "%s" ""

let rec run state =
    let now = DateTime.Now
    if (state <> now.Second) then
        Console.Clear()
        now.ToString("hh:mm:ss") |> fromString |> printBlock
        run now.Second
    else
        Thread.Sleep(TimeSpan.FromMilliseconds 500)
        run state

run -1
