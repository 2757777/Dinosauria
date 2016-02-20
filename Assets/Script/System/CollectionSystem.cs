using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollectionSystem : MonoBehaviour {
   public string[] GetCard;
    public GameObject[] Card;
   int Length;
	// Use this for initialization
	void Start () {
        Length = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void GetOne(string Name)
    {
        GetCard[Length] = Name;
        Length++;
    }
    void PhotoShow()
    {
        for (int i = 0; i < Length; i++)
        {
            if (GetCard[i] != null)
            {
                GameObject CollectionButton = GameObject.Find(GetCard[i]);
               CollectionButton.GetComponent<Button>().interactable = true;
               CollectionButton.transform.FindChild("LockImage").gameObject.GetComponentInChildren<Image>().enabled = false; 
            }
        }
    }
    void GivePrefab(Vector3 DeadPostion)
    {
      int s=Random.Range(0,Card.Length);
      GameObject Ca=Instantiate(Card[s], DeadPostion, Quaternion.identity)as GameObject;
      Ca.name = Card[s].name;
    }
}
