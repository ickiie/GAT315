using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulator : Singleton<Simulator>
{
	[SerializeField] IntData fixedFPS;
	[SerializeField] StringData fps;
	[SerializeField] List<Force> forces;

	//public List<Force> forces;

	public List<Body> bodies { get; set; } = new List<Body>();
	Camera activeCamera;

	float fixedDeltaTime;
	private float timeAccumulator;

	private void Start()
	{
		activeCamera = Camera.main;
		
	}

    private void Update()
    {
		fixedDeltaTime = 1 / fixedFPS.value;


		//Debug.Log(1.0f / Time.deltaTime);
		timeAccumulator += Time.deltaTime;

		fps.value = (1 / Time.deltaTime).ToString("F1");
		/*foreach(var body in bodies)
        {
			Integrator.SemiImplicitEuler(body, Time.deltaTime);
        }*/
		forces.ForEach(force => force.ApplyForce(bodies));

		while (timeAccumulator > fixedDeltaTime)
		{
			bodies.ForEach(body =>
			{
				Integrator.SemiImplicitEuler(body, Time.deltaTime);
			});

			timeAccumulator = timeAccumulator - fixedDeltaTime;
			bodies.ForEach(body => body.acceleration = Vector2.zero);
		}
		

		//gravity2 = new Vector2(0, gravity);


	}

    public Vector3 GetScreenToWorldPosition(Vector2 screen)
	{
		Vector3 world = activeCamera.ScreenToWorldPoint(screen);
		return world;
	}
}
