using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] List<GameObject> spawnableObjects;
    [SerializeField] List<GameObject> bombObjects;
    [SerializeField] TextMeshProUGUI scoreText;

    private int score;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
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
            yield return new WaitForSeconds(Random.Range(0.65f, 1.2f));
            if (Random.Range(0,8) != 0 )
            {
                InstantiateObject(spawnableObjects, false);
            } else
            {
                InstantiateObject(bombObjects, true);
            }

        }
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public void BombScore()
    {
        score -= 15;
        if (score < 0)
        {
            score = 0;
        }

        scoreText.text = "Score: " + score;
    }

    private void InstantiateObject(List<GameObject> spawnableObjects, bool isBomb)
    {
        GameObject newObject = Instantiate(spawnableObjects[Random.Range(0, spawnableObjects.Count)], transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        newObject.transform.position = new Vector3(newObject.transform.position.x + Random.Range(-8, 8), newObject.transform.position.y, newObject.transform.position.z);
        newObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-200, 200), Random.Range(600, 880)));
        newObject.GetComponent<FruitScript>().isBomb = isBomb;
        Destroy(newObject, 5f);
    }
}
