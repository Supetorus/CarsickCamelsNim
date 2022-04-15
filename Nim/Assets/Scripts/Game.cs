using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
	public GameObject row;
	public GameObject image;
	public GameObject button;
	public Transform buttonsPanel;
	private List<Row> rows = new List<Row>();
	private List<GameObject> buttons = new List<GameObject>();

	private int rowIndex = -1;

	private int diff;

	private void Awake()
	{
		foreach(Button b in buttonsPanel.GetComponentsInChildren<Button>())
		{
			b.gameObject.SetActive(false);
			buttons.Add(b.gameObject);
		}
	}

	public void NewGame()
    {
		StartGame(diff);
    }

	public void StartGame(int difficulty)
	{
		diff = difficulty;
		ResetGame();

		switch(difficulty)
		{
			default:
			case 0:
				SetUpRow(1);
				SetUpRow(3);
				SetUpRow(5);
				for (int i = 0; i < 3; ++i) { buttons[i].SetActive(true); }
				break;
			case 1:
				SetUpRow(1);
				SetUpRow(3);
				SetUpRow(5);
				SetUpRow(7);
				for (int i = 0; i < 4; ++i) { buttons[i].SetActive(true); }
				break;
			case 2:
				SetUpRow(3);
				SetUpRow(5);
				SetUpRow(7);
				SetUpRow(9);
				SetUpRow(11);
				for (int i = 0; i < 5; ++i) { buttons[i].SetActive(true); }
				break;
		}
	}

	private void ResetGame()
	{
		foreach(Row row in rows)
		{
			Destroy(row.gameObject);
		}

		foreach(GameObject b in buttons)
		{
			b.SetActive(false);
		}

		rows.Clear();
	}

	private void SetUpRow(int count)
	{
		Row newRow = Instantiate(row, transform).GetComponent<Row>();

		for (int i = 0; i < count; ++i)
		{
			newRow.images.Add(Instantiate(image, newRow.transform));
		}

		rows.Add(newRow);
	}

	public void EndTurn()
	{
		rowIndex = -1;
	}

	public void Remove(int index)
	{
		if(rowIndex == -1) { rowIndex = index; }

		if (rowIndex == index && rows[index].Remove())
		{
			rows[index].gameObject.SetActive(false);
			buttons[index].gameObject.SetActive(false);
		}
	}

    public void OnApplicationQuit()
    {
		Application.Quit();
    }
}
