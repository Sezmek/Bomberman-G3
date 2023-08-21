using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] Players;
    
    public void WinState()
    {
        int aliveCount =0;

        foreach (GameObject player in Players)
        {
            if (player.activeSelf)
            {
                aliveCount++;
            }
        }

        if (aliveCount <=1)
        {
            Invoke(nameof(NewRound), 3f);
        }
    }
    
    public void NewRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
