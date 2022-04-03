using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 target;
    bool isMoving;
    public float step;
    public float speed;
    public int maxSteps;
    private int actualStep;

    private bool stay;
    // Start is called before the first frame update
    void Start()
    {
        stay = false;
        target = this.transform.position;
        actualStep = 0;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stay) {
            if (!isMoving)
            {
                if (actualStep != maxSteps)
                {

                    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        target = new Vector3(transform.position.x + step, transform.position.y, transform.position.z);
                        isMoving = true;
                        actualStep++;
                        //GetComponent<Animator>().Play("turnRight");
                        Debug.Log("jobbra");
                    }
                }
                if (actualStep != -1 * maxSteps)
                {
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        target = new Vector3(transform.position.x - step, transform.position.y, transform.position.z);
                        isMoving = true;
                        actualStep--;
                        //GetComponent<Animator>().Play("turnLeft");
                        Debug.Log("balra");
                    }
                }
            }
    } 
        if (isMoving)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);

            if (Vector3.Distance(transform.position, target) < 0.001f)
            {
                transform.position = target;
                isMoving = false;
            }
        }
    }

    public void SetMovement(bool isMove)
    {
        stay = isMove;
    }
}
