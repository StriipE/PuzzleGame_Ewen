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
    public Case(int x, int y)
    {
        GameObject newCase = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newCase.transform.position = new Vector3(- x * 1.05f,- y * 1.05f, 0f);
        this.posX = x;
        this.posY = y;
        this.type = TypeCase.empty;
    }

    public Case(int x, int y, TypeCase type)
    {
        GameObject newCase = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newCase.transform.position = new Vector3(- x * 1.05f,- y * 1.05f, 0f);
        switch (type)
        {
            case TypeCase.wall :
                {
                    newCase.GetComponent<Renderer>().material.color = Color.red;
                    break;
                }
            case TypeCase.target :
                {
                    newCase.GetComponent<Renderer>().material.color = Color.cyan;
                    break;
                }
            case TypeCase.empty :
            default :
                {
                    break;
                }
        }
        this.posX = x;
        this.posY = y;
        this.type = type;
    }

    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
