using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{

    public static GManager instance = null;
    public bool isBallTouch = false; // 投下したボールが何かしらに触れたかどうか
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
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isBallTouch){
            // Debug.Log("isBallTouch");

            isBallTouch = false;
        }
    }
}
