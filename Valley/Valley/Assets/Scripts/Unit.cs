using UnityEngine;
using System.Collections.Generic;

public class Unit : MonoBehaviour
{

    public Vector2C position;

    int moveSpeed = 1;

    public List<Node> currentPath; // Use to handle  pathfinding, list all node which unit must/will move.

    void Awake()
    {
        currentPath = new List<Node>();
    }

    void Update()
    {

        /* DEBUG */
        if (currentPath != null)
        {
            int _currNode_ = 0;

            while (_currNode_ < currentPath.Count -1)
            {
                Vector3 _start_ = currentPath[_currNode_].ConvertToVector3() + new Vector3(0, 1, 0);
                Vector3 _end_ = currentPath[_currNode_ + 1].ConvertToVector3() + new Vector3(0, 1, 0);
                Debug.DrawLine(_start_, _end_, Color.red);

                _currNode_++;
            }
        }
        

    }

    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameManager.Player.selectedUnit = this;
            Debug.Log("Selected unit is : " + gameObject.name);
        }
    }

    /// <summary>
    /// Take a hexa position, and try to reach it. Set the path of the unit.
    /// </summary>
    public void Move(Vector2C arrivalPos)
    {
        GameManager.Map.GeneratePathTo(position, arrivalPos, out currentPath);
    }

    //public void MoveNextTile()
    //{
    //    float remainingMovement = moveSpeed;
    //    while (remainingMovement > 0)
    //    {
    //        if (currentPath == null)
    //            return;

    //        // Get cost from current tile to next tile.
    //        remainingMovement -= map.CostToEnterTile(currentPath[0].x, currentPath[0].y, currentPath[1].x, currentPath[1].y);

    //        // Now grab the new first node and move us to that position
    //        tileX = currentPath[1].x;
    //        tileY = currentPath[1].y;
    //        transform.position = map.TileCoordToWorldCoord(tileX, tileY); // Updating our unity's position.

    //        // Remove the old current/first node from the path.
    //        currentPath.RemoveAt(0);

    //        if (currentPath.Count == 1) // We only have one tile left in the path, and that tile MUST be our ultimate destination -- and we are standing on it !
    //                                    // so let's just clear our pathfinding info.

    //        {
    //            currentPath = null;
    //        }
    //    }
    //}
}
