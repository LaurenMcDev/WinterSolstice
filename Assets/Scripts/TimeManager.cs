using System;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : SingletonMonobehaviour<TimeManager>
{

    private int gameYear = 1;
    private seasons gameSeason = seasons.spring;
    private int gameDay = 1;
    private int gameHour = 6;
    private int gameMinute = 30;
    private int gameSecond = 0;
    private string gameDayOfWeek = "Mon";

    private bool gameClockPaused = false;

    private float gameTick = 0f;

    private string _iSaveableUniqueID;
    public string ISaveableUniqueID { get { return _iSaveableUniqueID; } set { _iSaveableUniqueID = value; } }

    

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private void BeforeSceneUnloadFadeOut()
    {
        gameClockPaused = true;
    }

    private void AfterSceneLoadFadeIn()
    {
        gameClockPaused = false;
    }


    private void Start()
    {
        EventHandler.CallAdvanceGameMinuteEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
    }

    private void Update()
    {
        if (!gameClockPaused)
        {
            GameTick();
        }
    }

    private void GameTick()
    {
        gameTick += Time.deltaTime;

        if (gameTick >= Settings.secondsPerGameSecond)
        {
            gameTick -= Settings.secondsPerGameSecond;

            UpdateGameSecond();
        }
    }

    private void UpdateGameSecond()
    {
        gameSecond++;

        if (gameSecond > 59)
        {
            gameSecond = 0;
            gameMinute++;


            if (gameMinute > 59)
            {
                gameMinute = 0;
                gameHour++;

                if (gameHour > 23)
                {
                    gameHour = 0;
                    gameDay++;

                    if (gameDay > 30)
                    {
                        gameDay = 1;

                        int gs = (int)gameSeason;
                        gs++;

                        gameSeason = (seasons)gs;

                        if (gs > 3)
                        {
                            gs = 0;
                            gameSeason = (seasons)gs;

                            gameYear++;

                            if (gameYear > 9999)
                                gameYear = 1;


                            EventHandler.CallAdvanceGameYearEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
                        }

                        EventHandler.CallAdvanceGameSeasonEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
                    }

                    gameDayOfWeek = GetDayOfWeek();
                    EventHandler.CallAdvanceGameDayEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
                }

                EventHandler.CallAdvanceGameHourEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
            }

            EventHandler.CallAdvanceGameMinuteEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);

        }

        // Call to advance game second event would go here if required
    }

    private string GetDayOfWeek()
    {
        int totalDays = (((int)gameSeason) * 30) + gameDay;
        int dayOfWeek = totalDays % 7;

        switch (dayOfWeek)
        {
            case 1:
                return "Mon";

            case 2:
                return "Tue";

            case 3:
                return "Wed";

            case 4:
                return "Thu";

            case 5:
                return "Fri";

            case 6:
                return "Sat";

            case 0:
                return "Sun";

            default:
                return "";
        }
    }

    public TimeSpan GetGameTime()
    {
        TimeSpan gameTime = new TimeSpan(gameHour, gameMinute, gameSecond);

        return gameTime;
    }


    //TODO:Remove
    /// <summary>
    /// Advance 1 game minute
    /// </summary>
    public void TestAdvanceGameMinute()
    {
        for (int i = 0; i < 60; i++)
        {
            UpdateGameSecond();
        }
    }

    //TODO:Remove
    /// <summary>
    /// Advance 1 day
    /// </summary>
    public void TestAdvanceGameDay()
    {
        for (int i = 0; i < 86400; i++)
        {
            UpdateGameSecond();
        }
    }

   

  

   
    public void ISaveableStoreScene(string sceneName)
    {
        // Nothing required here since Time Manager is running on the persistent scene
    }

    public void ISaveableRestoreScene(string sceneName)
    {
        // Nothing required here since Time Manager is running on the persistent scene
    }
}


/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    private int gameYear = 1;
    private seasons gameSeason = seasons.spring;
    private int gameDay = 1;
    private int gameHour = 6;
    private int gameMinute = 30;
    private int gameSecond = 0;
    private string gameDayOfWeek = "Mon";

    private bool gameClockPaused = false;
    private float gameTick = 0f;

    private void Start()
    {
        EventHandler.CallAdvanceGameMinuteEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
    }

    private void Update()
    {
        if(!gameClockPaused)
        {
            GameTick();
        }
    }

    private void GameTick()
    {
        gameTick += Time.deltaTime;
        if ((gameTick >= Settings.secondsPerGameSecond))
        {
            {
                gameTick -= Settings.secondsPerGameSecond;

                UpdateGameSecond();
            }
        }
    }

    public void UpdateGameSecond()
    {
        gameSecond++;
        if(gameSecond > 59)
        {
            gameSecond = 0;
            gameMinute++;

            if(gameMinute > 59)
            {
                gameMinute = 0;
                gameHour++;
            }    

              if(gameHour > 23)
              {
                  gameHour = 0;
                  gameDay++;

                  if(gameDay > 30)
                 {
                     gameDay = 1;
    
                     int gs = (int)gameSeason;
                     gs++;

                    gameSeason = (seasons)gs;

                        if(gs > 3)
                        {
                            gs = 0;
                            gameSeason = (seasons)gs;
                             gameYear++;

                            if(gameYear > 9999)
                            {
                                gameYear = 1;
                            }

                        EventHandler.CallAdvanceGameYearEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
                    }

                    EventHandler.CallAdvanceGameSeasonEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
                }
                gameDayOfWeek = GetDayOfWeek();
                EventHandler.CallAdvanceGameDayEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
            }
            EventHandler.CallAdvanceGameHourEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
        }

        EventHandler.CallAdvanceGameMinuteEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);

     //   Debug.Log("Year: " + gameYear + " Season: " + gameSeason + " Day Of Week: " + gameDay + " Hour: " + gameHour + " Minutes: " + gameMinute + " Seconds: " + gameSecond);
    }

    private string GetDayOfWeek()
    {
        int totalDays = (((int)gameSeason) * 30) + gameDay;
        int dayOfWeek = totalDays % 7;

        switch(dayOfWeek)
        {
            case 1:
                return "Mon";
            case 2:
                return "Tues";
            case 3:
                return "Wed";
            case 4:
                return "Thurs";
            case 5:
                return "Fri";
            case 6:
                return "Sat";
            case 7:
                return "Sun";
            default:
                return "";
        }
    }
}
*/