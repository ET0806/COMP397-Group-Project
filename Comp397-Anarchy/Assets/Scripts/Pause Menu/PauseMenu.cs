using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject PauseMenuC;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                Play();
            }
            else
            {
                Stop(); 
            }
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
            SceneManager.LoadScene(2);
        }
    }

    void Stop ()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PauseMenuC.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }
    
    public void Play()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PauseMenuC.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
