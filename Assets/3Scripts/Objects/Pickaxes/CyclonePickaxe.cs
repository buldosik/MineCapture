using UnityEngine;

public class CyclonePickaxe : Pickaxe
{
    public override float GetWidth {get{ throw new System.Exception("Class CyclonePickaxe not realise this function"); } }
    public override void AddWidth(float temp) => throw new System.Exception("Class CyclonePickaxe not realise this function"); 
}
