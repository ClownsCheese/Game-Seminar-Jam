using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarmanBehaviour : MonoBehaviour
{
    public float speed;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * -speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("ddd");
        gameManager.UpdatePoints(Random.Range(2, 100));
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("ddd");

        //Destroy(gameObject);
    }
}
