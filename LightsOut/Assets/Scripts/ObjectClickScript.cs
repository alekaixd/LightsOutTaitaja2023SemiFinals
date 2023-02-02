using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickScript : MonoBehaviour
{
    public bool isCorrectObject = false;
    [SerializeField] private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (isCorrectObject == true)
        {
            gameManager.WinGame();
        }
    }
}
