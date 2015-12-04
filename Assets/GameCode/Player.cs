using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour, Controls {

    private GameObject player;
    
    public void catchBlocks()
    {
        throw new NotImplementedException();
    }

    public void fireBlocks()
    {
        throw new NotImplementedException();
    }

    public void moveOnKeyPress(string s)
    {
        if (string.Equals(s, "left") && this.player.transform.position.x > - (Map.getMapX() - 1) * 1.05f)
            this.player.transform.position += new Vector3(-1.05f, 0, 0);
        if (string.Equals(s, "right") && this.player.transform.position.x < 0)
            this.player.transform.position += new Vector3(1.05f, 0, 0);
    }

    public void rotateOnKeyPress(string s)
    {
        throw new NotImplementedException();
    }
    
    // Use this for initialization
    void Start () {
		{
            Debug.Log(Map.getMapX());
            this.player = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            this.player.transform.position = new Vector3(-(float)Math.Truncate((decimal)Map.getMapX() / 2) * 1.05f, -Map.getMapY() - 2, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {

	    if (Input.GetKeyDown(KeyCode.Q))
        {
            moveOnKeyPress("left");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            moveOnKeyPress("right");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            rotateOnKeyPress("left");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            rotateOnKeyPress("right");
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            fireBlocks();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            catchBlocks();
        }

	}
}
