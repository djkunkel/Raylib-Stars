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
    internal class Stars : Layer
    {

        public Stars(float speed, int count)
        {
            _speed = speed;
            _count = count;

            stars = new Vector2[_count];
            starColors = new Color[_count];
        }



        Vector2[] stars { get; init; }
        Color[] starColors { get; init; }

        
        private int _width;
        private int _height;
        private float _speed;
        private int _count;

        public override void Init(int width, int height)
        {
            _width = width;
            _height = height;
            
            for(int i = 0;i < _count; i++) 
            {
                var intensity = GetRandomValue(128, 255);
                starColors[i] = new Color(intensity, intensity, intensity, 255);
                stars[i].X = GetRandomValue(0, width);
                stars[i].Y = GetRandomValue(0, height);
            }
        }

        public override void Update(float frameTime)
        {
            for (int i = 0; i < _count; i++)
            {
                stars[i].Y = (stars[i].Y + _speed*frameTime);
                if(stars[i].Y > _height)
                {
                    stars[i].Y = 0;
                    stars[i].X = GetRandomValue(0, _width);
                }
            }
        }
        public override void Draw()
        {
            for (int i = 0; i < _count; i++)
            {
                DrawCircle((int)stars[i].X, (int)stars[i].Y, 1, starColors[i]);
            }
        }

        
    }
}
