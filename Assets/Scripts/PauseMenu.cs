using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject settingsMenu;
    public GameObject supportMenu;
    public float mouseSensitivity = 1f;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenuUI.SetActive(false);
        settingsMenu.SetActive(false);
        supportMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(PlayerMovement.isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        settingsMenu.SetActive(false);
        supportMenu.SetActive(false);
        
        Time.timeScale = 1f;
        PlayerMovement.isPaused = false;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        settingsMenu.SetActive(false);
        supportMenu.SetActive(false);
        
        Time.timeScale = 0f;
        PlayerMovement.isPaused = true;
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        pauseMenuUI.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void OpenSupport()
    {
        pauseMenuUI.SetActive(false);
        supportMenu.SetActive(true);
    }
    
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void SetMouseSensitivity(float sensitivity)
    {
        mouseSensitivity = sensitivity;
    }
    
    public void BackToMenu()
    {
        settingsMenu.SetActive(false);
        supportMenu.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
}
