/*******************************************************************************************
* Raylib Stars demo
* 
* unlicense (see LICENSE.md)
* 
* Copyright 2025 DJ Kunkel
*
********************************************************************************************/

using System.Numerics;
using System;
using System.Text;
using Raylib_cs;
using static Raylib_cs.Raylib;
using Starfield.Utils;

namespace Starfield;

public class BasicWindow
{
    public static int Main()
    {

        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 600;
        const int screenHeight = 900;

        SetConfigFlags(ConfigFlags.VSyncHint);
        InitWindow(screenWidth, screenHeight, "Stars");




        // construct layers
        //--------------------------------------------------------------------------------------
        var layers = new List<Layer>()
        {
            new Stars(50, 100),
            new Stars(75, 60),
            new Stars(100, 25),
            new Ship()
        };


        //INIT
        foreach(var layer in layers)
        {
            layer.Init(screenWidth, screenHeight);
        }


        // Main game loop
        while (!WindowShouldClose())
        {
            var frameTime = GetFrameTime();

            //crude frame limiter?
            //if (frameTime < 1f / 60f)
            //{
            //    Thread.Sleep((int)(1f / 60f - frameTime)*1000);
            //}

            // Update
            //----------------------------------------------------------------------------------
            // update each layer
            foreach (var layer in layers)
            {
                layer.Update(frameTime);
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.Black);

            //draw each layer
            foreach (var layer in layers)
            {
                layer.Draw();
            }

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}