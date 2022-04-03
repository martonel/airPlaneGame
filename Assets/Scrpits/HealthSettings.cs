using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSettings : MonoBehaviour
{

    public GameObject particle1;
    public GameObject particle2;
    public Image playerHealth; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetHalfHealth(Color color)
    {
        particle1.GetComponent<ParticleSystem>().loop = false;
        GameObject obj = Instantiate(particle2, transform.position, Quaternion.identity);
        obj.transform.SetParent(this.gameObject.transform);
        obj.transform.localScale= new Vector3(0.1282215f, 0.1282215f, 0.1282215f);
        obj.transform.Rotate(90, 0, 0);
        obj.transform.position = new Vector3(this.transform.position.x, this.transform.position.y-0.5f, this.transform.position.z);
        playerHealth.color = color;
    }
}
