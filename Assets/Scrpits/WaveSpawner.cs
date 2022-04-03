using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public List<GameObject> activeEnemies = new List<GameObject>();
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public int phaseCounter;
    public bool isActiveNotNull;
    // Start is called before the first frame update
    void Start()
    {
        isActiveNotNull = false;
    }

    private void Update()
    {
        if(activeEnemies.Count == 0 && isActiveNotNull)
        {
            Debug.Log("AKTIVÁLÁS");
            NextPhase();
        }
    }
    public void SetEnemies(GameObject enemy, bool isBoss)
    {
        GameObject isEnemy;
        if (!isBoss)
        {

            isEnemy = Instantiate(enemy, this.transform.position, Quaternion.identity);
            isEnemy.transform.SetParent(this.gameObject.transform);
            isEnemy.transform.position = new Vector3(-1.7f, this.transform.position.y, this.transform.position.z);
            activeEnemies.Add(isEnemy);

            isEnemy = Instantiate(enemy, this.transform.position, Quaternion.identity);
            isEnemy.transform.SetParent(this.gameObject.transform);
            isEnemy.transform.position = new Vector3(0, this.transform.position.y, this.transform.position.z);
            activeEnemies.Add(isEnemy);

            isEnemy = Instantiate(enemy, this.transform.position, Quaternion.identity);
            isEnemy.transform.SetParent(this.gameObject.transform);
            isEnemy.transform.position = new Vector3(1.7f, this.transform.position.y, this.transform.position.z);
            activeEnemies.Add(isEnemy);
            isActiveNotNull = true;
            Debug.Log(isActiveNotNull);
        }
        else
        {
            isEnemy = Instantiate(enemy, this.transform.position, Quaternion.identity);
            isEnemy.transform.SetParent(this.gameObject.transform);
            activeEnemies.Add(isEnemy);
            isActiveNotNull = true;
        }
        GetComponent<ActivateLaser>().SetStart(activeEnemies);
    }
   
    private void NextPhase()
    {
        phaseCounter++;
        Debug.Log(phaseCounter);
        switch (phaseCounter)
        {
            case 1:
                Debug.Log("case 1");
                SetEnemies(enemy1, false);
                break;
            case 2:
                SetEnemies(enemy2, false);
                break;
            case 3:
                SetEnemies(enemy3, false);
                break;
            case 4:
                SetEnemies(enemy4, false);
                break;
            case 5:
                SetEnemies(enemy5, true);
                break;
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
        foreach (GameObject item in activeEnemies)
        {
            if (item != null)
            {
                newList.Add(item);
            }
        }
        activeEnemies = newList;
    }

    public void StartGame()
    {
        isActiveNotNull = true;
    }

}
