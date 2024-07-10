using System.Collections.Generic;
using UnityEngine;

public class ProgenTerrain : MonoBehaviour
{
    public int CunckSize;
    Terrain terrain; TerrainCollider terrain2;
    public GameObject prefab;
    public GameObject[] treePrefab;
    List<GameObject> trees = new List<GameObject>();
    public TerrainLayer[] Paint;
    int x, y;
    int cx, cy;
    float[,] CunckHeights;
    public Transform viwer;
    public Vector2Int offset;
    Vector2Int soffset;
    public Vector2 CanckPosition;
    void Start()
    {
        viwer = mover.main().transform;
        soffset = offset;
      
        transform.position = new Vector3(
            (((int)viwer.position.x + (soffset.x * CunckSize)) / CunckSize) * CunckSize,
            2000,
            (((int)viwer.position.z + (soffset.y * CunckSize)) / CunckSize) * CunckSize);
        Genarate();

    }
    void treeGen(float x, float y)
    {
        System.Random rand =new System.Random((int)x+(int)y);
        for (int i = 0; i < trees.Count; i++)
        {
            GameObject obj = trees[i];
            trees.Remove(obj);
            obj.AddComponent<DELETE>();
        }
        for (int i = 0; i < 6; i++)
        {
            foreach (GameObject tree in treePrefab)
            {
                Ray r = new Ray(transform.position + new Vector3(rand.Next(-500, 500), 0, rand.Next(-500, 500)), Vector3.down);

                if (Physics.Raycast(r, out RaycastHit hit))
                {

                   
                        GameObject obj = Instantiate(tree, hit.point, Quaternion.identity);
                        if (obj.GetComponent<MultyObject>())
                        {
                            MultyObject mo = obj.GetComponent<MultyObject>();
                            mo.startPosition.x = hit.point.x;
                            mo.startPosition.y = hit.point.y;
                            mo.startPosition.z = hit.point.z;
                        }
                        trees.Add(obj);
                   

                }
            }
        }
    }
    private void Genarate()
    {
      
        cx = (((int)transform.position.x) / CunckSize) * CunckSize;
        cy = (((int)transform.position.z) / CunckSize) * CunckSize;

        GameObject obj = Instantiate(prefab, new Vector3(cx - 500, 0, cy - 500), Quaternion.identity);
        obj.SetActive(true);
        terrain = obj.transform.GetComponent<Terrain>();
        terrain2 = obj.transform.GetComponent<TerrainCollider>();
        terrain.terrainData = new TerrainData()
        {
            heightmapResolution = 513,
            size = new Vector3(CunckSize, 2000, CunckSize),
            terrainLayers = Paint
        };
        x = 513;
        y = 513;
        CunckHeights = new float[x, y];
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                TerrainFunc(i, j);
                //CunckHeights[0, j] = 0;
                //CunckHeights[1, j] = 0;
                //CunckHeights[511, j] = 0;
                //CunckHeights[512, j] = 0;
                //CunckHeights[i, 0] = 0;
                //CunckHeights[i, 1] = 0;
                //CunckHeights[i, 511] = 0;
                //CunckHeights[i, 512] = 0;
            }
        }
        terrain.terrainData.SetHeights(0, 0, CunckHeights);
        terrain2.terrainData = terrain.terrainData;
        treeGen(cx, cy);
    }

    private void TerrainFunc(int i, int j)
    {
        float ix = (float)i / 512;
        ix *= CunckSize;
        float jy = (float)j / 512;
        jy *= CunckSize;
        CunckHeights[j, i] = Mathf.PerlinNoise((((float)ix / 20) + (cx / 20)) + 0.1242f, (((float)jy / 20) + (cy / 20)) + 0.1242f) / 100f;
        CunckHeights[j, i] += Mathf.PerlinNoise((((float)ix / 200) + (cx / 200)) + 0.1242f, (((float)jy / 200) + (cy / 200)) + 0.1242f) / 20f;
    }

    private void reGenarate()
    {
     
        cx = (((int)transform.position.x) / CunckSize) * CunckSize;
        cy = (((int)transform.position.z) / CunckSize) * CunckSize;

        terrain.transform.position = new Vector3(cx - 500, 0, cy - 500);


      
        x = 513;
        y = 513;
        CunckHeights = new float[x, y];
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                TerrainFunc(i, j);
                //CunckHeights[0, j] = 0;
                //CunckHeights[1, j] = 0;
                //CunckHeights[511, j] = 0;
                //CunckHeights[512, j] = 0;
                //CunckHeights[i, 0] = 0;
                //CunckHeights[i, 1] = 0;
                //CunckHeights[i, 511] = 0;
                //CunckHeights[i, 512] = 0;
            }
        }
        terrain.terrainData.SetHeights(0, 0, CunckHeights);
        terrain2.terrainData = terrain.terrainData;
        treeGen(cx / CunckSize, cy / CunckSize);
    }

    private void Update()
    {
        soffset = offset;
    
        transform.position = new Vector3(
            (((int)viwer.position.x + (soffset.x * CunckSize)) / CunckSize) * CunckSize,
            2000,
            (((int)viwer.position.z + (soffset.y * CunckSize)) / CunckSize) * CunckSize);
        cx = (((int)transform.position.x) / CunckSize) * CunckSize;
        cy = (((int)transform.position.z) / CunckSize) * CunckSize;
        
        CanckPosition = new Vector2(cx / CunckSize, cy / CunckSize);
        Ray r = new Ray(transform.position,Vector3.down);
      
        if (!Physics.Raycast(r,out RaycastHit hit))
        {
           
                reGenarate();
          

        }
      
    }

}
