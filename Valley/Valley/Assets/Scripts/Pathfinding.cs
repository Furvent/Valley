//using UnityEngine;
//using System.Collections;

//public class Pathfinding
//{

//    public void GeneratePathTo(int x, int y)
//    {

//        /*// Store coord in unit;
//        selectedUnit.GetComponent<Unit>().tileX = x;
//        selectedUnit.GetComponent<Unit>().tileY = y;

//        //Move it;
//        selectedUnit.transform.position = new Vector3(x, y, 0);
//        */

//        // Clear out our unit's old path.
//        selectedUnit.GetComponent<Unit>().currentPath = null;

//        if (UnitCantEnterTile(x, y) == false)
//        {
//            // We probably clicked on a mountain or something, so just quit out.
//            return;
//        }

//        Dictionary<Node, float> dist = new Dictionary<Node, float>();
//        Dictionary<Node, Node> prev = new Dictionary<Node, Node>();

//        //Setup the "Q", the list of nodes we haven't checked yet.
//        List<Node> unvisited = new List<Node>();

//        Node source = graph[selectedUnit.GetComponent<Unit>().tileX,
//                            selectedUnit.GetComponent<Unit>().tileY];

//        Node target = graph[x, y];

//        dist[source] = 0;
//        prev[source] = null;

//        // Initialize everything to have INFINITY distance, since we don't know any better right now.
//        // Also it's possible that some nodes CAN'T be reached from the source, wich would make INFINITY a reasonable value.
//        foreach (Node v in graph)
//        {
//            if (v != source)
//            {
//                dist[v] = Mathf.Infinity;
//                prev[v] = null;
//            }

//            unvisited.Add(v);
//        }

//        while (unvisited.Count > 0)
//        {
//            // This is not fast ! But it's short ! Consider having "unvisited"  be a priority queue or some other self-sorting, optimized data structure.
//            //Node u = unvisited.OrderBy(n => dist[n]).First();

//            // "u" is going to be the unvisited node with the smallest distance.
//            Node u = null;

//            foreach (Node possibleU in unvisited)
//            {
//                if (u == null || dist[possibleU] < dist[u])
//                {
//                    u = possibleU;
//                }
//            }

//            if (u == target)
//            {
//                break; // Exit the while loop !
//            }

//            unvisited.Remove(u);

//            foreach (Node v in u.neighbours)
//            {
//                //float alt = dist[u] + u.DistanceTo(v);
//                float alt = dist[u] + CostToEnterTile(u.x, u.y, v.x, v.y);
//                if (alt < dist[v])
//                {
//                    dist[v] = alt;
//                    prev[v] = u;
//                }
//            }
//        }

//        // If we get there, the either we found the shortest route to our target, or there is no route at ALL to our target.
//        if (prev[target] == null)
//        {
//            // No route between our target and the source.
//            return;
//        }

//        List<Node> currentPath = new List<Node>();
//        Node curr = target;

//        // Step through the "prev" chain and add it to our path.
//        while (curr != null)
//        {
//            currentPath.Add(curr);
//            curr = prev[curr];
//        }

//        // Right now, currentPath describes a route from our target to our source, so we need to invert it.
//        currentPath.Reverse();
//        selectedUnit.GetComponent<Unit>().currentPath = currentPath;
//    }
//}
