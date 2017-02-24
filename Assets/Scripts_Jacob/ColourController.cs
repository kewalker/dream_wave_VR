//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class ColourController : MonoBehaviour {

	public Color alt_color = Color.white;
    public Renderer rend; 

	float color_min;
	float color_max;
	float velocity_min;
	float velocity_max;
	float acceleration_min;
	float acceleration_max;
	float current_velocity;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();

		color_max = 1f;
		color_min = 0f;

		velocity_min = -0.02f;
		velocity_max = 0.02f;
		acceleration_min = -0.01f;
		acceleration_max = 0.01f;

        rend.material.color = alt_color;
		current_velocity = 0;
	}
	
	// Update is called once per frame
	void Update () {

		//int velocity_i;
		//float velocity;
		Color color = new Color(0,0,0);

		//velocity_i = Random.Range(0, 2);
		//velocity = velocities[ velocity_i ];
		float acceleration = Random.Range( acceleration_min, acceleration_max );
		current_velocity += acceleration;
		if( current_velocity > velocity_max ){
			current_velocity = velocity_max;
		}
		else if( current_velocity < velocity_min ){
			current_velocity = velocity_min;
		}
		float velocity_split_1 = Random.Range(0, current_velocity);
		float velocity_split_2 = Random.Range(0, current_velocity);
		float[] velocities = new float[3];
		if( current_velocity >= 0 ){
			velocities[0] = Mathf.Min(velocity_split_1,velocity_split_2);
			velocities[1] = Mathf.Max(velocity_split_1,velocity_split_2) - Mathf.Min(velocity_split_1,velocity_split_2);
			velocities[2] = current_velocity - Mathf.Max(velocity_split_1,velocity_split_2);
		}
		else{
			velocities[0] = Mathf.Max(velocity_split_1,velocity_split_2);
			velocities[1] = Mathf.Min(velocity_split_1,velocity_split_2) - Mathf.Max(velocity_split_1,velocity_split_2);
			velocities[2] = current_velocity - Mathf.Min(velocity_split_1,velocity_split_2);
		}

		// r
		float velocity = velocities[0];
		float r = rend.material.color.r;
		r += velocity;
		if ( r < 0 ){
			r = 0;
		}
		else if ( r > 1 ){
			r = 1;
		}
		color[0] = r;

		// g
		velocity = velocities[ 1 ];
		float g = rend.material.color.g;
		g += velocity;
		if ( g < 0 ){
			g = 0;
		}
		else if ( g > 1 ){
			g = 1;
		}
		color[1] = g;

		// b
		velocity = velocities[ 2 ];
		float b = rend.material.color.b;
		b += velocity;
		if ( b < 0 ){
			b = 0;
		}
		else if ( b > 1 ){
			b = 1;
		}
		color[2] = b;


		this.rend.material.SetColor( "_Color", color );
	}
}
