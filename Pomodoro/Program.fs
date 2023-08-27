let c = '█'
let e = ' '

// https://github.com/bencao/terminal-block-fonts/blob/master/index.js

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
    ]

let asRows block =
    seq { for x in [0..(Array2D.length1 block) - 1] do
             yield block[x, *] }

let asStrings (block: char[,]) =
    block
    |> asRows
    |> Seq.map (fun row -> row |> System.String)

let printBlock block =
    block
    |> asStrings
    |> Seq.iter (fun s -> printfn "%s" s)
    printfn "%s" ""

blocks.Values |> Seq.iter printBlock


//UI.run () |> ignore
