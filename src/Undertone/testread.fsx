﻿#r @"..\..\lib\NAudio\NAudio.dll"
#load "MiscConsts.fs"
#load "Enums.fs"
#load "WaveFunctions.fs"
#load "NAudioWaveStreamSource.fs"
#load "Player.fs"
#load "Player.net.fs"
#load "reader.fs"
open System.IO
open Undertone

let ffpath = @"C:\code\Undertone\src\Undertone\piano\Piano.pp.A1.aiff"
let file = 
    IO.read ffpath 
    //Reader.read (Path.Combine(__SOURCE_DIRECTORY__, "..\..\data\susan3.wav"))

Seq.length file // 16,865,280

let file' = file |> Seq.map ((*) 100.)

#load "FSharpChart.fsx"
 
open System
open System.Drawing
open Samples.Charting
open Samples.Charting.ChartStyles
open System.Windows.Forms.DataVisualization.Charting

let sample =
    file 
    //|> Seq.skip 30000
    |> Seq.take 15000
    |> Seq.toArray

let sample' =
    seq { for _ in 0 .. 5 do yield! sample }
        

let player = Player.Play(file', Repeat = true)
player.Play()
player.Stop()

file'
|> Seq.toList
|> FSharpChart.Line


