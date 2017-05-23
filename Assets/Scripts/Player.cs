using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Transform player;

    public Camera D1Camera;
    public Camera D2Camera;

    public Camera DEBUG;

    public Vector3 D1PlayerPos;
    public Vector3 D2PlayerPos;

    private Vector3 DOffset = new Vector3(0,0,40);

    public bool isInD1;
    public bool Debug;

	// Use this for initialization
	void Start ()
    {
        player = this.gameObject.transform;

 //       D1Camera = GameObject.FindGameObjectWithTag("D1").GetComponent<Camera>();
 //       D2Camera = GameObject.FindGameObjectWithTag("D2").GetComponent<Camera>();

//        DEBUG = GameObject.FindGameObjectWithTag("Debug").GetComponent<Camera>();



        D1PlayerPos = player.position;
        D2PlayerPos = player.position + DOffset;


        isInD1 = true;
        Debug = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        TEMPCHOOSECAMERA();
        KeyInputs();

        if(isInD1 == true)
        {
            //Set Player Position
            player.position = D1PlayerPos;

            //Update Variables
            D1PlayerPos = player.position;
            D2PlayerPos = player.position + DOffset;
        }

        else
        {
            //Set Player Position
            player.position = D2PlayerPos;

            //Update Variables
            D1PlayerPos = player.position - DOffset;
            D2PlayerPos = player.position;
        }

	}


    void TEMPCHOOSECAMERA()
    {
        if(isInD1 == true && Debug == false)
        {
            //Set Main Camera
            D1Camera.gameObject.tag = "MainCamera";
            D2Camera.gameObject.tag = "MainCamera";
            DEBUG.gameObject.tag = "Debug";

            D1Camera.gameObject.SetActive(true);
            D2Camera.gameObject.SetActive(false);
            DEBUG.gameObject.SetActive(false);
        }

        else if (isInD1 == false && Debug == false)
        {
            //Set Main Camera
            D2Camera.gameObject.tag = "MainCamera";
            D1Camera.gameObject.tag = "D1";
            DEBUG.gameObject.tag = "Debug";

            D1Camera.gameObject.SetActive(false);
            D2Camera.gameObject.SetActive(true);
            DEBUG.gameObject.SetActive(false);
        }

        else
        {
            DEBUG.gameObject.tag = "MainCamera";
            D1Camera.gameObject.tag = "D1";
            D2Camera.gameObject.tag = "D2";

            DEBUG.gameObject.SetActive(true);

            D1Camera.gameObject.SetActive(false);
            D2Camera.gameObject.SetActive(false);
        }
    }

    void KeyInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isInD1 = !isInD1;
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug = !Debug;
        }
    }
}
