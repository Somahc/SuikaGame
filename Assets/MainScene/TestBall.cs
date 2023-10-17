using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBall : MonoBehaviour
{
    [SerializeField] GameObject _biggerBallPrefab;
    public bool collisionDestory = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Red" && collisionDestory){
            other.gameObject.GetComponent<TestBall>().collisionDestory = false;
            Debug.Log("Red");
            Destroy(other.gameObject);
            GameObject go = Instantiate(_biggerBallPrefab);  
        }

    }
}
