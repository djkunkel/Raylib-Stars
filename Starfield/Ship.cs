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
        float size = 40;
        float speed = 500;
        float shotSpeed = 600;

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
                position.X = Math.Max(size / 2, position.X - speed *frameTime);
            }
            else if (IsKeyDown(KeyboardKey.Right))
            {
                position.X = Math.Min(_width - (size / 2), position.X + speed*frameTime);
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
                    projectiles[i].Y = position.Y - size/2;
                    projectiles[i].X = position.X;
                }
            }

            
        }

        public override void Draw()
        {
            DrawTriangle(
                new Vector2(position.X + size / 2, position.Y + size),
                new Vector2(position.X, position.Y),
                new Vector2(position.X - size / 2, position.Y + size),
                Color.Red
            );

            for (int i = 0; i < projectiles.Length; i++)
            {
                if (projectiles[i].Y >= 0)
                {
                    DrawCircle((int)projectiles[i].X, (int)projectiles[i].Y, 4.0f, Color.Green);
                }
            }
        }
    }
}
