using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
  public GameObject tile_prefab_;
  public List<Tile> tiles_;
  // Start is called before the first frame update
  void Start()
  {
    SpawnTiles (Vector3.zero, 10, 10);
  }

  // Update is called once per frame
  void Update()
  {
      
  }

  void SpawnTiles(Vector3 start_point, int n_rows, int n_cols){
    for(int y = 0; y < n_rows; y++){
      for(int x = 0; x < n_cols; x++){
        Vector3 spawn_point = start_point;
        spawn_point.x += x;
        spawn_point.z += y;
        GameObject tile_go = Instantiate(tile_prefab_, spawn_point, Quaternion.identity);
      }
    }
  }
}
