using UnityEngine;
using System.Collections;

public class GetCard : MonoBehaviour {
	// Use this for initialization
    CollectionSystem CardSystem;
	void Start () {
        CardSystem = GameObject.Find("GameManager").GetComponent<CollectionSystem>();
        CardSystem.SendMessageUpwards("GivePrefab", transform.position);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
