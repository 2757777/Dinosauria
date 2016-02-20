using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
   public Animator animator;
    private Camera _mainCamera;
    public Vector3 ShooterPosition, KnifePosition;
    public bool GoRight;
    int direction=1;
    public bool NoDamage;
    public GameObject TargetPlayer;
    public float WalkSpeed,RunSpeed;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        //はじめの状態
        animator.SetBool("Walk", true);
        //方向判断
        int n = Random.Range(0, 2);
        if (n == 1)
            transform.position = new Vector2(transform.position.x * -1, transform.position.y);
        if (transform.position.x < 0)
        {
            transform.rotation=new Quaternion(0,0,0,0);
            GoRight = true;
        }
        else
        {
            transform.rotation = new Quaternion(0, -180, 0, 0);
            GoRight = false;

        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!GoRight)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
        //プレイヤーの位置
        ShooterPosition = transform.FindChild("ShooterPosition").gameObject.transform.position;
        KnifePosition = transform.FindChild("KnifePosition").gameObject.transform.position;

        //歩く状態の動き
        if (GetComponent<EnemyState>().State == EnemyState.States.Walk)
        {
            transform.position = new Vector2(transform.position.x + WalkSpeed * direction*Time.deltaTime*60, transform.position.y);
        }
        if (GetComponent<EnemyState>().State == EnemyState.States.Run)
        {
            transform.position = new Vector2(transform.position.x + RunSpeed * direction*Time.deltaTime * 60, transform.position.y);
        }
        //ターゲットを殺した
        if (TargetPlayer != null && TargetPlayer.GetComponent<PersonalPro>().ThisNowHp < 0)
        {
            TargetPlayer = null;
            GoRight = !GoRight;
            NoDamage = true;
            GetComponent<EnemyState>().State = EnemyState.States.Walk;
            animator.SetBool("Walk", true); 
            animator.SetBool("Attack", false);
            animator.SetBool("Run", false);
            //向き変換
            if (GoRight)
            {
                this.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else
            {
                this.transform.rotation = new Quaternion(0, -180, 0, 0);
            }

        }
        //範囲外なら削除
        if (transform.position.x > 8 || transform.position.x < -8)
        {
            Destroy(this.gameObject);
        }
	}
    //向きを変換するの判断
    void ChangeDirection(GameObject Player)
    {
        //向き変換は一回だけ 
        if (NoDamage)
        {
            TargetPlayer = Player;
            GetComponent<EnemyState>().State = EnemyState.States.Run;
            ChangeRun();
            NoDamage = false;
            switch (GoRight)
            {
                // 右向きの時
                case true:
                    if (Player.transform.position.x < this.transform.position.x)
                    {
                        this.transform.rotation = new Quaternion(0, -180, 0, 0);
                        GoRight = false;
                    }
                    break;
                //左向きの時
                case false:
                    if (Player.transform.position.x > this.transform.position.x)
                    {
                        this.transform.rotation = new Quaternion(0, 0, 0, 0);
                        GoRight = true;
                    }
                    break;
            }
        }
    }
    void ChangeRun()
    {
        animator.SetBool("Walk", false);
        animator.SetBool("Run", true);

    }
    void OnTriggerStay2D(Collider2D other)
    {
        //ターゲットプレイヤーと衝突したらアッタクモード
        if (other.gameObject == TargetPlayer)
        {
            GetComponent<EnemyState>().State = EnemyState.States.Attack;
            animator.SetBool("Run", false);
            animator.SetBool("Attack", true);
        //    TargetPlayer.GetComponent<PlayerMove>().animator.SetBool("IdleShoot",true);
        }
    }


}
