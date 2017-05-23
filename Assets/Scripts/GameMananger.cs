using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMananger : MonoBehaviour
{

    public List<string> enemyList = new List<string>();


    void Start()
    {
        enemyList.Add("Enemy01");
        enemyList.Add("Enemy02");
    }
}
