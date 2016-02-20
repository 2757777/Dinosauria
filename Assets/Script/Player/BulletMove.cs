using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {
    public bool RightShoot;
    int direction;
   public GameObject MidAirExplo;
    PlayerPro PlayerManager;
   float MaxAttack, MinAttack,Damage;
   float timer=0;
    
        // Use this for initialization
	void Start () {
        PlayerManager = GameObject.Find("PalyerManager").GetComponent<PlayerPro>();
        //弾の向き
        if (transform.parent.gameObject.GetComponentInParent<Transform>().rotation.y!=0)
        {
            direction = -1;
        }
        else
            direction = 1;
	}
	
	// Update is called once per frame
	void Update () {
        //弾移動
        transform.position = new Vector2(transform.position.x + 0.1f*direction, transform.position.y);
        //タイムリミット
        timer += Time.deltaTime;
        if (timer > 3)
        {
            Destroy(gameObject);
        }
	}
    void OnTriggerEnter2D(Collider2D other) {
        //ターゲットと物理衝突した後
        if (other.gameObject == transform.parent.gameObject.GetComponent<PlayerMove>().target)
        {   //敵の向き判断
            other.gameObject.GetComponent<EnemyMove>().SendMessageUpwards("ChangeDirection", transform.parent.gameObject);
            //最新の攻撃力をもらえる
            MaxAttack = PlayerManager.ShooterMaxAttack;
            MinAttack = PlayerManager.ShooterMixAttack;

            //ダメージを与える
            if (timer < 0.1f)
            {
                Damage = Random.Range(MinAttack, MaxAttack) / 2;
            }
            else
                Damage = Random.Range(MinAttack, MaxAttack);
            other.GetComponent<EnemyPro>().SendMessageUpwards("Damage",Damage);
            //花火が出る
            Instantiate(MidAirExplo, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

    }
}
