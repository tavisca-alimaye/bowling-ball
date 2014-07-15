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
            int bonus = 0;
            int remaining = 20;
            int current;
            bool strike = false;
            int[] frame = new int[2];
            for (current = 0; current < _rolls.Count; current++)
            {
                
                if (_rolls[current] == 10 && remaining > 0) 
                {
                    strike = false;    
                    StikeOrSpare(_rolls, current, ref strike);
                    if (strike == true)
                    {
                        bonus += _rolls[current + 1] + _rolls[current + 2] + _rolls[current];
                        remaining -= 2;
                        if (remaining <= 0)
                            break;
                    }
                    else
                    {
                        bonus += _rolls[current + 1] + _rolls[current];
                        remaining -= 1;
                    }
                }
                else
                {
                    _score += _rolls[current];
                    remaining--;
                }
            }
            for (current = 0; current < _rolls.Count-1; current += 2)
            {
                if ((_rolls[current] + _rolls[current + 1]) == 10 && _rolls[current] != 10)
                {
                    bonus += _rolls[current + 2];
                }
            }
                _score += bonus;
            return _score;
        }

        private void StikeOrSpare(List<int> _rolls, int current, ref bool strike)
        {
            if (current % 2 == 0)
                strike = true;
            else
                strike = false;
        }

        

    }
}
