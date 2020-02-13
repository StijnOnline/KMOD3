using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Astar {
    /// <summary>
    /// returns a list of Vector2Int positions which describes a path from the startPos to the endPos
    /// </summary>
    /// <param name="startPos"></param>
    /// <param name="endPos"></param>
    /// <param name="grid"></param>
    /// <returns></returns>
    public List<Vector2Int> FindPathToTarget(Vector2Int startPos, Vector2Int endPos, Cell[,] grid) {
        List<Node> openSet = new List<Node>();

        int width = grid.GetLength(0);
        int heigth = grid.GetLength(1);

        Node[,] nodes = new Node[width, heigth];
        //Start Node
        nodes[startPos.x, startPos.y] = new Node(startPos, null, 0, Heuristic(startPos, endPos));
        openSet.Add(nodes[startPos.x, startPos.y]);

        while(openSet.Count > 0) {
            Node currentNode = getLowestFScore(openSet);

            //Reached end ?-> Return path
            if(currentNode.position == endPos) {
                List<Vector2Int> result = new List<Vector2Int>();
                Node n = currentNode;
                while(n != null) {
                    result.Add(n.position);
                    n = n.parent;
                }
                result.Reverse();
                return result;
            }

            //Calculate Neighbours
            openSet.Remove(currentNode);
            for(int x = -1; x <= 1; x++) {
                for(int y = -1; y <= 1; y++) {

                    //Only Check direct neighbours
                    if(System.Math.Abs(x) == System.Math.Abs(y))
                        continue;

                    Vector2Int nextPos = currentNode.position + new Vector2Int(x, y);
                    if(nextPos.x < 0 || nextPos.x >= width || nextPos.y < 0 || nextPos.y >= heigth)
                        continue;

                    //Check for wall
                    int walls = (int)(grid[currentNode.position.x, currentNode.position.y].walls);
                    int bitPos = (x != 0 ? x + 1 : 0) + (y != 0 ? 2 - y : 0); //bitposition to check
                    if((walls & (1 << bitPos)) != 0) { //save a few if statements with bitwise logic
                        continue;
                    }

                    if(nodes[nextPos.x, nextPos.y] == null) { //New Node
                        nodes[nextPos.x, nextPos.y] = new Node(nextPos, null, currentNode.GScore + 1, Heuristic(nextPos, endPos));
                        nodes[nextPos.x, nextPos.y].parent = currentNode;
                        openSet.Add(nodes[nextPos.x, nextPos.y]);
                    } else { //Better score ?-> Overwrite
                        Node n = nodes[nextPos.x, nextPos.y];
                        if(currentNode.GScore + 1 + Heuristic(nextPos, endPos) < n.FScore) {
                            n.GScore = currentNode.GScore + 1;
                            n.HScore = Heuristic(nextPos, endPos);
                            n.parent = currentNode;
                            if(!openSet.Contains(n)) {
                                openSet.Add(n);
                            }
                        }
                    }
                }
            }
        }
        return null;
    }

    int Heuristic(Vector2Int currentPos, Vector2Int endPos) {
        //Manhattan Distance
        return System.Math.Abs(currentPos.x - endPos.x) + System.Math.Abs(currentPos.y - endPos.y);
    }

    Node getLowestFScore(List<Node> _set) {
        //Linq
        return _set.First(n1 => n1.FScore == _set.Min(n2 => n2.FScore));
    }

    /// <summary>
    /// This is the Node class you can use this class to store calculated FScores for the cells of the grid, you can leave this as it is
    /// </summary>
    public class Node {
        public Vector2Int position; //Position on the grid
        public Node parent; //Parent Node of this node

        public float FScore { //GScore + HScore
            get { return GScore + HScore; }
        }
        public int GScore; //Current Travelled Distance
        public int HScore; //Distance estimated based on Heuristic

        public Node() { }
        public Node(Vector2Int position, Node parent, int GScore, int HScore) {
            this.position = position;
            this.parent = parent;
            this.GScore = GScore;
            this.HScore = HScore;
        }
    }
}
