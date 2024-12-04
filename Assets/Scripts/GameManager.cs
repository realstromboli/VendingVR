using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject winScreen;

    public VendMachineScript vendScript;

    void Start()
    {
        
    }

    

    void Update()
    {
        WinGame();
    }

    public void WinGame()
    {
        if (vendScript.currentHealth <= 0)
        {
            winScreen.gameObject.SetActive(true);
            vendScript.helpScreen.SetActive(false);
        }
        
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void toggleScreen()
    {
        winScreen.gameObject.SetActive(false);
    }
}
