using UnityEngine;

public class RayPickaxe : Pickaxe
{
    [SerializeField]
    protected float width;

    public override float GetWidth { get{return width;} }
    public override void AddWidth(float temp) => width += temp; 
}
