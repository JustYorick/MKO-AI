using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    [SerializeField] GameObject half1;
    [SerializeField] GameObject half2;
    [SerializeField] bool cut = false;
    bool isFruitSplit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cut && !isFruitSplit)
        {
            half1.AddComponent<Rigidbody2D>();
            half1.GetComponent<Collider2D>().isTrigger = false;
            half2.AddComponent<Rigidbody2D>();
            half2.GetComponent<Collider2D>().isTrigger = false;
            isFruitSplit = true;
            //schiet ze random kanten op ofzo
        }
        //destroy fruit object
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Blade"))
        {
            cut = true;
        }
    }
}
