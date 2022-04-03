using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    bool isMoving;
    public float speed;
    public float y; Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        isMoving = true;
        target = new Vector3(transform.position.x, transform.position.y - y, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);

            if (Vector3.Distance(transform.position, target) < 0.01f)
            {
                transform.position = target;
                isMoving = false;
                if (
                GetComponent<BossMove>() != null) {
                    GetComponent<BossMove>().SetStart();
                }
            }
        }

    }
}
