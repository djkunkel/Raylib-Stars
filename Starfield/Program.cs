/*******************************************************************************************
*
*   raylib [core] example - Basic window
*
*   Welcome to raylib!
*
*   To test examples, just press F6 and execute raylib_compile_execute script
*   Note that compiled executable is placed in the same folder as .c file
*
*   You can find all basic examples on C:\raylib\raylib\examples folder or
*   raylib official webpage: www.raylib.com
*
*   Enjoy using raylib. :)
*
*   This example has been created using raylib 1.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2013-2016 Ramon Santamaria (@raysan5)
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
            // Update
            //----------------------------------------------------------------------------------
            // TODO: Update your variables here
            //----------------------------------------------------------------------------------
            foreach (var layer in layers)
            {
                layer.Update(frameTime);
            }

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            ClearBackground(Color.Black);

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