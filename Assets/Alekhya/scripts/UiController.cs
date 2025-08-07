using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    [SerializeField] private GameObject GamePanel;
    [SerializeField] private GameObject currActivePanel;
    [SerializeField] private List<PanelData> panelObject;



    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in panelObject)
        {
            item.PanelOpenButton.onClick.AddListener(() => OpenPanel(item.PanelObject));
            item.PanelCloseButton.onClick.AddListener(() => ClosePanel());
        }
    }


    private void OpenPanel(GameObject panels)
    {
        if (currActivePanel != null) ClosePanel();
        if (!GamePanel.activeSelf) GamePanel.SetActive(true);
        panels.SetActive(true);
        currActivePanel = panels;
    }

    private void ClosePanel()
    {
        if (currActivePanel != null)
        {
            currActivePanel.SetActive(false);
            currActivePanel = null;

        }
    }


    public void BackToLobby()
    {
        SceneManager.LoadScene("PlayerMainMenu");
    }

    
}

[System.Serializable]
public class PanelData
{
    public Button PanelOpenButton;
    public Button PanelCloseButton;
    public GameObject PanelObject;
}
