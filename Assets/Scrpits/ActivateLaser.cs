using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLaser : MonoBehaviour
{

    public List<GameObject> lasers;
    public int randNum;
    private int laserNumber;
    private bool isTrue;
    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        laserNumber = lasers.Count;
        randNum = 1;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isTrue)
        {
            isActive = true;
            StartCoroutine(WaitTime4());
            if (laserNumber == 1)
            {
                randNum = 5;
            }
            else
            {
                randNum = Random.Range(0, laserNumber);
            }
            for (int i = 0; i < laserNumber; i++)
            {
                if (lasers[i].gameObject != null)
                {
                    if (i != randNum)
                    {
                        lasers[i].GetComponent<EnemyLaser>().ActivateLaser();
                    }
                }
            }
            isTrue = false;
        }
    }

    public void SetNewList()
    {
        StartCoroutine(WaitTime2());
    }
    IEnumerator WaitTime2()
    {
        yield return new WaitForSeconds(0.1f);
        List<GameObject> newList = new List<GameObject>();
        foreach (GameObject item in lasers)
        {
            if (item != null)
            {
                newList.Add(item);
            }
        }
        lasers = newList;
        laserNumber = lasers.Count;
        Debug.Log(laserNumber + "kevesebb lett");
        SetShoot();
    }

    public void SetStart(List<GameObject> enemies)
    {
        lasers = enemies;
        StartCoroutine(WaitTime3());
        laserNumber = lasers.Count;
    }
    IEnumerator WaitTime3()
    {
        yield return new WaitForSeconds(1.0f);
        isTrue = true;
    }
    public void SetShoot()
    {
        if (!isTrue)
        {
            isTrue = true;
        }
    }
    IEnumerator WaitTime4()
    {
        yield return new WaitForSeconds(3.0f);
        if (!isActive)
        {
            isTrue = true;
        }
    }
    public void SetActive(bool isA)
    {
        isActive = isA;
    }

}
