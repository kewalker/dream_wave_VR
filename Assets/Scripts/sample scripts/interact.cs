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
            if (Input.GetButtonDown("Fire1"))
            {
                if (seen.collider.tag == "dream_wave_VR")
                {
                    game_manager.instance.set_state("menu");

                }
                else if (seen.collider.tag == "select_a_session")
                {
                    game_manager.instance.set_state("select_a_session");

                }
                else if (seen.collider.tag == "random_relax")
                {
                    game_manager.instance.set_state("random_relax");

                }
                else if (seen.collider.tag == "options")
                {
                    game_manager.instance.set_state("options");
                }
            }

            if (Input.GetMouseButtonDown(1))
            //(Input.GetKeyDown (Keycode.Escape))
            {
                if (game_manager.instance.get_state() == "started")
                {
                    print("pressing escape");
                    game_manager.instance.set_state("pause");
                } else if (game_manager.instance.get_state() == "pause")
                {
                    print("resuming...");
                    game_manager.instance.set_state("resume");
                }
            }
            /* if (seen.collider.tag == "button" && (Input.GetButtonDown("Fire1")))
             {
                 if (seen.collider.name == "dream_wave_VR" || seen.collider.name == "dream_wave_VR(Clone)") 
                 {
                     game_manager.instance.set_state("menu");
                 }

                 if (seen.collider.name == "")

                 else
                 {
                     print("unknown");
                 }

                // print("start");
                 //if (!hasPlayed)
                 //{
                     //seen.collider.GetComponent<AudioSource>().PlayOneShot(seen.collider.GetComponent<AudioSource>().clip, 1.0f);

                  //   print("name " + seen.collider.name);
                    // game_manager.instance.set_state(seen.collider.name);
                     //audio_temp = seen.collider.GetComponent<AudioSource>();
                     //hasPlayed = true;
                 //}

             }*/

            //}

        }
        else
        {
           // print("db");
            //  print("stopping");
            // audio_temp.Stop();
            //hasPlayed = false;
        }



        Debug.DrawRay(transform.position, playerRotation, Color.black, 1);
    }
}
