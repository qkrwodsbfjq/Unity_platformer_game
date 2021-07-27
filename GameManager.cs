using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menuSet;
    public GameObject optionMenu;
    public GameObject soundMenu;
    public GameObject languageMenu;
    public GameObject player;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            
            if (soundMenu.activeSelf)
                soundMenu.SetActive(false);
            else if (languageMenu.activeSelf)
                languageMenu.SetActive(false);
            else if (optionMenu.activeSelf)
                optionMenu.SetActive(false);
            else if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else
                menuSet.SetActive(true);
           
        }
    }


    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);

        //World, gold, stage...
        //PlayerPrefs.SetInt()

        PlayerPrefs.Save();
    }


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

}
