using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] GameObject backgroundObj;
    [SerializeField] List<Sprite> backgroundImages;
    int backgroundIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeBackground());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeBackground()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(9f, 10f));
            if (backgroundIndex < backgroundImages.Count - 1)
            {
                backgroundObj.GetComponent<SpriteRenderer>().sprite = backgroundImages[backgroundIndex];
                backgroundIndex++;
            } else
            {
                backgroundIndex = 0;
            }
        }
    }
}
