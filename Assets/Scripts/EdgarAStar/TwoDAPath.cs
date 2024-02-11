using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Edgar;

public class TwoDAPath : MonoBehaviour
{
    public LayerMask unwalkableMask;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    Edgar.Node[,] grid;

    float nodeDiameter;
    int gridSizeX, gridSizeY;

    void Start()
    {
        
        nodeDiameter = nodeRadius * 2;
        
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        
        CreateGrid();
        
    }


    private void CreateGrid()
    {
        grid = new Edgar.Node[gridSizeX, gridSizeY];
        
        Vector2 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 -
            Vector3.up * gridWorldSize.y / 2; //En 3d Cambiar up por Forward

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector2.right * (x * nodeDiameter + nodeRadius) + Vector2.up * (y * nodeDiameter + nodeRadius);
                
                bool walkable = !(Physics2D.OverlapCircle(worldPoint, nodeRadius, unwalkableMask));

                grid[x, y] = new Edgar.Node(walkable, worldPoint);
                
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, gridWorldSize.y, 1));

        if (grid != null)
        {
            foreach (Edgar.Node n in grid)
            {
                Gizmos.color = n.walkable ? Color.white : Color.red;

                Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter - .1f));
            }
        }
    }

    

}
