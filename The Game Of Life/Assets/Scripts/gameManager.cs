/// <summary>
/// Game manager.
/// Spawns cell and mananges the tik time
/// </summary>
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    [SerializeField]
    GameObject cellPrefab, panel;

    [SerializeField]
    Text stateText;

    [Header("Input no:")]
    [SerializeField]
    int row = 6;
    [SerializeField]
    int col=6;

    [Header("Time between each tik:")]
    [SerializeField]
    float tikInterval=0.1f;

    cellManager[][] cells;

    GridLayoutGroup layout;

    [Header("% Random to be alive")]
    [SerializeField]
    [Range(0f,100f)]
    float randomizeFrequency=50f;

    bool isPaused=true;
    // Start is called before the first frame update
    void Start()
    {
        //Extensibility
        layout = panel.GetComponent<GridLayoutGroup>();
        layout.cellSize = Vector2.one * Screen.height / row;

        if (row < col)
        {
            layout.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            layout.constraintCount = row;
        }else if (col < row)
        {
            layout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            layout.constraintCount = col;
        }

        //Init
        cells = new cellManager[row][];

        //Spawn cells
        for(int i = 0; i < row; i++)
        {
            cells[i] = new cellManager[col];
            for(int j = 0; j < col; j++)
            {
                GameObject temp = Instantiate(cellPrefab);
                temp.transform.SetParent(panel.transform);
                temp.transform.localScale = Vector3.one;
                cells[i][j] = temp.GetComponent<cellManager>();
            }
        }

        //Assigning Neighbors
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (i-1>=0&&j-1>=0)
                    cells[i][j].neighbors.Add(cells[i - 1][j - 1]);
                if (i-1>=0)
                    cells[i][j].neighbors.Add(cells[i - 1][j]);
                if (i+1<row)
                    cells[i][j].neighbors.Add(cells[i + 1][j]);
                if (i+1<row&&j-1>=0)
                    cells[i][j].neighbors.Add(cells[i + 1][j - 1]);

                if (i+1<row&&j+1<col)
                    cells[i][j].neighbors.Add(cells[i + 1][j + 1]);
                if (j-1>=0)
                    cells[i][j].neighbors.Add(cells[i][j - 1]);
                if (j+1<col)
                    cells[i][j].neighbors.Add(cells[i][j + 1]);
                if (i-1>=0&&j+1<col)
                    cells[i][j].neighbors.Add(cells[i - 1][j + 1]);
            }
        }

        //Start ticking
        StartCoroutine(globalTick());
    }

    IEnumerator globalTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(tikInterval);
            if (!isPaused)
            {
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        cells[i][j].tick();
                    }
                }
            }
        }
    }

    void Update()
    {
        //Pause/Play
        if (Input.GetKeyDown(KeyCode.Space))
        {
            toggleState();
        }
    }

    public void nextGeneration()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                cells[i][j].tick();
            }
        }
    }

    public void toggleState()
    {
        isPaused = !isPaused;
        stateText.text = isPaused ? "Paused" : "Play";
    }

    public void randomizeGrid()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                cells[i][j].willBeAlive(randomizeFrequency / 100f);
            }
        }
    }

    private void OnApplicationQuit()
    {
        StopAllCoroutines();
    }
}
