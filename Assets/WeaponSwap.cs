using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
	float prevScrollDelta;
	float currentScrollDelta;
	public GameObject player;
	public List<GameObject> weapons;
	public byte activeWeapon = 0;

	private void Start()
	{
		prevScrollDelta = Input.mouseScrollDelta.magnitude;
	}
	void Update()
    {
		currentScrollDelta = Input.mouseScrollDelta.magnitude;
        if ((currentScrollDelta > prevScrollDelta || currentScrollDelta < prevScrollDelta))
		{
			SwapWeapon();
		}

    }

	void SwapWeapon()
	{
		if (weapons[0].activeSelf == false)
		{
			weapons[0].SetActive(true);
			weapons[1].SetActive(false);
			activeWeapon = 0;
		}
		else
		{
			weapons[0].SetActive(false);
			weapons[1].SetActive(true);
			activeWeapon = 1;
		}

	}
}
