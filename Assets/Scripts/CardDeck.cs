using UnityEngine;
using System;

public class CardDeck : MonoBehaviour
{
    [Serializable]
    public class CardData
    {
        public GameObject cardPrefab;
        public float probability;
    }

    public CardData[] cards;
    public GameObject SourceLocation;

    void Start()
    {
        // Calculate the total probability of all cards
        float totalProbability = 0.0f;
        foreach (CardData card in cards)
        {
            totalProbability += card.probability;
        }

        // Generate a random value between 0 and the total probability
        float randomValue = UnityEngine.Random.Range(0.0f, totalProbability);

        // Select a card based on its probability
        float cumulativeProbability = 0.0f;
        foreach (CardData card in cards)
        {
            cumulativeProbability += card.probability;
            if (randomValue < cumulativeProbability)
            {
                GameObject newobj= Instantiate(card.cardPrefab, SourceLocation.transform);
                Debug.Log(card.cardPrefab);
                break;
            }
        }
    }
}
