using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBall : MonoBehaviour
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
        GManager.instance.isBallTouch = true;

        if(other.gameObject.tag == "Blue" && collisionDestory){
            other.gameObject.GetComponent<BlueBall>().collisionDestory = false;
            Debug.Log("Blue");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            GameObject go = Instantiate(_biggerBallPrefab, this.transform.position, Quaternion.identity);
        }

    }
}
