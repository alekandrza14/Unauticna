using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatMaze : MonoBehaviour
{
    mover _player;
    int cellSize = 10;
    public int width = 10;
    public int height = 10;
    public int depth = 10;
    public GameObject[] wallPrefab;
    public int seed;
    private int[,,] maze;
    private GameObject[,,] mazeobjs;
    private cellMaze[,,] mazecells;
    System.Random random;

    System.Random randomtime;


  void Start()
    {
        _player = mover.main();
        maze = new int[width, height, depth];
        mazeobjs = new GameObject[width, height, depth];
        mazecells = new cellMaze[width, height, depth];
        random = new System.Random((int)Globalprefs.GetIdPlanet() + seed); 
        randomtime = new System.Random((int)Globalprefs.GetIdPlanet() + seed + VarSave.GetInt("time", 0));
        GenerateMaze();
        DrawMaze();
        InvokeRepeating("CellUpadate",3,1);
    }
    private void CellUpadate()
    {
        for (int i =0;i<3;i++)
        {
            int x = randomtime.Next(0, width);
            int y = randomtime.Next(0, height);
            int z = randomtime.Next(0, depth);
            mazecells[x, y, z].randomSetActive(x + y * x + z * y * x+ VarSave.GetInt("time", 0));
        }
        randomtime = new System.Random((int)Globalprefs.GetIdPlanet() + seed + VarSave.LoadInt("time", 1));
    }

    void GenerateMaze()
    {
        // Initialize maze with walls
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int z = 0; z < depth; z++)
                {
                    maze[x, y, z] = random.Next(0, wallPrefab.Length);
                }
            }
        }

        // Recursive Backtracking algorithm to LoadTerraform the maze

        // TODO: Implement Recursive Backtracking algorithm here
    }

    void DrawMaze()
    {
        // Instantiate walls based on maze array
        int i = 0;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int z = 0; z < depth; z++)
                {
                      i++;
                      GameObject cell = Instantiate(wallPrefab[maze[x, y, z]], new Vector3(x * cellSize, y * cellSize, z * cellSize), Quaternion.identity);
                      cell.SetActive(true);
                      mazeobjs[x, y, z] = cell;
                      mazecells[x, y, z] = cell.GetComponent<cellMaze>(); mazecells[x, y, z].randomSetActive(i);
                }
            }
        }
    }
}
