using UnityEngine;
using System.Collections;

public class MeetMove : MonoBehaviour {
     GameObject FinalPosition;
     MeatSystem MeetSystem;
	// Use this for initialization
	void Start () {
        FinalPosition = GameObject.Find("MeetFinalPosition");
        MeetSystem = GameObject.Find("GameManager").GetComponent<MeatSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, FinalPosition.transform.position, Time.deltaTime*8);
        if (gameObject.transform.position == FinalPosition.transform.position)
        {
            MeetSystem.HaveMeat++;
            MeetSystem.SendMessage("RefreshMeat");
            Destroy(this.gameObject);
        }
	}
}
