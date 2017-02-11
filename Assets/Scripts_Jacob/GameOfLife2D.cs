using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife2D : MonoBehaviour {

	int[,] grid;
	GameObject[,] object_grid;
	int time;
	int change = 120;

	int[][] adjacents = new int[8][];

	int space = 2;

	public GameObject cuber; 

	// Use this for initialization
	void Start ()
	{
		int width = 10;
		int height = 10;

		cuber = GameObject.FindGameObjectWithTag( "why" );

		grid = new int[width, height];
		object_grid = new GameObject[width, height];
		
		for( int i = 0 ; i < grid.GetLength(0) ; i++ )
		{
			for( int j = 0 ; j < grid.GetLength(1) ; j++ )
			{
				int state = Random.Range(0, 2);
				grid[i , j] = state;

				if( state == 1 )
				{
					object_grid[i,j] = Instantiate( cuber, new Vector3(i*space, j*space, 0), Quaternion.identity);
				}
			}
		}

		int[] adjacent_x = {-1,0,1};
		int[] adjacent_y = {-1,0,1};
		int adjacent_count = 0;

		for( int x = 0 ; x < adjacent_x.GetLength(0) ; x ++ )
		{
			for ( int y = 0 ; y < adjacent_y.GetLength(0) ; y ++ ) 
			{
				if( adjacent_x[x] != 0 || adjacent_y[y] != 0 )
				{
					adjacents[adjacent_count] = new int[] {adjacent_x[x] , adjacent_y[y]};
					adjacent_count ++;
				}
			}
		}

		/*for( int i = 0 ; i < adjacents.GetLength(0) ; i++ )
		{
			print( i );
			print( adjacents[i][0] + " " + adjacents[i][1] );
		}
		*/

		time = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( time % change == 0 )
		{
			UpdateGrid();
		}
		time ++;
	}

	void UpdateGrid ()
	{
		int width = grid.GetLength(0);
		int height = grid.GetLength(1);
		int[,] new_grid = new int[width, height];

		for( int i = 0 ; i < grid.GetLength(0) ; i++ )
		{
			for( int j = 0 ; j < grid.GetLength(1) ; j++ )
			{
				int state = grid[i,j];
				int count = 0;

				for( int ai = 0 ; ai < adjacents.GetLength(0) ; ai++ )
				{
					try 
					{
						if ( grid[i + adjacents[ai][0], j + adjacents[ai][1]] == 1 )
						{
							count ++;
						}
					}
					catch
					{
					}
				}
				
				/*
				if( i > 0 && grid[i-1,j] == 1 )
				{
					count ++;
				}
				if( j > 0 && grid[i,j-1] == 1 )
				{
					count ++;
				}
				if( i < grid.GetLength(0)-1 && grid[i+1,j] == 1 )
				{
					count ++;
				}
				if( j < grid.GetLength(1)-1 && grid[i,j+1] == 1 )
				{
					count ++;
				}
				if( i > 0 && j > 0 && grid[i-1,j-1] == 1 )
				{
					count ++;
				}
				if( i > 0 && j < grid.GetLength(1)-1 && grid[i-1,j+1] == 1 )
				{
					count ++;
				}
				if( i < grid.GetLength(0)-1 && j > 0 && grid[i+1,j-1] == 1 )
				{
					count ++;
				}
				if( i < grid.GetLength(0)-1 && j < grid.GetLength(1)-1 && grid[i+1,j+1] == 1 )
				{
					count ++;
				}
				*/

				if( state == 0 && count == 3 )
				{
					new_grid[i,j] = 1;
				}
				else if ( state == 1 && count >= 2 && count <= 3 )
				{
					new_grid[i,j] = 1;
				}
				else
				{
					new_grid[i,j] = 0;
				}
			}
		}

		for( int i = 0 ; i < grid.GetLength(0) ; i++ )
		{
			for( int j = 0 ; j < grid.GetLength(1) ; j++ )
			{
				if( grid[i,j] == 1 ){
					Destroy( object_grid[i,j] );
				}
			}
		}
		
		grid = new_grid;

		for( int i = 0 ; i < grid.GetLength(0) ; i++ )
		{
			for( int j = 0 ; j < grid.GetLength(1) ; j++ )
			{
				if( grid[i,j] == 1 )
				{
					object_grid[i,j] = Instantiate( cuber, new Vector3(i*space, j*space, 0), Quaternion.identity);
				}
			}
		}

		string str = "";
		for( int i = 0 ; i < grid.GetLength(0) ; i++ )
		{
			for( int j = 0 ; j < grid.GetLength(1) ; j++ )
			{
				str += grid[i, j] + ", ";
			}
			str += "\n";
		}
		print( str );
	}

}
