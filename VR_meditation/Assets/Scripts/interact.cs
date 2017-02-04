using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class interact : MonoBehaviour {

    public float sightlength = 5;
    public int thrust = 1;
    AudioSource audio_temp;
    private bool hasPlayed = false;

    // Use this for initialization
    void Start()
    {
        audio_temp = null;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit seen;
        Quaternion HMDRotation = InputTracking.GetLocalRotation(VRNode.CenterEye);
        Vector3 playerRotation = HMDRotation * transform.forward;
        //Quaternion camrot = transform.rotation;
        //Vector3 playerRotation = camrot * transform.forward;
        Ray raydirection = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(raydirection, out seen))
        {
            if (seen.collider.tag == "button" && (Input.GetButtonDown("Fire1")))
            {
                print("start");
                if (!hasPlayed)
                {
                    seen.collider.GetComponent<AudioSource>().PlayOneShot(seen.collider.GetComponent<AudioSource>().clip, 1.0f);
                    print("here");
                    print("name " + seen.collider.name);
                    state_manager.instance.set_state(seen.collider.name);
                    audio_temp = seen.collider.GetComponent<AudioSource>();
                    //hasPlayed = true;
                }

            }

        }
        else
        {
             print("stopping");
            audio_temp.Stop();
            hasPlayed = false;
        }



        Debug.DrawRay(transform.position, playerRotation, Color.black, 1);
    }
}
