using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager myInstance = null;
    public static EnemyManager Instance
    {
        get
        {
            if (myInstance == null)
            {
                return null;
            }
            else
            {
                return myInstance;
            }
        }
    }

    public GameObject[] Enemys;
    public float EnemySpawnRate;
    
    private bool IsSpawn;

    private Stack<GameObject> enemyPoint;

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
        IsSpawn = true;
        enemyPoint = new Stack<GameObject>();
        Transform[] objs = Utility.RootGameObjectFind("Field").GetComponentsInChildren<Transform>();
        foreach(var obj in objs){
            if(obj.name == "Field")continue;
            enemyPoint.Push(obj.gameObject);
        }
    }

    void Update()
    {
        if (IsSpawn)
        {
            IsSpawn = false;
            int randNum = Random.RandomRange(0, Enemys.Length);
            Instantiate(Enemys[randNum]).GetComponent<Enemy>().SetTarget(enemyPoint.Pop().transform);
            StartCoroutine("Enemyspawn");
        }
    }
    IEnumerator Enemyspawn()
    {
        yield return new WaitForSeconds(EnemySpawnRate);
        IsSpawn = true;
    }

    public void PointPush(GameObject obj_){
        enemyPoint.Push(obj_);
    }




}
