using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerPro : MonoBehaviour {
    public float ShooterMaxAttack, ShooterMixAttack, KnifeMaxAttack, KnifeMinAttack, KniferMaxHp, ShooterMaxHP;
    public Text ShooterAttack, ShooterHP, KniferAttack, KniferHp,ShooterCount,KniferCount;
    public  GameObject[] gos;
    //数
    public int Shotter, Knifer;
	// Use this for initialization
	void Awake () {
        Refresh();
        Count();
	}
	
	// Update is called once per frame
	void Update () {
        //人数
        //Count();
	}
    void Refresh()
    {
        //Shooterパラメータのテキスト
        ShooterAttack.text = "攻撃 " + (int)ShooterMixAttack + "-" + (int)ShooterMaxAttack;
        ShooterHP.text = "体力 " + (int)ShooterMaxHP;
        //Kniferパラメータのテキスト
        KniferAttack.text = "攻撃 " + (int)KnifeMinAttack + "-" + (int)KnifeMaxAttack;
        KniferHp.text = "体力 " + (int)KniferMaxHp;
    }
    void Count()
    {
        gos = GameObject.FindGameObjectsWithTag("Knifer");
        Knifer = gos.Length;
        KniferCount.text = Knifer + "人";
        gos = GameObject.FindGameObjectsWithTag("Shooter");
        Shotter = gos.Length;
        ShooterCount.text = Shotter + "人";
    }
}
