using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointcreate : MonoBehaviour
{
    public GameObject PointPrefab;
    private int idx;
    void Awake(){
        for(int i= 20;i>0;i--){
            for(int j=-15;j<=15;j++){
                if(j%2==0)continue;
                if(i%2==0)continue;
                GameObject Point = Instantiate(PointPrefab,new Vector3(j,0,i),default);
                Point.name = "Point"+idx;
                Point.transform.parent = this.transform;
                idx++;
            }
        }
    }
}
