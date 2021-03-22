using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DaySystem : MonoBehaviour
{
	public float fullDay = 120f;
	[Range(0, 1)] public float currentTime;

	void Update()
	{
		currentTime += Time.deltaTime / fullDay;
		if (currentTime >= 1) currentTime = 0; else if (currentTime < 0) currentTime = 0;
		transform.localRotation = Quaternion.Euler((currentTime * 360f) - 90, 170, 0);
	}
}