using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinLoseTrigger : MonoBehaviour
{

   public int votesRequired = 8; // Number of votes required to win
    private string sceneToLoad;
    private bool enterAllowed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("entered trigger");
        if (collision.CompareTag("Player"))
        {
            Debug.Log("comparing player working");
            int votesCollected = DialogueManager.GetInstance().votesCollected; // Get the number of votes collected
            
                if (votesCollected >= votesRequired)
                {   
                    Debug.Log("win state");
                    sceneToLoad = "Win Screen"; // Load win state scene
                    enterAllowed = true;
                }
                else
                {
                    Debug.Log("lose state");
                    sceneToLoad = "Lose Screen"; // Load lose state scene
                    enterAllowed = true;
                }
                
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("player exit trigger");
        enterAllowed = false;
    }

    private void Update()
    {
        if(enterAllowed && Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
