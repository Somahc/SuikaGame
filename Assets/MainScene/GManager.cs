using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{

    public int[] ballList = new int[2];
    public static GManager instance = null;
    public bool isHaveBall = true; // ボールをプレイヤーが持っているかどうか

    private void Awake(){
    if(instance == null)
    {
         instance = this;
         DontDestroyOnLoad(this.gameObject); 
    }
    else
    {
         Destroy(this.gameObject);
    }
    ballList[0] = Random.Range(0, 3);
    ballList[1] = Random.Range(0, 3);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    
}
