using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickScript : MonoBehaviour
{
    public bool isCorrectObject = false; // is changed
    [SerializeField] private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() //on click executes if statements
    {
        if (isCorrectObject == true) //checks if the gameobjects "isCorrectObject" has been changed
        {
            gameManager.WinGame();
        }

        else // if not you lose
        {
            gameManager.LoseGame();
        }
    }
}
