// static class with usefull functions
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Utils
{
    //thanks answer.unity
    public static T FindNearest<T>(Transform reference) where T : MonoBehaviour => FindNearest<T>(reference.position);

    //return the nearest T
    public static T FindNearest<T>(Vector3 reference) where T : MonoBehaviour
    {
        //get the list of T
        List<T> list = ( GameObject.FindObjectsOfType(typeof(T)) as T[] ).ToList();

        //sort by closest
        list.Sort(
        (x, y) =>
        ( x.transform.position - reference ).sqrMagnitude
        .CompareTo(( y.transform.position - reference ).sqrMagnitude));

        //return the first of default if none
        return list.FirstOrDefault();
    }

    //return the nearest T in range (included)
    public static T FindNearestInRange<T>(Transform reference, float range) where T : MonoBehaviour
    {
        T nearest = FindNearest<T>(reference.transform);

        if(nearest != null)
        {
            //check if in range
            return Vector3.Distance(nearest.transform.position, reference.position) <= range ? nearest : null;
        }
        return null;
    }
}