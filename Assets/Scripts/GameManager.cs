using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public GameObject GameMenuPanel;
    public GameObject SuccessMenuPanel;
    public GameObject FailedMenuPanel;
    private void Awake()
    {
       if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
       else
        {
            Instance = this;
        }
    }



    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void StartButtonTapped()
    {
        GameMenuPanel.SetActive(false);
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        PlayerController playerScript = playerGO.GetComponent<PlayerController>();
        playerScript.StartPlayerMoving();
    }

   public void ShowSuccessMenuPanel()
    {
       SuccessMenuPanel.SetActive(true);
    }

    public void RestartButtonTapped()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ShowFailedMenuPanel() 
    { 
        FailedMenuPanel.SetActive(true);
    
    
    }

}
