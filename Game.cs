// Include code libraries you need below (use the namespace).
using Assignment_3;
using System;
using System.Numerics;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Bird bird = new Bird(new Vector2(250, 300));
        Pipe[] pipes = new Pipe[10];

        int pipesPassed = 0;



        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(800, 600);
            Window.TargetFPS = 60;

            pipes[0] = new Pipe(300);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            bird.Update();
            UpdatePipes();


        }

        void UpdatePipes() 
        {
            for (int i = 0; i < pipes.Length; i++)
            {
                Pipe current_pipe = pipes[i];

                if (current_pipe == null) continue;

                current_pipe.Update();
                
                if (current_pipe.position.X < bird.position.X && !current_pipe.passed)
                {
                    current_pipe.passed = true;
                    pipesPassed++;
                }
                if (current_pipe.position.X < 0 - current_pipe.size) current_pipe = null;
            }
        }
    }
}
