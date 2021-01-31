using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// Fake File Manager that uses Unity's built in hiearchy system 
/// 
/// Of note: 
/// </summary>
public class FileManager : MonoBehaviour
{
    Transform currFolder = null;
    Transform root = null;
    Transform desktop = null;

    public void Start()
    {
        desktop = GameObject.Find("Desktop").GetComponent<Transform>();
        root = GameObject.Find("Root").GetComponent<Transform>();
        currFolder = root;
    }

    public void ChangeLevel(Transform newFolder)
    {
        // Hide current level
        HideCurrFolder();
        // Display new level
        if(!newFolder.Equals(root))
        {
            DisplayNewFolder(newFolder);
        } else {
            DisplayRoot();
        }
        // Update reference
        currFolder = newFolder;
    }

    public void GoUpOneLevel()
    {
        if (!currFolder.Equals(root))
        {
            ChangeLevel(currFolder.parent.transform);
        }
    }

    public void MoveToDesktop(GameObject obj)
    {
        // This method is the same as setting the transform.parent property 
        // except that it also lets the Transform keep its local orientation rather than its global orientation.
        obj.transform.SetParent(desktop);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////

    // Deactivate all the files in the current level
    private void HideCurrFolder()
    {
        foreach (Transform child in currFolder)
        {
            child.gameObject.SetActive(false);
        }
    }

    // Make all children of the new level active
    private void DisplayNewFolder(Transform folder)
    {
        // Need to make base folder active for children, but also hide it's image/text
        folder.gameObject.SetActive(true);
        
        // Set each child in the first depth to active
        for(var i = 0; i < folder.childCount; i++)
        {
            Transform child = folder.GetChild(i);
            child.gameObject.SetActive(i > 1); // Set to TRUE if it's not the image/text of the curr folder
            
            // Now make sure you show the image/text of each child
            if (child.childCount > 0)
            {
                child.GetChild(0).gameObject.SetActive(true);
                Image img = child.GetChild(0).GetComponent<Image>();
                if (img != null)
                {
                    img.enabled = true;
                }

                

                child.GetChild(1).gameObject.SetActive(true);
                child.GetChild(1).GetComponent<Text>().enabled = true;
            }
        }
    }

    // Same as DisplayNewFolder except it doesn't have to worry about the first 2 children
    private void DisplayRoot()
    {
        foreach (Transform child in root)
        {
            child.gameObject.SetActive(true);
            // Now make sure you show the image/text of each child
            if (child.childCount > 0)
            {
                child.GetChild(0).gameObject.SetActive(true);
                child.GetChild(0).GetComponent<Image>().enabled = true;

                child.GetChild(1).gameObject.SetActive(true);
                child.GetChild(1).GetComponent<Text>().enabled = true;
            }
        }
    }
}

