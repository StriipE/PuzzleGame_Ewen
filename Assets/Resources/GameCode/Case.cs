using UnityEngine;
using System.Collections;

public enum TypeCase
{
    empty,
    target,
    wall,
    block,
    good
}

public class Case {

    public int posX { get; set; }
    public int posY { get; set; }
    public TypeCase type {get; set;}
    public GameObject newCase;

    public Case(int x, int y)
    {
        newCase = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newCase.transform.position = new Vector3(x * 1.0f,- y * 1.0f, 0f);
        posX = x;
        posY = y;
        type = TypeCase.empty;
    }

    public Case(int x, int y, TypeCase type)
    {
        newCase = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newCase.transform.position = new Vector3(x * 1.0f,- y * 1.0f, 0f);
        renderCase(type);
        posX = x;
        posY = y;
        this.type = type;
    }

    public void renderCase(TypeCase type)
    {
        switch (type)
        {
            case TypeCase.block:
                {
                    newCase.GetComponent<Renderer>().material.color = Color.yellow;
                    break;
                }
            case TypeCase.wall:
                {
                    newCase.GetComponent<Renderer>().material.color = Color.red;
                    break;
                }
            case TypeCase.target:
                {
                    newCase.GetComponent<Renderer>().material.color = Color.cyan;
                    break;
                }
            case TypeCase.good:
                {
                    newCase.GetComponent<Renderer>().material.color = Color.green;
                    break;
                }
            case TypeCase.empty:
            default:
                {
                    newCase.GetComponent<Renderer>().material.color = Color.white;
                    break;
                }
        }
    }

    public void moveCase(int x, int y)
    {
        newCase.transform.position = new Vector3(x * 1.0f, -y * 1.0f, 0f);
    }

    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
       
    }
}
