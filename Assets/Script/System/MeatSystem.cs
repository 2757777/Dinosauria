using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MeatSystem : MonoBehaviour {
    public float HaveMeat;
    //肉のてき
    public Text MeatText;
    float timer = 0;
	// Use this for initialization
	void Start () {
        RefreshMeat();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 15)
        {
            HaveMeat++;
            RefreshMeat();
            timer = 0;
        }
	}
    void RefreshMeat()
    {
        MeatText.text = HaveMeat + "";
        GetComponent<ButtressSystem>().SendMessage("OpenButton");
        GetComponent<MakeNewPlayer>().SendMessage("OpenButton");
    }
}
