using UnityEngine;
using System.Collections;

public class GetMeat : MonoBehaviour {
   public GameObject MeatPrefab;
	// Use this for initialization
	void Start () {
      int  m = Random.Range(0,(int) (GetComponent<EnemyPro>().EnemyLevel*10));
      for (int i = 0; i < m; i++)
      {
          Instantiate(MeatPrefab, new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f)), Quaternion.identity);
      }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
