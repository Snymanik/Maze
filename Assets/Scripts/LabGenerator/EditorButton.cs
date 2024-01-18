using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.TerrainTools;
using Palmmedia.ReportGenerator.Core;

[CustomEditor(typeof(LevelGenerator))]
public class EditorButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelGenerator generator = (LevelGenerator)target;
        if(GUILayout.Button("Create Labyrinth"))
        {
            generator.generateLabyrinth();
        }
    }
    
        
}
