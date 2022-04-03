using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isUp;
    public bool isDown;
    public float number;
    public float intenzity;
    void Start()
    {
        number = 0.0f;
        isDown = false;
        isUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isUp)
        {
            number = 0.0f;
            number += intenzity * Time.deltaTime;
            if (number <= 0.2f)
            {
                GetComponent<LineRenderer>().startWidth = number;
                GetComponent<LineRenderer>().endWidth = number;
            }
            else
            {
                isUp = false;
            }
        }
        if (isDown)
        {
            number = 0.2f;
            number -= intenzity * Time.deltaTime;
            if (number > 0.0f)
            {
                GetComponent<LineRenderer>().startWidth = number ;
                GetComponent<LineRenderer>().endWidth = number ;
            }
            else
            {
                isDown = false;
            }
        }
    }
    public void SetUp()
    {
        isUp = true;
    }
    public void SetDown()
    {
        isDown = true;
    }


}
