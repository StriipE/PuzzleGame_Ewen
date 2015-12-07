using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class LevelReader {

    // Paramètres stockant la taille de la map lue
    public int mapX { get; set; }
    public int mapY { get; set; }

    public TypeCase[,] allTypes { get; set; }

    public static Case[,] map { get; set; }

    // Reader des maps qui se trouvent dans le dossier Levels
    public LevelReader(int zone, int level)
    {
        try {
            string levelName = "Assets\\Levels\\level" + zone + "-" + level + ".txt";
            System.IO.StreamReader file = new System.IO.StreamReader(levelName);
            parseMapSize(file); // Récupération de la taille de la map
            allTypes = parseMapTypes(file);
            
            generateMap(); // Génération des cases de la map
        }
        catch (System.Exception e)
        {
            Debug.LogError("Le fichier de génération du niveau" + zone + "-" + level + "n'a pas été chargé\n" +
                            e.ToString());
        }

    }

    // Parse la première ligne du fichier pour en extraire la taille de la map
    private void parseMapSize(System.IO.StreamReader file)
    {
        string line = file.ReadLine();
        MatchCollection mapDimentions = Regex.Matches(line, @"(\d+)");
        mapX = System.Int32.Parse(mapDimentions[0].Value);
        mapY = System.Int32.Parse(mapDimentions[1].Value);
    }

    private TypeCase[,] parseMapTypes(System.IO.StreamReader file)
    {
        TypeCase[,] arrayTypes = new TypeCase[mapX, mapY];

        for (int i = 0; i < mapY; i++)
        {
            string line = file.ReadLine();
            int cpt = 0;
            foreach (char c in line)
            { 
                switch (c)
                {
                    case 'W':
                        {
                            arrayTypes[cpt, i] = TypeCase.wall;
                            break;
                        }
                    case 'T':
                        {
                            arrayTypes[cpt, i] = TypeCase.target;
                            break;
                        }
                    case 'E':
                    default:
                        {
                            arrayTypes[cpt, i] = TypeCase.empty;
                            break;
                        }      
                }
                cpt++;
            }
        }
        return arrayTypes;
    }

    private void generateMap()
    {
        Case[,] test = new Case[mapX, mapY];
        for (int y = 0; y < mapY; y++)
        {
            for (int x = 0; x < mapX; x++)
            {
                test[x,y] = new Case(x, y, allTypes[x,y]);
            }
        }
        map = test;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
