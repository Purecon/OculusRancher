using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Go To 3D")]
public class GoToBehavior3D : FilteredFlockBehavior3D
{
    public float radius = 2f;

    public FoodSO foodSO;

    public override Vector3 CalculateMove(FlockAgent3D agent, List<Transform> context, Flock3D flock)
    {
        //NOTE FILTER DOESNT WORK FOR DISTANCE OBJECT
        //List<Transform> filteredContext = (filter==null) ? context: filter.Filter(agent, context);
        //NOTE Can use SO
        //List<Transform> filteredContext = new List<Transform>(GameObject.FindGameObjectsWithTag("Food").Select(item => item.transform));
        List<Transform>  filteredContext = foodSO.foods;

        //if no neighbors, return no adjust
        if (filteredContext.Count == 0)
        {
            //Debug.Log("No food detected");
            return Vector3.zero;
        }

        //add all points together and average
        Vector3 goToMove = Vector3.zero;
        int nGoTo = 0;

        foreach (Transform item in filteredContext)
        {
            //Transform di pusat
            //Debug.Log("Food: "+item.gameObject.name);
            Transform centerTransform = item;
            Vector3 center = new Vector3(centerTransform.transform.position.x, centerTransform.transform.position.y, centerTransform.transform.position.z);
            Vector3 centerOffset = center - (Vector3)agent.transform.position;
            
            goToMove += (Vector3)(centerOffset);
            nGoTo++;
        }
        if(nGoTo > 0)
        {
            //avoidanceMove = avoidanceMove.normalized;
            goToMove /= nGoTo;
        }
        return goToMove;
    }
}
