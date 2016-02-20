using UnityEngine;
using System.Collections;

public class EnemyPro : MonoBehaviour {
    public float Hp, MaxAttack,MinAttack,EnemyLevel;
	// Use this for initialization
    void Awake()
    {
        EnemyLevel = Random.Range(0.3f, 0.7f);
        transform.localScale = new Vector3(EnemyLevel, EnemyLevel, 0);
        MaxAttack *= (EnemyLevel + 0.3f);
        MinAttack *= (EnemyLevel + 0.3f);
        Hp *= (EnemyLevel + 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void Damage(float damage)
    {
        Hp-=damage;
        if (Hp < 0)
        {
            GetComponent<EnemyMove>().animator.Play("Dead");
            GetComponent<GetExp>().enabled = true;
            GetComponent<GetMeat>().enabled = true;
            int n = Random.Range(0, 10);
            if (n == 1 || n == 2)
            {
                GetComponent<GetCard>().enabled = true;
            }
            GetComponent<EnemyState>().State = EnemyState.States.Dead;
        }

    }
}
