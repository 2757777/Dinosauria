using UnityEngine;
using System.Collections;

public class MakeEnemy : MonoBehaviour {
    public GameObject dilopo, MakePoint, Pachy, Dimetrodon,NextEnemy;
   public float NextEnemyTimer;
    float timer = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > NextEnemyTimer)
        {
            int n = Random.Range(0, 10);
            if (n > 8)
            {
                NextEnemy = dilopo;
            }
            else if (n == 6 || n == 7||n==5)
            {
                NextEnemy = Dimetrodon;
            }
            else
                NextEnemy = Pachy;
           Instantiate(NextEnemy, new Vector2(MakePoint.transform.position.x, Random.Range(-1.5f, 0.8f)), Quaternion.identity);
            NextEnemyTimer = Random.Range(2, 6);
           timer = 0;
        }
	}
}
