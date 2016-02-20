using UnityEngine;
using System.Collections;

public class EnemyState : MonoBehaviour {
    public enum States { Walk, Run, Dead,Attack};
    public States State;
	// Use this for initialization
	void Start () {
        State = States.Walk;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
