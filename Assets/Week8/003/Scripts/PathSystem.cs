using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathSystem : MonoBehaviour {

    public enum SeedType { RANDOM, CUSTOM }
    [Header("Random Related Stuff")]
    public SeedType seedType = SeedType.RANDOM;
    System.Random random;
    public int seed = 0;

    [Space]
    public bool animatedPath;
    public List<MyGridCell> gridCellList = new List<MyGridCell>();
    public int pathLength = 10;
    [Range(1.0f, 10.0f)]
    public float cellSize = 1.0f;

    public Transform startLocation;
    public GameObject mazePrefab;
    public GameObject[] powerups;

    // Start is called before the first frame update
    void Start() {
         SetSeed();

            if (animatedPath)
                StartCoroutine(CreatePathRoutine());
            else
                CreatePath();
        
        powerups = new GameObject[2];
        powerups[0]=GameObject.FindGameObjectWithTag("Bad");
        powerups[1]=GameObject.FindGameObjectWithTag("Good");        

    
        

    }

    void SetSeed() {
        if (seedType == SeedType.RANDOM) {
            random = new System.Random();
        }
        else if (seedType == SeedType.CUSTOM) {
            random = new System.Random(seed);
        }
    }

    void CreatePath() {

        gridCellList.Clear();
        Vector2 currentPosition = startLocation.transform.position;
        gridCellList.Add(new MyGridCell(currentPosition));

        for (int i = 0; i < pathLength; i++) {

            int n = random.Next(100);

            if (n.IsBetween(0, 49)) {
                currentPosition = new Vector2(currentPosition.x + cellSize, currentPosition.y);
            }
            else {
                currentPosition = new Vector2(currentPosition.x, currentPosition.y + cellSize);
            }

            gridCellList.Add(new MyGridCell(currentPosition));
            
             GameObject m = Instantiate(mazePrefab,gridCellList[i].location, Quaternion.identity);
             

        }
        for (int j=0; j<5; j++){
  
            GameObject p = Instantiate(powerups[Random.Range(0,2)],gridCellList[Random.Range(2,10)].location,Quaternion.identity);
        }
    }
  
    IEnumerator CreatePathRoutine() {

        gridCellList.Clear();
        Vector2 currentPosition = startLocation.transform.position;
        gridCellList.Add(new MyGridCell(currentPosition));

        for (int i = 0; i < pathLength; i++) {

            int n = random.Next(100);

            if (n.IsBetween(0, 49)) {
                currentPosition = new Vector2(currentPosition.x + cellSize, currentPosition.y);
            }
            else {
                currentPosition = new Vector2(currentPosition.x, currentPosition.y + cellSize);
            }

            gridCellList.Add(new MyGridCell(currentPosition));
            yield return null;
        }
    }



    private void OnDrawGizmos() {
        for (int i = 0; i < gridCellList.Count; i++) {
            Gizmos.color = Color.white;
            Gizmos.DrawWireCube(gridCellList[i].location, Vector3.one * cellSize);
            Gizmos.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            Gizmos.DrawCube(gridCellList[i].location, Vector3.one * cellSize);
        }
    }

    // Update is called once per frame
    void Update() {
     /*   if (Input.GetKeyDown(KeyCode.Space)) {
            SetSeed();

            if (animatedPath)
                StartCoroutine(CreatePathRoutine());
            else
                CreatePath();
        }*/
    }
}
