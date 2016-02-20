using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour {
  public  Text BarText, LevelText;
    int Level;
    float NowExp,MaxExp;
     Scrollbar ExpScrollbar;
  public PlayerPro PlayerPro;
	// Use this for initialization
	void Start () {
        ExpScrollbar = GetComponent<Scrollbar>();
        Level = 1;
        NowExp = 1;
        MaxExp = 10;
        RefreshExpBar();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void ExpPlus()
    {
        NowExp++;
        RefreshExpBar();
    }
    void RefreshExpBar()
    {
        if (NowExp == MaxExp)
        {
            NowExp = 1;
            Level++;
            MaxExp +=(int)Mathf.Pow(Level, 0.8f) * 7;
            PlayerPro.KniferMaxHp +=Mathf.Pow(Level, 0.8f);
            PlayerPro.ShooterMaxHP += Mathf.Pow(Level, 0.4f);
            PlayerPro.SendMessage("Refresh");
        }
        ExpScrollbar.size = NowExp / MaxExp;
        BarText.text = NowExp + "/" + MaxExp;
        LevelText.text = "LV." + Level;

    }
}
