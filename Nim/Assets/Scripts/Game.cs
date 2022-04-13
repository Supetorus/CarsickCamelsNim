using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
	public GameObject row;
	public GameObject image;
	List<Row> rows = new List<Row>();

	public void StartGame(int difficulty)
	{
		ResetGame();

		switch(difficulty)
		{
			default:
			case 0:
				SetUpRow(1);
				SetUpRow(3);
				SetUpRow(5);
				break;
			case 1:
				SetUpRow(1);
				SetUpRow(3);
				SetUpRow(5);
				SetUpRow(7);
				break;
			case 2:
				SetUpRow(3);
				SetUpRow(5);
				SetUpRow(7);
				SetUpRow(9);
				SetUpRow(11);
				break;
		}
	}

	private void ResetGame()
	{
		foreach(Row row in rows)
		{
			Destroy(row.gameObject);
		}
		
		rows.Clear();
	}

	private void SetUpRow(int count)
	{
		Row newRow = Instantiate(row, transform).GetComponent<Row>();

		for (int i = 0; i < count; ++i)
		{
			newRow.images.Add(Instantiate(image, newRow.transform).GetComponent<Sprite>());
		}

		rows.Add(newRow);
	}

	public void Remove(int index)
	{
		rows[index].gameObject.SetActive(false);
	}
}
