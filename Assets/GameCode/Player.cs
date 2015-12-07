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
       int playerX = (int) Math.Round((player.transform.position.x) / 1.05f);
       int blockY = checkFirstBlock(playerX);

       Debug.Log(blockY);

       if (blockY != Map.getMapY())
           LevelReader.map[playerX, blockY + 1].type = TypeCase.block;
       else
           throw new InvalidOperationException("Impossible de tirer un bloc ici !");
               
    }

    public void moveOnKeyPress(string s)
    {
        if (string.Equals(s, "left") && player.transform.position.x > 0)
            player.transform.position += new Vector3(-1.05f, 0, 0);
        if (string.Equals(s, "right") && player.transform.position.x < (Map.getMapX() - 1) * 1.05f)
            player.transform.position += new Vector3(1.05f, 0, 0);
    }

    public void rotateOnKeyPress(string s)
    {
        throw new NotImplementedException();
    }
    
    private int checkFirstBlock(int playerPos)
    {
        int blockY = -1;

        for (int i = 0; i < Map.getMapY(); i++)
        {
            if (LevelReader.map[playerPos, i].type == TypeCase.block || LevelReader.map[playerPos, i].type == TypeCase.wall)
                blockY = i; 
        }
        
        return blockY;
    }
    // Use this for initialization
    void Start () {
		{
            player = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            player.transform.position = new Vector3((float)Math.Truncate((decimal)Map.getMapX() / 2) * 1.05f, -Map.getMapY() - 2, 0);
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
