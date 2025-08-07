using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject[] allPanel;
    // [SerializeField] private Button gameRulesPanel;
    // [SerializeField] private Button backButtonPanel;



    private void ShowOnePanel(GameObject panelShow)
    {
        foreach (GameObject panel in allPanel)
        {
            panel.SetActive(panel == panelShow);
        }
    }
    private void HidePanel(GameObject panelShow)
    {
        foreach (GameObject panel in allPanel)
        {
            panel.SetActive(false);
        }
    }


    public void ShowGameRulespanel()
    {
        ShowOnePanel(allPanel[0]);
    }
    public void ShowGameInfopanel()
    {
        ShowOnePanel(allPanel[1]);
    }
    public void HideGameRulespanel()
    {
        HidePanel(allPanel[0]);
    }
    public void HideGameInfopanel()
    {
        HidePanel(allPanel[1]);
    }
}
