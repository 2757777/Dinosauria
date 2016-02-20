using UnityEngine;
using System.Collections;

public class PersonalPro : MonoBehaviour {
    public enum Kind { Shooter, Knife}
    public Kind kind;
    public PlayerPro PlayerPro;
    public float ThisMaxHp,ThisNowHp;
    public Animator animator;
    public AnimatorStateInfo stateInfo;

	// Use this for initialization
	void Start () {
        PlayerPro = GameObject.Find("PalyerManager").GetComponent<PlayerPro>();
        GetProData();
        ThisNowHp = ThisMaxHp;
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
	}
    void GetProData()
    {//最大hpをgetする
        if (kind == Kind.Knife)
            ThisMaxHp = PlayerPro.KniferMaxHp;
        else
            if (kind == Kind.Shooter)
                ThisMaxHp = PlayerPro.ShooterMaxHP;
    }
    void Damage(float damage)
    {
        ThisNowHp -= damage;
        if (ThisNowHp < 0)
        {
            GetComponent<PlayerMove>().animator.Play("Dead");
        }
    }
}
