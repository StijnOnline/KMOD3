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

    const string TARGET_NAME = "Target";
    const string OBSTACLE_NAME = "Obstacle";

    void Start() {
        gridSize = setGridSize;
        grid = new float[gridSize, gridSize];
        FindInterestPoints();
        CalculateGrid();


        //optional
        NormalizeGrid();

        SubtractEnvironment();


        SpawnVisualGrid();

    }

    void Update() {

    }
    void FindInterestPoints() {
        interestPoints.Clear();
        for(int x = 0; x < grid.GetLength(0); x++) {
            for(int y = 0; y < grid.GetLength(0); y++) {
                Vector2Int pos = new Vector2Int(x, y);
                if(environment.GetTile((Vector3Int)pos)?.name == TARGET_NAME)
                    interestPoints.Add(pos);
            }
        }
    }
    void CalculateGrid() {
        for(int x = 0; x < grid.GetLength(0); x++) {
            for(int y = 0; y < grid.GetLength(0); y++) {
                grid[x, y] = 0;
                foreach(Vector2Int pos in interestPoints) {
                    grid[x, y] += Vector2Int.Distance(new Vector2Int(x, y), pos);
                }
            }
        }
    }
    void SubtractEnvironment() {
        for(int x = 0; x < grid.GetLength(0); x++) {
            for(int y = 0; y < grid.GetLength(0); y++) {
                Vector2Int pos = new Vector2Int(x, y);
                if(environment.GetTile((Vector3Int)pos)?.name == OBSTACLE_NAME)
                    grid[pos.x, pos.y] = Mathf.Infinity;
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

            potentialFieldsMap.SetColor((Vector3Int)pos, new Color(grid[pos.x, pos.y], 0, 0));
        }

    }

    public static Vector2 GetDirection(Vector2 pos) {
        Vector2Int gridPos = Vector2Int.FloorToInt(pos);

        Vector2Int bestDir = Vector2Int.zero;
        float min = float.MaxValue;
        for(int x = -1; x <= 1; x++) {
            for(int y = -1; y <= 1; y++) {

                if(x == 0 && y == 0)
                    continue;

                Vector2Int nextPos = gridPos + new Vector2Int(x, y);
                if(nextPos.x < 0 || nextPos.x >= gridSize || nextPos.y < 0 || nextPos.y >= gridSize)
                    continue;

                if(grid[nextPos.x, nextPos.y] < min) {
                    min = grid[nextPos.x, nextPos.y];
                    bestDir = nextPos - gridPos;
                }

            }
        }

        return bestDir;
    }
}