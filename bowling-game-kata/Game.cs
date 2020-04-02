
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
            IncrementScore(kickedBalls);
            if (IsFirstThrow)
            {
                SetThrows(CurrentFrame * 2, kickedBalls);

                if (IsStrike(CurrentFrame - 1) && CurrentFrame < 11)
                {
                    IncrementScore(kickedBalls);
                    SetThrows((CurrentFrame - 1) * 2 + 1, kickedBalls);

                    if (IsStrike(CurrentFrame - 2))
                    {
                        IncrementScore(kickedBalls);
                        SetThrows((CurrentFrame - 2) * 2 + 1, kickedBalls);
                    }
                }
                if (IsSpare())
                {
                    IncrementScore(kickedBalls);
                    SetThrows((CurrentFrame - 1) * 2 + 1, kickedBalls);
                }
                if (kickedBalls == 10)
                {
                    IncrementCurrentFrame();
                }
                else IsFirstThrow = false;
            }
            else
            {
                SetThrows(CurrentFrame * 2 + 1, kickedBalls);
                if (IsStrike(CurrentFrame - 1))
                {
                    IncrementScore(kickedBalls);
                    SetThrows((CurrentFrame - 2) * 2 + 1, kickedBalls);
                }
                IsFirstThrow = true;
                IncrementCurrentFrame();
            }

        }

        private void SetThrows(int throwNumber, int kickedBalls)
        {
            throws[throwNumber] += kickedBalls;
        }

        private void IncrementScore(int kickedBalls)
        {
            Score += kickedBalls;
        }

        private bool IsStrike(int frameNumber)
        {
            return throws[(frameNumber) * 2] == 10;
        }

        private void IncrementCurrentFrame()
        {
            if (CurrentFrame < 11) CurrentFrame++;
        }

        private bool IsSpare()
        {
            return throws[(CurrentFrame - 1) * 2]
                + throws[(CurrentFrame - 1) * 2 + 1] == 10;
        }

        public int GetScoreByFrame(int frameNumber)
        {
            return throws[frameNumber * 2] + throws[frameNumber * 2 + 1];
        }
    }
}
