using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public FoodSO foodSO;
    public GameObject foodPrefab;
    public Transform foodSpawn;

    void Start()
    {
        foodSO.FoodUpdate();
    }

    public void SpawnFood()
    {
        Instantiate(foodPrefab, foodSpawn.position ,foodSpawn.rotation);
        foodSO.FoodUpdate();
    } 
}
