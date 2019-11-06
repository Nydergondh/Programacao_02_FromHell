using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public Transform startPos;
    public Transform endPos;
    public Transform parentVehicles;

    public GameObject vehiclePrefab;
    private BoxCollider collider;


    public LayerMask vehicleLayer;

    public int maxTimeSpawn;
    public int vehicleCount = 0;
    public bool spawnPointIsFree = false;
    public int maxVehicles = 3;

    private float timeToSpawn;


    // Start is called before the first frame update
    void Awake() {
        collider = GetComponent<BoxCollider>();
    }
    void Start()
    {
        CreateCar();
    }
    
    void Update()
    {
        timeToSpawn -= Time.deltaTime;

        if (timeToSpawn < 0 && spawnPointIsFree && vehicleCount < maxVehicles)
        {
            SpawnCar();
        }
    }

    public void CreateCar() {
        GameObject vehicle = Instantiate(vehiclePrefab, startPos.position, Quaternion.identity, transform);
        vehicle.GetComponent<Car>().carSpawner = this; //checar se isso nao vai dar errado em runtime com a instancia de vehicle
        vehicleCount++;
    }

    private void OnTriggerExit(Collider other) {
        print(collider.gameObject.layer);
        if ((vehicleLayer & (1 << other.gameObject.layer)) != 0) {

            spawnPointIsFree = true;
        }
        
    }

    private void SpawnCar()
    {
        spawnPointIsFree = false;
        timeToSpawn = Random.Range(0.5f, maxTimeSpawn);

        CreateCar();
    }

}
