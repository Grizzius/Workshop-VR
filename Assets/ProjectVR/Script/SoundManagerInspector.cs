using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(SoundManagerScript))]
public class SoundManagerInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
    }
}
