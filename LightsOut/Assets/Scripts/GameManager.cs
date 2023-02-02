using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject blackScreen; // black overlay that gets enabled
    [SerializeField] private TextMeshProUGUI timerText; // the text that changes in the black screen
    [SerializeField] private GameObject infoText; //the whole info object
    [SerializeField] private TextMeshProUGUI infoTextMeshPro; // the info text

    public GameObject[] randomObjects; //list of dissappearing objects
    private GameObject objectToHide; // used to pick an object randomly
    private bool wasSpacePressed = false; // fixes an issue where the black screen can be activated again

    [SerializeField] private AudioSource ukkonenSoundEffect; //thunder sound effect
    [SerializeField] private AudioSource taustamusiikki; // background music
    // Start is called before the first frame update
    void Start()
    {
        taustamusiikki.Play(); // starts the music
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && wasSpacePressed == false)  // checks if space was pressed and it hasn't been pressed before
        {
            wasSpacePressed = true;
            taustamusiikki.Stop(); 
            ukkonenSoundEffect.Play();
            blackScreen.SetActive(true); // activates a black overlay
 
            StartCoroutine(BlackScreenTimer()); // starts a coroutine
            
        }
    }

    private IEnumerator BlackScreenTimer()
    {
        int i = 0; // for the while loop
        infoText.SetActive(false);
        while (i < 11) // loops to change the timer text on the dark screen
        {
            yield return new WaitForSeconds(1);
            timerText.text = Convert.ToString(10 - i); //changes the text in the black screen
            i++;
        }
        taustamusiikki.Play();
        HideItem(); // hides the random item after the 10 second countdown
        timerText.text = "";
        blackScreen.SetActive(false); // disables the black overlay
        infoTextMeshPro.text = "What has changed?\nClick Where the object disappeared"; // changes the info txt
        infoText.SetActive(true);
    }

    private void HideItem()
    {
        objectToHide = randomObjects[Random.Range(0, randomObjects.Length)]; // gets a random number and chooses the game object from the list
        objectToHide.GetComponent<ObjectClickScript>().isCorrectObject = true; //refers to the correct objets script and changes a bool to true
        objectToHide.GetComponent<SpriteRenderer>().enabled = false; // hides the sprite of the object but the collider can still be accessed
        Debug.Log(objectToHide);
    }

    public void WinGame() //on win condition changes to another scene
    {
        Debug.Log("Win game!"); // this writes a debug message to the console on the unity editor
        SceneManager.LoadScene("Win Scene"); //Player goes to Win scene
        
    }

    public void LoseGame()
    {
        SceneManager.LoadScene("Lose Scene"); //Player goes to Lose Scene
        
    }
}
