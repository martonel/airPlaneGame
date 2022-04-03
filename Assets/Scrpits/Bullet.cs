using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2;
    private Vector3 target;

    private void Start()
    {
        target = new Vector3(transform.position.x, transform.position.y+100, transform.position.z);
    }
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);
        if (hit.collider != null)
        {
            if(hit.collider.gameObject.GetComponent<PlayerHealth>()!= null)
            {
                hit.collider.gameObject.GetComponent<PlayerHealth>().GetDamage(1);
            }
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
}
