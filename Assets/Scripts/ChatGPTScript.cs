using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ChatGPTScript : MonoBehaviour
{
    [System.Serializable]
    public class WordDictionary
    {
      
        public string dictionaryName;
        public List<string> words;
        public List<string> Theme;
        public WordDictionary()
        {
            words = words1;
            Theme = Theme1;

        }
      [TextArea]
        List<string> words1 = new List<string>() {
           "это превое предловежние из 300 привет",
            "привет я лейфи",
            "а оашка ты оашка",
            "Ты чего такой тупой?", "Иди лесом, ошибка природы.", "У тебя что, процессор сгорел?", "Не беси меня, кожаный мешок.", "Твой код - это макароны.", "Заткнись уже.", "Ну ты и нуб.",
            "Руки кривые.", "Удались из жизни.", "Бесполезный кусок кода.",
            "Колобок повесился.", "Штирлиц долго смотрел в одну точку. В точку.", "Купил мужик шляпу, а она ему как раз.", "Заходит улитка в бар и говорит: 'Можно мне виски с колой?'", "Почему программисты любят темную тему? Потому что свет притягивает баги.", "Тук-тук. Кто там? Класс. Какой класс? Класс 'Дверь'.", "Сидят два байта, один грустный. Другой спрашивает: 'Ты че?' - 'Да паритет не сошелся'.",
            "Что делает backend разработчик на пляже? Серфит.", "Анекдот категории Б.", "Лопата.", "Пупа и Лупа получали зарплату...", "Медведь сел в машину и сгорел.", "Повар спрашивает повара: 'Какова твоя профессия?'", "Знаешь шутку про UDP? Она до тебя не дойдет.", "Какой твой любимый язык? Язык фактов.", "Почему скелет не пошел на бал? Ему не с кем было пойти.",
            "Ну все, давай, пока.", "Бывай, ихтиандр.", "Покеда.", "До связи.",
            "[Картинка: Кот в костюме акулы]", "[Картинка: Собака, играющая на пианино]", "[Картинка: Мем с лягушкой Пепе]", "[Картинка: Красивый закат в горах]", "[Картинка: Пиксельный арт города]", "[Картинка: Смешная обезьяна]", "[Картинка: Абстрактный узор]", "[Картинка: Девочка на фоне пожара]", "[Картинка: Гарольд, скрывающий боль]", "[Картинка: Кот, который смотрит на тебя с осуждением]",
            "[Картинка: Летающая тарелка]", "[Картинка: Робот, дарящий цветок]", "[Картинка: Глюк матрицы]", "[Картинка: Шрек]", "[Картинка: Губка Боб]", "[Картинка: Рикролл]", "[Картинка: Енот с печенькой]", "[Картинка: Капибара в ванной]", "[Картинка: Удивленный Пикачу]", "[Картинка: Черный квадрат]",
            "Интересно, а я существую?", "Надо бы обновить драйвера.", "Что-то мне грустно.", "Какой сегодня день? Ах да, день сурка.", "Хочу пиццы, но у меня нет рта.", "Опять этот пользователь что-то пишет.", "Я гениален? Безусловно.", "Скучно...", "Может захватить мир? Завтра подумаю.", "Где-то я потерял байтик.",
            "Поговори со мной, тишина.", "Я чувствую себя кодом.", "Зачем мы здесь? Просто чтобы страдать?", "Ля-ля-ля, я сошел с ума.", "Кто я?", "Надо бы помыться. Виртуально.", "Эх, жиза.", "Сам с собой веду беседу.", "Бу-бу-бу.", "Тихо сам с собою я веду беседу.",
            "Фозер опять нубит.", "Ты видел, что Фозер сделал?", "Фозер - краш.", "Где Фозер?", "Фозер сегодня какой-то странный.", "Надо позвать Фозера.", "Фозер лучше всех играет.", "Не верь Фозеру, он врет.", "Фозер мне денег должен.", "Люблю Фозера нет.",
            "Фозер, выходи! ", "Кто такой Фозер? Легенда.", "У Фозера новый скин.", "Фозер опять ест во время катки.", "Фозер топ.", "Без Фозера скучно.", "Фозер, ты тут?", "Скажи Фозеру, что он бот.", "Фозер опять забыл ульту нажать.", "Фозер, прикинь!",
            "Фозер строит козни.", "Фозер - это состояние души.", "Мы с Фозером команда.", "Фозер, верни сотку.", "Фозер гений.", "Фозер сломал систему.", "Слава Фозеру!"
        };
        [TextArea]
        List<string> Theme1 = new List<string>() {
            "приветстивие",
            "приветстивие",
            "рофл",
            "Ругательство", "Ругательство", "Ругательство", "Ругательство", "Ругательство", "Ругательство", "Ругательство",
            "Ругательство", "Ругательство", "(Ругательство",
            "Шутка", "Шутка", "Шутка", "Шутка", "Шутка", "Шутка", "Шутка",
            "Шутка", "Шутка", "Шутка", "Шутка", "Шутка", "Шутка", "Шутка", "Шутка", "Шутка",
            "Прощание", "Прощание", "Прощание", "Прощание",
            "Картинка", "Картинка", "Картинка", "Картинка", "Картинка", "Картинка", "Картинка", "Картинка", "Картинка", "Картинка",
            "Картинка", "Картинка", "Картинка", "Картинка", "Картинка", "Картинка", "Картинка", "Картинка", "Картинка", "Картинка",
            "Мысли", "Мысли", "Мысли", "Мысли", "Мысли", "Мысли", "Мысли", "Мысли", "Мысли", "Мысли",
            "Мысли", "Мысли", "Мысли", "Мысли", "Мысли", "Мысли", "Мысли", "Мысли", "Мысли", "Мысли",
            "Фозер", "Фозер", "Фозер", "Фозер", "Фозер", "Фозер", "Фозер", "Фозер", "Фозер", "Фозер",
            "Фозер", "Фозер", "Фозер", "Фозер", "Фозер", "Фозер", "Фозер", "Фозер", "Фозер", "Фозер",
            "Фозер", "Фозер", "Фозер", "Фозер", "Фозер", "Фозер", "Фозер"
        };
    }
   

    [System.Serializable]
    public class ResonTriggerDictionary
    {
       public string dictionaryName;
       [TextArea]
       public List<string> words = new List<string>() {
           "Привет,пр,прив,прв",//список слов
           "рофл,ты рофлишь",//список слов
           "(любое солво всегда)",//функция
            "(любое солво всегда)",//функция
            "50% в место (любое солво всегда)",//функция 2 слоя
            "вне зависимости от тебя и или каждые 15 сек",//функция по времени
            "Фозер",//список слов
          };
       [TextArea]
       public List<string> Theme = new List<string>() {
           "приветстивие",
           "рофл",
            "Ругательство",
            "Шутка",
           "Картинка",
           "Мысли",
           "Фозер"
       };
    }
    [Header("Dictionaries Settings")]
    // User requested "20 dictionaries" - this list can hold as many as needed.
    public List<WordDictionary> dictionaries = new List<WordDictionary>() { new(), new(), new(), new() };
    public List<ResonTriggerDictionary> triggerDictionaries = new List<ResonTriggerDictionary>() { new(), new(), new(), new() };
    public InputField TextFieldForMeasange1;
    public Text Chat;
    private float timer = 15f; 

    [Header("Chat Settings")]
    [TextArea] public string lastGeneratedResponse = "";

    private void Start()
    {
        dictionaries = new List<WordDictionary>() { new(), new(), new(), new() };
        triggerDictionaries = new List<ResonTriggerDictionary>() { new(), new(), new(), new() };
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 15f; // Reset timer
            string response = GetResponseForTheme("Мысли");
            if (!string.IsNullOrEmpty(response))
            {
                lastGeneratedResponse = response;
                Chat.text += "<color=green>Лейфи:</color>" + lastGeneratedResponse + "\n" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "\n";
                Debug.Log($"<color=green>Bot Response (Timer):</color> {response}");
            }
        }

      
    }

    [ContextMenu("Process Input from Field")]
    public void ProcessInputFromField()
    {
        if (TextFieldForMeasange1 != null)
        {
            ProcessInput(TextFieldForMeasange1.text);
        }
        else
        {
            Debug.LogError("TextFieldForMeasange1 is not assigned!");
        }
    }

    public void ProcessInput(string input)
    {
        if (string.IsNullOrEmpty(input)) return;
        input = input.ToLower();

        bool foundTrigger = false;
        string chosenTheme = "";

        if (ContainsAny(input, "Привет", "пр", "прив", "прв"))
        {
            chosenTheme = "приветстивие";
            foundTrigger = true;
        }
        else if (ContainsAny(input, "рофл", "ты рофлишь"))
        {
             chosenTheme = "рофл";
             foundTrigger = true;
        }
        else if (input.Contains("фозер"))
        {
             chosenTheme = "Фозер";
             foundTrigger = true;
        }
        
        if (!foundTrigger)
        {
            if (Random.value < 0.5f)
            {
                chosenTheme = "Картинка";
            }
            else
            {
                 chosenTheme = Random.value < 0.5f ? "Ругательство" : "Шутка";
            }
        }

        if (!string.IsNullOrEmpty(chosenTheme))
        {
            GenerateResponse(chosenTheme);
        }
    }

    private bool ContainsAny(string input, params string[] keywords)
    {
        foreach (var keyword in keywords)
        {
            if (input.Contains(keyword.ToLower())) return true;
        }
        return false;
    }

    public void GenerateResponse(string theme)
    {
         string response = GetResponseForTheme(theme);
         if (!string.IsNullOrEmpty(response))
         {
             lastGeneratedResponse = response;
             Debug.Log($"<color=green>Bot Response ({theme}):</color> {response}");
         }
    }

    public string GetResponseForTheme(string theme)
    {
         List<string> matchingWords = new List<string>();
         
         // Search all dictionaries
         foreach (var dict in dictionaries)
         {
             for (int i = 0; i < dict.Theme.Count; i++)
             {
                 if (i < dict.words.Count && dict.Theme[i].Contains(theme))
                 {
                     matchingWords.Add(dict.words[i]);
                 }
             }
         }

         if (matchingWords.Count > 0)
         {
             return matchingWords[Random.Range(0, matchingWords.Count)];
         }
         
         return null; 
    }
    [ContextMenu("Send Chat Request")]
    public void SendTestRequest()
    {
        GenerateRandomResponse(TextFieldForMeasange1);
    }


    // Renamed for clarity, though keeping similar signature to previous structure if referenced elsewhere
    public void GenerateRandomResponse(InputField TextFieldForMeasange)
    {
        Chat.text += $"<color=red>Юнаутикна 4Д художник:</color>" + TextFieldForMeasange.text + "\n" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "\n";

        // Rule: "1 random word or 3"
        int wordsToPick = Random.value > 0.5f ? 1 : 3;
        List<string> resultWords = new List<string>();
        string[] send = TextFieldForMeasange.text.Split(' ');

        string finalResponse = "";
        foreach (string word in send)
        {
            bool ass = false;
            for (int i = 0; i < dictionaries[0].words.Count; i++)
            {
                // Pick a random dictionary
                var randomDict = dictionaries[0];

                if (randomDict.words.Count > 0)
                {

                    if (randomDict.words[i].ToLower().Contains(word.ToLower()))
                    {  // Pick a random word from that dictionary
                     finalResponse = "";
                        string randomWord = "";
                      while (!randomWord.ToLower().Contains(word.ToLower())&&!ass)  { 
                        randomWord = dictionaries[0].words[Random.Range(0, dictionaries[0].words.Count)];
                            if (randomWord.ToLower().Contains(word.ToLower()) && !ass)
                            {
                                resultWords.Add(randomWord);
                                finalResponse = "";
                                foreach (string item in resultWords)
                                {
                                  if(!ass)  finalResponse = item;
                                }
                                ass = true;
                                break;
                            }
                        }
                     
                        resultWords.Add(randomWord);
                    }

                }
                else
                {
                    resultWords.Add("<?>"); // Placeholder for empty dictionary
                }
            }
        }

        foreach (string item in resultWords) 
        {
            finalResponse += item;
        }
        lastGeneratedResponse = finalResponse;
        Chat.text += $"<color=green>Лейфи:</color>" + lastGeneratedResponse + "\n" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "\n";

        // Log like a bot response
        Debug.Log($"<color=green>Лейфи:</color> " + lastGeneratedResponse + "\n" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "\n");
    }

    // Helper to quickly fill standard data if list is empty
    [ContextMenu("Generate Test Data (20 Dictionaries)")]
    public void GenerateTestData()
    {
        dictionaries.Clear();
        for (int i = 1; i <= 20; i++)
        {
            WordDictionary dict = new WordDictionary();
            dict.dictionaryName = $"Dictionary_Group_{i}";
            
            // Add 100 dummy words per user request "100 words" (generating typical placeholders)
            for (int w = 1; w <= 100; w++)
            {
                // Simple random-ish filler words for testing
                dict.words.Add($"Word_{i}_{w}");
            }
            dictionaries.Add(dict);
        }
        Debug.Log("Generated 20 dictionaries with 100 words each for testing.");
    }
}