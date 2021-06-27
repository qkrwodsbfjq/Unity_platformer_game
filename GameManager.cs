//==========================================
// writer : Jae Yoon Park.
// file : GameManager.cs.
// content : Save, Load, Esc event.
// descript : .
//==========================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject menuSet;
    public GameObject soundMenu;
    public GameObject languageMenu;
    public GameObject player;

    PlayerController myPlayerController;
    StaminaController myStaminaController;
    MinigameController myMinigameController;

    private void Awake()
    {
        myPlayerController = FindObjectOfType<PlayerController>();
        myStaminaController = FindObjectOfType<StaminaController>();
        myMinigameController = FindObjectOfType<MinigameController>();
    }

    void Start()
    {

    }

    //------------------------------------------------------------------------

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (soundMenu.activeSelf)
                soundMenu.SetActive(false);
            else if (languageMenu.activeSelf)
                languageMenu.SetActive(false);
            else if (menuSet.activeSelf)
            {
                menuSet.SetActive(false);
                ResumeGame();
            }
            else
            {
                menuSet.SetActive(true);
                PauseGame();
            }
        }
    }

    //------------------------------------------------------------------------

    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);

        //World, gold, stage...
        //PlayerPrefs.SetInt()

        PlayerPrefs.Save();
    }

    //------------------------------------------------------------------------

    public void GameLoad()
    {
        if (PlayerPrefs.HasKey("playerX"))
            return;

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        //int World, gold, stage... =

        player.transform.position = new Vector3(x, y, 0);

        //World, gold, stage...
    }

    private void PauseGame() //일시정지.
    {
        if (myPlayerController != null)
        {
            myPlayerController.canControl = false;
        }
        else if(myPlayerController == null)
        {
            myMinigameController.canInput = false;
        }

        Time.timeScale = 0;
    }

    private void ResumeGame() //일시정지해제.
    {
        if (myPlayerController != null)
        {
            myPlayerController.canControl = true;
        }
        else if (myPlayerController == null)
        {
            myMinigameController.canInput = true;
        }
        Time.timeScale = 1;
    }
}
