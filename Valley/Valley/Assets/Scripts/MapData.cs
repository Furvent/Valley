using UnityEngine;
using System.Collections.Generic;

public class MapData //: MonoBehaviour
{
    private int _radius;
    public int Radius { get { return _radius; } private set { } }

    private int _raw; 
    private int _col;

    public Dictionary<Vector2, Hexa> mapHexaData;

    public MapData(int rad)
    {
        _radius = rad;
        _raw = (rad * 2) + 1;
        _col = (rad * 2) + 1;

        mapHexaData = new Dictionary<Vector2, Hexa>();

        CreateMapTileData();
    }

    private void CreateMapTileData()
    {
        int __correcteurNegatif = 0;
        int __correcteurPositif = _radius;
        for (int r = -_radius; r <= _radius ; r++)
        {
            Debug.Log("Current Raw is : " + r);
            for (int q = -_radius; q <= _radius; q++)
            {
                if ( (r <= 0 && q >= __correcteurNegatif)
                  || (r > 0 && q < __correcteurPositif))
                {
                    Debug.Log("Create hexa : " + r + "/" + q);
                    //CreateHexagon(r, q);
                    GameObject obj = new GameObject("Hexagone r" + r.ToString() + ":q" + q.ToString() );
                    obj.transform.position = new Vector3(r, 0f, q);
                    mapHexaData.Add(new Vector2(r, q), obj.AddComponent<Hexa>());
                    
                }

                /*else if (r > 0 && q < __correcteurPositif)
                {
                    Debug.Log("Create hexa : " + r + "/" + q);
                }*/

                else
                {
                    //mapIndex[r, q] = null;
                }
            }

            __correcteurNegatif--;

            if (r > 0)
            {
                __correcteurPositif--;
                //Debug.Log(__correcteurPositif);
            }
            
        }
    }

    private void CreateHexagon(int raw, int col)
    {

    }
}
