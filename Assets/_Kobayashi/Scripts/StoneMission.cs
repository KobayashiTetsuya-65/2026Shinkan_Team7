using DG.Tweening;
using UnityEngine;

public  class StoneMission : MissionObjectBase
{
    private Transform _tr;

    public override void CrearAnimation()
    {
        base.CrearAnimation();
        _tr = transform;
    }
}
