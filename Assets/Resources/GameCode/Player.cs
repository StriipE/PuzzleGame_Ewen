using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour, Controls {

    private GameObject player;
    private int nbBlocksLeft = 0;
    private int nbTargetsCovered = 0;
    // Méthode pour récupérer les blocks
    public void catchBlocks()
    {
        // On récupère la position du joueur et le premier block solide. 
        int playerX = (int)Math.Round((player.transform.position.x) / 1.05f);
        int blockY = checkFirstBlock(playerX);

        if (blockY != -1)
        {
            if (ALevelReader.map[playerX, blockY].type == TypeCase.block) // Suppression d'un bloc sur une case vide
            {
                ALevelReader.map[playerX, blockY].type = TypeCase.empty;
                ALevelReader.map[playerX, blockY].renderCase(TypeCase.empty);
                nbBlocksLeft++;
            }
            else if (ALevelReader.map[playerX, blockY].type == TypeCase.good) // Suppression d'un bloc sur une case target
            {
                ALevelReader.map[playerX, blockY].type = TypeCase.target;
                ALevelReader.map[playerX, blockY].renderCase(TypeCase.target);
                nbTargetsCovered--;
                nbBlocksLeft++;
            }
            else if (ALevelReader.map[playerX, blockY].type == TypeCase.wall)
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

        // Si le joueur a encore des blocs à tirer
        if (nbBlocksLeft > 0)
        {
            // On ajoute le bloc logiquement et on l'affiche
            if (blockY != -1 && (blockY + 1) != Map.getMapY())
            {
                if (ALevelReader.map[playerX, blockY + 1].type == TypeCase.empty) // Ajout d'un bloc sur une case vide
                {
                    ALevelReader.map[playerX, blockY + 1].type = TypeCase.block;
                    ALevelReader.map[playerX, blockY + 1].renderCase(TypeCase.block);
                }
                else if (ALevelReader.map[playerX, blockY + 1].type == TypeCase.target) // Ajout d'un bloc sur une case target
                {
                    ALevelReader.map[playerX, blockY + 1].type = TypeCase.good;
                    ALevelReader.map[playerX, blockY + 1].renderCase(TypeCase.good);
                    nbTargetsCovered++;
                }
                nbBlocksLeft--;
            }
            else
                Debug.Log("Impossible de tirer un bloc ici !");
        }
        else
            Debug.Log("Vous n'avez plus de bloc à tirer");


        if (nbBlocksLeft == 0 && nbTargetsCovered == ALevelReader.nbTargets)
            Debug.Log("Bravo tu es le gagnant du jeu !");

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
                    temp[j, Map.getMapX() - i - 1] = ALevelReader.map[i, j];
                }

            for (int j = 0; j < Map.getMapY(); j++)
                for (int i = 0; i < Map.getMapX(); i++)
                {
                    ALevelReader.map[i, j] = temp[i,j];
                    ALevelReader.map[i, j].moveCase(i, j);
                    ALevelReader.map[i, j].renderCase(ALevelReader.map[i, j].type);
                }

        }
        if (string.Equals(s, "right") )
        {
            for (int j = 0; j < Map.getMapY(); j++)
                for (int i = 0; i < Map.getMapX(); i++)
                {
                    temp[Map.getMapX() - j - 1, i] = ALevelReader.map[i, j];
                }

            for (int j = 0; j < Map.getMapY(); j++)
                for (int i = 0; i < Map.getMapX(); i++)
                {
                    ALevelReader.map[i, j] = temp[i, j];
                    ALevelReader.map[i, j].moveCase(i, j);
                    ALevelReader.map[i, j].renderCase(ALevelReader.map[i, j].type);
                }
        }
    }
    
    // Méthode de recherche du premier bloc solide dans une colonne 
    private int checkFirstBlock(int playerPos)
    {
        int blockY = -1;

        for (int i = 0; i < Map.getMapY(); i++)
        {
            if (ALevelReader.map[playerPos, i].type == TypeCase.block ||
                ALevelReader.map[playerPos, i].type == TypeCase.wall  ||
                ALevelReader.map[playerPos, i].type == TypeCase.good)
                blockY = i; 
        }

        return blockY;
    }

    // Use this for initialization
    void Start () {
		{
            nbBlocksLeft = ALevelReader.nbTargets;
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

        Gamedata.AvailableBlocks = nbBlocksLeft;
        Gamedata.TargetBlocks = ALevelReader.nbTargets - nbTargetsCovered;
    }
}
