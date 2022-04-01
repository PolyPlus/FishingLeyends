using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmManager : MonoBehaviour
{
    public bool started = false;
    public float initSpeed = 200;
    public float speed;
    public GameObject latIz;
    public GameObject latDer;
    public GameObject bait;
    public GameObject pez;
    public float tiempoAparicion;
    public GameObject panelRitmo;

    

    public int size = 0; //3: GRANDE, 2: MEDIANO, 1: PEQUE
    
    private int score;
    private bool isActive = false;
    private GameObject[] fish;
    private float timeFish = 0;
    private int currentFish;
    private int lastFish = 0;
    private BaitStateManager baitManager;

    public BaitStateManager BaitManager { get => baitManager; set => baitManager = value; }

    private void Start()
    {        
        ResetSpeed();
        startFishing();
    }
    //Si empiezas a pescar, para todo el combo completo
    public void startFishing()
    {       
        pez.GetComponent<RythmFish>().Init(this, latIz, latDer, speed);
    }
    //Si pica pez
    public void startRythmGame(int numFish)
    {
        score = 0;
        size = numFish;
        lastFish = 0;
        currentFish = lastFish;
        timeFish = 0;
        fish = new GameObject[size];
        panelRitmo.SetActive(true);
        isActive = true;
        speed += 50;
        pez.GetComponent<RythmFish>().speed = speed;

    }
    //Cada PEZ que aparece seg�n el tama�o, dentro del combo
    public void spawnFish()
    {
        //GameObject newFish;
        GameObject newFish = Instantiate(pez) as GameObject;
        int randomChance = Random.Range(1, 101); //Crea un valor aleatorio del 1 al 100      
        if (randomChance <= 50)
        {
            newFish.transform.SetParent(latDer.transform, false);
        }
        else
        {
            newFish.transform.SetParent(latIz.transform, false);
        }
        newFish.GetComponent<RythmFish>().Init(this, latIz, latDer, speed);

        timeFish = Time.time;
        fish[lastFish] = newFish;
        started = true;
    }

    public void OnPointerPress(Vector2 position)
    {
        int value;
        RythmFish rythmFish = fish[currentFish].GetComponent<RythmFish>();
        bool right = rythmFish.right;      
        if (position.x < Screen.width / 2 && !right)
        {
            value = checkDistance();
        }
        else if (position.x >= Screen.width / 2 && right)
        {
            value = checkDistance();
        }
        else
        {
            value = 0;
        }

        if (value == 0)
        {
            ResetCombo();
            stopRythmGame(true);
            return;
        }
        score += value;
        Destroy(fish[currentFish]);
        ++currentFish;
        if (currentFish >= size)
        {
            stopRythmGame(false);
        }
    }

    private int checkDistance()
    {
        float distance = Mathf.Abs(fish[currentFish].transform.position.x - bait.transform.position.x);
        if (distance <= 10.0f)
        {
            Debug.Log("EXCELENTE");
            return 2;
        }
        else if (distance <= 20.0f)
        {
            Debug.Log("BIEN");
            return 1;
        }
        else
        {
            Debug.Log("MAL");
            return 0;
        }       
    }

    public void stopRythmGame(bool comboFailed)
    {
        started = false;
        panelRitmo.SetActive(false);
        isActive = false;
        for (int i = currentFish; i < fish.Length; ++i)
            Destroy(fish[i]);
        if (comboFailed) size = 0;
        BaitManager.StopRythmGame(comboFailed, score);
    }

    public void ResetSpeed()
    {
        speed = initSpeed;
    }

    public void ResetCombo()
    {
        score = 0;
        size = 0;
        speed = initSpeed;
    }

    private void FixedUpdate()
    {
        if (isActive && (lastFish < fish.Length) && (Time.time - timeFish > tiempoAparicion))
        {
            spawnFish();
            ++lastFish;
        }
    }
}
