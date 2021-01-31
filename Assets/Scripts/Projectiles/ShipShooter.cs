using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooter : MonoBehaviour
{
    public List<ShipProjectile> projectiles;
    public List<ShipProjectile> moreProjectiles;

    public AudioClip shooot;
    
    private bool _shooted = false;
    private int _num = 0;

    [HideInInspector]
    public int selectedType = 0;

    

    // Update is called once per frame
    void Update()
    {
        // Coroutine that initializes the shooting
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(Shoot());
        }
    }

    // How the different threads are made
    public IEnumerator Shoot()
    {
        float t = projectiles[selectedType].rate;
        if (_shooted)
            yield return null;
        if (!_shooted)
        {
            _shooted = true;
            yield return new WaitForSeconds(t);

            // GameObject proj = GameObject.Instantiate(projectiles[selectedType].gameObject) as GameObject;
            // New line using ObjectPool (more efficient)
            GameObject proj = ObjectPool.SharedInstance.GetPooledObject(projectiles[selectedType].gameObject);

            GetComponent<AudioSource>().Play();


            proj.transform.position = transform.position;
            proj.transform.rotation = transform.rotation;

            //New line
            proj.SetActive(true);

            _shooted = false;

            // Way of changing the projectile's type
            if (Input.GetKey(KeyCode.Q))
            {
                selectedType = (selectedType + 1) % projectiles.Count;

                // To change the music when changing the projectile type
                AudioClip aux = GetComponent<AudioSource>().clip;
                GetComponent<AudioSource>().clip = shooot;
                shooot = aux;
            }       
        }
    }

    public void PowerUp(string bulletName)
    {        
        if (bulletName == "Bullet2")
            _num = 0; 
        else
            _num = 1;
        
        projectiles.Add(moreProjectiles[_num]);
        
        /* StartCoroutine(waiting()); */
    }

    /* IEnumerator waiting()
    {
        yield return new WaitForSecondsRealtime(10);
        print("");
        StopCoroutine(waiting());
        
    } */

} 


