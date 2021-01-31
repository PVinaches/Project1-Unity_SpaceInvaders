using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMarkers : MonoBehaviour
{
    public GameObject gameMarkersMenu;
    /* public string scene; */
    
    // Start is called before the first frame update
    void Start()
    {
        gameMarkersMenu.SetActive(true);
    }


    public void GameMarkersInactive()
    {
        gameMarkersMenu.SetActive(true);
    }
}
