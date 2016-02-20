using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpenButterss : MonoBehaviour {
   public GameObject ButtressBoard;
   bool Up;
	// Use this for initialization
	void Start () {
        Up = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Up && ButtressBoard.transform.localPosition.y < -510)
        {
            ButtressBoard.transform.localPosition = new Vector2(ButtressBoard.transform.localPosition.x, ButtressBoard.transform.localPosition.y + 10f);
        }
        else if (Up == false && ButtressBoard.transform.localPosition.y > -793)
        {
            ButtressBoard.transform.localPosition = new Vector2(ButtressBoard.transform.localPosition.x, ButtressBoard.transform.localPosition.y - 10f);

        }
	}
    void OnClick()
    {
        Up = !Up;
    }
}
