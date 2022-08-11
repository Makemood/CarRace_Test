using TMPro;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI bestTime;
    [SerializeField]
    private GameObject menu;

    private void Start()
    {
        Actions.OnFinish += OpenStartMenu;
        OpenStartMenu();
        
    }
    public void OpenStartMenu()
    {
        bestTime.text = $"Лучшее {PlayerPrefs.GetString("bestTime","0")}";
        menu.SetActive(true);
        Time.timeScale = 0;
    }
    public void OnPlayGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        Actions.RestartGame();
    }


}
