using UnityEngine;
using System.Collections;

public class rotate_clockwise : MonoBehaviour {

    float speed;
    int reverse;

    // Use this for initialization
    void Start()
    {
        speed = Random.Range(0f, 0.5f);

        reverse = Random.Range(0, 2);

        if (reverse == 1)
        {
            speed = (-1) * speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(speed, 0, 0);
    }
}
