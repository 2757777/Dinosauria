using UnityEngine;
using System.Collections;

public class CleanPlayer : MonoBehaviour {
    public PlayerPro PlayerPro;
	// Use this for initialization
	void Start () {
        PlayerPro = GameObject.Find("PalyerManager").GetComponent<PlayerPro>();
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.tag = "DeadMan";
        PlayerPro.SendMessage("Count");
        Destroy(gameObject);
	}
}
