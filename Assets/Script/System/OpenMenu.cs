using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour {
    public GameObject PausePanel;
    bool Open;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
    void OnClick()
    {
        Open = !Open;
        PausePanel.SetActive(Open);
        if (Open)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
