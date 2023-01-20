using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    private static ObjectPoolManager myInstance = null;
    public static ObjectPoolManager Instance
    {
        get
        {
            if (myInstance == null)
            {
                return null;
            }
            return myInstance;
        }
    }

    private Stack<GameObject> BulletPool;
    public GameObject BulletPrefab;
    public int BulletCount;


    void Awake()
    {
        if (myInstance == null)
        {
            myInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        BulletPool = new Stack<GameObject>();
        for (int i = 0; i < BulletCount; i++)
        {
            GameObject object_ = Instantiate(BulletPrefab);
            object_.transform.parent = gameObject.transform;
            object_.transform.position = Vector3.zero;
            object_.SetActive(false);
            BulletPool.Push(object_);
        }
    }

    public GameObject PlayerBulletPop()
    {
        GameObject bullet = BulletPool.Pop();
        bullet.tag = "PlayerBullet";
        return bullet;
    }

    public GameObject EnemyBulletPop()
    {
        GameObject bullet = BulletPool.Pop();
        bullet.tag = "EnemyBullet";
        return bullet;
    }

    public void BulletPush(GameObject obj_)
    {
        obj_.transform.position = Vector3.zero;
        obj_.SetActive(false);
        BulletPool.Push(obj_);
    }

    public void SceneReload()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            BulletPush(transform.GetChild(i).gameObject);
        }
    }
}
