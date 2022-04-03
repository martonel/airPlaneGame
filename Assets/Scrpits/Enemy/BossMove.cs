using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    private float a;
    private float c;

    bool isMoving;
    public float speed;
    private int counter;
    Vector3 target;
    public int randNum;
    private bool isLeftRight;
    // Start is called before the first frame update
    void Start()
    {
        randNum = Random.Range(1, 5);
        isLeftRight = false;
        a = -1.7f;
        c = 1.7f;
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);

            if (Vector3.Distance(transform.position, target) < 0.001f)
            {
                transform.position = target;
                if(target.x == 1.7f)
                {
                    target = new Vector3(this.transform.position.x + a, this.transform.position.y, this.transform.position.z);
                    isLeftRight = true;
                }
                else if(target.x == 0 && isLeftRight) {
                    target = new Vector3(this.transform.position.x + a, this.transform.position.y, this.transform.position.z);
                }
                else if (target.x == 0 && !isLeftRight)
                {
                    target = new Vector3(this.transform.position.x + c, this.transform.position.y, this.transform.position.z);
                }
                else if (target.x == -1.7f)
                {
                    target = new Vector3(this.transform.position.x + c, this.transform.position.y, this.transform.position.z);
                    isLeftRight = false;
                }
                counter++;
                if (counter == randNum)
                {
                    isMoving = false;
                    counter = 0;
                    GetComponent<EnemyLaser>().Activate();
                    GetComponent<EnemyLaser>().ActivateLaser();
                    Debug.Log("Activate!");
                }
            }
        }
    }
    public void SetStart()
    {
        Debug.Log("újra mozog");
        isMoving = true;
        randNum = Random.Range(1, 5);
        counter = 0;
    }
}
