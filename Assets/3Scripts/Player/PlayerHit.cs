using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private float _timer = 0f;
    public Pickaxe _pickaxe;
    private PlayerController _lockManager => GetComponent<PlayerController>();
    private int _type;
    private bool _hitting = false;

    private void Update()
    {
        _timer -= Time.deltaTime;
        //_hitting = false;
        if(_pickaxe.GetType() == "cyclone")
            Cyclone(_pickaxe.GetAttackPower, _pickaxe.GetAttackRange, _timer);
        if(_pickaxe.GetType() == "ray") 
            Ray(_pickaxe.GetAttackPower, _pickaxe.GetAttackRange, _timer);
        if(_type == 1)
            _lockManager.LockRotation = true;
        else
            _lockManager.LockRotation = false;
    }
    private bool CheckTimer(float current, float max)
    {
        if(current < max) return false;
        return true;
    }

    private void RockHit(List <RaycastHit> _hitList, float _attackPower)
    {
        if(_hitList.Count == 0)
            return;
        int flag = -1;
        float min = 999f;
        for(int i = 0; i < _hitList.Count; i++)
            if(min > _hitList[i].distance)
            {
                flag = i;
                min = _hitList[i].distance;
            }
        if(!_hitList[flag].transform.gameObject.TryGetComponent<RocksStats>(out RocksStats _target))
            return;
        _target.AddHealth(-_attackPower);
        _timer = 1.0f / _pickaxe.GetAttackSpeed;
    }
    private void Ray(float _attackPower, float _attackRange, float _time)
    {
        if(CheckTimer(_time,0))
            return;
        _type = 2;
        _hitting = true;
        float width = 0.2f + _pickaxe.GetWidth / 100;

        Vector3 offsetDirection = new Vector3(0.1f,0f,0f);
        Vector3 _direction = transform.TransformDirection(Vector3.forward);
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        List <RaycastHit> hitList = new List<RaycastHit>();
        RaycastHit hit;

        Vector3 rightPoint = new Vector3(_direction.x + _direction.z, 0, _direction.z - _direction.x) - _direction;
        Vector3 leftPoint = new Vector3(_direction.x - _direction.z, 0, _direction.z + _direction.x) - _direction;

        leftPoint *= width;
        rightPoint *= width;

        if (Physics.Raycast(transform.position, _direction, out hit, _attackRange, layerMask))
            hitList.Add(hit);
        if (Physics.Raycast(transform.position + leftPoint, _direction, out hit, _attackRange, layerMask))
            hitList.Add(hit);
        if (Physics.Raycast(transform.position + rightPoint, _direction, out hit, _attackRange, layerMask))
            hitList.Add(hit);
        //Debug.DrawRay(transform.position + rightPoint, _direction * _attackRange, Color.yellow);
        //Debug.DrawRay(transform.position + leftPoint, _direction * _attackRange, Color.yellow);
        //Debug.DrawRay(transform.position, _direction * _attackRange, Color.yellow);
        
        RockHit(hitList, _attackPower);
    }
     private void Cyclone(float _attackPower, float _attackRange, float _time)
    {
        if(CheckTimer(_time,0))
            return;
        _type = 1;
        _hitting = true;

        float offset = 0f;
        Vector3 _direction = Vector3.forward;
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        List <RaycastHit> hitList = new List<RaycastHit>();
        RaycastHit hit; 
        for(int i = 0; i < 36; i++)
        {
            if(Physics.Raycast(transform.position, _direction, out hit, _attackRange, layerMask))
                hitList.Add(hit);
            //Debug.DrawRay(transform.position, _direction * _attackRange, Color.red);
            offset += Mathf.PI / 18;
            _direction = new Vector3(Mathf.Sin(offset), 0, Mathf.Cos(offset));
        }
    }
}
