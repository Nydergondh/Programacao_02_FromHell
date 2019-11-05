using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public Transform startPos;
    public Transform endPos;

    public GameObject vehicle;
    private BoxCollider collider;

    public LayerMask vehicleLayer;

    public int vehicleCount = 0;
    private int maxVehicles = 3;

    // Start is called before the first frame update
    void Awake() {
        collider = GetComponent<BoxCollider>();
    }
    void Start()
    {
        CreateCar();
    }

    public void CreateCar() {
        vehicle = Instantiate(vehicle, startPos.position, Quaternion.identity, transform);
        vehicle.GetComponent<Car>().carSpawner = this; //checar se isso nao vai dar errado em runtime com a instancia de vehicle
        vehicleCount++;
    }
    private void OnTriggerExit(Collider other) {
        print(collider.gameObject.layer);
        if (other.gameObject.layer == 9) {

            if (vehicleCount < maxVehicles) {
                CreateCar();
            }
        }
        
    }

}
