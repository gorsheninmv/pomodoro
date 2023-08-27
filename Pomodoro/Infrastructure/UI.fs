namespace Pomodoro.Infrastructure

open System
open NStack
open Terminal.Gui

module UI =
    let private ustr (x: string) = ustring.Make(x)

    let run () =
        Application.Init ()
        let top = Application.Top
        let win = Window (ustr "Hello",
                          X = Pos.At 1, Y = Pos.At 1)
        let lbl = Label (ustr "Hello World", TextDirection.LeftRight_TopBottom)
        lbl.X = 1
        lbl.Y = 1
        lbl.Width = 11
        lbl.Height = 22
        win.Add lbl
        top.Add win
        Application.Run ()
        Application.Shutdown ()
        ignore
