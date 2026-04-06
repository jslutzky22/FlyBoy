using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool gamePaused;

    private InputAction pause;

    private GameObject pauseUI;

    private void Awake()
    {
        pause = InputSystem.actions.FindAction("Pause");
        pause.performed += PauseInput;

        pauseUI = transform.GetChild(0).gameObject;
        pauseUI.SetActive(false);
    }

    private void OnDestroy()
    {
        pause.performed -= PauseInput;
    }

    public void PauseInput(InputAction.CallbackContext ctx)
    {
        ResumeGame();
    }

    public void ResumeGame()
    {
        if (pauseUI.activeSelf)
        {
            print("UNPAUSED");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Time.timeScale = 1;
            gamePaused = false;

            pauseUI.SetActive(false);
        }
        else
        {
            print("PAUSED");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0;
            gamePaused = true;

            pauseUI.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void ReturnToMainMenu()
    {
        //  assuming scene 0 is the main menu
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
