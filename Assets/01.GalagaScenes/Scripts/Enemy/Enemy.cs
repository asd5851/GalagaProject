using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Enemy
{
    public void Move();
    public void Attack();
    public void Die();
    public void SetTarget(Transform target_);

}
