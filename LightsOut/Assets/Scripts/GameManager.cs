using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private TextMeshProUGUI timerText;

    public GameObject[] randomObjects;
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
        GameObject objectToHide = randomObjects[UnityEngine.Random.Range(0, randomObjects.Length)];
        Debug.Log(objectToHide);
    }
}
