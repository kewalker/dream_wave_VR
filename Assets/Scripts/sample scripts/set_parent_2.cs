using UnityEngine;
using System.Collections;

public class set_parent_2 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        this.transform.parent = GameObject.FindGameObjectWithTag("sound_controller").transform;
        Destroy(GetComponent<set_parent_2>());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
