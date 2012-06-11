using System;

namespace Bowling
{
    public class Game
    {
        int[] _rolls = new int[21];
        int _currentRoll;

        public void Roll(int pins)
        {
            _rolls[_currentRoll] = pins;
            _currentRoll++;
        }

        public int Score
        {
            get
            {
                var score = 0;
                ForEachFrame(() =>
                {
                    if (IsSpare)
                    {
                        score += ScoreOfSpare;
                        _currentRoll += 2;
                    }
                    else if (IsStrike)
                    {
                        score += ScoreOfStrike;
                        _currentRoll += 1;
                    }
                    else
                    {
                        score += ScoreOfOpenFrame;
                        _currentRoll += 2;
                    }
                });
                return score;
            }
        }

        void ForEachFrame(Action action)
        {
            _currentRoll = 0;
            for (var i = 0; i < 10; i++)
            {
                action();
            }
        }

        bool IsSpare
        {
            get { return _rolls[_currentRoll] + _rolls[_currentRoll + 1] == 10; }
        }

        int ScoreOfSpare
        {
            get { return 10 + _rolls[_currentRoll + 2]; }
        }

        bool IsStrike
        {
            get { return _rolls[_currentRoll] == 10; }
        }

        int ScoreOfStrike
        {
            get { return 10 + _rolls[_currentRoll + 1] + _rolls[_currentRoll + 2]; }
        }

        int ScoreOfOpenFrame
        {
            get { return _rolls[_currentRoll] + _rolls[_currentRoll + 1]; }
        }
    }
}