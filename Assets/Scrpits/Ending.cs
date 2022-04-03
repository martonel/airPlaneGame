using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    bool isMove; 
    public float speed;

    public GameObject target;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMove) {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

            if (Vector3.Distance(transform.position, target.transform.position) < 0.001f)
            {
                isMove = false;
                anim.Play("EndGame");
            }
        }
    }

    public void End()
    {
        Debug.Log("ending");
        isMove = true;
        GetComponent<PlayerMovement>().SetMovement(true);
    }
}
