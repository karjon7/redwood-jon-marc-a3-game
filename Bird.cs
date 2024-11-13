using Game10003;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    public class Bird
    {
        public Vector2 position;
        public Vector2 velocity;
        public int size = 25;
        private int jump_strength = 15;

        int gravity = 1;

        public Bird(Vector2 pos) 
        {
            position = pos;
        }

        public void Update()
        {
            velocity.Y += gravity;

            GetInput();
            UpdateVelocity();
            CheckWindowCollisions();

            DrawBird();
        }

        public void DrawBird()
        {
            Draw.LineSize = 3;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.Yellow;

            Draw.Circle(position, size);
        }


        private void GetInput()
        {
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space)) velocity.Y = -jump_strength;
        }
        
        
        private void UpdateVelocity() 
        {
            position += velocity;
        }


        private void CheckWindowCollisions()
        {
            if (position.Y - size < 0) position.Y = 0 + size;
            // if (position.Y + size > Window.Height) position.Y = Window.Height - size;
        }
    }
}
