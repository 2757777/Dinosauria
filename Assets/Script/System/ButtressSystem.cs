using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtressSystem : MonoBehaviour {
    //必要の肉
    public float KnifeNeedMeat, ShootNeedMeat;
    //必要の肉のテキスト
    public Text KnifeNeedMeatText, ShootNeedMeatText;
    //今の段階
    public float KnifeLevel, ShootLevel;
    //今の肉量
     MeatSystem MeatSystem;
    //PlayerPro
    public PlayerPro PlayerPro;
    //ブーストボタン
    public Button KnifeUp, ShootUp;
	// Use this for initialization
	void Start () {
        //初期化
        KnifeLevel = ShootLevel = 1;
        KnifeNeedMeat = ShootNeedMeat = 5;
        KnifeNeedMeatText.text = KnifeNeedMeat + "";
        ShootNeedMeatText.text = ShootNeedMeat + "";
        MeatSystem = GetComponent<MeatSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void PlusKnife()
    {
        MeatSystem.HaveMeat -= KnifeNeedMeat;
        PlayerPro.KnifeMaxAttack += Mathf.Pow(KnifeLevel, 0.3f);
        PlayerPro.KnifeMinAttack += Mathf.Pow(KnifeLevel, 0.1f);
        KnifeNeedMeat +=(int) Mathf.Pow(KnifeLevel, 0.8f);
        KnifeLevel++;
        PlayerPro.SendMessage("Refresh");
        KnifeNeedMeatText.text = KnifeNeedMeat + "";
        OpenButton();
        MeatSystem.SendMessage("RefreshMeat");

    }
    void PlusShoot()
    {
        MeatSystem.HaveMeat -= ShootNeedMeat;
        PlayerPro.ShooterMaxAttack += Mathf.Pow(ShootLevel, 0.4f);
        PlayerPro.ShooterMixAttack += Mathf.Pow(ShootLevel, 0.2f);
        ShootNeedMeat += (int)Mathf.Pow(ShootLevel, 0.82f);
        ShootLevel++;
        PlayerPro.SendMessage("Refresh");
        ShootNeedMeatText.text = ShootNeedMeat + "";
        OpenButton();
        MeatSystem.SendMessage("RefreshMeat");
    }
    void OpenButton()
    {
        if (ShootNeedMeat <= MeatSystem.HaveMeat)
        {
            ShootUp.interactable = true;
        }else
            ShootUp.interactable = false;

        if (KnifeNeedMeat <= MeatSystem.HaveMeat)
        {
            KnifeUp.interactable = true;
        }
        else
            KnifeUp.interactable = false;

    }
}
