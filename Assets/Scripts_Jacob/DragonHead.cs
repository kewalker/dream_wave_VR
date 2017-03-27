using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHead : MonoBehaviour {
	float velocity;
	Vector3 direction;

	int body_segments_number;
	GameObject[] body_segments;
	int segment_space;

	List<Vector3> history;

	public GameObject segment;

	int time = 0;

	float angle_change;

	// Use this for initialization
	void Start () {

		transform.position = new Vector3(0, 0, 0);
		velocity = 2f;
		direction = new Vector3(1, 0, 0);

		angle_change = .01f;

		body_segments_number = 5;
		segment_space = 32;
		body_segments = new GameObject[body_segments_number];
		for( int i = 0 ; i < body_segments_number ; i ++ ){
			body_segments[i] = Instantiate( segment, transform.position, Quaternion.identity );
		}

		history = new List<Vector3>();//[body_segments_number * segment_space];
		for( int i = 0 ; i < body_segments_number * segment_space + 1 ; i ++ ){
			history.Add(transform.position);
		}
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(direction * velocity * Time.deltaTime);
		transform.rotation = Quaternion.LookRotation( direction );
		
		history.Insert( 0, transform.position );
		history.RemoveAt( history.Count-1 );

		direction = direction + new Vector3(Random.Range(-angle_change,angle_change), Random.Range(-angle_change,angle_change), Random.Range(-angle_change,angle_change));
		direction.Normalize();

		print( direction );
		/*for( int i = history.Count ; i > 0 ; i -- ){
			history[i] = history[i-1];
			print( i );
		}
		history[0] = position;*/

		/*string str = "[";
		for( int i = 0 ; i < history.GetLength(0) ; i ++ ){
			str += history[i];
			str += ",";
		}
		str += "]";
		print( str );*/

		//print( history.Count );
		//print( history[ 0 ] );
		for( int i = 0 ; i < body_segments.GetLength(0) ; i ++ ){
			body_segments[i].transform.position = history[ (i+1) * segment_space ];
			
		}
		
	}
}
