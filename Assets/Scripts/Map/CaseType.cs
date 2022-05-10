using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseType 
{
    [System.Serializable]
    public struct TerrainType {
        public string name;
        public float height;
        public Color colour;
    }

    public static TerrainType[] DefaultTerrain()
    {
        TerrainType[] regions = new CaseType.TerrainType[7];
        regions[0].name = "Water";
        regions[0].height = 0.4f;
        regions[0].colour = new Color(18f/255f,55f/255f,255f/255f);
        regions[1].name = "Sand";
        regions[1].height = 0.45f;
        regions[1].colour = new Color(205f/255f,209f/255f,84f/255f);
        regions[2].name = "LowLand";
        regions[2].height = 0.51f;
        regions[2].colour = new Color(96f/255f,180f/255f,54f/255f);
        regions[3].name = "Land";
        regions[3].height = 0.7f;
        regions[3].colour = new Color(17f/255f,127f/255f,10f/255f);
        regions[4].name = "LowMountain";
        regions[4].height = 0.8f;
        regions[4].colour = new Color(205f/255f, 133f/255f, 63f/255f);
        regions[5].name = "Mountain";
        regions[5].height = 0.95f;
        regions[5].colour = new Color(47f/255f, 27f/255f, 12f/255f);
        regions[6].name = "Snow";
        regions[6].height = 1f;
        regions[6].colour = Color.white;
        return regions;
    }
}
