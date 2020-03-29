using System;
using System.Collections.Generic;
using System.Text;

namespace bowling_game_kata
{
    public class Game
    {
        public int Score { get; private set; }
        public int CurrentFrame { get; private set; }

        private bool firstThrow = false;
        private int[] frames = new int[11];
        public void Played(int v)
        {
            Score += v;
            if (!firstThrow) firstThrow = true;
            else {
                CurrentFrame++;
                frames[CurrentFrame] = Score;
                firstThrow = false; }
        }

        public int GetScoreByFrame(int frameNumber)
        {
            return frames[frameNumber];
        }
    }
}
