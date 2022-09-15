using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFood : MonoBehaviour
{
    public FoodSO foodSO;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Monster")
        {
            Debug.Log("Eaten by " + collider.gameObject.name);
            this.gameObject.SetActive(false);
            foodSO.FoodUpdate();
            Destroy(gameObject);
        }
    }
}
