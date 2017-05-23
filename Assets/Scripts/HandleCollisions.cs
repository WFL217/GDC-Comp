using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCollisions : MonoBehaviour
{
    //Scripts
    private GameMananger gManager;
    private GameObject playerPrefab;
    private PlayerMovement player;

    public float radius = 10.0f;

    public float timer = 0.0f;
    public float survivalTimer = 1.0f;




    void Start()
    {
        #region Obtain the GameManager SCripts 
        gManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameMananger>();
        #endregion

        #region Obtain the Player SCripts 
        playerPrefab = GameObject.FindWithTag("Player");
        player = playerPrefab.GetComponent<PlayerMovement>();
        #endregion

        #region Timer
        if (transform.tag == "Player")
        {
            StartCoroutine(Timer());
        }
        #endregion

    }

    void OnTriggerEnter(Collider collider)
    {
        #region Player Collision Handler

        if (this.transform.tag == "Player")
        {
            if (collider.gameObject.tag == "EnemyProjectile" || collider.gameObject.tag == "Enemy") //Set these to TAG [Your Tag's]
            {
                if (timer <= survivalTimer)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    timer = 0;

                    #region Dimension Shift [Destroys Bullets in Radius around player]
                    player.dimensionShift(true, player.isShifted, player.passTags);
                    Collider[] colliders = Physics.OverlapSphere(collider.gameObject.transform.position, radius);
                    foreach (Collider col in colliders)
                    {
                        if (col.tag == "Enemy01" || col.tag == "Enemy02" || col.tag == "EnemyProjectile")
                        {
                            Destroy(col.gameObject);
                        }
                    }

                    #endregion
                }
            }
        }
        #endregion

        #region Enemy Collision Handler
        else
        { 
            if (gManager.enemyList.Contains(transform.tag))
            {
                if (collider.tag == "Projectile")
                {
                    transform.GetComponent<EnemyTemplateScript>().health--;
                    Destroy(collider.gameObject);            
                }
            }
        }

        #endregion
    }

    #region [Enumerators]

    IEnumerator Timer()
    {
        timer++;
        yield return new WaitForSeconds(1);
        StartCoroutine(Timer());
    }

    #endregion

}
