using MoonSharp.Interpreter;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LuaTerrain : InventoryEvent
{
    string code;
    public InputField ifd;
    string codepath;

    public itemName itemName;
    // Start is called before the first frame update

    public void Load1()
    {
        if (itemName)
        {

            codepath = itemName.ItemData;

            if (string.IsNullOrEmpty(codepath))
            {

                codepath = "res/scripts/Terrain.lua";
                itemName.ItemData = codepath;
            }
            code = File.ReadAllText(codepath);

        }
        ifd.text = codepath;
    }
    public int CunckSize;
    Terrain terrain; TerrainCollider terrain2;
    public GameObject prefab;
    public TerrainLayer[] Paint;
    public Generator_terrain test;
    int x, y;
    int cx, cy;
    float[,] CunckHeights;
    public Transform viwer;
    public Vector2Int offset;
    Vector2Int soffset;
    public Vector2 CanckPosition;
    void Start()
    { //  code = File.ReadAllText("res/scripts/Jump.lua");
        if (Map_saver.LoadADone) if (itemName)
            {

                codepath = itemName.ItemData;

                if (string.IsNullOrEmpty(codepath))
                {

                    codepath = "res/scripts/Terrain.lua";
                    itemName.ItemData = codepath;
                }
                code = File.ReadAllText(codepath);

            }
        ifd.text = codepath;
        viwer = transform;
        soffset = offset;

        transform.position = new Vector3(
            (((int)viwer.position.x + (soffset.x * CunckSize)) / CunckSize) * CunckSize,
            2000,
            (((int)viwer.position.z + (soffset.y * CunckSize)) / CunckSize) * CunckSize);
        Genarate();
        test.enabled = true;
        test.Start();
    }

    private void Genarate()
    {

        cx = (((int)transform.position.x) / CunckSize) * CunckSize;
        cy = (((int)transform.position.z) / CunckSize) * CunckSize;

        GameObject obj = prefab;
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
       
                TerrainFunc(cx, cy);
                //CunckHeights[0, j] = 0;
                //CunckHeights[1, j] = 0;
                //CunckHeights[511, j] = 0;
                //CunckHeights[512, j] = 0;
                //CunckHeights[i, 0] = 0;
                //CunckHeights[i, 1] = 0;
                //CunckHeights[i, 511] = 0;
                //CunckHeights[i, 512] = 0;
      
        terrain.terrainData.SetHeights(0, 0, CunckHeights);
        terrain2.terrainData = terrain.terrainData;

    } float timer = 0;
    int patrn = 0;
    float[,] JumpLogic(string scriptCode,float x,float y)
    {
        timer += Time.deltaTime;
        float[,] sdf = new float[513, 513];
        UserData.RegisterType<float[,]>();
        Script script = new Script();
        script.Globals["out"] = sdf;
        script.Globals["x"] = x;
        script.Globals["y"] = y;
        script.DoString(scriptCode);

        DynValue luaFactFunction = script.Globals.Get("GetTexture");

        DynValue res = script.Call(luaFactFunction, (double)timer);
     

        return (float[,])res.UserData.Object;
    }
    private void TerrainFunc(int i, int j)
    {
        
        CunckHeights = JumpLogic(code,i,j);
        
    }

    private void reGenarate()
    {

        cx = (((int)transform.position.x) / CunckSize) * CunckSize;
        cy = (((int)transform.position.z) / CunckSize) * CunckSize;

        terrain.transform.position = new Vector3(cx - 500, 0, cy - 500);



        x = 513;
        y = 513;
        CunckHeights = new float[x, y];

        TerrainFunc(cx, cy);
        //CunckHeights[0, j] = 0;
        //CunckHeights[1, j] = 0;
        //CunckHeights[511, j] = 0;
        //CunckHeights[512, j] = 0;
        //CunckHeights[i, 0] = 0;
        //CunckHeights[i, 1] = 0;
        //CunckHeights[i, 511] = 0;
        //CunckHeights[i, 512] = 0;

        terrain.terrainData.SetHeights(0, 0, CunckHeights);
        terrain2.terrainData = terrain.terrainData;
       
    }

    private void Update()
    {
        if (itemName) itemName.ItemData = ifd.text;
        soffset = offset;

        transform.position = new Vector3(
            (((int)viwer.position.x + (soffset.x * CunckSize)) / CunckSize) * CunckSize,
            2000,
            (((int)viwer.position.z + (soffset.y * CunckSize)) / CunckSize) * CunckSize);
        cx = (((int)transform.position.x) / CunckSize) * CunckSize;
        cy = (((int)transform.position.z) / CunckSize) * CunckSize;

        CanckPosition = new Vector2(cx / CunckSize, cy / CunckSize);
        Ray r = new Ray(transform.position, Vector3.down);

        if (!Physics.Raycast(r, out RaycastHit hit))
        {

            reGenarate();


        }

    }
}
