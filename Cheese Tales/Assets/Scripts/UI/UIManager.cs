
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    private bool showPauseMenu = false;
    public GameObject pauseMenu;

    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 1)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            { 
                showPauseMenu = !showPauseMenu; 
            }
          
        }
        if (showPauseMenu)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }
    public static void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void OnClickExit()
    {
        Application.Quit();
    }
    public void Resume()
    {
        showPauseMenu = false;
        
    }
}

