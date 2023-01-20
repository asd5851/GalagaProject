using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoei : MonoBehaviour, Enemy
{
    private float timeAfterSpawn;
    public Transform targetPosition;
    public Transform player;

    private float timeAfterFire;
    public float fireRateMin = 0.5f;
    public float fireRateMax = 2.5f;
    private float fireRate;

    public void Attack()
    {
        timeAfterFire = timeAfterFire + Time.deltaTime;

        if (timeAfterFire >= fireRate)
        {
            timeAfterFire = 0;

            GameObject bullet = ObjectPoolManager.Instance.EnemyBulletPop();
            bullet.SetActive(true);
            bullet.transform.position = this.transform.position;
            bullet.transform.LookAt(player);
            fireRate = Random.Range(fireRateMin, fireRateMax);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Bullet : {other.name},{other.tag}");
        if (other.tag.Equals("PlayerBullet"))
        {
            Die();
        }
    }

    public void Die()
    {
        UIManager.Instance.ScoreAdd(50);
        EnemyManager.Instance.PointPush(targetPosition.gameObject);
        Destroy(gameObject);
    }

    public void Move()
    {
        timeAfterSpawn = timeAfterSpawn + Time.deltaTime;

        if (timeAfterSpawn > 5)
        {
            transform.position =
            Vector3.MoveTowards(gameObject.transform.position, targetPosition.position, 20 * Time.deltaTime);
        }

        else if (timeAfterSpawn % 2 < 1)
        {
            transform.Translate(new Vector3(-1, 0, -1) * 10 * Time.deltaTime);
        }
        else if (timeAfterSpawn % 2 > 1)
        { //>=1&&timeAfterSpawn <2){
            transform.Translate(new Vector3(1, 0, -1) * 10 * Time.deltaTime);

        }


    }

    void Start()
    {
        //임시
        int random = Random.Range(-14, 14);
        transform.position = new Vector3(random, 0, 28);

        timeAfterFire = 0;
        fireRate = Random.Range(fireRateMin, fireRateMax);

        player = Utility.RootGameObjectFind("Player").transform;
    }

    void Update()
    {
        Move();
        Attack();
    }
    public void SetTarget(Transform target_)
    {
        targetPosition = target_;
    }

}
