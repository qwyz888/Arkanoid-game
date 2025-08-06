using UnityEngine;
using System.Collections.Generic;

public class SaveLevel
{
    public void Save( GameLevel gameLevel)
    {
       gameLevel.Blocks = new List<BlockObject>();

        BaseBlock[] baseBlocks = GameObject.FindObjectsByType<BaseBlock>(FindObjectsSortMode.None);

        foreach (var item in baseBlocks)
        {
            BlockObject blockObject = new BlockObject
            {
                position = item.gameObject.transform.position,
                Block = item.BlockData
            };


            gameLevel.Blocks.Add(blockObject);
            
        }
       
    }
}
