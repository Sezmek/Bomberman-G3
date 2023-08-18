using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Animations start;
    public Animations middle;
    public Animations end;

    public void SetActiveAnimation(Animations animation)
    {
        start.enabled = animation == start;
        middle.enabled = animation == middle;
        end.enabled = animation == end;
    }

    public void SetDirection(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

}
