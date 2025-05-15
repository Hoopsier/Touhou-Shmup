using Godot;
using System;
using System.Collections.Generic;
public abstract partial class EnemyShot : Resource
{
    public abstract IEnumerable<Vector2> shotStyle();
}
