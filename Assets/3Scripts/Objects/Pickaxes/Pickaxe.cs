using UnityEngine;

public abstract class Pickaxe : MonoBehaviour
{
    [SerializeField]
    protected float attackPower;
    [SerializeField]
    protected float attackSpeed;
    [SerializeField]
    protected float attackRange;
    [SerializeField]
    protected int targetCount;
    [SerializeField]
    protected string type;
    public float GetAttackPower { get{return attackPower;} }
    public void AddAttackPower(float temp) => attackPower += temp;
    public float GetAttackSpeed { get{return attackSpeed;} }
    public void AddAttackSpeed(float temp) => attackSpeed += temp;
    public float GetAttackRange { get{return attackRange;} }
    public void AddAttackRange(float temp) => attackRange += temp;
    public int GetTargetCount { get{return targetCount;} }
    public void AddTargetCount(int temp) => targetCount += temp;
    public new string GetType() { return type; }

    public abstract float GetWidth {get; }
    public abstract void AddWidth(float temp);
}
