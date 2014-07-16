using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class Game
    {
        private int _score;
        private List<int> _rolls;

        public Game()
        {
            _score = 0;
            _rolls = new List<int>();
        }
        public void Roll(int pins)
        {
            _rolls.Add(pins);
        }

        public int GetScore()
        {
            List<int> strikeIndex = new List<int>();
            List<int> spareIndex = new List<int>();
            int lastframeIndex = _rolls.Count();

            GetIndexStrikeAndSpare(_rolls, ref lastframeIndex, strikeIndex, spareIndex);

            _score = GetTotal(lastframeIndex, _rolls, strikeIndex, spareIndex);
                        
            return _score;
        }

        private int GetTotal(int lastframeIndex, List<int> _rolls, List<int> strikeIndex, List<int> spareIndex)
        {
            int score = 0;
            int bonus = 0;
            int current;
            for (int i = 0; i < lastframeIndex; i++)
            {
                score += _rolls[i];
            }
            for (int i = 0; i < strikeIndex.Count; i++)
            {
                current = strikeIndex[i];
                bonus += _rolls[current + 1] + _rolls[current + 2];
            }
            for (int i = 0; i < spareIndex.Count; i++)
            {
                current = spareIndex[i];
                bonus += _rolls[current + 1];
            }

            return score + bonus;
        }

        private void GetIndexStrikeAndSpare(List<int> _rolls, ref int lastframeIndex, List<int> strikeIndex, List<int> spareIndex)
        {
            lastframeIndex = _rolls.Count;
            int count = 0;
            int frames = 0;
            int roll1, roll2;
            int len = _rolls.Count;
            for (int i = 0; i < len; i += 2)
            {
                roll1 = _rolls[i];
                roll2 = _rolls[i + 1];
                if (frames < 10)
                {
                    if (roll1 == 10)
                    {
                        strikeIndex.Add(i);
                        frames += 1;
                        i--;
                        count++;
                    }
                    else if (roll2 == 10)
                    {
                        spareIndex.Add(i + 1);
                        frames += 1;
                        count += 2;
                    }
                    else if ((roll1 + roll2) == 10)
                    {
                        spareIndex.Add(i + 1);
                        frames += 1;
                        count += 2;
                    }
                    else
                    {
                        frames += 1;
                        count += 2;
                    }
                }
                if (frames == 10)
                {
                    lastframeIndex = count;
                    break;
                }
            }
        }
        

    }
}
