using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Displayer showing the option of projectile using at the moment
public class BulletMarker : MonoBehaviour
{
    public Text bulletNumber;
    public ShipShooter shooterPlayer;

    // Start is called before the first frame update
    private void Start()
    {
        /* bulletNumber = GetComponent<Text>(); */
        shooterPlayer=  GameObject.FindGameObjectWithTag("Player").GetComponent<ShipShooter>();
        
        bulletNumber.text = (shooterPlayer.selectedType + 1).ToString();
    }

    // Update is called once per frame
    private void Update()
    {   
        bulletNumber.text = (shooterPlayer.selectedType + 1).ToString();
    }
}
