using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum WorkType
{
    Worker,director,CraftTable,DirectorTable
}

public class WorkOrganisation : MonoBehaviour
{
    public WorkType workType;
    bool isWorkOrganisation = false;
    public WorkTerritory workter;
    public int CashFlow;
  public  bool IsTaking;
    string TakingSpace;
    void Start()
    {
        
            TakingSpace = Map_saver.total_lif + SceneManager.GetActiveScene().buildIndex;
        IsTaking = VarSave.GetFloat(TakingSpace + "TakingVin") == 2;
        if (workType == WorkType.DirectorTable)
        {

            InvokeRepeating("Math", 2, 99999999);
        }
        }
        void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<WorkTerritory>() && !isWorkOrganisation)
        {
            if (workType == WorkType.Worker)
            {
                other.GetComponent<WorkTerritory>().Workers.Add(gameObject);
                isWorkOrganisation = true;
            }
            if (workType == WorkType.director)
            {

                other.GetComponent<WorkTerritory>().Directors.Add(gameObject); isWorkOrganisation = true;
            }
            if (workType == WorkType.CraftTable)
            {

                other.GetComponent<WorkTerritory>().Worckstatoins.Add(gameObject); isWorkOrganisation = true;
            }
            if (workType == WorkType.DirectorTable)
            {

                other.GetComponent<WorkTerritory>().TableDirector = gameObject; isWorkOrganisation = true;
                workter = other.GetComponent<WorkTerritory>();
            }
        }
    }
    void Update()
    {
        if (workType == WorkType.DirectorTable)
        {

            RaycastHit hit = MainRay.MainHit;
            if (hit.collider && Input.GetKeyDown(KeyCode.Mouse0)) if (hit.collider.gameObject.GetComponent<WorkOrganisation>().workType == WorkType.DirectorTable)
                {
                    WorkOrganisation wo = hit.collider.gameObject.GetComponent<WorkOrganisation>();
                    VarSave.LoadMoney("CashFlow", -wo.GetMath2());
                    if (wo.GetMath2() != CashFlow) wo.Math2();
                    VarSave.LoadMoney("CashFlow", wo.GetMath2());
                }
        }
    }
    public void OnSignal()
    {

        if (workType == WorkType.DirectorTable)
        {
            WorkOrganisation wo = GetComponent<WorkOrganisation>();
            VarSave.LoadMoney("CashFlow", -wo.GetMath2());
            if (wo.GetMath2() != CashFlow) wo.Math2();
            VarSave.LoadMoney("CashFlow", wo.GetMath2());
        }
    }
        void Math()
    {
        float UNUTaxMult = 1;
        int nalogovaya = 0;
        if (IsTaking)
        {
            UNUTaxMult = 0.1f;
            if (workter.TaxHomes.Count>=1)
            {
                nalogovaya = 10;
            }
        }
        int workstanions = workter.Worckstatoins.Count;
        int workers = workter.Workers.Count;
        int workstanionsnotisbusy = workstanions - workers;
        if (workstanionsnotisbusy < 0)
        {
            workstanionsnotisbusy = 0;
        }
        CashFlow = workstanions - workstanionsnotisbusy;
        if (workter.Directors.Count < 1)
        {
            CashFlow = 0;
        }
        CashFlow *= 10;
        float workMultypy = CashFlow * ((workter.Dupers.Count + workter.Magia.Count + workter.Programs.Count + workter.EctroStations.Count + nalogovaya) * .1f) / UNUTaxMult;
        CashFlow += (int)workMultypy;

    }
    public decimal GetMath2()
    {
        int workDetails = workter.Worckstatoins.Count + (workter.Workers.Count * 2 + (workter.Directors.Count * 4 + (100))) + (IsTaking == true ? 400 : 2856);

       
       return VarSave.GetMoney("WorkTerritoryCashFlow" + workter.transform.position.x + workter.transform.position.y + workter.transform.position.z + workDetails);
    }
    public void Math2()
    {
        int workDetails = workter.Worckstatoins.Count + (workter.Workers.Count * 2 + (workter.Directors.Count * 4 + (100)))+ (IsTaking == true ? 400 : 2856);
        float UNUTaxMult = 1;
        int nalogovaya = 0;
        if (IsTaking)
        {
            UNUTaxMult = 0.1f;
            if (workter.TaxHomes.Count >= 1)
            {
                nalogovaya = 10;
            }
        }
        int workstanions = workter.Worckstatoins.Count;
        int workers = workter.Workers.Count;
        int workstanionsnotisbusy = workstanions - workers;
        if (workstanionsnotisbusy < 0)
        {
            workstanionsnotisbusy = 0;
        }
        CashFlow = workstanions - workstanionsnotisbusy;
        if (workter.Directors.Count < 1)
        {
            CashFlow = 0;
        }
        CashFlow *= 10;
        float workMultypy = CashFlow * ((workter.Dupers.Count + workter.Magia.Count + workter.Programs.Count + workter.EctroStations.Count + nalogovaya) * .1f) / UNUTaxMult;
        CashFlow += (int)workMultypy;
        VarSave.SetMoney("WorkTerritoryCashFlow" + workter.transform.position.x + workter.transform.position.y + workter.transform.position.z + workDetails, CashFlow);
        }
}
