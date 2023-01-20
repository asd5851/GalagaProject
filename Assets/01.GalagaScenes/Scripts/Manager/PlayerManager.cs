using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager myInstance = null;
    public static PlayerManager Instance
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
    // Start is called before the first frame update
    public GameObject player;
    void Awake()
    {
        if (myInstance == null)
        {
            myInstance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //Destroy(this.gameObject);
        }
        player = Utility.RootGameObjectFind("Player");
    }

    void OnEnable()
    {

    }
    // Update is called once per frame
    void Update()
    {
    }
    public void Dead()
    {
        Debug.Log("ddsad");
        player.SetActive(false);
    }
    public void RespawnPlayerexe()
    {
        player.transform.position = new Vector3(0, 0, -20);
        player.SetActive(true);
    }
    public void RespawnPlayer()
    {
        Invoke("RespawnPlayerexe", 2f);
    }
    public void SetPlayer()
    {
        player = Utility.RootGameObjectFind("Player");
    }


}
