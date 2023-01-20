using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class Utility
{
    // 최상위 Hireachy에서 오브젝트를 찾는 함수
    public static GameObject RootGameObjectFind(string objName_)
    {
        Scene currecntScene = SceneManager.GetActiveScene();
        GameObject[] findObjs = currecntScene.GetRootGameObjects();
        GameObject resultObj = default;
        foreach (var obj in findObjs)
        {
            if (obj.name.Equals(objName_))
            {
                resultObj = obj;
            }
        }

        if (resultObj.Equals(default))
        {
            return null;
        }
        else
        {
            return resultObj;
        }
    }
    // GameObject에 자식중에서 오브젝트르 찾는 함수
    public static GameObject FindChildObject(this GameObject targetObj_, string objName_)
    {
        GameObject serchResult = default;
        GameObject serchTarget = default;
        for (int i = 0; i < targetObj_.transform.childCount; i++)
        {
            serchTarget = targetObj_.transform.GetChild(i).gameObject;
            if (serchTarget.name.Equals(objName_))
            {
                serchResult = serchTarget;
                return serchResult;
            }
            else
            {
                serchResult = FindChildObject(serchTarget, objName_);
            }
        }
        return serchResult;
    }

}
