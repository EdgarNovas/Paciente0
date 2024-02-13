using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Edgar
{

    public class Node 
    {
        public bool walkable;
        public Vector3 worldPosition;
        public int gridX;
        public int gridY;

        public int gCost;
        public int hCost;

        public Node parent;

        public Node(bool _walkable, Vector3 _worldPos, int gridX, int gridY)
        {
            walkable = _walkable;
            worldPosition = _worldPos;
            this.gridX = gridX;
            this.gridY = gridY;
        }

        public int fCost{
            get{
                return gCost + hCost;
            }
        }
    }
}
