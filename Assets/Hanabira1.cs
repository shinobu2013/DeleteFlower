using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hanabira1 : MonoBehaviour
{
    public float speedX, speedY;
    public float rotateZ;
    int updateCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        // speedX = 0.025f;
        // speedY = 0.025f;
    }

    // Update is called once per frame
    void Update()
    {
        Transform tf = GetComponent<Transform>();
        tf.position += new Vector3(speedX, speedY, 0.0f);
        tf.rotation = Quaternion.Euler(0.0f, 0.0f, rotateZ);
        updateCount++;
        if( updateCount >= 1000 ){
            Destroy(this);
        }
    }
}
