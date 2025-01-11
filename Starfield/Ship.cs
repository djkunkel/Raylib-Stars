using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Starfield
{
    internal class Ship : Layer
    {

        Vector2[] projectiles;

        Vector2 position;
        private int _width;
        private int _height;
        
        float shipSize = 40;
        float shipSpeed = 500;
        float shotSpeed = 600;

        int shotsFired = 0;

        public Ship()
        {
            projectiles = new Vector2[20];
        }

        public override void Init(int width, int height)
        {
            position = new Vector2(width/2, height-75);
            _width = width;
            _height = height;
        }

        public override void Update(float frameTime)
        {
            if (IsKeyDown(KeyboardKey.Left))
            {
                position.X = Math.Max(shipSize / 2, position.X - shipSpeed *frameTime);
            }
            else if (IsKeyDown(KeyboardKey.Right))
            {
                position.X = Math.Min(_width - (shipSize / 2), position.X + shipSpeed*frameTime);
            }


            bool fired = false;
            for (int i = 0; i < projectiles.Length; i++)
            {
                if (projectiles[i].Y > 0)
                {
                    projectiles[i].Y = projectiles[i].Y - shotSpeed*frameTime;
                }

                if (!fired && IsKeyPressed(KeyboardKey.Space) && projectiles[i].Y<=0)
                {
                    fired = true;
                    shotsFired++;
                    projectiles[i].Y = position.Y + 4f;
                    projectiles[i].X = position.X;
                }
            }

            
        }

        public override void Draw()
        {
            DrawTriangle(
                new Vector2(position.X + shipSize / 2, position.Y + shipSize),
                new Vector2(position.X, position.Y),
                new Vector2(position.X - shipSize / 2, position.Y + shipSize),
                Color.Red
            );

            for (int i = 0; i < projectiles.Length; i++)
            {
                if (projectiles[i].Y >= 0)
                {
                    DrawCircle((int)projectiles[i].X, (int)projectiles[i].Y, 4.0f, Color.Green);
                }
            }

            DrawText($"Shots fired: {shotsFired}", 10, _height-25, 20, Color.Magenta);
        }
    }
}
