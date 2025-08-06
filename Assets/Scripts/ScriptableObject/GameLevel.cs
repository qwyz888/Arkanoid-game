using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Levels", menuName = "GameData/Create/Gamelevel")]
public class GameLevel: ScriptableObject
{
    public List<BlockObject> Blocks = new List<BlockObject>();
    public List<BonusAttach> Bonuses = new List<BonusAttach>();
}

[System.Serializable]
public class BlockObject
{
    public Vector3 position;
    public BlockData Block;
}
