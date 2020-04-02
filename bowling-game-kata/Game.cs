using System;
using System.Collections.Generic;
using System.Text;

namespace bowling_game_kata
{
    public class Game
    {
        public int Score { get; private set; }
        public int CurrentFrame { get; private set; } = 1;

        private bool IsFirstThrow = true;
        private int[] throws = new int[23];
        public void Played(int kickedBalls)
        {
            Score += kickedBalls;
            if (IsFirstThrow)
            {
                throws[CurrentFrame * 2] += kickedBalls;


                if (throws[(CurrentFrame - 1) * 2] == 10 && CurrentFrame < 11)
                {
                    throws[(CurrentFrame - 1) * 2 + 1] += kickedBalls;
                    Score += kickedBalls;

                    if (throws[(CurrentFrame - 2) * 2] == 10)
                    {
                        throws[(CurrentFrame - 2) * 2 + 1] += kickedBalls;
                        Score += kickedBalls;
                    }
                }
                else
                    if (IsSpare())
                {
                    throws[(CurrentFrame - 1) * 2 + 1] += kickedBalls;
                    Score += kickedBalls;
                }
                if (kickedBalls == 10)
                {
                    IncrementCurrentFrame();
                }
                else IsFirstThrow = false;
            }
            else
            {
                throws[CurrentFrame * 2 + 1] += kickedBalls;
                if (throws[(CurrentFrame - 1) * 2] == 10 && CurrentFrame < 11)
                {
                    throws[(CurrentFrame - 1) * 2 + 1] += kickedBalls;
                    Score += kickedBalls;
                }
                IsFirstThrow = true;
                IncrementCurrentFrame();
            }

        }

        private void IncrementCurrentFrame()
        {
            if (CurrentFrame < 11) CurrentFrame++;
        }

        private bool IsSpare()
        {
            return throws[(CurrentFrame - 1) * 2] + throws[(CurrentFrame - 1) * 2 + 1] == 10;
        }

        public int GetScoreByFrame(int frameNumber)
        {
            return throws[frameNumber * 2] + throws[frameNumber * 2 + 1];
        }
    }
}
