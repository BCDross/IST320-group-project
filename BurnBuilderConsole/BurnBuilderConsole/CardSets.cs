using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Transactions;
using MtgApiManager.Lib.Model;

namespace BurnBuilderConsole
{
    public class Sets
    {
        public Set SetData { get; set; }
    }
    
    public class CardSet
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("booster")]
        public string[] Booster { get; set; }

        [JsonPropertyName("releaseDate")]
        public DateTime ReleaseDate { get; set; }

        [JsonPropertyName("block")]
        public string Block { get; set; }

        [JsonPropertyName("onlineOnly")]
        public string OnlineOnly { get; set; }

    }

    public class CardSets : IEnumerable
    {
        private CardSet[] _cardSets;

        public CardSets(CardSet[] cSArray)
        {
            _cardSets = new CardSet[cSArray.Length];

            for (int i = 0; i < cSArray.Length; i++)
            {
                _cardSets[i] = cSArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }

        public CardSetsEnum GetEnumerator()
        {
            return new CardSetsEnum(_cardSets);
        }
    }

    public class CardSetsEnum : IEnumerator
    {
        public CardSet[] _cardSets;

        int position = -1;

        public CardSetsEnum(CardSet[] list)
        {
            _cardSets = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _cardSets.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public CardSet Current
        {
            get
            {
                try
                {
                    return _cardSets[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
