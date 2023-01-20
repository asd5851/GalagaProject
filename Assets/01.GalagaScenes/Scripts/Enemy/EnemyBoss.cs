using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour, Enemy
{
   public int bossLife = 2;
    
    
    public void Attack()
    {

    }

    public void Die()
    {
        bossLife --;
        if(bossLife<=0){
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other){ 
        if(other.tag.Equals("Bullet")){
            Die();
        } 
    }

    public void Move()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTarget(Transform target_)
    {

    }
}
