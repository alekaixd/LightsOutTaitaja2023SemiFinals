using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject infoText; //the whole object
    [SerializeField] private TextMeshProUGUI infoTextMeshPro;

    public GameObject[] randomObjects;
    private GameObject objectToHide;

    [SerializeField] private AudioSource ukkonenSoundEffect;
    [SerializeField] private AudioSource taustamusiikki;
    // Start is called before the first frame update
    void Start()
    {
        taustamusiikki.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            taustamusiikki.Stop(); 
            ukkonenSoundEffect.Play();
            blackScreen.SetActive(true); // activates a black overlay
 
            StartCoroutine(BlackScreenTimer());
            
        }
    }

    private IEnumerator BlackScreenTimer()
    {
        int i = 0;
        infoText.SetActive(false);
        while (i < 11) // loops to change the timer text on the dark screen
        {
            yield return new WaitForSeconds(1);
            timerText.text = Convert.ToString(10 - i);
            i++;
        }
        taustamusiikki.Play();
        HideItem();
        timerText.text = "";
        blackScreen.SetActive(false);
        infoTextMeshPro.text = "What has changed?\nClick Where the object disappeared";
        infoText.SetActive(true);
    }

    private void HideItem()
    {
        objectToHide = randomObjects[Random.Range(0, randomObjects.Length)];
        objectToHide.GetComponent<ObjectClickScript>().isCorrectObject = true;
        objectToHide.GetComponent<SpriteRenderer>().enabled = false;
        Debug.Log(objectToHide);
    }

    public void WinGame()
    {
        Debug.Log("Win game!");
    }
}
