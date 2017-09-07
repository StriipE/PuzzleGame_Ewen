using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

	private static int mapX;
	private static int mapY;
	// Use this for initialization
	void Start () {
        Generator generator = new Generator(1,2);
        setMapX(generator.mapX); setMapY(generator.mapY);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void setMapX(int newX)
	{
		Map.mapX = newX;
	}

	public static void setMapY(int newY)
	{
		Map.mapY = newY;
	}

	public static int getMapX()
	{
        return Map.mapX;
	}

	public static int getMapY()
	{
        return Map.mapY;
	}

}
