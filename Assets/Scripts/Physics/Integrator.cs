using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Integrator
{
    public static void ExplicitEuler(Body body, float dt)
    {
        body.acceleration = body.acceleration / body.mass;
        body.position = body.position + body.velocity * dt;
        body.velocity = body.velocity + body.acceleration * dt;

/*        body.position += body.velocity * dt;
        body.velocity += body.acceleration * dt;*/
    }

    public static void SemiImplicitEuler(Body body, float dt)
    {
        body.acceleration = body.acceleration / body.mass;
        body.velocity = body.velocity + body.acceleration * dt;
        body.position = body.position + body.velocity * dt;

        body.velocity += Force.ApplyDrag(body.velocity, body.drag) * dt;
    }
}
