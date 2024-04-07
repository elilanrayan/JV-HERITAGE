using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewAttackDatabase", menuName = "Database/Attack", order = 0)]
public class AttackDataBase : ScriptableObject
{
    public List<AttackData> datas=new(); 
}
