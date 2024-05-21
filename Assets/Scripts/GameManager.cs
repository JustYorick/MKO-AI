using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnableObjects;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    // Update is called once per frame
    void Update()
    { 
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GameObject newObject = Instantiate(spawnableObjects[0], transform.position, transform.rotation);
            newObject.transform.position = new Vector3(newObject.transform.position.x + Random.Range(-8, 8), newObject.transform.position.y, newObject.transform.position.z);
            newObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-200, 200), Random.Range(600, 880)));
            //spawnedObjects.Add(newObject);
            Destroy(newObject, 5f);
        }
    }
}
