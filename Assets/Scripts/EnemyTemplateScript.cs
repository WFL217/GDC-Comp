using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTemplateScript : MonoBehaviour
{
    private Transform EnemyTemplate;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public int health;


    private float timer = 0.0f;
    private float rateOfFire = 0.5f;

    void Start()
    {
        EnemyHealthSelect();
        StartCoroutine(HealthCheck());
    }


    void Update()
    {
        EnemyPosition();
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = rateOfFire;
            Fire();
        }
    }

    void EnemyPosition()
    {
        EnemyTemplate = transform;
    }

    void Fire()
    {
        bulletSpawn.position = EnemyTemplate.position;

        GameObject bullet;

        bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.transform.position + (-2 * transform.up),
            new Quaternion());

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * -10;
        Destroy(bullet, 3.0f);
    }

    void EnemyHealthSelect()
    {
        #region Enemy01
        if (this.transform.tag == "Enemy01")
        {
            health = 20;
        }
        #endregion

        #region Enemy01
        if (this.transform.tag == "Enemy02")
        {
            health = 100;
        }
        #endregion
    }



    #region [Enumerators]

    IEnumerator HealthCheck()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        yield return new WaitForSeconds(.1f);
        StartCoroutine(HealthCheck());
    }

    #endregion
}