using UnityEngine;
using System.Collections;

public class shrink_and_destroy : MonoBehaviour {

    public float targetScale;
    public float shrinkSpeed;

	// Use this for initialization
	void Start () {
        targetScale = 0.05f;
        shrinkSpeed = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, new Vector3(targetScale, targetScale, targetScale), Time.deltaTime * shrinkSpeed);

        //destroy if within 0.05 tolerance
        if (gameObject.transform.localScale.x - targetScale < 0.05f)
        {
            Destroy(gameObject);
        }
	}
}
