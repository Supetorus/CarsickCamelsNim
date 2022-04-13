using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Row : MonoBehaviour
{
	public List<Sprite> images = new List<Sprite>();

	public bool Remove()
	{
		images.RemoveAt(images.Count - 1);

		return images.Count == 0;
	}
}
