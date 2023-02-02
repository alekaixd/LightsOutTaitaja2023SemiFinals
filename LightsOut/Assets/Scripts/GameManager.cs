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

    public GameObject[] randomObjects;
    private GameObject objectToHide;

    // Start is called before the first frame update
    void Start()
    {
        HideItem();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            blackScreen.SetActive(true); // activates a black overlay
            StartCoroutine(BlackScreenTimer());
        }
    }

    private IEnumerator BlackScreenTimer()
    {
        int i = 0;
        while (i < 10) // loops to change the timer text on the dark screen
        {
            yield return new WaitForSeconds(1);
            timerText.text = Convert.ToString(10 - i);
            i++;
        }
        
        blackScreen.SetActive(false);
    }

    private void HideItem()
    {
        objectToHide = randomObjects[Random.Range(0, randomObjects.Length)];
        objectToHide.GetComponent<SpriteRenderer>().enabled = false;
        Debug.Log(objectToHide);
    }

    public void WinGame()
    {
        
    }
}
