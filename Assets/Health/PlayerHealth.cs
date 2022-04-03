using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    private int health;
    public Slider slider;
    public bool isEnemy;
    public GameObject particle;
    public Animator EndAnim;
    public Animator EnemyAnim;
    public bool isBoss;
    bool isInFire;
    public AudioSource deathAudio;
    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        isInFire = true;
        health = maxHealth;
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void PlusHealth(int number)
    {
        if (health + number > maxHealth)
        {
            health += number;
        }
        else
        {
            health = maxHealth;
        } 
        slider.value = health;

    }
    public int GetHealth()
    {
        return health;
    }

    public void GetDamage(float number)
    {
        if (!isDead)
        {
            if (health - number < maxHealth / 2 && !isEnemy && isInFire)
            {
                GetComponent<HealthSettings>().SetHalfHealth(Color.red);
                isInFire = false;
            }

            if (health - number <= 0)
            {
                if (isEnemy)
                {
                    StartCoroutine(EnemyDeath());
                }
                else
                {
                    if (particle != null)
                    {
                        GameObject obj = Instantiate(particle, this.gameObject.transform.position, Quaternion.identity);
                        obj.transform.SetParent(this.gameObject.transform);
                    }
                    GetComponent<Animator>().Play("Crashing");
                    if (EndAnim != null)
                    {
                        EndAnim.Play("GameOver");
                    }
                    if (deathAudio != null)
                    {
                        deathAudio.Play();
                    }
                    Time.timeScale = 0.5f;
                    StartCoroutine(EndGame());
                    Debug.Log("gameOver");
                    health = 0;
                }
                isDead = true;
            }
            else
            {
                health--;
            }
            slider.value = health;
        }
    }
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1.2f);
        Time.timeScale = 0.0f;
    }
    IEnumerator EnemyDeath()
    {
        Debug.Log("vége");
        if (particle != null)
        {
            GameObject obj = Instantiate(particle, this.gameObject.transform.position, Quaternion.identity);
            obj.transform.SetParent(this.gameObject.transform);
        }
        if (EndAnim != null)
        {
            EndAnim.Play("YouWinAnim");
        }
        if (EnemyAnim != null)
        {
            EnemyAnim.Play("Enemy1Dead");
        }
        if (deathAudio != null)
        {
            deathAudio.Play();
        }
        yield return new WaitForSeconds(0.7f);
        if (!isBoss)
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemies");
            objs[0].gameObject.GetComponent<WaveSpawner>().SetNewList();
            objs[0].gameObject.GetComponent<ActivateLaser>().SetNewList();
            objs[0].gameObject.GetComponent<ActivateLaser>().SetActive(false);
        }
        if (isBoss)
        {
            Debug.Log("boss volt");
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Ending>().End();
        }

        Destroy(this.gameObject);
    }
}
