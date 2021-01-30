using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : Overlappable
{
    public override void FileOverlapStarted()
    {

    }

    public override void FileOverlapEnded()
    {

    }

    public override void HandleOverlappingFileReleased(File file)
    {
        file.gameObject.SetActive(false);
    }
}
