using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MakeNewPlayer : MonoBehaviour {
    //両者のプレハブ
    public GameObject Shooter, Knifer;
    //今の人数スクリプト
    public PlayerPro PlayerPro;
    //必要の肉
    public float  NeedMeat;
    //必要の肉のテキスト
    public Text KniferNeedMeatText, ShooterNeedMeatText;
    //今の肉量のスクリプト
    MeatSystem MeatSystem ;
    //増員ポタン
    public Button ShooterButton, KniferButton;
	// Use this for initialization
	void Start () {
        MeatSystem = GetComponent<MeatSystem>();
        RefreshNeedMeat();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void MakeShooter()
    {
        Instantiate(Shooter, new Vector2(Random.Range(-2.2f, 2.4f), 2f), Quaternion.identity);
        MeatSystem.HaveMeat -= NeedMeat;
        PlayerPro.SendMessage("Count");
        RefreshNeedMeat();
        MeatSystem.SendMessage("RefreshMeat");
    }
    void MakeKnifer()
    {
        Instantiate(Knifer, new Vector2(Random.Range(-2.2f, 2.4f), 2f), Quaternion.identity);
        MeatSystem.HaveMeat -= NeedMeat;
        PlayerPro.SendMessage("Count");
        RefreshNeedMeat();
        MeatSystem.SendMessage("RefreshMeat");
    }
    void RefreshNeedMeat()
    {
        NeedMeat = (int)Mathf.Pow(PlayerPro.Shotter+PlayerPro.Knifer, 1.2f) * 5;
        KniferNeedMeatText.text = NeedMeat + "";
        ShooterNeedMeatText.text = NeedMeat + "";
        if (NeedMeat > MeatSystem.HaveMeat)
        {
            ShooterButton.interactable = false;
            KniferButton.interactable = false;
            OpenButton();
        }
    }
    void OpenButton()
    {
        if (NeedMeat > MeatSystem.HaveMeat)
        {
            ShooterButton.interactable = false;
            KniferButton.interactable = false;
        }
        else
        {
                   
            ShooterButton.interactable = true;
        KniferButton.interactable = true;
        }
    }
    }

