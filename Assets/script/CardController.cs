using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    [SerializeField] Image andarCardImage;
    [SerializeField] Image baharCardImage;

    [SerializeField] Image jokerImage;

    [SerializeField]
    List<string> allCards = new List<string>
    {
    "H_A", "H_2", "H_3", "H_4", "H_5", "H_6", "H_7", "H_8", "H_9", "H_10", "H_J", "H_Q", "H_K",
    "D_A", "D_2", "D_3", "D_4", "D_5", "D_6", "D_7", "D_8", "D_9", "D_10", "D_J", "D_Q", "D_K",
    "C_A", "C_2", "C_3", "C_4", "C_5", "C_6", "C_7", "C_8", "C_9", "C_10", "C_J", "C_Q", "C_K",
    "S_A", "S_2", "S_3", "S_4", "S_5", "S_6", "S_7", "S_8", "S_9", "S_10", "S_J", "S_Q", "S_K"
    };

    string jokerRank = "";

    public void setJoker()
    {
        int randomIndex = Random.Range(0, allCards.Count);
        string jokerCard = allCards[randomIndex];
        jokerImage.sprite = ResourceManager.Instance.spriteDict[jokerCard];
        allCards.RemoveAt(randomIndex);
        jokerRank = jokerCard.Split('_')[1];
    }

    public bool Deal(bool andar)
    {

        int randomIndex = Random.Range(0, allCards.Count);
        string card = allCards[randomIndex];
        allCards.RemoveAt(randomIndex);


        if (andar)
            andarCardImage.sprite = ResourceManager.Instance.spriteDict[card];
        else
            baharCardImage.sprite = ResourceManager.Instance.spriteDict[card];
        string rankString = card.Split('_')[1];

        if (rankString == jokerRank) return true;
        else return false;
    }

}
