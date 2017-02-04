using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class state_manager : MonoBehaviour
{

    public static state_manager instance = null;
    public GameObject text;

    public Text message;

    public string state;

    public GameObject test;

    /*public GameObject asteroid;
    public GameObject player;
    public GameObject enemy_ship_1;

    public static game_manager instance = null;
    public float coins = 0f;
    public int points;
    public int level;
    public int lives;
    public int asteroid_speed;
    public int enemy_ship_speed;

    private bool level_up;

    public bool triple_shot;

    public int num_asteroids;

    public int asteroid_max;

    public float time;
    public int time_reset;

    public int num_kills;
    */
    /*public int lives = 3;
    public int bricks = 24;
    public float resetDelay = 1f;
    public Text livesText;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject bricksPrefab;
    public GameObject paddle;
    public GameObject deathParticles;
    public static GM instance = null;

    private GameObject clonePaddle;
    */
    // Use this for initialization
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Setup();

    }

    public void Setup()
    {
        message.text = "Tap To Start";
        state = "menu";
        /*asteroid_max = 5;
        points = 0;
        asteroid_speed = 1;
        enemy_ship_speed = 2;
        level = 1;
        lives = 3;
        num_asteroids = 0;
        triple_shot = false;
        time = 0;
        time_reset = 5;
        num_kills = 0;*/
        //clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        //Instantiate(bricksPrefab, new Vector3(0.99f, -2.92f, 0f), Quaternion.identity);
    }

    void CheckGameOver()
    {
        //if (lives < 1)
        //{
         //   Debug.Log("You lost, sucker");
        //}
        /*if (bricks < 1)
        {
            youWon.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }

        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }*/

    }

    void Reset()
    {
        //Time.timeScale = 1f;
        //Application.LoadLevel(Application.loadedLevel);
    }

    public void LoseLife()
    {
        /*lives--;
        livesText.text = "Lives: " + lives;
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
        */
    }

    public void SetupPaddle()
    {
        //clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        //bricks--;
        //CheckGameOver();
    }

    /*public int AsteroidSpeed()
    {
        return asteroid_speed;
    }

    public int EnemyShipSpeed()
    {
        return enemy_ship_speed;
    }

    public void DestroyAsteroid()
    {
        num_asteroids--;
        points += 10;
        num_kills++;

    }*/

    /*public void AsteroidDestroyAsteroid()
    {
        //num_asteroids--;
    }

    public void DestroyAsteroidNoPoints()
    {
        num_asteroids--;
    }

    public void DestroyEnemyShip()
    {
        points += 10;
        num_kills++;
    }

    public void DestroyEnemyShipNoPoints()
    {

    }


    public void DestroyShip()
    {

        if (lives > 0)
        {
            lives--;
            Instantiate(player, new Vector3(0, -3.5f, 0), Quaternion.Euler(0, 90, 270));
        }
        else {
            CheckGameOver();
        }
    }

    public int get_num_kills()
    {
        return num_kills;
    }

    public void reset_num_kills()
    {
        num_kills = 0;
    }

    public bool is_triple_shot()
    {
        return triple_shot;
    }

    void Update()
    {

        //coins += Time.deltaTime;

        if (time > time_reset)
        {
            //enemy wave
            Instantiate(enemy_ship_1, new Vector3(-2, 11, 0), Quaternion.Euler(-90, 0, 0));
            Instantiate(enemy_ship_1, new Vector3(0, 11, 0), Quaternion.Euler(-90, 0, 0));
            Instantiate(enemy_ship_1, new Vector3(2, 11, 0), Quaternion.Euler(-90, 0, 0));
            time = 0;

        }
        else //if ( time < time_reset)
        {
            time += Time.deltaTime;
        }


        if (num_asteroids < asteroid_max)
        {

            Random.seed = (int)Time.time;
            Vector3 temp = new Vector3(Random.Range(-4, 4), 11 + Random.Range(0, 10), 0);
            Instantiate(asteroid, temp, Quaternion.Euler(-90, 0, 0));
            num_asteroids++;

        }

        if (points != 0 && points % 200 == 0)
        {
            asteroid_max++;
            asteroid_speed++;
            level += 1;
            points += 10;

            //uncomment for triple shot @ level 2
            //triple_shot = true;
        }

    }*/


    public void update_message ()
    {
        if (state == "menu")
        {
            message.text = "Tap to start";
            message.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 30);

            //VR GUI
            TextMesh textObject = test.GetComponent<TextMesh>();
            textObject.text = "Tap to start";
            textObject.characterSize = 1.25f;
            test.transform.position = new Vector3(test.transform.position.x, (test.transform.position.y - 2), test.transform.position.z);
            test.transform.position = new Vector3((test.transform.position.x - 1.25f), test.transform.position.y, test.transform.position.z);

        } else if (state == "select")
        {
            message.text = "Random Relaxation\n\nCustom Chill\n\nOptions";
            message.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 200);

            //VR GUI
            TextMesh textObject = test.GetComponent<TextMesh>();
            textObject.text = "Random Relaxation\n\n\tCustom Chill\n\n\t\tOptions";
            textObject.characterSize = 0.75f;
            test.transform.position = new Vector3 (test.transform.position.x, (test.transform.position.y + 2), test.transform.position.z);
            test.transform.position = new Vector3((test.transform.position.x + 1.25f), test.transform.position.y, test.transform.position.z);
        } else if (state == "random_relax")
        {
            TextMesh textObject = test.GetComponent<TextMesh>();
            textObject.text = "Prepare to relax...";
            textObject.characterSize = 1.25f;
            test.transform.position = new Vector3(test.transform.position.x, (test.transform.position.y - 2), test.transform.position.z);
            test.transform.position = new Vector3((test.transform.position.x - 1.25f), test.transform.position.y, test.transform.position.z);
        }



    }


    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            if ( state == "menu" )
            {
                state = "select";
                update_message();
            }

            else if ( state == "select")
            {
                //state = "menu";
                //update_message();
            }


        }
    }

    public void set_state (string new_state)
    {
        state = new_state;
        update_message();
    }

   






    /*void OnGUI()
    {
        GUI.contentColor = Color.white;
        // Debug.Log("check 1");
        string score = ("Score is: " + points);
        string temp_level = ("Level is: " + level);
        GUI.Label(new Rect(5, 10, 500, 500), score);
        GUI.Label(new Rect(580, 10, 500, 500), temp_level);
        // GUI.Label(new Rect(10, 10, 100, 20), "Hello World!");
    }*/
}