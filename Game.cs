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
        Bird bird = new Bird(new Vector2(250, Window.Width / 2));
        Pipe[] pipes = new Pipe[10];

        int pipesPassed = 0;
        float timeSinceLastNewPipe = 5f;
        float pipeInterval = 5f;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(800, 600);
            Window.TargetFPS = 60;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);
            ShowScoreText();
            ManageTime();

            bird.Update();
            UpdatePipes();

        }


        void ShowScoreText()
        {
            Text.Size = 50;
            Text.Draw($"Score: {pipesPassed}", new Vector2(0, 0));
        }


        void ManageTime()
        {
            if (timeSinceLastNewPipe >= pipeInterval)
            {
                AddPipe();
                timeSinceLastNewPipe = 0f;
            }

            timeSinceLastNewPipe += Time.DeltaTime;
        }


        void AddPipe()
        {
            Console.WriteLine("Added Pipe");
            
            for (int i = 0; i < pipes.Length; i++)
            {
                if (pipes[i] != null) continue;

                pipes[i] = new Pipe(Random.Integer(0, Window.Height + 1));
                break;
            }
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
