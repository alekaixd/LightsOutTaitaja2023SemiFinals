using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("perusscene"); //vaihtaa scenen "p‰‰sceneen", jossa itse gameplay tapahtuu
    }

    public void Quitgame()
    {
        Application.Quit(); //Lopetta pelin
    }

    public void Credits()
    {
        SceneManager.LoadScene("credits"); //Siirt‰‰ pelaajan credits sceneen, jossa n‰kyy krediitit
    }

    public void main_menu()
    {
        SceneManager.LoadScene("MainMeniu");
    }



}
