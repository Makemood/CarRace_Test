
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;
    
    public void PauseMenuOpen()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
    }
    public void PauseMenuClose()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnRestartGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        Actions.RestartGame();
    }
}
