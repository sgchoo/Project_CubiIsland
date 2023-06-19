using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBox : GravitySource
{
    [SerializeField] float gravity = 12.0f;

	[SerializeField] Vector3 boundaryDistance = new Vector3(1f, 1f, 1f);

	[SerializeField, Min(0f)] float innerDistance = 0f, innerFalloffDistance = 0f;

	[SerializeField, Min(0f)]
	float outerDistance = 0f, outerFalloffDistance = 0f;

	float innerFalloffFactor, outerFalloffFactor;

	public override Vector3 GetGravity (Vector3 position) {
		position =
			transform.InverseTransformDirection(position - transform.position);

		Vector3 vector = Vector3.zero;
		int outside = 0;
		if (position.x > boundaryDistance.x) {
			vector.x = boundaryDistance.x - position.x;
			outside = 1;
		}
		else if (position.x < -boundaryDistance.x) {
			vector.x = -boundaryDistance.x - position.x;
			outside = 1;
		}

		if (position.y > boundaryDistance.y) {
			vector.y = boundaryDistance.y - position.y;
			outside += 1;
		}
		else if (position.y < -boundaryDistance.y) {
			vector.y = -boundaryDistance.y - position.y;
			outside += 1;
		}

		if (position.z > boundaryDistance.z) {
			vector.z = boundaryDistance.z - position.z;
			outside += 1;
		}
		else if (position.z < -boundaryDistance.z) {
			vector.z = -boundaryDistance.z - position.z;
			outside += 1;
		}

		if (outside > 0) {
			float distance = outside == 1 ?
				Mathf.Abs(vector.x + vector.y + vector.z) : vector.magnitude;
			if (distance > outerFalloffDistance) {
				return Vector3.zero;
			}
			float g = gravity / distance;
			if (distance > outerDistance) {
				g *= 1f - (distance - outerDistance) * outerFalloffFactor;
			}
			return transform.TransformDirection(g * vector);
		}

		Vector3 distances;
		distances.x = boundaryDistance.x - Mathf.Abs(position.x);
		distances.y = boundaryDistance.y - Mathf.Abs(position.y);
		distances.z = boundaryDistance.z - Mathf.Abs(position.z);
		if (distances.x < distances.y) {
			if (distances.x < distances.z) {
				vector.x = GetGravityComponent(position.x, distances.x);
			}
			else {
				vector.z = GetGravityComponent(position.z, distances.z);
			}
		}
		else if (distances.y < distances.z) {
			vector.y = GetGravityComponent(position.y, distances.y);
		}
		else {
			vector.z = GetGravityComponent(position.z, distances.z);
		}
		return transform.TransformDirection(vector);
	}

	float GetGravityComponent (float coordinate, float distance) {
		if (distance > innerFalloffDistance) {
			return 0f;
		}
		float g = gravity;
		if (distance > innerDistance) {
			g *= 1f - (distance - innerDistance) * innerFalloffFactor;
		}
		return coordinate > 0f ? -g : g;
	}

	void Awake () {
		OnValidate();
	}

	void OnValidate () {
		boundaryDistance = Vector3.Max(boundaryDistance, Vector3.zero);
		float maxInner = Mathf.Min(
			Mathf.Min(boundaryDistance.x, boundaryDistance.y), boundaryDistance.z
		);
		innerDistance = Mathf.Min(innerDistance, maxInner);
		innerFalloffDistance =
			Mathf.Max(Mathf.Min(innerFalloffDistance, maxInner), innerDistance);
		outerFalloffDistance = Mathf.Max(outerFalloffDistance, outerDistance);

		innerFalloffFactor = 1f / (innerFalloffDistance - innerDistance);
		outerFalloffFactor = 1f / (outerFalloffDistance - outerDistance);
	}
}
