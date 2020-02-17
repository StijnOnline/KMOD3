using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class Grid : MonoBehaviour {


    [SerializeField] private Tilemap environment;
    [SerializeField] private Tilemap potentialFieldsMap;
    [SerializeField] private TileBase visualTile;
    [SerializeField] private static int gridSize;
    [SerializeField] private int setGridSize;
    [SerializeField] private static float[,] grid;
    [SerializeField] private List<Vector2Int> interestPoints;
    [SerializeField] private List<Vector2Int> obstaclePoints;

    [SerializeField] private string TARGET_NAME = "Target";
    [SerializeField] private float TARGET_STRENGTH;
    [SerializeField] private float TARGET_RANGE;

    [SerializeField] private string OBSTACLE_NAME = "Obstacle";
    [SerializeField] private float OBSTACLE_STRENGTH;
    [SerializeField] private float OBSTACLE_RANGE;

    void Start() {
        gridSize = setGridSize;

        Calculate();
    }

    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            Calculate();
        }
    }

    void Calculate() {
        CreateGrid();
        ScanEnvironment();
        CalculateGrid();


        SubtractEnvironment();

        NormalizeGrid();



        SpawnVisualGrid();
    }

    void CreateGrid() {

        grid = new float[gridSize, gridSize];

        for(int x = 0; x < grid.GetLength(0); x++) {
            for(int y = 0; y < grid.GetLength(0); y++) {
                grid[x, y] = -1;
            }
        }
    }


    void ScanEnvironment() {
        for(int x = 0; x < grid.GetLength(0); x++) {
            for(int y = 0; y < grid.GetLength(0); y++) {
                Vector2Int pos = new Vector2Int(x, y);
                string tileName = environment.GetTile((Vector3Int)pos)?.name;
                if(tileName == TARGET_NAME)
                    interestPoints.Add(pos);
                if(tileName == OBSTACLE_NAME)
                    obstaclePoints.Add(pos);
            }
        }
    }
    void CalculateGrid() {
        for(int x = 0; x < grid.GetLength(0); x++) {
            for(int y = 0; y < grid.GetLength(0); y++) {
                //grid[x, y] = 0;
                foreach(Vector2Int pos in interestPoints) {
                    float d = Vector2Int.Distance(new Vector2Int(x, y), pos);
                    grid[x, y] += TARGET_STRENGTH * (Mathf.Max(0f,TARGET_RANGE - d) / TARGET_RANGE);
                }
            }
        }
    }
    void SubtractEnvironment() {
        for(int x = 0; x < grid.GetLength(0); x++) {
            for(int y = 0; y < grid.GetLength(0); y++) {
                foreach(Vector2Int pos in obstaclePoints) {
                    grid[x, y] -= OBSTACLE_STRENGTH * Mathf.Max(0f,OBSTACLE_RANGE -((pos - new Vector2Int(x, y))).magnitude)/ OBSTACLE_RANGE;
                }
            }
        }
    }

    void NormalizeGrid() {
        float max = grid.Cast<float>().Max();
        for(int x = 0; x < grid.GetLength(0); x++) {
            for(int y = 0; y < grid.GetLength(0); y++) {
                grid[x, y] = grid[x, y] / max;
            }
        }
    }
    void SpawnVisualGrid() {

        for(int i = 0; i < gridSize * gridSize; i++) {
            Vector2Int pos = new Vector2Int(i % gridSize, i / gridSize);

            potentialFieldsMap.SetTile((Vector3Int)pos, visualTile);
            float val = grid[pos.x, pos.y];
            potentialFieldsMap.SetColor((Vector3Int)pos, new Color(val > 0 ? val : 0, 0, val < 0 ? -val : 0));
        }

    }

    public static Vector2 GetDirection(Vector2 pos) {
        Vector2Int gridPos = Vector2Int.FloorToInt(pos);

        Vector2Int bestDir = Vector2Int.zero;
        float max = float.MinValue;
        for(int x = -1; x <= 1; x++) {
            for(int y = -1; y <= 1; y++) {

                if(x == 0 && y == 0)
                    continue;

                Vector2Int nextPos = gridPos + new Vector2Int(x, y);
                if(nextPos.x < 0 || nextPos.x >= gridSize || nextPos.y < 0 || nextPos.y >= gridSize)
                    continue;

                if(grid[nextPos.x, nextPos.y] > max) {
                    max = grid[nextPos.x, nextPos.y];
                    bestDir = nextPos - gridPos;
                }

            }
        }

        return bestDir;
    }
}