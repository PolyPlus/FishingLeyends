using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticInfo 
{
    public static List<FishData> staticFishDataList;

    public static FishData[] staticFishData = null;

    public static int position;

    public static int[,] map;

    public static bool finishRoute = true;

    public static bool addRanking = false;

    public static string name;

    public static int tutorialID;

    //public static LinkedList<Vector3> indexPoints;

    public static List<RouteData> route;
    
    // Guardar en playerPrefs
    public static int monedas, nivelBarco = 1, maxAnzuelos = 3;
    // Actualizar en cada ruta
    public static int fishingScore, totalScore, numAnzuelos;

    public static Dictionary<int, bool> piscipedia;

    public static float probabilityByDistance;

    // Claves de Player Prefs
    public static string tutorialKey = "TutorialVisto", 
        monedasKey = "monedas", 
        nivelBarcoKey = "nivelBarco",
        maxAnzuelosKey = "maxAnzuelos",
        tutorialNavKey = "TutorialNavigationVisto",
        tutorialFishKey = "TutorialPescaVisto",
        tutorialShopKey = "TutorialTiendaVisto";

    // Peces
    public static string[] fishKeys = { 
        "Barracuda", "Caballito", "Cangrejo", 
        "Cirujano", "Estrella", "MantaRaya", 
        "Cometa", "PezEspada", "PezGlobo", 
        "PezPayaso", "PeligrosoKey", "Pulpo", 
        "Tiburon" };

    // Nombres escenas
    public static string navigationScene = "NavigationScene",
        tutorialScene = "TutorialScene",
        storyScene = "StoryScene",
        fishingScene = "FishingScene",
        shopScene = "ShopScene",
        startScene = "StartScene";
}
