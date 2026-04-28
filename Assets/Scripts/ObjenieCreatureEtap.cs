using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oce : MonoBehaviour
{
    public static ObjenieCreatureEtap main()
    {
        return FindAnyObjectByType<ObjenieCreatureEtap>();
    }
}

public class ObjenieCreatureEtap : MonoBehaviour
{
    [Header("Creature Settings")]
    [Min(1)]
    public int creatureLevel = 1;
    public static GameObject curcreature;
    public GameObject _interface;
    public static ObjenieCreatureEtap main() 
    {
        return FindAnyObjectByType<ObjenieCreatureEtap>();
    }

    [Header("Communication Value")]
    [Range(-10, 10)]
    public int communicationValue = 0; // от -1 до 10

    public int minCommunication = -10;
    public int maxCommunication = 10;

    public Slider singbar;
    public Text hintText;

    [Header("Debate Sequence")]
    public List<int> expectedButtonSequence = new List<int> { 1, 2, 3, 4 };
    public int currentStep = 0;

    public bool isDebateActive = false;

    void Start()
    {
        _interface.SetActive(false);
        ResetDebate();
        UpdateCommunicationFromLevel();
        SetHint();
    }


    void Update()
    {
        // Здесь можно добавить логику для визуализации прогресса.
    }

    public void UpdateCommunicationFromLevel()
    {
        // Пример зависимости: на уровне 1 начинаем с -1, на уровне 11 получаем максимум 10
        communicationValue = Mathf.Clamp(creatureLevel - 2, minCommunication, maxCommunication);
    }

    public void StartDebate()
    {
        isDebateActive = true;
        currentStep = 0;
        SetHint();
    }

    public void ResetDebate()
    {
        isDebateActive = false;
        currentStep = 0;
        UpdateCommunicationFromLevel();
        SetHint(); _interface.SetActive(false);
    }

    public void RandomizeSequence()
    {
        for (int i = expectedButtonSequence.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            int temp = expectedButtonSequence[i];
            expectedButtonSequence[i] = expectedButtonSequence[j];
            expectedButtonSequence[j] = temp;
        }
    }

    public void SetHint()
    {
        if (hintText == null)
            return;

        if (!isDebateActive)
        {
            hintText.text = "Нажмите кнопку, чтобы начать спор";
            return;
        }

        if (currentStep >= 0 && currentStep < expectedButtonSequence.Count)
        {
            hintText.text = $"Текущий ход: нажмите кнопку {expectedButtonSequence[currentStep]}";
        }
        else
        {
            hintText.text = "Спор завершен";
        }
    }

    public void OnButtonPressed(int buttonId)
    {
        if (!isDebateActive)
            return;

        if (currentStep >= expectedButtonSequence.Count)
            return;

        if (buttonId == expectedButtonSequence[currentStep])
        {
            // правильное нажатие
            currentStep++;
            communicationValue = Mathf.Clamp(communicationValue + 1, minCommunication, maxCommunication);

            if (currentStep >= expectedButtonSequence.Count)
            {
                CompleteDebate();
            }
            else
            {
                RandomizeSequence();
                SetHint();
            }
            singbar.value = communicationValue;
        }
        else
        {
            // неправильный порядок, штраф
            communicationValue = Mathf.Clamp(communicationValue - 1, minCommunication, maxCommunication);
            singbar.value = communicationValue;
            // можно требовать повтор, либо сбрасывать текущий шаг
            currentStep = 0;
            SetHint();
        }
    }

    private void CompleteDebate()
    {
        isDebateActive = false;
        Debug.Log($"Спор окончен. Уровень общения: {communicationValue}");
        if (communicationValue == 10)
        {
            Success(); 
        }
        else
        {
            Fail();
        }
    }

    private void Success()
    {
        Debug.Log("Success: последовательность будет перетасована.");
        RandomizeSequence();
        currentStep = 0;
        communicationValue = 0;
        Instantiate(Resources.Load<GameObject>("IcoFirend"),Vector3.zero,Quaternion.identity);
        SetHint();
        curcreature.GetComponent<telo>().EgoPolitic += 1;
        curcreature.GetComponent<telo>().Chiberty += 1;
        _interface.SetActive(false);
    }
    private void Fail()
    {
        Debug.Log("Success: последовательность будет перетасована.");
        RandomizeSequence();
        currentStep = 0;
        communicationValue = 0;
        SetHint();
        curcreature.GetComponent<telo>().EgoPolitic += 1;
        curcreature.GetComponent<telo>().LiberMarket += 1;
        _interface.SetActive(false);
    }
}
