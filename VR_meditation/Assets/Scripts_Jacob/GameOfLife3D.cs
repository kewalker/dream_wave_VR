using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife3D : MonoBehaviour {

	int[,,] grid;
	GameObject[,,] object_grid;
	int time;
	int change = 60;

	int space = 2;
	public GameObject cuber; 

	// Use this for initialization
	void Start () {
		int x = 10;
		int y = 10;
		int z = 10;

		cuber = GameObject.FindGameObjectWithTag( "why" );

		grid = new int[x, y, z];
		object_grid = new GameObject[x, y, z];
		
		for( int i = 0 ; i < grid.GetLength(0) ; i++ ){
			for( int j = 0 ; j < grid.GetLength(1) ; j++ ){
				for( int k = 0 ; k < grid.GetLength(2) ; k++ ){

					int state = Random.Range(0, 2);
					grid[i , j, k] = state;

					if( state == 1 ){
						object_grid[i,j,k] = Instantiate( cuber, new Vector3(i*space, j*space, k*space), Quaternion.identity);
					}
				}
			}
		}

		string str = "";
		for( int i = 0 ; i < grid.GetLength(0) ; i++ ){
			for( int j = 0 ; j < grid.GetLength(1) ; j++ ){
				for( int k = 0 ; k < grid.GetLength(1) ; k++ ){
					str += grid[i, j, k] + ", ";
				}

				str += "\n";
			}
			str += "\n";
		}
		print( str );
		print( "HIII" );

		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if( time % change == 0 ){
			UpdateGrid();
		}

		time ++;
	}

	void UpdateGrid (){
		int x = grid.GetLength(0);
		int y = grid.GetLength(1);
		int z = grid.GetLength(2);
		int[,,] new_grid = new int[x, y, z];
		//int[,,] new_grid = new int[grid.GetLength(0), grid.GetLength(1), grid.GetLength(2)];

		for( int i = 0 ; i < grid.GetLength(0) ; i++ ){
			for( int j = 0 ; j < grid.GetLength(1) ; j++ ){
				for( int k = 0 ; k < grid.GetLength(2) ; k++ ){
					int state = grid[i,j,k];
					int count = 0;

					if ( i > 0 && grid[i-1,j,k] == 1 ){
						count ++;
					}
					if ( j > 0 && grid[i,j-1,k] == 1 ){
						count ++;
					}
					if ( k > 0 && grid[i,j,k-1] == 1 ){
						count ++;
					}
					if( i < grid.GetLength(0)-1 && grid[i+1,j,k] == 1 ){
						count ++;
					}
					if( j < grid.GetLength(1)-1 && grid[i,j+1,k] == 1 ){
						count ++;
					}
					if( k < grid.GetLength(2)-1 && grid[i,j,k+1] == 1 ){
						count ++;
					}
					if ( i > 0 && j > 0 && grid[i-1,j-1,k] == 1 ){
						count ++;
					}
					if ( i > 0 && k > 0 && grid[i-1,j,k-1] == 1 ){
						count ++;
					}
					if ( i > 0 && j < grid.GetLength(1)-1 && grid[i-1,j+1,k] == 1 ){
						count ++;
					}
					if ( i > 0 && k < grid.GetLength(2)-1 && grid[i-1,j,k+1] == 1 ){
						count ++;
					}
					if ( i < grid.GetLength(0)-1 && j > 0 && grid[i+1,j-1,k] == 1 ){
						count ++;
					}
					if ( i < grid.GetLength(0)-1 && k > 0 && grid[i+1,j,k-1] == 1 ){
						count ++;
					}
					if ( i < grid.GetLength(0)-1 && j < grid.GetLength(1)-1 && grid[i+1,j+1,k] == 1 ){
						count ++;
					}
					if ( i < grid.GetLength(0)-1 && k < grid.GetLength(2)-1 && grid[i+1,j,k+1] == 1 ){
						count ++;
					}
					if ( j > 0 && k > 0 && grid[i,j-1,k-1] == 1 ){
						count ++;
					}
					if ( j > 0 && k < grid.GetLength(2)-1 && grid[i,j-1,k+1] == 1 ){
						count ++;
					}
					if ( j < grid.GetLength(1)-1 && k > 0 && grid[i,j+1,k-1] == 1 ){
						count ++;
					}
					if ( j < grid.GetLength(1)-1 && k < grid.GetLength(2)-1 && grid[i,j+1,k+1] == 1 ){
						count ++;
					}
					if( i > 0 && j > 0 && k > 0 && grid[i-1,j-1,k-1] == 1 ){
						count ++;
					}
					if( i > 0 && j > 0 && k < grid.GetLength(2)-1 && grid[i-1,j-1,k+1] == 1 ){
						count ++;
					}
					if( i > 0 && j < grid.GetLength(1)-1 && k > 0 && grid[i-1,j+1,k-1] == 1 ){
						count ++;
					}
					if( i > 0 && j < grid.GetLength(1)-1 && k < grid.GetLength(2)-1 && grid[i-1,j+1,k+1] == 1 ){
						count ++;
					}
					if( i < grid.GetLength(0)-1 && j > 0 && k > 0 && grid[i+1,j-1,k-1] == 1 ){
						count ++;
					}
					if( i < grid.GetLength(0)-1 && j > 0 && k < grid.GetLength(2)-1 && grid[i+1,j-1,k+1] == 1 ){
						count ++;
					}
					if( i < grid.GetLength(0)-1 && j < grid.GetLength(1)-1 && k > 0 && grid[i+1,j+1,k-1] == 1 ){
						count ++;
					}
					if( i < grid.GetLength(0)-1 && j < grid.GetLength(1)-1 && k < grid.GetLength(2)-1 && grid[i+1,j+1,k+1] == 1 ){
						count ++;
					}

					if( state == 0 && count == 3 ){
						new_grid[i,j,k] = 1;
					}
					else if ( state == 1 && count >= 2 && count <= 3 ){
						new_grid[i,j,k] = 1;
					}
					else{
						new_grid[i,j,k] = 0;
					}
				}
			}
		}
	
		

		for( int i = 0 ; i < grid.GetLength(0) ; i++ ){
			for( int j = 0 ; j < grid.GetLength(1) ; j++ ){
				for( int k = 0 ; k < grid.GetLength(2) ; k++ ){
					if( grid[i,j,k] == 1 ){
						Destroy( object_grid[i,j,k] );
					}
				}
			}
		}

		grid = new_grid;

		for( int i = 0 ; i < grid.GetLength(0) ; i++ ){
			for( int j = 0 ; j < grid.GetLength(1) ; j++ ){
				for( int k = 0 ; k < grid.GetLength(2) ; k++ ){
					if( grid[i,j,k] == 1 ){
						object_grid[i,j,k] = Instantiate( cuber, new Vector3(i*space, j*space, k*space), Quaternion.identity);
					}
				}
			}
		}

		

	}
}
