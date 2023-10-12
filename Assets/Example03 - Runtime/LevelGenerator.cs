using Unity.AI.Navigation;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour 
{
	[SerializeField] private int width = 10;
	[SerializeField] private int height = 10;

	[SerializeField] private GameObject wall;
	[SerializeField] private GameObject player;

	[SerializeField] private NavMeshSurface surface;

	private bool playerSpawned = false;

	void Awake()
	{
		if (surface == null)
			surface = FindObjectOfType<NavMeshSurface>();
	}

	// Use this for initialization
	void Start () 
	{
		GenerateLevel();
		
		// Update Navmesh
		surface.BuildNavMesh();
	}
	
	// Create a grid based level
	void GenerateLevel()
	{
		// Loop over the grid
		for (int x = 0; x <= width; x+=2)
		{
			for (int y = 0; y <= height; y+=2)
			{
				// Should we place a wall?
				if (Random.value > .7f)
				{
					// Spawn a wall
					Vector3 pos = new Vector3(x - width / 2f, 1f, y - height / 2f);
					Instantiate(wall, pos, Quaternion.identity, transform);
				} 
				// Should we spawn a player?
				else if (!playerSpawned)
				{
					// Spawn the player
					Vector3 pos = new Vector3(x - width / 2f, 1.25f, y - height / 2f);
					Instantiate(player, pos, Quaternion.identity);
					playerSpawned = true;
				}
			}
		}
	}
}
