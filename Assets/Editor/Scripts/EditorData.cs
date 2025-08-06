using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "EditorData", menuName = "EditorData/Create/Data")]
public class EditorData:ScriptableObject
{
    public List<EditorBlockData> BlockDatas = new List<EditorBlockData>();
}

[System.Serializable]
public class EditorBlockData
{
    public Texture2D Texture2D;
    public BlockData BlockData;
}