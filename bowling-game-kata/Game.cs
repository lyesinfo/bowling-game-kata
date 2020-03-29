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
        private int[] throws = new int[21];
        public void Played(int kickedBalls)
        {
            Score += kickedBalls;

            if (IsFirstThrow)
            {
                throws[CurrentFrame * 2] = kickedBalls;
                IsFirstThrow = false;
                if (IsSpare())
                {
                    throws[(CurrentFrame - 1) * 2 + 1] += kickedBalls;
                    Score += kickedBalls;
                }
            }
            else
            {
                throws[CurrentFrame * 2 + 1] = kickedBalls;

                IsFirstThrow = true;
                CurrentFrame++;
            }
        }

        private bool IsSpare()
        {
            return throws[(CurrentFrame - 1) * 2] + throws[(CurrentFrame - 1) * 2 + 1] == 10;
        }

        public int GetScoreByFrame(int frameNumber)
        {
            return throws[frameNumber * 2] + throws[frameNumber * 2 +1];
        }
    }
}
