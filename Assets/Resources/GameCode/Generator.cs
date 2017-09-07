using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Generator : ALevelReader
{
    public Generator(int x, int y) : base(x, y)
    {
        generateMap();
    }

    public override void generateMap()
    {
        Case[,] test = new Case[mapX, mapY];
        for (int y = 0; y < mapY; y++)
        {
            for (int x = 0; x < mapX; x++)
            {
                test[x, y] = new Case(x, y, allTypes[x, y]);
            }
        }
        map = test;
    }
}

