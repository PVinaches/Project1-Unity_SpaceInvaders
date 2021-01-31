using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject obj;
    public float minX;
    public float maxX;
    public float timeSpawn;
    private bool spawned;
    
    // Start is called before the first frame update
    void Start()
    {
        spawned = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!spawned)
            StartCoroutine(TimedSpawn(timeSpawn));
    }

    IEnumerator TimedSpawn(float t)
    {
        spawned = true;
        yield return new WaitForSeconds(t);
        Spawn();
        spawned = false;
    }

    public void Spawn()
    {
        Vector2 newPos = new Vector2(Random.Range(minX, maxX), 7f);
        GameObject ob = ObjectPool.SharedInstance.GetPooledObject(obj);
        if (ob != null)
        {
            ob.transform.position = newPos;
            ob.SetActive(true);
        }
    }
}
