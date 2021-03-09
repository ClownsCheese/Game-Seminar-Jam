using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMover : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 30;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * -speed * Time.deltaTime);

        if (transform.position.x < -19)
        {
            transform.position = new Vector3(19f, transform.position.y, transform.position.z);
        }
    }
}
