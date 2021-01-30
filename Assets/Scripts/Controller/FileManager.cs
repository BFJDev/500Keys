using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    Transform currLevel = null;
    Transform root = null;
    Transform desktop = null;

    public void Start()
    {
        desktop = GameObject.Find("Desktop").GetComponent<Transform>();
        root = GameObject.Find("Root").GetComponent<Transform>();
        currLevel = root;
    }

    public void ChangeLevel(Transform folder)
    {
        // Display new level
        DisplayFolder(folder);
        // Hide previous 
        HideFolder(folder); // Note: z-order won't really matter since we're only switching b/w 2 views
        // Update reference
        currLevel = folder;
    }

    // Make all children of selected level active
    public void DisplayFolder(Transform folder)
    {
        foreach (Transform child in folder)
        {
            child.gameObject.SetActive(true);
            // Make sure file name gets shown
            if (child.childCount > 0)
            {
                child.GetChild(0).gameObject.SetActive(true); 
            }           
        }
    }

    // Deactivate all the files in the current level EXCEPT the one we just opened
    public void HideFolder(Transform folderToSkip)
    {
        foreach (Transform child in currLevel)
        {
            if(!child.transform.Equals(folderToSkip))
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void MoveToDesktop(GameObject obj) { 
        // This method is the same as setting the transform.parent property 
        // except that it also lets the Transform keep its local orientation rather than its global orientation.
        obj.transform.SetParent(desktop);
    }
}

