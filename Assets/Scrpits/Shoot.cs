using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shoot : MonoBehaviour
{
    private Vector3 target;
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public AudioSource shootAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Shooting();
            shootAudio.Play();
        }
    }
    
    void Shooting()
    {
        target = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        Instantiate(bulletPrefab, shootPoint.transform.position, Quaternion.identity);
    }
}
