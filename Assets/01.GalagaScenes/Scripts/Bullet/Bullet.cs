using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Player;
    public float speed = 8.0f;
   
    void OnEnable(){
        StartCoroutine("BulletPoolPush");
    }

    void OnTriggerEnter(Collider other){
        if(other.tag.Equals("Player")){
            ObjectPoolManager.Instance.BulletPush(gameObject);
        }
    }
    void Update(){
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    IEnumerator BulletPoolPush(){
        yield return new WaitForSeconds(10.0f);
        ObjectPoolManager.Instance.BulletPush(this.gameObject);
    }
}
