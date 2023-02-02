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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            blackScreen.SetActive(true);
            StartCoroutine(BlackScreenTimer());
        }
    }

    private IEnumerator BlackScreenTimer()
    {
        int i = 0;
        while (i < 10)
        {
            yield return new WaitForSeconds(1);
            timerText.text = Convert.ToString(10 - i);
            i++;
        }
        
        blackScreen.SetActive(false);
    }
}
