﻿namespace Katas.FSharp.Tests

open System
open Xunit
open Xunit.Extensions

module MarsRoverTests =


    open Katas.FSharp.MarsRoverKata.Rover
    open Katas.FSharp.MarsRoverKata.Spatial
//    type ``When sending command`` () =
    let toDirection = function
        | "N" -> North | "S" -> South | "W" -> West | "E" -> East
        | _ -> failwith "wrong direction"
    
    let planet = {Name = "Planet"; Size = 100}
    let position = {At = { X = 0; Y = 0}; Facing = North}
    let rover = {Rover.Position = position; OnPlanet = planet}


    [<Theory>]
    [<InlineData(0,0,"f", 0,1)>]
    [<InlineData(0,0,"ff", 0,2)>]
    [<InlineData(0,0,"ffbb", 0,0)>]
    let ``When sending a command, rover moves to the correct coordinates``
        (initX:int, initY:int, commands:string, expectedX:int, expectedY:int) =
            
            let initialCoords = {X = initX; Y = initY}
            let rover = {rover with Position = { rover.Position with At = {X = initX; Y = initY}}}

            let expectedCoords = {X = expectedX; Y = expectedY}
            verify <@  (rover |> Send commands).Position.At = expectedCoords @>
   
        