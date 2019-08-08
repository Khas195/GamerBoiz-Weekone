using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontBackSortingManager : MonoBehaviour
{
    [SerializeField]
    List<FrontBackSorting> sortingObjects;
    [SerializeField]
    Transform character;
    // Start is called before the first frame update
    void Start()
    {
        var sortingList = GameObject.FindObjectsOfType<FrontBackSorting>();
        foreach (var sortingTarget in sortingList)
        {
            sortingObjects.Add(sortingTarget);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var target in sortingObjects)
        {
            var pos = target.GetHostPosition();
            if (character.position.y > pos.y)
            {
                pos.z = character.position.z - 1;
            }
            else if (character.position.y < pos.y)
            {
                pos.z = character.position.z + 1;
            }
            else
            {
                pos.z = character.position.z;
            }
            target.SetHostPosition(pos);
        }
    }
}
