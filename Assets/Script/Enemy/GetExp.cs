using UnityEngine;
using System.Collections;

public class GetExp : MonoBehaviour {
    GameObject ExpBar;
	// Use this for initialization
	void Start () {
        ExpBar = GameObject.Find("ExpBar");
        ExpBar.SendMessage("ExpPlus");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
