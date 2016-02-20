using UnityEngine;
using System.Collections;

public class KnifeAttack : MonoBehaviour {
    public bool Attack;
    PlayerPro PlayerManager;
    float MaxAttack, MinAttack, Damage;

	// Use this for initialization
	void Start () {
        PlayerManager = GameObject.Find("PalyerManager").GetComponent<PlayerPro>();

	}
	
	// Update is called once per frame
	void Update () {
        if (Attack&&GetComponent<PlayerMove>().target!=null)
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2(GetComponent<PlayerMove>().target.GetComponent<EnemyMove>().KnifePosition.x, gameObject.transform.position.y),10* Time.deltaTime);
           GetComponent<PlayerMove>().target.GetComponent<EnemyMove>().SendMessageUpwards("ChangeDirection", transform.gameObject);
           //最新の攻撃力をもらえる
           MaxAttack = PlayerManager.ShooterMaxAttack;
           MinAttack = PlayerManager.ShooterMixAttack;

            Damage = Random.Range(MinAttack, MaxAttack);
            //ダメージを与える
            GetComponent<PlayerMove>().target.GetComponent<EnemyPro>().SendMessageUpwards("Damage", Damage);
        }
	}
}
