using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour, Controls {

    private GameObject player;
    
    // Méthode pour récupérer les blocks
    public void catchBlocks()
    {
        // On récupère la position du joueur et le premier block solide. 
        int playerX = (int)Math.Round((player.transform.position.x) / 1.05f);
        int blockY = checkFirstBlock(playerX);

        if (blockY != -1)
        {
            if (LevelReader.map[playerX, blockY].type == TypeCase.block) // Suppression d'un bloc sur une case vide
            {
                LevelReader.map[playerX, blockY].type = TypeCase.empty;
                LevelReader.map[playerX, blockY].renderCase(TypeCase.empty);
            }
            else if (LevelReader.map[playerX, blockY].type == TypeCase.good) // Suppression d'un bloc sur une case target
            {
                LevelReader.map[playerX, blockY].type = TypeCase.target;
                LevelReader.map[playerX, blockY].renderCase(TypeCase.target);
            }
            else if (LevelReader.map[playerX, blockY].type == TypeCase.wall)
                Debug.Log("Impossible de retirer un mur.");
        }
        else
            Debug.Log("Il n'y a pas de bloc à récupérer ici.");
    }

    // Méthode pour tirer les blocks
    public void fireBlocks()
    {
       // On récupère la position du joueur et le premier block solide. 
       int playerX = (int) Math.Round((player.transform.position.x) / 1.05f);
       int blockY = checkFirstBlock(playerX);

        // On ajoute le bloc logiquement et on l'affiche
        if (blockY != -1 && (blockY + 1) != Map.getMapY() )
        {
            if (LevelReader.map[playerX, blockY + 1].type == TypeCase.empty) // Ajout d'un bloc sur une case vide
            {
                LevelReader.map[playerX, blockY + 1].type = TypeCase.block;
                LevelReader.map[playerX, blockY + 1].renderCase(TypeCase.block);
            }
            else if (LevelReader.map[playerX, blockY + 1].type == TypeCase.target) // Ajout d'un bloc sur une case target
            {
                LevelReader.map[playerX, blockY + 1].type = TypeCase.good;
                LevelReader.map[playerX, blockY + 1].renderCase(TypeCase.good);
            }
        }
        else
            Debug.Log("Impossible de tirer un bloc ici !");
               
    }

    // Gestion des déplacements à gauche/droite
    public void moveOnKeyPress(string s)
    {
        if (string.Equals(s, "left") && player.transform.position.x > 0)
            player.transform.position += new Vector3(-1.05f, 0, 0);
        if (string.Equals(s, "right") && player.transform.position.x < (Map.getMapX() - 1) * 1.05f)
            player.transform.position += new Vector3(1.05f, 0, 0);
    }

    public void rotateOnKeyPress(string s)
    {
        Case[,] temp = new Case[Map.getMapY(),Map.getMapX()];
        if (string.Equals(s, "left") )
        {
            for (int j = 0; j < Map.getMapY(); j++)
                for (int i = 0; i < Map.getMapX(); i++)
                {
                    temp[j, Map.getMapX() - i - 1] = LevelReader.map[i, j];
                }

            for (int j = 0; j < Map.getMapY(); j++)
                for (int i = 0; i < Map.getMapX(); i++)
                {
                    LevelReader.map[i, j] = temp[i,j];
                    LevelReader.map[i, j].moveCase(i, j);
                    LevelReader.map[i, j].renderCase(LevelReader.map[i, j].type);
                }

        }
        if (string.Equals(s, "right") )
        {
            for (int j = 0; j < Map.getMapY(); j++)
                for (int i = 0; i < Map.getMapX(); i++)
                {
                    temp[Map.getMapX() - j - 1, i] = LevelReader.map[i, j];
                }

            for (int j = 0; j < Map.getMapY(); j++)
                for (int i = 0; i < Map.getMapX(); i++)
                {
                    LevelReader.map[i, j] = temp[i, j];
                    LevelReader.map[i, j].moveCase(i, j);
                    LevelReader.map[i, j].renderCase(LevelReader.map[i, j].type);
                }
        }
    }
    
    // Méthode de recherche du premier bloc solide dans une colonne 
    private int checkFirstBlock(int playerPos)
    {
        int blockY = -1;

        for (int i = 0; i < Map.getMapY(); i++)
        {
            if (LevelReader.map[playerPos, i].type == TypeCase.block ||
                LevelReader.map[playerPos, i].type == TypeCase.wall  ||
                LevelReader.map[playerPos, i].type == TypeCase.good)
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
