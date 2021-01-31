using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;

    // Dictionaries that will form part of the game pool
    public Dictionary<string, Queue<GameObject>> pooledObjects = new Dictionary<string, Queue<GameObject>>();

    // Start is called before the first frame update
    void Start()
    {
        SharedInstance = this;
    }

    // Adding objects to the game pool
    void AddObjects(GameObject objectToPool)
    {
        Queue<GameObject> objPool = new Queue<GameObject>();
        var obj = GameObject.Instantiate(objectToPool);
        obj.transform.parent = transform;
        obj.SetActive(false);
        objPool.Enqueue(obj);

        // Condition to add objects when there are some with the same tag already
        if (pooledObjects.ContainsKey(objectToPool.tag))
        {
            pooledObjects[objectToPool.tag].Enqueue(obj);
        }
        else
        {
            pooledObjects.Add(objectToPool.tag, objPool);
        }
    }

    public GameObject GetPooledObject(GameObject objectToPool)
    {
        // Confition if there is no object with this tag in the pool
        if (!pooledObjects.ContainsKey(objectToPool.tag)){
            AddObjects(objectToPool);
        }
        else
        {
            // Condition when there is no objects in the pool
            if (pooledObjects[objectToPool.tag].Count == 0){
                AddObjects(objectToPool);
            }
        }
        return pooledObjects[objectToPool.tag].Dequeue();
    }

    // Removing the object when destroyed and returning it to the pool 
    public void ReturnToPool(GameObject objToPool)
    {
        objToPool.SetActive(false);
        pooledObjects[objToPool.tag].Enqueue(objToPool);
    }
}
