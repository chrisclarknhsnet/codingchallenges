using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace YouFeelingLuckyPunk
{
    public abstract class LuckyDipBase : ILuckyDip
    {
        private Random _random = new Random(DateTime.Now.Millisecond);
        private IEnumerator<int> _enumerator;

        public LuckyDipBase()
        {
            chooseNumbers();
        }

        /// <summary>
        /// The lowest possible number to choose
        /// </summary>
        protected abstract int lowestNumber { get; }

        /// <summary>
        /// The highest possible number to choose
        /// </summary>
        protected abstract int highestNumber { get; }

        /// <summary>
        /// The number of balls which are drawn as part of the lottery
        /// </summary>
        protected abstract int numberOfChoices { get; }

        public IEnumerator<int> GetEnumerator()
        {
            return _enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _enumerator;
        }

        public int Current => _enumerator.Current;

        object IEnumerator.Current => _enumerator.Current;

        public bool MoveNext()
        {
            return _enumerator.MoveNext();
        }

        public void Reset()
        {
            this._random = new Random(DateTime.Now.Millisecond);
            chooseNumbers();
        }

        public void Dispose()
        {
            this._enumerator = null;
            this._random = null;
        }

        private void chooseNumbers()
        {
            var choices = new List<int>();

            for (var i = 1; i <= this.numberOfChoices; i++)
            {
                int number;

                do
                {
                    number = _random.Next(this.lowestNumber, this.highestNumber);
                } while (choices.Any(n => n == number));

                choices.Add(number);
            }

            _enumerator = choices.OrderBy(n => n).GetEnumerator();
        }
    }
}
