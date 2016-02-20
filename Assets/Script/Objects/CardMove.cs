using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardMove : MonoBehaviour {
    GameObject FinalPosition;
  public   CollectionSystem CollectionSystem;
   string Name;
	// Use this for initialization
	void Start () {
        Name = name + "Button";
        FinalPosition = GameObject.Find("CardPosition");
        CollectionSystem = GameObject.Find("CardPosition").GetComponent<CollectionSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, FinalPosition.transform.position, Time.deltaTime*5);
        if (gameObject.transform.position == FinalPosition.transform.position)
        {
            CollectionSystem.SendMessageUpwards("GetOne", Name);
            Destroy(this.gameObject);
        }
	}
	}

