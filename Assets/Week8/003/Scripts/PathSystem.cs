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
    public List<MyGridCell> UpBorderList = new List<MyGridCell>();
    public List<MyGridCell> DownBorderList = new List<MyGridCell>();
    
    public int pathLength = 10;
    [Range(1.0f, 10.0f)]
    public float cellSize = 1.0f;
    public float offset = 1.0f;

    public Transform startLocation;
    public Transform UpLocation;
    public Transform DownLocation;
    public GameObject mazePrefab;
    public GameObject maze2Prefab;
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

        UpBorderList.Clear();
        DownBorderList.Clear();
        gridCellList.Clear();
        Vector2 currentPosition = startLocation.transform.position;
        Vector2 UpPosition = UpLocation.transform.position;
        Vector2 DownPosition = DownLocation.transform.position;
        gridCellList.Add(new MyGridCell(currentPosition));
        UpBorderList.Add(new MyGridCell(UpPosition));
        DownBorderList.Add(new MyGridCell(DownPosition));

        //Original path
        for (int i = 0; i < 10; i++) {

            int n = random.Next(100);

            if (n.IsBetween(0, 49)) {
                currentPosition = new Vector2(currentPosition.x + cellSize, currentPosition.y);
                UpPosition = new Vector2(UpPosition.x + cellSize, UpPosition.y );
                DownPosition = new Vector2(DownPosition.x + cellSize, DownPosition.y);

            }
            else {
                currentPosition = new Vector2(currentPosition.x, currentPosition.y + cellSize);
                UpPosition = new Vector2(UpPosition.x , UpPosition.y + cellSize);
                DownPosition = new Vector2(DownPosition.x , DownPosition.y + cellSize);
            }

             gridCellList.Add(new MyGridCell(currentPosition));  
             UpBorderList.Add(new MyGridCell(UpPosition));
             DownBorderList.Add(new MyGridCell(DownPosition));

             GameObject r = Instantiate(mazePrefab,gridCellList[i].location, Quaternion.identity);
             GameObject m = Instantiate(maze2Prefab,UpBorderList[i].location, Quaternion.identity);
             GameObject o = Instantiate(maze2Prefab,DownBorderList[i].location,Quaternion.identity);
        }
        //powerups
        for (int j=0; j<5; j++){
  
            GameObject p = Instantiate(powerups[Random.Range(0,2)],gridCellList[Random.Range(2,10)].location,Quaternion.identity);
        }

        //UpBorder
       /* for (int k = 0; k < pathLength; k++){

            int o = random.Next(100);
            
            if (o.IsBetween(0,49)){
                UpPosition = new Vector2(UpPosition.x + cellSize, UpPosition.y);
            }
            else{
                UpPosition = new Vector2(UpPosition.x, UpPosition.y +cellSize);
            }

            UpBorderList.Add(new MyGridCell(UpPosition));
            GameObject m = Instantiate(mazePrefab,gridCellList[k].location , Quaternion.identity);
            
        }

        for (int l = 0; l < pathLength; l++){

            int q = random.Next(100);
               
            if (q.IsBetween(0,49)){
                DownPosition = new Vector2(DownPosition.x + cellSize, DownPosition.y);
            }
            else{
                DownPosition = new Vector2(DownPosition.x, DownPosition.y +cellSize);
            }

            DownBorderList.Add(new MyGridCell(DownPosition));
            GameObject m = Instantiate(mazePrefab,gridCellList[l].location, Quaternion.identity);

        }*/
    }
  
    IEnumerator CreatePathRoutine() {

        gridCellList.Clear();
        Vector2 currentPosition = startLocation.transform.position;
        gridCellList.Add(new MyGridCell(currentPosition));

        for (int i = 0; i < 10; i++) {

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
