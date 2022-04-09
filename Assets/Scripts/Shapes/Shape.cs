using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shape : MonoBehaviour
{
    public abstract float size { get; set; }
    public abstract float area { get; }

    public float mass => area;
    public float density { get; set; } = 1;
}
