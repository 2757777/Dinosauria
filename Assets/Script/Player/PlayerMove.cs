using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
  public  Animator animator;
  public GameObject target, GameManager;
    // 位置座標
    private Vector3 position,startPosition;
    // スクリーン座標をワールド座標に変換した位置座標
  //  private Vector3 screenToWorldPointPosition;
    public AnimatorStateInfo stateInfo;
    public float speed;
    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        animator = GetComponent<Animator>();
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
         stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        //ターゲットをタッチした時
        if (GameManager.GetComponent<ChooseChar>().NextPlayer == this.gameObject)
        {
            if (Input.GetMouseButtonDown(0) && target == null && stateInfo.IsName("Idle"))
            {
                /////
                Vector3 aTapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D aCollider2d = Physics2D.OverlapPoint(aTapPoint);
                if (aCollider2d&&aCollider2d.tag == "Enemy")
                {
                    //hpを最大にする
                    GetComponent<PersonalPro>().ThisNowHp = GetComponent<PersonalPro>().ThisMaxHp;
                    target = aCollider2d.transform.gameObject;
                    animator.SetBool("Move", true);
                    animator.SetBool("Idle", false);
                    // Vector3でマウス位置座標を取得する
                    // position = Input.mousePosition;
                    if (GetComponent<PersonalPro>().kind == PersonalPro.Kind.Shooter)
                    {
                        position = target.GetComponent<EnemyMove>().ShooterPosition;
                        position.x += Random.Range(-0.5f, 0.5f);
                    }
                    else if (GetComponent<PersonalPro>().kind == PersonalPro.Kind.Knife)
                    {
                        position = target.GetComponent<EnemyMove>().KnifePosition;
                    }
                    // Z軸修正
                    // position.z = 10f;
                    // マウス位置座標をスクリーン座標からワールド座標に変換する
                    //    screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);


                }

            }
        }
        if(target!=null){
         //   if (target.GetComponent<EnemyMove>().GoRight == false)
            if(target.transform.position.x<transform.position.x)
                    {
                        transform.rotation = new Quaternion(0, -180, 0, 0);
                    }
                    else
                    {
                        transform.rotation = new Quaternion(0, 0, 0, 0);

                    }
        }
        // ワールド座標に変換されたマウス座標を代入
        if (animator.GetBool("Move"))
        {
            //NextChar
            GameManager.GetComponent<ChooseChar>().NextPlayer = null;
            if (position.x < -2.4f)
            {
                position.x = -2.4f;
            }
            else if (position.x > 2.4)
            {
                position.x = 2.4f;
            }
                //プレイヤーを移動する
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2(position.x, position.y), speed * Time.deltaTime);

        }
        //銃を構え
        if (gameObject.transform.position == position)
        {
            animator.SetBool("Move", false);
            animator.SetBool("Attack", true); 
        }
   /*     //銃を構えとともに移動する
        if (animator.GetBool("WalkShoot") )
        {
            transform.position = new Vector2(transform.position.x+0.01f , transform.position.y);
        }*/
        //立て撃つ
        if (animator.GetBool("Attack"))
        {
            animator.SetBool("Move", false);
        }
        //ターゲット消失
        if (target!=null&&target.GetComponent<EnemyPro>().Hp < 0)
        {
            target = null;
            animator.SetBool("Move", false);
            animator.SetBool("Attack", false);
            animator.SetBool("Back", true); 
        }
        //家に帰る
        if(animator.GetBool("Back")){
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2(startPosition.x, startPosition.y), speed * Time.deltaTime);
            if (gameObject.transform.position == startPosition)
            {
                animator.SetBool("Back", false);
                animator.SetBool("Idle", true);
                animator.SetBool("Attack", false);
                //NextChar
                this.enabled = false;
            }
        }
    }

}