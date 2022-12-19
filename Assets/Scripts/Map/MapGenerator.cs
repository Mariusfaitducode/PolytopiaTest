using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    
    public enum DrawMode {NoiseMap, ColourMap};
    public DrawMode drawMode;
    public int mapWidth = Constants.MapSize_1;
    public int mapHeight = Constants.MapSize_1;
    public float noiseScale;

    public int octaves;
    [Range(0,1)]
    public float persistance;
    public float lacunarity;

    public int seed;
    public Vector2 offset;

    public CaseType.TerrainType[] regions;

    public PlateauJeu plateau;
    
    private System.Random ran = new System.Random();

    public InitTerrain terrain;
    

    public int level;

    /*MapGenerator()
    {
        drawMode = DrawMode.ColourMap;
        mapWidth = Constants.MapWidth;
        mapHeight = Constants.MapHeight;
        noiseScale = 25;
        octaves = 5;
        persistance = 0.5f;
        lacunarity = 1.94f;
        seed = 32;
        offset = new Vector2(-0.43f, 2.8f);
        regions = CaseType.DefaultTerrain();
        
        public void Start()
    {
        terrain = FindObjectOfType<InitTerrain> ();
    }
    }*/
    public void Start()
    {
        int size = Constants.GetConstant(level);
        print(size);

        mapWidth = size;
        mapHeight = size;
    }


    public void GenerateMap(){
        
        float[,] noiseMap = Noise.GenerateNoiseMap (mapWidth, mapHeight, noiseScale, seed, octaves, persistance, lacunarity, offset);
        
        Color[] colourMap = new Color[mapWidth * mapHeight];
        for ( int y = 0; y < mapWidth; y++){
            for ( int x = 0; x < mapHeight; x++){
                float currentHeight = noiseMap [x, y];
                for (int i = 0; i < regions.Length; i++){
                    if (currentHeight <= regions[i].height){
                        colourMap [y * mapWidth + x] = regions[i].colour;
                        break;
                    }
                }
            }
        }
        MapDisplay display = FindObjectOfType<MapDisplay> ();
        if (drawMode == DrawMode.NoiseMap){
            display.DrawTexture (TextureGenerator.TextureFromHeightMap(noiseMap));
        }
        else if (drawMode == DrawMode.ColourMap){
            display.DrawTexture (TextureGenerator.TextureFromColourMap(colourMap, mapWidth, mapHeight));
        }
        /*else if (drawMode == DrawMode.Map3d)
        {
            Generate3dMap();
        }*/
    }

    public void Generate3dMap(bool rand, int level)
    {
        if (rand)
        {
            seed = ran.Next(0, 100);
        }
        int size = Constants.GetConstant(level);
        print(size);

        mapWidth = size;
        mapHeight = size;

        float[,] noiseMap = Noise.GenerateNoiseMap (mapWidth, mapHeight, noiseScale, seed, octaves, persistance, lacunarity, offset);
        
        print("length noise");
        print(noiseMap.Length);
        terrain.GenerateTerrain(noiseMap, regions, level);
        
    }
    void OnValidate(){
        if (mapWidth < 1){
            mapWidth = 1;
        }
        if (mapHeight < 1){
            mapHeight = 1;
        }
        if (lacunarity < 1){
            lacunarity = 1;
        }
        if (octaves < 0){
            octaves = 0;
        }
    }
}


