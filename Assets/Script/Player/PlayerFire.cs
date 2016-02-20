using UnityEngine;
using System.Collections;

public class PlayerFire : MonoBehaviour {
    public GameObject prefab, Muzzle;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
       // Debug.Log(Muzzle.GetComponent<SpriteRenderer>().sprite.name);
        //ある画像になった時弾が出る
        if (Muzzle.GetComponent<SpriteRenderer>().sprite.name == "OrangeMuzzle__006")
        {
            GameObject bullet = Instantiate(prefab, Muzzle.transform.position, transform.rotation) as GameObject;
          bullet.transform.parent = transform;
          bullet.transform.localScale = new Vector3(1, 1, 0);
        }

	}
}
