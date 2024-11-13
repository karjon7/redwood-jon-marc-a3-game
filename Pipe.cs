using Game10003;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    public class Pipe
    {
        public Vector2 position;
        public int speed = 3;
        public int space_size = 300;
        public int size = 100;
        public bool passed = false;
        
        public Pipe(int height)
        {
            position = new Vector2(Window.Width, height);
        }

        public void Update()
        {
            position.X -= (float)speed;

            DrawPipe();
        }

        public void DrawPipe()
        {
            Draw.FillColor = Color.Green;
            Draw.LineColor = Color.Black;
            Draw.LineSize = 2;

            int top_pipe_end = (int)position.Y - space_size / 2;
            int bottom_pipe_start = top_pipe_end + space_size;

            Draw.Rectangle(position.X, 0, size, top_pipe_end);
            Draw.Rectangle(position.X, bottom_pipe_start, size, Window.Height - position.Y + space_size / 2);
        }
    }
}
