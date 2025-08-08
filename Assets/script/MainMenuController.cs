

//     private void HandlePlayButton()
//     {
//         Debug.Log("I am clicked");
//         string sceneName = "SampleScene";

//         if (Application.CanStreamedLevelBeLoaded(sceneName))
//         {
//             Debug.Log("I have Entered The Rummy Game");
//             SceneManager.LoadScene(sceneName);
//         }

//         else
//         {
//             Debug.Log("SceneName is no Valid");
//         }
//     }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuController : MonoBehaviour
{

    [SerializeField] private GameObject MainmenuPanel;
    [SerializeField] private GameObject currActivePanel;

    [SerializeField] private List<MenuPanelData> allPanel;


    private void Start()
    {
        foreach(var item in allPanel)
        {
            item.panelOpenButton.onClick.AddListener(() => OpenPanel(item.panelObject));
            item.panelCloseButton.onClick.AddListener(() => ClosePanel());

        }
    }



    private void OpenPanel(GameObject panel)
    {
        if (currActivePanel != null) ClosePanel();
        if (!MainmenuPanel.activeSelf) MainmenuPanel.SetActive(true);
        panel.SetActive(true);
        currActivePanel = panel;
    }

    private void ClosePanel()
    {
        if (currActivePanel!=null)
        {
            currActivePanel.SetActive(false);
            currActivePanel = null;
        }
    }
    
}

[System.Serializable]

public class MenuPanelData
{
    public Button panelOpenButton;
    public Button panelCloseButton;
    public GameObject panelObject;
}
