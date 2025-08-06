using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    [SerializeField] CardController cardController;
    [SerializeField] GameObject betPanel;
    [SerializeField] GameObject andarChipObject;
    [SerializeField] TMP_Text andarChipText;
    [SerializeField] GameObject baharChipObject;
    [SerializeField] TMP_Text baharChipText;
    [SerializeField] TMP_Text balanceText;
    [SerializeField] TMP_Text gameStatusText;

    [SerializeField] Button restartButton;

    [Header("Betting Variables")]

    [SerializeField] Button andar;
    [SerializeField] Button andarPlus;
    [SerializeField] Button andarMinus;
    [SerializeField] Button bahar;
    [SerializeField] Button baharPlus;
    [SerializeField] Button baharMinus;
    [SerializeField] TMP_Text andarBetText;
    [SerializeField] TMP_Text baharBetText;
    public int balance;
    int baharBetTotal=10;
    int andarBetTotal=10;

    bool andarSelected;
    bool baharSelected;
    bool isGameStarted;
    bool dealCards;
    bool canbet;

    void Start()
    {
        andar.onClick.AddListener(() => OnBet(true));
        bahar.onClick.AddListener(() => OnBet(false));

        baharPlus.onClick.AddListener(() => OnAddBet(false));
        baharMinus.onClick.AddListener(() => OnRemoveBet(false));

        andarPlus.onClick.AddListener(() => OnAddBet(true));
        andarMinus.onClick.AddListener(() => OnRemoveBet(true));
        StartCoroutine(GameLoop());

    }

    IEnumerator GameLoop()
    {
        balanceText.text = balance.ToString();
        int count = 5;
        gameStatusText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);
        while (count > 0)
        {
            gameStatusText.text = "Game Starts in " + count.ToString();
            gameStatusText.color = Color.red;
            yield return new WaitForSeconds(1f);
            count--;
        }
        gameStatusText.gameObject.SetActive(false);
        isGameStarted = true;
        dealCards = true;
        cardController.setJoker();
        gameStatusText.gameObject.SetActive(true);
        gameStatusText.text = "Place Your Bets";
        gameStatusText.color = Color.green;

        yield return new WaitForSeconds(1f);
        gameStatusText.gameObject.SetActive(false);

        betPanel.SetActive(true);
        canbet = true;
        bool andarMatched = false;
        bool baharMatched = false;

        yield return new WaitUntil(() => !canbet);
        yield return new WaitForSeconds(1f);
        andarMatched = cardController.Deal(true);
        if (!andarMatched)
        {
            yield return new WaitForSeconds(1f);
            baharMatched = cardController.Deal(false);
            yield return new WaitForSeconds(1f);
        }
        if (andarMatched || baharMatched)
        {
            gameStatusText.gameObject.SetActive(true);
            gameStatusText.text = "Joker Matched!";
            gameStatusText.color = Color.yellow;
            OnGameEnd(andarMatched, baharMatched);
            yield break;
        }
        gameStatusText.gameObject.SetActive(true);
        betPanel.SetActive(true);
        canbet = true;
        gameStatusText.text = "Place Your Bets";
        yield return new WaitForSeconds(1f);
        gameStatusText.gameObject.SetActive(false);
        yield return new WaitUntil(() => !canbet);
        yield return new WaitForSeconds(1f);
        while (!andarMatched && !baharMatched)
        {
            andarMatched = cardController.Deal(true);
            if (andarMatched) break;
            yield return new WaitForSeconds(1f);
            baharMatched = cardController.Deal(false);
            yield return new WaitForSeconds(1f);
        }
        OnGameEnd(andarMatched, baharMatched);

    }
    public void OnBet(bool andar)
    {
        if (andar)
        {
            andarChipObject.SetActive(true);
            andarChipText.text = andarBetTotal.ToString();
            betPanel.SetActive(false);
            betPanel.SetActive(false);
            andarSelected = true;
            UpdateBalance(-andarBetTotal);
            canbet = false;
            return;
        }
        baharSelected = true;
        baharChipObject.SetActive(true);
        baharChipText.text = baharBetTotal.ToString();
        UpdateBalance(-baharBetTotal);
        betPanel.SetActive(false);
        canbet = false;


    }


    void OnAddBet(bool andar)
    {
        if (andar)
        {
            andarBetTotal += 10;
            andarBetText.text = andarBetTotal.ToString();
        }
        else
        {
            baharBetTotal += 10;
            baharBetText.text = baharBetTotal.ToString();
        }
    }


    void OnRemoveBet(bool andar)
    {

        if (andar && andarBetTotal >= 20)
        {
            andarBetTotal -= 10;
            andarBetText.text = andarBetTotal.ToString();

        }
        else if (!andar && baharBetTotal >= 20)
        {

            baharBetTotal -= 10;
            baharBetText.text = baharBetTotal.ToString();

        }
    }

    void UpdateBalance(int amuount)
    {
        balance = balance + amuount;
        balanceText.text = balance.ToString();

    }

    void OnGameEnd(bool andarMatched, bool baharMatched)
    {
        gameStatusText.gameObject.SetActive(true);
        if (andarMatched && andarSelected)
        {
            UpdateBalance(andarBetTotal * 2);
            gameStatusText.text = "Andar Wins!";
            gameStatusText.color = Color.blue;
        }
        else if (baharMatched && baharSelected)
        {
            UpdateBalance(baharBetTotal * 2);
            gameStatusText.text = "Bahar Wins!";
            gameStatusText.color = Color.red;
        }
        else
        {
            gameStatusText.text = "No Winners!";
            gameStatusText.color = Color.gray;
        }
        restartButton.gameObject.SetActive(true);
        restartButton.onClick.AddListener(() => SceneManager.LoadScene(0));


    }

}
