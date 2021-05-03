using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    [SerializeField] GameObject controls;
    private static bool controlsOpen = false;

    private void Start()
    {
        transition.SetTrigger("Start");
    }


    void Update()
    {
        if (controlsOpen)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                controlsOpen = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
    public void PlayGame()
    {
        controls.SetActive(true);
        controlsOpen = true;
    }

  public void QuitGame ()
    {
        Debug.Log("Quitted the game");
        Application.Quit();
    }
}
