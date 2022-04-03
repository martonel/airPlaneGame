using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    GameObject laser;
    private bool isActive;
    public AudioSource laserSound;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        laser = this.gameObject;
    }
    public void ActivateLaser()
    {
        if (!isActive)
        {
            Debug.Log("activating!!!");
            StartCoroutine(WaitTime());
        }
    }
    IEnumerator WaitTime()
    {
        isActive = true;
        laser.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        laser.GetComponent<Animator>().Play("LaserUp");
        yield return new WaitForSeconds(1.2f);
        laserSound.Play();
        laserSound.loop = true;
        laser.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        laser.gameObject.transform.GetChild(0).gameObject.GetComponent<LaserShoot>().SetUp();

        yield return new WaitForSeconds(1.0f);
        laser.gameObject.transform.GetChild(0).gameObject.GetComponent<LaserShoot>().SetDown();
        laser.GetComponent<Animator>().Play("LaserDown");
        laserSound.loop = false;
        yield return new WaitForSeconds(1.2f);
        laser.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        this.gameObject.transform.GetComponentInParent<ActivateLaser>().SetShoot();
        if (GetComponent<BossMove>() != null)
        {
            GetComponent<BossMove>().SetStart();
        }
        else
        {
            Activate();
        }
    }

    public void Activate()
    {
        isActive = false;
    }
}
