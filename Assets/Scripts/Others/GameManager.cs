using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded;
    
    // Game Over
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            FindObjectOfType<DeathUI>().DeathMenuOpen();
            FindObjectOfType<GameMarkers>().GameMarkersInactive();
        }
    }
}
