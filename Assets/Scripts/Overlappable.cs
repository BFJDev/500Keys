using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Overlappable : MonoBehaviour
{
    public abstract void FileOverlapStarted();

    public abstract void FileOverlapEnded();

    public abstract void HandleOverlappingFileReleased(File file);
}
