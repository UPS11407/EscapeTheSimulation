using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPivot : MonoBehaviour
{
	Transform gunParent;
	Transform pivot;

	public GameObject gun;
	bool gunIsFlipped;
	bool updatedRotation;

	void Start()
	{
		gunParent = GameObject.Find("GunHolder").gameObject.transform;
		pivot = gunParent.transform;
		transform.parent = pivot;
		transform.position += Vector3.up * 0;
	}

	void Update()
	{
		Vector3 gunVector = Camera.main.WorldToScreenPoint(gunParent.position);
		gunVector = Input.mousePosition - gunVector;
		float angle = Mathf.Atan2(gunVector.y, gunVector.x) * Mathf.Rad2Deg;

		pivot.position = gunParent.position;
		pivot.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

		if (gunParent.rotation.eulerAngles.z < 180)
		{
			gun.transform.rotation = Quaternion.Euler(0, 180, -angle + 180);
		}
		else
		{
			gun.transform.rotation = Quaternion.Euler(0, 0, angle);
		}
	}
}