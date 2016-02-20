using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
    float MaxAttack, MinAttack;
    public bool Attack;
	// Use this for initialization
	void Start () {
        MaxAttack = GetComponent<EnemyPro>().MaxAttack;
        MinAttack = GetComponent<EnemyPro>().MinAttack;
	}
	
	// Update is called once per frame
	void Update () {
        //アニメーションと合わせて攻撃する
        if (Attack&&GetComponent<EnemyMove>().TargetPlayer!=null)
        {
            GetComponent<EnemyMove>().TargetPlayer.GetComponent<PersonalPro>().SendMessageUpwards("Damage", Random.Range(MinAttack, MaxAttack));

        }
	}
}
