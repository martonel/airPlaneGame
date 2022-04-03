using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float distanceRay = 100;
    public Transform firePoint;
    public LineRenderer lineRenderer;
    public float LaserDamage;

    private void Update()
    {
    }


    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        if (hit.collider != null)
        {
            Draw2Ray(firePoint.position, hit.point);
            if (hit.collider.gameObject.GetComponent<PlayerHealth>() != null)
            {
                hit.collider.gameObject.GetComponent<PlayerHealth>().GetDamage(LaserDamage);
            }
        }
        else
        {
            Draw2Ray(firePoint.position, new Vector2(this.transform.position.x, transform.position.y - 1 * distanceRay));
        }
    }

    void ShootLaser()
    {
        if (Physics2D.Raycast(transform.position, transform.right))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
            Draw2Ray(firePoint.position,hit.point);
        }
        else {
            Draw2Ray(firePoint.position, firePoint.transform.right * distanceRay);
        }
    }
    void Draw2Ray(Vector2 startPos,Vector2 endPos)
    {
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1,endPos);
    }
}
