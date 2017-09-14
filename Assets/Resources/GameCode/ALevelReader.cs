using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public abstract class ALevelReader {

    // Paramètres stockant la taille de la map lue
    public int mapX { get; set; }
    public int mapY { get; set; }
    public TypeCase[,] allTypes { get; set; }
    public static int nbTargets { get; set; }
    public static Case[,] map { get; set; }

    // Reader des maps qui se trouvent dans le dossier Levels
    public ALevelReader(int zone, int level)
    {
        try {
            string levelName = "Assets\\Resources\\Levels\\level" + zone + "-" + level + ".txt";
            System.IO.StreamReader file = new System.IO.StreamReader(levelName);
            parseMapSize(file); // Récupération de la taille de la map
            allTypes = parseMapTypes(file);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Le fichier de génération du niveau" + zone + "-" + level + " n'a pas été chargé\n" +
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
        nbTargets = 0;

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
                            nbTargets++;
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

    public abstract void generateMap();

}
