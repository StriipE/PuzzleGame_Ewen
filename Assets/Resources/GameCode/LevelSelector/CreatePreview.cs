using UnityEngine;
using System.Collections;
using System;
using System.Linq;

public class CreatePreview : ALevelReader
{

    private static int PreviewX = 80;
    private static int PreviewY = 80;
    private Texture2D _texturePreview;
    public Texture2D TexturePreview { get; set; }
    // Crée une texture de preview pour la map du niveau x/y
    public CreatePreview(int x, int y) : base(x, y)
    {
        generateMap();
    }

    public override void generateMap()
    {
        Texture2D tempTexture = new Texture2D(PreviewX, PreviewY);
        Color selectedColor = new Color();

        for (int y = 0; y < mapY; y++)
        {
            for (int x = 0; x < mapX; x++)
            {
                switch (allTypes[x, y])
                {

                    case TypeCase.block:
                        {
                            selectedColor = Color.yellow;
                            break;
                        }
                    case TypeCase.wall:
                        {
                            for (int i = 0; i < PreviewX * PreviewY; i++)
                            {
                                selectedColor = Color.red;
                            }
                            break;
                        }
                    case TypeCase.target:
                        {
                            for (int i = 0; i < PreviewX * PreviewY; i++)
                            {
                                selectedColor = Color.cyan;
                            }
                            break;
                        }
                    case TypeCase.good:
                        {
                            selectedColor = Color.green;
                            break;
                        }
                    case TypeCase.empty:
                    default:
                        {
                            selectedColor = Color.white;
                            break;
                        }
                }

                Color[] tempColor = Enumerable.Repeat(selectedColor, PreviewX * PreviewY).ToArray();

                tempTexture.SetPixels(x * (PreviewX / mapX), y * (PreviewY / mapY), // Position du point
                                     (PreviewX / mapX), (PreviewY / mapY), tempColor);  // Taille X/Y + couleur
                tempTexture.Apply();
            }
        }

        TexturePreview = tempTexture;
    }
}
