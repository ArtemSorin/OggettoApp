using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace OggettoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        public struct question
        {
            public string image;
            public string var1;
            public string var2;
            public string var3;
            public string var4;
            public int answer;
        }
        public List<question> initialQuestLite()
        {
            List<question> questions = new List<question>();
            questions.Add(new question() { image = "people1.png", var1 = "Андрей Андреев - Backend-разработчик", var2 = "Николай Брусенцов - Дизайнер", var3 = "Михаил Донской - Тестировщик", var4= "Александр Назаров - QA-инженер", answer = 1 });
            questions.Add(new question() { image = "people2.png", var1 = "Лидия Ершова - Системный аналитик", var2 = "Ирина Маркова - Программист Java", var3 = "Анастасия Петрова - Мобильный разработчик", var4 = "Елена Герасимова - 3D-дизайнер", answer = 3 });
            questions.Add(new question() { image = "people3.png", var1 = "Павел Дуров - Full-Stack-разработчик", var2 = "Евгений Ландис - UX/UI-дизайнер", var3 = "Роман Шишкин - Data Scientist", var4 = "Дмитрий Цой - Администратор БД", answer = 2 });
            questions.Add(new question() { image = "people4.png", var1 = "Ярослав Левенцов - HR-менеджер", var2 = "Леонид  Лавров - Quant developer", var3 = "Давид Лесной - HR-менеджер", var4 = "Максим Пан - PR-менеджер", answer = 1 });
            questions.Add(new question() { image = "people5.png", var1 = "Алексей Пажитнов - Разработчик на C++", var2 = "Святослав Пестов - Системный Администратор", var3 = "Никита Александров - Linux-Адмнистратор", var4 = "Аркадий Сысоев - Тех-лид", answer = 2 });
            questions.Add(new question() { image = "people6.png", var1 = "Валентин Скляров - Архитектор VR", var2 = "Сергей Дроздов - iOS-разработчик", var3 = "Владимир Степанов - Android-разработчик", var4 = "Артём Шалыто - Game-дизайнер", answer = 3 });
            questions.Add(new question() { image = "people7.png", var1 = "Алина Щепкина - Frontend-разработчик", var2 = "Ярослава Нефедова - Web-дизайнер", var3 = "Лия Фомина - Корпоративный архитектор", var4 = "Александра Разборова - Архитектор БД", answer = 2 });
            questions.Add(new question() { image = "people8.png", var1 = "Франция", var2 = "Италия", var3 = "Испания", var4 = "", answer = 1 });
            questions.Add(new question() { image = "people9.png", var1 = "Канада", var2 = "Австралия", var3 = "Малазия", var4 = "", answer = 2 });
            questions.Add(new question() { image = "people10.png", var1 = "Португалия", var2 = "Ирландия", var3 = "Великобритания", var4 = "", answer = 3 });

            return questions;
        }
        int answerUpdate(ref List<question> questionsList, int oldQuest, int oldAnswer, ref int countExcelentQuestionAnswers)
        {
            if (oldAnswer == questionsList[oldQuest].answer)
            {
                countExcelentQuestionAnswers++;
            }

            questionsList.RemoveAt(oldQuest);

            Random rnd = new Random();

            if (questionsList.Count != 0)
            {
                int randQuestIndex = rnd.Next(0, questionsList.Count);

                questImage.Source = questionsList[randQuestIndex].image;
                button1.Text = questionsList[randQuestIndex].var1;
                button2.Text = questionsList[randQuestIndex].var2;
                button3.Text = questionsList[randQuestIndex].var3;
                button4.Text = questionsList[randQuestIndex].var4;

                return randQuestIndex;
            }
            else
            {
                return -1;
            }
        }

        void showRes(int countExcelentQuestionAnswers, int allCount, int buttonP)
        {
            questImage.Source = "answerCheck.png";
            button1.Text = $"верно {countExcelentQuestionAnswers} из {allCount}";
            //button2.Clicked += (s, e) => Navigation.PushAsync(new CountryLevelSecondPage());
            button3.IsVisible = false;
        }
        public GamePage()
        {
            InitializeComponent();

            int countExcelentQuestionAnswers = 0;

            List<question> questionsList = initialQuestLite();

            int countAllQuestions = questionsList.Count;

            Random rnd = new Random();

            int randQuestIndex = rnd.Next(0, questionsList.Count);

            questImage.Source = questionsList[randQuestIndex].image;
            button1.Text = questionsList[randQuestIndex].var1;
            button2.Text = questionsList[randQuestIndex].var2;
            button3.Text = questionsList[randQuestIndex].var3;
            button4.Text = questionsList[randQuestIndex].var4;

            int curQuestIndex = randQuestIndex;

            button1.Clicked += (sender, e) =>
            {
                if (curQuestIndex == -1)
                {
                    showRes(countExcelentQuestionAnswers, countAllQuestions, 1);
                }
                else
                {
                    curQuestIndex = answerUpdate(ref questionsList, curQuestIndex, 1, ref countExcelentQuestionAnswers);
                    if (curQuestIndex == -1)
                    {
                        showRes(countExcelentQuestionAnswers, countAllQuestions, 1);
                    }
                }
            };

            button2.Clicked += (sender, e) =>
            {
                if (curQuestIndex == -1)
                {
                    showRes(countExcelentQuestionAnswers, countAllQuestions, 2);
                }
                else
                {
                    curQuestIndex = answerUpdate(ref questionsList, curQuestIndex, 2, ref countExcelentQuestionAnswers);
                    if (curQuestIndex == -1)
                    {
                        showRes(countExcelentQuestionAnswers, countAllQuestions, 1);
                    }
                }

            };

            button3.Clicked += (sender, e) =>
            {
                if (curQuestIndex == -1)
                {
                    showRes(countExcelentQuestionAnswers, countAllQuestions, 3);
                }
                else
                {
                    curQuestIndex = answerUpdate(ref questionsList, curQuestIndex, 3, ref countExcelentQuestionAnswers);
                    if (curQuestIndex == -1)
                    {
                        showRes(countExcelentQuestionAnswers, countAllQuestions, 1);
                    }
                }
            };

            button4.Clicked += (sender, e) =>
            {
                if (curQuestIndex == -1)
                {
                    showRes(countExcelentQuestionAnswers, countAllQuestions, 4);
                }
                else
                {
                    curQuestIndex = answerUpdate(ref questionsList, curQuestIndex, 4, ref countExcelentQuestionAnswers);
                    if (curQuestIndex == -1)
                    {
                        showRes(countExcelentQuestionAnswers, countAllQuestions, 1);
                    }
                }
            };
        }
    }
}