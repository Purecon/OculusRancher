using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Food/Foods")]
public class FoodSO : ScriptableObject
{
    public List<Transform> foods;

    public void FoodUpdate()
    {
        foods = new List<Transform>(GameObject.FindGameObjectsWithTag("Food").Select(item => item.transform));
    }
}
