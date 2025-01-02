using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class PinSplit
{
    public bool isPin1;
    public bool isPin2;
    public bool isPin3;
    public bool isPin4;
    public bool isPin5;
    public bool isPin6;
    public bool isPin7;
    public bool isPin8;
    public bool isPin9;
    public bool isPin10;
}

public class Game : MonoBehaviour
{
    private List<int> rolls1 = new List<int>();
    private List<int> rolls2 = new List<int>();
    private List<int> rolls3 = new List<int>();
    private List<int> rolls4 = new List<int>();
    private List<int> scores1 = new List<int>();
    private List<int> scores2 = new List<int>();
    private List<int> scores3 = new List<int>();
    private List<int> scores4 = new List<int>();
    private int score1;
    private int score2;
    private int score3;
    private int score4;
    private int strikes1;
    private int strikes2;
    private int strikes3;
    private int strikes4;
    private int spares1;
    private int spares2;
    private int spares3;
    private int spares4;
    private int gutters1;
    private int gutters2;
    private int gutters3;
    private int gutters4;
    private int frames1 = 1;
    private int frames2 = 1;
    private int frames3 = 1;
    private int frames4 = 1;
    private int turns = 0;
    private int nextTurn = 0;
    private int playerTurn = 0;
    private int ballTurn = 0;
    private int wins = 1;
    private int stage = 1;
    private int spareBalls = 5;

    public GameObject[] alleys = new GameObject[8];
    public GameObject[] alleyScores = new GameObject[8];
    public enum AnimationScenes { Off, Strike, Spare, Double, Turkey }
    public AnimationScenes animations;
    public enum Crowds { NoCrowd, CheerBig, CheerMed, CrowdOk, CrowdHohum, CrowdCrap, Laugh, Oooh, Firework }
    public Crowds crowdType;
    public enum AllVoices { Strike, Spare, Gutterball, Double, Turkey, Split, Split710, SplitPick, Most, Few, One, Miss, EndBad, EndOk, EndGood, EndGreat, Perfect }
    public ScoreDisplay[] scoreDisplay;
    public ScoreDisplayBall3[] scoreDisplay3;
    public GameObject[] scoreCards = new GameObject[3];
    public GameObject[] playersBallTwo = new GameObject[4];
    public GameObject[] playersBallThree = new GameObject[4];
    public GameObject[] winGameBalls = new GameObject[18];
    public Text[] winGameName1;
    public Text[] winGameName2;
    public Text[] winGameName3;
    public Text[] winGameName4;
    public Text[] winGameNameCPU;
    public Text[] winGameScore1;
    public Text[] winGameScore2;
    public Text[] winGameScore3;
    public Text[] winGameScore4;
    public Text[] winGamePrize1;
    public Text[] winGamePrize2;
    public Text[] winGamePrize3;
    public Text[] winGamePrize4;
    public GameObject[] normalPin;
    public GameObject[] duckPin;
    public GameObject[] candlePin;
    public int pinsCounter;
    public int maxBalls = 2;
    public int throwBall = 0;
    public bool isScooper = true;
    public int gutterAnimation = 0;
    public bool isPin = false;
    public PinCounter pinCounter;
    public AudioSource opening;
    public AudioSource crowdAudio;
    public AudioSource rollCrowd;
    public AudioSource winCrowd;
    public AudioSource commentatorAudio;
    public AudioSource fireworksMulti;
    public static AudioSource audioSource;
    public AudioSource rainPorch;
    public bool isSplit;
    public PinSplit[] pinSplits;
    public CameraFollow cameraFollow;
    public bool isComputer;
    public bool isReplay;
    public bool isReplayRecord = false;
    public bool isCurrentReplay = false;
    public float currentReplayIndex;
    public GameObject customBallButton;
    public GameObject startButton;
    public GameObject menuRegisterButton;
    public GameObject[] ballsRegisterButton;
    public GameObject[] nextButton;
    public GameObject[] bowlButton;
    public GameObject alleyRegistered;
    public GameObject ballLocked;
    public GameObject ballNeed;
    public GameObject ballUnlock;
    public GameObject ballUnlocked;
    public GameObject ballRegistered;
    public GameObject bowlerUIElement;
    public Transform bowlerWrapper;
    public GameObject scoreUIElement;
    public Transform[] scoreWrapper = new Transform[8];
    public int regCount = 0;
    public GameObject menuCam;
    public GameObject gameCam;
    public GameObject scoreCardCam;
    public Transform infoCam;
    public RenderTexture infoScreenCam;
    public RenderTexture firstPersonCam;
    public Animation thunderAnimation;
    public GameObject menuUI;
    public GameObject gameUI;
    public GameObject replayText;
    public GameObject ballObject;
    public MeshRenderer ballRender;
    public MeshRenderer winBallRender1;
    public MeshRenderer winBallRender2;
    public MeshRenderer winBallRender3;
    public MeshRenderer winBallRender4;
    public MeshRenderer winBallRenderCPU;
    public Text alleyText;
    public Text playerNameText;
    public Text ballNameText;
    public Text ballDataText;
    public Text ballNameMenuText;
    public Text ballDataMenuText;
    public Text ballDataCustomText;
    public Text bowlerText;
    public Text qualityText;
    public Text resolutionText;
    public TextMesh playerName1;
    public TextMesh playerName2;
    public TextMesh playerName3;
    public TextMesh playerName4;
    public GameObject playerName;
    public Text scoreTextBall2;
    public Text scoreTextBall3;
    public Text ballsText;
    public Text stagesText;
    public Text stagesWinText;
    public GameObject chooseBallUI;
    public Image selectAlleysUI;
    public GameObject[] trueObjects;
    public GameObject[] falseObjects;
    public GameObject loadingUI;
    public GameObject menuAlleyUI;
    public GameObject highScoreUI;
    public GameObject registerUI;
    public GameObject lockAlleyUI;
    public GameObject unlockAlleyUI;
    public GameObject unlockedText;
    public GameObject unlockedAlley;
    public GameObject unlockedBallBeat;
    public GameObject unlockedBallEarn;
    public GameObject unlockedBallScore;
    public GameObject unlockedBallSpare;
    public Text lockAlleyText;
    public GameObject registerFail;
    public GameObject registerComplete;
    public InputField keyField;
    public InputField customBallNameField;
    public Slider customBallLbs;
    public Slider customBallSpeed;
    public Slider customBallSpin;
    public InputField bowlerField;
    public InputField customBallFileField;
    public InputField infoFileField;
    public GameObject[] pins;
    public GameObject sendingEmail;
    public GameObject emailSent;
    public GameObject arrowBowler;
    public Button[] bowlerButton = new Button[4];
    public AudioClip bowling1;
    public AudioClip bowling2;
    public AudioClip bowling4;
    public AudioClip bowling6;
    public AudioClip bowling10;
    public GameObject fireworks;

    private AudioSource music;
    private GameObject[] sounds;
    private bool isIntro = true;
    private GameManager gameManager;
    private AllVoices allVoices;
    private Commentator commentator;
    private Ball ball;
    private Pin pin1;
    private Pin pin2;
    private Pin pin3;
    private Pin pin4;
    private Pin pin5;
    private Pin pin6;
    private Pin pin7;
    private Pin pin8;
    private Pin pin9;
    private Pin pin10;
    private Crowd crowd;
    private Coroutine b;
    private ActionReplay[] replays;
    private bool is710;
    private bool isCommentator = true;
    private float commentatorTime = 0;
    private int commentatorIndex = 0;
    private bool isEndGame;
    private int introAnimIndex;
    private int gbAnimIndex;
    private int gbAnimIndex2X;
    private int replayIndex;
    private int reactIndex;
    private float replayTime = 0;
    private int rainIndex = 0;
    private bool isAnim = false;
    private int chargeBallIndex;
    private float openingTime;
    private bool isResetPins = false;
    private int pinCounts;
    public delegate void OnHighscoreListChanged(List<ScoreBowler> list);
    public static event OnHighscoreListChanged onHighscoreListChanged;

    // Use this for initialization
    void Start ()
	{
        pinCounter.Reset();
        music = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        crowdAudio = GameObject.Find("Crowd").GetComponent<AudioSource>();
        rollCrowd = GameObject.Find("RollingCrowd").GetComponent<AudioSource>();
        winCrowd = GameObject.Find("WinCrowd").GetComponent<AudioSource>();
        audioSource = GameObject.Find("SFXSource").GetComponent<AudioSource>();
        rainPorch = GameObject.Find("RainPorch").GetComponent<AudioSource>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager.SavePrefs();
        for (int i = 0; i < gameManager.bowler.Count; i++)
        {
            GameObject element = Instantiate(bowlerUIElement, bowlerWrapper) as GameObject;
            element.GetComponent<BowlerUI>().BowlerUpdate(gameManager.bowler[i].playerName, gameManager.bowler[i].playerMoney, gameManager.bowler[i].playerWin, gameManager.bowler[i].playerLoss, gameManager.bowler[i].playerStrikes, gameManager.bowler[i].playerSpares, gameManager.bowler[i].playerGutters);
        }
        for (int i = 0; i < gameManager.r_hs.Count; i++)
        {
            GameObject element = Instantiate(scoreUIElement, scoreWrapper[0]) as GameObject;
            element.GetComponent<ScoreUI>().BowlerUpdate(i + 1, gameManager.r_hs[i].playerName, gameManager.r_hs[i].playerScore, gameManager.r_hs[i].playerStrikes, gameManager.r_hs[i].playerSpares, gameManager.r_hs[i].playerGutters);
        }
        for (int i = 0; i < gameManager.z_hs.Count; i++)
        {
            GameObject element = Instantiate(scoreUIElement, scoreWrapper[1]) as GameObject;
            element.GetComponent<ScoreUI>().BowlerUpdate(i + 1, gameManager.z_hs[i].playerName, gameManager.z_hs[i].playerScore, gameManager.z_hs[i].playerStrikes, gameManager.z_hs[i].playerSpares, gameManager.z_hs[i].playerGutters);
        }
        for (int i = 0; i < gameManager.j_hs.Count; i++)
        {
            GameObject element = Instantiate(scoreUIElement, scoreWrapper[2]) as GameObject;
            element.GetComponent<ScoreUI>().BowlerUpdate(i + 1, gameManager.j_hs[i].playerName, gameManager.j_hs[i].playerScore, gameManager.j_hs[i].playerStrikes, gameManager.j_hs[i].playerSpares, gameManager.j_hs[i].playerGutters);
        }
        for (int i = 0; i < gameManager.i_hs.Count; i++)
        {
            GameObject element = Instantiate(scoreUIElement, scoreWrapper[3]) as GameObject;
            element.GetComponent<ScoreUI>().BowlerUpdate(i + 1, gameManager.i_hs[i].playerName, gameManager.i_hs[i].playerScore, gameManager.i_hs[i].playerStrikes, gameManager.i_hs[i].playerSpares, gameManager.i_hs[i].playerGutters);
        }
        for (int i = 0; i < gameManager.w_hs.Count; i++)
        {
            GameObject element = Instantiate(scoreUIElement, scoreWrapper[4]) as GameObject;
            element.GetComponent<ScoreUI>().BowlerUpdate(i + 1, gameManager.w_hs[i].playerName, gameManager.w_hs[i].playerScore, gameManager.w_hs[i].playerStrikes, gameManager.w_hs[i].playerSpares, gameManager.w_hs[i].playerGutters);
        }
        for (int i = 0; i < gameManager.m_hs.Count; i++)
        {
            GameObject element = Instantiate(scoreUIElement, scoreWrapper[5]) as GameObject;
            element.GetComponent<ScoreUI>().BowlerUpdate(i + 1, gameManager.m_hs[i].playerName, gameManager.m_hs[i].playerScore, gameManager.m_hs[i].playerStrikes, gameManager.m_hs[i].playerSpares, gameManager.m_hs[i].playerGutters);
        }
        for (int i = 0; i < gameManager.b_hs.Count; i++)
        {
            GameObject element = Instantiate(scoreUIElement, scoreWrapper[6]) as GameObject;
            element.GetComponent<ScoreUI>().BowlerUpdate(i + 1, gameManager.b_hs[i].playerName, gameManager.b_hs[i].playerScore, gameManager.b_hs[i].playerStrikes, gameManager.b_hs[i].playerSpares, gameManager.b_hs[i].playerGutters);
        }
        for (int i = 0; i < gameManager.c_hs.Count; i++)
        {
            GameObject element = Instantiate(scoreUIElement, scoreWrapper[7]) as GameObject;
            element.GetComponent<ScoreUI>().BowlerUpdate(i + 1, gameManager.c_hs[i].playerName, gameManager.c_hs[i].playerScore, gameManager.c_hs[i].playerStrikes, gameManager.c_hs[i].playerSpares, gameManager.c_hs[i].playerGutters);
        }
        for (int customBalls = 0; customBalls < gameManager.chooseBalls.Length; customBalls++)
        {
            if (customBalls > 84)
            {
                gameManager.chooseBalls[customBalls].ballName = PlayerPrefs.GetString("CustomBallName" + customBalls, gameManager.chooseBalls[customBalls].ballName);
                gameManager.chooseBalls[customBalls].lbs = PlayerPrefs.GetInt("CustomBallLbs" + customBalls, 12);
                gameManager.chooseBalls[customBalls].speed = PlayerPrefs.GetInt("CustomBallSpeed" + customBalls, 55);
                gameManager.chooseBalls[customBalls].spin = PlayerPrefs.GetInt("CustomBallSpin" + customBalls, 50);
                gameManager.chooseBalls[customBalls].urlTextureBall = PlayerPrefs.GetString("CustomBallURL" + customBalls);
                StartCoroutine(gameManager.DownloadTexture(PlayerPrefs.GetString("CustomBallURL" + customBalls), gameManager.chooseBalls[customBalls].ballMat));
            }
        }
        switch (GameManager.chooseAlleys)
        {
            case GameManager.Alley.Retro:
                alleys[0].SetActive(true);
                break;
            case GameManager.Alley.Wacky:
                alleys[1].SetActive(true);
                break;
            case GameManager.Alley.Iceberg:
                alleys[2].SetActive(true);
                break;
            case GameManager.Alley.Jungle:
                alleys[3].SetActive(true);
                break;
            case GameManager.Alley.Zen:
                alleys[4].SetActive(true);
                break;
            case GameManager.Alley.Cosmic:
                alleys[5].SetActive(true);
                break;
            case GameManager.Alley.Barnyard:
                alleys[6].SetActive(true);
                break;
            case GameManager.Alley.Mineshaft:
                alleys[7].SetActive(true);
                break;
        }
        foreach (GameObject chars in GameObject.FindGameObjectsWithTag("Chars"))
        {
            chars.SetActive(GameManager.isChars);
        }
        foreach (GameObject particles in GameObject.FindGameObjectsWithTag("Particles"))
        {
            particles.SetActive(GameManager.isParticle);
        }
        ball = GameObject.FindObjectOfType<Ball>();
        switch (GameManager.pinMode)
        {
            case GameManager.PinMode.Tenpin:
                maxBalls = 2;
                scoreCards[1].SetActive(true);
                playerName.SetActive(true);
                ball.transform.localScale = new Vector3(32, 32, 32);
                ball.rollAudio.pitch = 1f;
                ball.pinAudio.pitch = 1f;
                foreach (GameObject pins in normalPin)
                {
                    pins.SetActive(true);
                }
                isScooper = true;
                break;
            case GameManager.PinMode.Spare:
                maxBalls = 1;
                scoreCards[0].SetActive(true);
                playerName.SetActive(false);
                ball.transform.localScale = new Vector3(32, 32, 32);
                ball.rollAudio.pitch = 1f;
                ball.pinAudio.pitch = 1f;
                foreach (GameObject pins in normalPin)
                {
                    pins.SetActive(true);
                }
                isScooper = true;
                break;
            case GameManager.PinMode.Duckpin:
                maxBalls = 3;
                scoreCards[2].SetActive(true);
                playerName.SetActive(true);
                ball.transform.localScale = new Vector3(24, 24, 24);
                ball.rollAudio.pitch = 1.1f;
                ball.pinAudio.pitch = 1f;
                foreach (GameObject pins in duckPin)
                {
                    pins.SetActive(true);
                }
                isScooper = true;
                break;
            case GameManager.PinMode.Candlepin:
                maxBalls = 3;
                scoreCards[2].SetActive(true);
                playerName.SetActive(true);
                ball.transform.localScale = new Vector3(24, 24, 24);
                ball.rollAudio.pitch = 1.1f;
                ball.pinAudio.pitch = 1.1f;
                foreach (GameObject pins in candlePin)
                {
                    pins.SetActive(true);
                }
                isScooper = false;
                break;
        }
        crowd = GameObject.FindObjectOfType<Crowd>();
        commentator = GameObject.FindObjectOfType<Commentator>();
        pin1 = GameObject.Find("Pin (1)").GetComponent<Pin>();
        pin2 = GameObject.Find("Pin (2)").GetComponent<Pin>();
        pin3 = GameObject.Find("Pin (3)").GetComponent<Pin>();
        pin4 = GameObject.Find("Pin (4)").GetComponent<Pin>();
        pin5 = GameObject.Find("Pin (5)").GetComponent<Pin>();
        pin6 = GameObject.Find("Pin (6)").GetComponent<Pin>();
        pin7 = GameObject.Find("Pin (7)").GetComponent<Pin>();
        pin8 = GameObject.Find("Pin (8)").GetComponent<Pin>();
        pin9 = GameObject.Find("Pin (9)").GetComponent<Pin>();
        pin10 = GameObject.Find("Pin (10)").GetComponent<Pin>();
        pins = GameObject.FindGameObjectsWithTag("Pin");
        replays = GameObject.FindObjectsOfType<ActionReplay>();
        reactIndex = Random.Range(0, GameObject.FindObjectOfType<PinSetter>().reacts.Length);
        if (GameManager.pinMode == GameManager.PinMode.Spare)
        {
            GameObject.FindObjectOfType<PinSetter>().ResetPinsFall();
        }
        if (GameManager.isHighScore)
        {
            if (GameManager.unlockRegister == 0)
            {
                highScoreUI.SetActive(true);
                ShowAlleyScores();
            }
            else if (GameManager.unlockRegister == 1)
            {
                registerUI.SetActive(true);
            }
        }
        else
        {
            menuAlleyUI.SetActive(true);
        }
        unlockedAlley.GetComponent<Text>().text = gameManager.nameAlleys[(int)GameManager.alleyLockType] + " Alley";
        unlockedBallBeat.GetComponent<Text>().text = gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].ballName + " Ball";
        unlockedBallEarn.GetComponent<Text>().text = gameManager.chooseBalls[gameManager.unlockBallEarn].ballName + " Ball";
        unlockedBallScore.GetComponent<Text>().text = gameManager.chooseBalls[gameManager.unlockBallScore].ballName + " Ball";
        unlockedBallSpare.GetComponent<Text>().text = gameManager.chooseBalls[gameManager.unlockBallSpare].ballName + " Ball";
        InfoCam();
        introAnimIndex = Random.Range(0, GameObject.FindObjectOfType<PinSetter>().introAnimations.Length);
        scoreCardCam.transform.position = new Vector3(GameObject.FindObjectOfType<PinSetter>().scordCardPos.x, GameObject.FindObjectOfType<PinSetter>().scordCardPos.y, GameObject.FindObjectOfType<PinSetter>().scordCardPos.z);
        scoreCardCam.transform.rotation = Quaternion.Euler(GameObject.FindObjectOfType<PinSetter>().rot * GameObject.FindObjectOfType<PinSetter>().rotScoreCard, 180, 0);
        AlleyTheme(GameObject.FindObjectOfType<PinSetter>().alleySong);
        if (GameManager.isOpening && GameManager.type == GameManager.GameState.Menu)
        {
            ChargeAlleys();
            StartChargeBalls();
            opening.Play();
        }
        if (!music.isPlaying && !GameManager.isOpening && GameManager.type == GameManager.GameState.Menu)
        {
            music.Play();
        }
        if (GameManager.type == GameManager.GameState.Menu)
        {
            menuUI.SetActive(true);
            gameCam.SetActive(false);
            RandomChargeBall();
            ball.ResetBowl();
            ball.ResetCam();
        }
        else
        {
            GameManager.type = GameManager.GameState.Intro;
            gameUI.SetActive(true);
            menuCam.SetActive(false);
            chooseBallUI.SetActive(false);
            ball.Reset();
            music.Play();
            cameraFollow.type = CameraFollow.CameraType.Anim;
            if (GameManager.isVoice && GameManager.pinMode != GameManager.PinMode.Spare)
            {
                commentator.Intro(commentatorAudio);
                commentatorAudio.Play();
            }
            GameObject.FindObjectOfType<PinSetter>().introAnimations[introAnimIndex].PlayAnimation();
            StartCoroutine(IntroTime());
            if (GameManager.pinMode == GameManager.PinMode.Spare)
            {
                playerName1.text = "3";
                playerName2.text = "2";
                playerName3.text = "1";
                playerName4.text = "Go!";
            }
            if (GameManager.allPlayers == GameManager.Players.OnePlayer && GameManager.pinMode != GameManager.PinMode.Spare)
            {
                playerName1.text = gameManager.bowler[gameManager.turnNameIndex1].playerName;
            }
            else if (GameManager.allPlayers == GameManager.Players.TwoPlayer && GameManager.pinMode != GameManager.PinMode.Spare)
            {
                playerName1.text = gameManager.bowler[gameManager.turnNameIndex1].playerName;
                playerName2.text = gameManager.bowler[gameManager.turnNameIndex2].playerName;
            }
            else if (GameManager.allPlayers == GameManager.Players.ThreePlayer && GameManager.pinMode != GameManager.PinMode.Spare)
            {
                playerName1.text = gameManager.bowler[gameManager.turnNameIndex1].playerName;
                playerName2.text = gameManager.bowler[gameManager.turnNameIndex2].playerName;
                playerName3.text = gameManager.bowler[gameManager.turnNameIndex3].playerName;
            }
            else if (GameManager.allPlayers == GameManager.Players.FourPlayer && GameManager.pinMode != GameManager.PinMode.Spare)
            {
                playerName1.text = gameManager.bowler[gameManager.turnNameIndex1].playerName;
                playerName2.text = gameManager.bowler[gameManager.turnNameIndex2].playerName;
                playerName3.text = gameManager.bowler[gameManager.turnNameIndex3].playerName;
                playerName4.text = gameManager.bowler[gameManager.turnNameIndex4].playerName;
            }
            else if (GameManager.allPlayers == GameManager.Players.Computer && GameManager.pinMode != GameManager.PinMode.Spare)
            {
                playerName1.text = gameManager.bowler[gameManager.turnNameIndex1].playerName;
                playerName2.text = gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].CPUName;
            }
        }
    }

    // Update is called once per frame
    void Update ()
	{
        if (gameManager.bowler.Count == 0)
        {
            bowlerButton[0].interactable = false;
            bowlerButton[1].interactable = false;
            bowlerButton[2].interactable = false;
            bowlerButton[3].interactable = false;
        }
        else if (gameManager.bowler.Count == 1)
        {
            bowlerButton[0].interactable = true;
            bowlerButton[1].interactable = false;
            bowlerButton[2].interactable = false;
            bowlerButton[3].interactable = false;
        }
        else if (gameManager.bowler.Count == 2)
        {
            bowlerButton[0].interactable = true;
            bowlerButton[1].interactable = true;
            bowlerButton[2].interactable = false;
            bowlerButton[3].interactable = false;
        }
        else if (gameManager.bowler.Count == 3)
        {
            bowlerButton[0].interactable = true;
            bowlerButton[1].interactable = true;
            bowlerButton[2].interactable = true;
            bowlerButton[3].interactable = false;
        }
        else if (gameManager.bowler.Count >= 4)
        {
            bowlerButton[0].interactable = true;
            bowlerButton[1].interactable = true;
            bowlerButton[2].interactable = true;
            bowlerButton[3].interactable = true;
        }
        ballDataCustomText.text = customBallLbs.value + "lbs.  speed:" + customBallSpeed.value + "  spin:" + customBallSpin.value;
        replays = GameObject.FindObjectsOfType<ActionReplay>();
        if (spareBalls < 0)
        {
            ballsText.text = "no balls";
        }
        else if (spareBalls == 0)
        {
            ballsText.text = "last balls";
        }
        else if (spareBalls > 0)
        {
            ballsText.text = "balls: " + spareBalls;
        }
        stagesText.text = "stage: " + stage;
        stagesWinText.text = "stages cleared: " + stage;
        winBallRender1.material = gameManager.chooseBalls[gameManager.turnBalls1].ballMat;
        winBallRender2.material = gameManager.chooseBalls[gameManager.turnBalls2].ballMat;
        winBallRender3.material = gameManager.chooseBalls[gameManager.turnBalls3].ballMat;
        winBallRender4.material = gameManager.chooseBalls[gameManager.turnBalls4].ballMat;
        winBallRenderCPU.material = gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].ballMat;
        AlleyRegister();
        if (GameManager.isOpening)
        {
            openingTime += Time.deltaTime;
        }
        if (GameManager.isOpening && openingTime >= 14 || GameManager.isOpening && !opening.isPlaying)
        {
            music.Play();
            GameManager.isOpening = false;
        }
        sounds = GameObject.FindGameObjectsWithTag("Sound");
        music.mute = !GameManager.isMusic;
        foreach (GameObject sound in sounds)
        {
            if (GameManager.type != GameManager.GameState.Menu)
            {
                sound.GetComponent<AudioSource>().mute = !GameManager.isSound;
            }
            else if (GameManager.type == GameManager.GameState.Menu)
            {
                sound.GetComponent<AudioSource>().mute = true;
            }
        }
        if (gameManager.bowler.Count == 1)
        {
            foreach (Text winName1 in winGameName1)
            {
                winName1.text = gameManager.bowler[gameManager.turnNameIndex1].playerName;
            }
        }
        else if (gameManager.bowler.Count == 2)
        {
            foreach (Text winName1 in winGameName1)
            {
                winName1.text = gameManager.bowler[gameManager.turnNameIndex1].playerName;
            }
            foreach (Text winName2 in winGameName2)
            {
                winName2.text = gameManager.bowler[gameManager.turnNameIndex2].playerName;
            }
        }
        else if (gameManager.bowler.Count == 3)
        {
            foreach (Text winName1 in winGameName1)
            {
                winName1.text = gameManager.bowler[gameManager.turnNameIndex1].playerName;
            }
            foreach (Text winName2 in winGameName2)
            {
                winName2.text = gameManager.bowler[gameManager.turnNameIndex2].playerName;
            }
            foreach (Text winName3 in winGameName3)
            {
                winName3.text = gameManager.bowler[gameManager.turnNameIndex3].playerName;
            }
        }
        else if (gameManager.bowler.Count >= 4)
        {
            foreach (Text winName1 in winGameName1)
            {
                winName1.text = gameManager.bowler[gameManager.turnNameIndex1].playerName;
            }
            foreach (Text winName2 in winGameName2)
            {
                winName2.text = gameManager.bowler[gameManager.turnNameIndex2].playerName;
            }
            foreach (Text winName3 in winGameName3)
            {
                winName3.text = gameManager.bowler[gameManager.turnNameIndex3].playerName;
            }
            foreach (Text winName4 in winGameName4)
            {
                winName4.text = gameManager.bowler[gameManager.turnNameIndex4].playerName;
            }
        }
        foreach (Text winNameCPU in winGameNameCPU)
        {
            winNameCPU.text = gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].CPUName;
        }
        foreach (Text winScore1 in winGameScore1)
        {
            winScore1.text = "score: " + score1;
        }
        foreach (Text winScore2 in winGameScore2)
        {
            winScore2.text = "score: " + score2;
        }
        foreach (Text winScore3 in winGameScore3)
        {
            winScore3.text = "score: " + score3;
        }
        foreach (Text winScore4 in winGameScore4)
        {
            winScore4.text = "score: " + score4;
        }
        qualityText.text = QualitySettings.names[gameManager.qualityIndex];
        resolutionText.text = GameManager.resolutions[gameManager.resolutionIndex].width + " x " + GameManager.resolutions[gameManager.resolutionIndex].height;
        alleyText.text = gameManager.nameAlleys[PlayerPrefs.GetInt("ChooseAlleys")];
        selectAlleysUI.sprite = gameManager.spriteAlleys[PlayerPrefs.GetInt("ChooseAlleys")];
        if (Input.GetMouseButtonDown(0) && GameManager.type == GameManager.GameState.Intro && isIntro)
        {
            StopCoroutine(IntroTime());
            if (isIntro)
            {
                chooseBallUI.SetActive(true);
                for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().introAnimations.Length; i++)
                {
                    GameObject.FindObjectOfType<PinSetter>().introAnimations[i].SkipAnimation();
                }
                GameManager.type = GameManager.GameState.Game;
                cameraFollow.type = CameraFollow.CameraType.MoveX;
                ball.ResetCam();
                isIntro = false;
            }
        }
        if (scores1.Count <= 0)
        {
            score1 = 0;
        }
        else if (scores1.Count > 0)
        {
            score1 = scores1[scores1.Count - 1];
        }
        if (scores2.Count <= 0)
        {
            score2 = 0;
        }
        else if (scores2.Count > 0)
        {
            score2 = scores2[scores2.Count - 1];
        }
        if (scores3.Count <= 0)
        {
            score3 = 0;
        }
        else if (scores3.Count > 0)
        {
            score3 = scores3[scores3.Count - 1];
        }
        if (scores4.Count <= 0)
        {
            score4 = 0;
        }
        else if (scores4.Count > 0)
        {
            score4 = scores4[scores4.Count - 1];
        }
        if (turns == 0)
        {
            scoreTextBall2.text = "score:" + score1;
            scoreTextBall3.text = "score:" + score1;
        }
        else if (turns == 1)
        {
            scoreTextBall2.text = "score:" + score2;
            scoreTextBall3.text = "score:" + score2;
        }
        else if (turns == 2)
        {
            scoreTextBall2.text = "score:" + score3;
            scoreTextBall3.text = "score:" + score3;
        }
        else if (turns == 3)
        {
            scoreTextBall2.text = "score:" + score4;
            scoreTextBall3.text = "score:" + score4;
        }
        if (GameManager.type != GameManager.GameState.Menu)
        {
            if (playerTurn == 0)
            {
                gameManager.chooseBallIndex = gameManager.turnBalls1;
                playerNameText.text = gameManager.bowler[gameManager.turnNameIndex1].playerName;
            }
            else if (playerTurn == 1)
            {
                gameManager.chooseBallIndex = gameManager.turnBalls2;
                playerNameText.text = gameManager.bowler[gameManager.turnNameIndex2].playerName;
            }
            else if (playerTurn == 2)
            {
                gameManager.chooseBallIndex = gameManager.turnBalls3;
                playerNameText.text = gameManager.bowler[gameManager.turnBalls3].playerName;
            }
            else if (playerTurn == 3)
            {
                gameManager.chooseBallIndex = gameManager.turnBalls4;
                playerNameText.text = gameManager.bowler[gameManager.turnNameIndex4].playerName;
            }
            else if (playerTurn == 4)
            {
                gameManager.chooseBallIndex = gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex;
                playerNameText.text = gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].CPUName;
            }
            if (gameManager.chooseBallIndex < gameManager.chooseBalls.Length)
            {
                ball.ChargeBall(gameManager.chooseBalls[gameManager.chooseBallIndex].ballMat, gameManager.chooseBalls[gameManager.chooseBallIndex].lbs, gameManager.chooseBalls[gameManager.chooseBallIndex].speed, gameManager.chooseBalls[gameManager.chooseBallIndex].spin);
            }
        }
        for (int i = 0; i < regCount; i++)
        {
            if (playerTurn == 0)
            {
                if (gameManager.bowler.Count != 1)
                {
                    arrowBowler.SetActive(true);
                }
                else
                {
                    arrowBowler.SetActive(false);
                }
                if (gameManager.bowler.Count >= 1)
                {
                    bowlerText.text = gameManager.bowler[gameManager.turnNameIndex1].playerName;
                }
                if (gameManager.chooseBalls[gameManager.turnBalls1].isLock != 1)
                {
                    ballLocked.SetActive(false);
                    ballNeed.SetActive(false);
                    ballUnlock.SetActive(false);
                    if (gameManager.chooseBalls[gameManager.turnBalls1].lockType != ChooseBall.LockType.None && gameManager.chooseBalls[gameManager.turnBalls1].lockType != ChooseBall.LockType.Custom)
                    {
                        ballUnlocked.SetActive(true);
                    }
                    else
                    {
                        ballUnlocked.SetActive(false);
                    }
                    if (gameManager.chooseBalls[gameManager.turnBalls1].lockType != ChooseBall.LockType.Custom)
                    {
                        customBallButton.SetActive(false);
                    }
                    else
                    {
                        customBallButton.SetActive(true);
                    }
                    ballRender.material = gameManager.chooseBalls[gameManager.turnBalls1].ballMat;
                    SetAlwaysBowl(true);
                }
                else
                {
                    customBallButton.SetActive(false);
                    ballLocked.SetActive(true);
                    ballNeed.SetActive(true);
                    ballUnlock.SetActive(true);
                    ballUnlocked.SetActive(false);
                    ballRender.material = gameManager.lockBallMat;
                    SetAlwaysBowl(false);
                }
                if (gameManager.chooseBalls[gameManager.turnBalls1].lockType == ChooseBall.LockType.Score)
                {
                    ballUnlock.GetComponent<Text>().text = "Get a score of " + gameManager.chooseBalls[gameManager.turnBalls1].totalLock;
                }
                else if (gameManager.chooseBalls[gameManager.turnBalls1].lockType == ChooseBall.LockType.Spare)
                {
                    ballUnlock.GetComponent<Text>().text = "Get a spare of " + gameManager.chooseBalls[gameManager.turnBalls1].totalLock;
                }
                else if (gameManager.chooseBalls[gameManager.turnBalls1].lockType == ChooseBall.LockType.Beat)
                {
                    ballUnlock.GetComponent<Text>().text = "Beat " + gameManager.chooseBalls[gameManager.turnBalls1].CPUName;
                }
                else if (gameManager.chooseBalls[gameManager.turnBalls1].lockType == ChooseBall.LockType.Earn)
                {
                    ballUnlock.GetComponent<Text>().text = "Get $" + gameManager.chooseBalls[gameManager.turnBalls1].totalLock * 0.001f + ",000 Earnings";
                }
                if (gameManager.turnBalls1 >= 5 && GameManager.unlockRegister == 1)
                {
                    ballRender.material = gameManager.lockBallMat;
                }
                ballNameText.text = gameManager.chooseBalls[gameManager.turnBalls1].ballName;
                ballNameMenuText.text = gameManager.chooseBalls[gameManager.turnBalls1].ballName;
                ballDataText.text = gameManager.chooseBalls[gameManager.turnBalls1].lbs + "lbs.  speed:" + gameManager.chooseBalls[gameManager.turnBalls1].speed + "  spin:" + gameManager.chooseBalls[gameManager.turnBalls1].spin;
                ballDataMenuText.text = gameManager.chooseBalls[gameManager.turnBalls1].lbs + "lbs.  speed:" + gameManager.chooseBalls[gameManager.turnBalls1].speed + "  spin:" + gameManager.chooseBalls[gameManager.turnBalls1].spin;
            }
            else if (playerTurn == 1)
            {
                if (gameManager.bowler.Count != 1)
                {
                    arrowBowler.SetActive(true);
                }
                else
                {
                    arrowBowler.SetActive(false);
                }
                if (gameManager.bowler.Count >= 2)
                {
                    bowlerText.text = gameManager.bowler[gameManager.turnNameIndex2].playerName;
                }
                if (gameManager.chooseBalls[gameManager.turnBalls2].isLock != 1)
                {
                    ballLocked.SetActive(false);
                    ballNeed.SetActive(false);
                    ballUnlock.SetActive(false);
                    if (gameManager.chooseBalls[gameManager.turnBalls2].lockType != ChooseBall.LockType.None && gameManager.chooseBalls[gameManager.turnBalls2].lockType != ChooseBall.LockType.Custom)
                    {
                        ballUnlocked.SetActive(true);
                    }
                    else
                    {
                        ballUnlocked.SetActive(false);
                    }
                    if (gameManager.chooseBalls[gameManager.turnBalls2].lockType != ChooseBall.LockType.Custom)
                    {
                        customBallButton.SetActive(false);
                    }
                    else
                    {
                        customBallButton.SetActive(true);
                    }
                    ballRender.material = gameManager.chooseBalls[gameManager.turnBalls2].ballMat;
                    SetAlwaysBowl(true);
                }
                else
                {
                    customBallButton.SetActive(false);
                    ballLocked.SetActive(true);
                    ballNeed.SetActive(true);
                    ballUnlock.SetActive(true);
                    ballUnlocked.SetActive(false);
                    ballRender.material = gameManager.lockBallMat;
                    SetAlwaysBowl(false);
                }
                if (gameManager.chooseBalls[gameManager.turnBalls2].lockType == ChooseBall.LockType.Score)
                {
                    ballUnlock.GetComponent<Text>().text = "Get a score of " + gameManager.chooseBalls[gameManager.turnBalls2].totalLock;
                }
                else if (gameManager.chooseBalls[gameManager.turnBalls2].lockType == ChooseBall.LockType.Spare)
                {
                    ballUnlock.GetComponent<Text>().text = "Get a spare of " + gameManager.chooseBalls[gameManager.turnBalls2].totalLock;
                }
                else if (gameManager.chooseBalls[gameManager.turnBalls2].lockType == ChooseBall.LockType.Beat)
                {
                    ballUnlock.GetComponent<Text>().text = "Beat " + gameManager.chooseBalls[gameManager.turnBalls2].CPUName;
                }
                else if (gameManager.chooseBalls[gameManager.turnBalls2].lockType == ChooseBall.LockType.Earn)
                {
                    ballUnlock.GetComponent<Text>().text = "Get $" + gameManager.chooseBalls[gameManager.turnBalls2].totalLock * 0.001f + ",000 Earnings";
                }
                if (gameManager.turnBalls2 >= 5 && GameManager.unlockRegister == 1)
                {
                    ballRender.material = gameManager.lockBallMat;
                }
                ballNameText.text = gameManager.chooseBalls[gameManager.turnBalls2].ballName;
                ballNameMenuText.text = gameManager.chooseBalls[gameManager.turnBalls2].ballName;
                ballDataText.text = gameManager.chooseBalls[gameManager.turnBalls2].lbs + "lbs.  speed:" + gameManager.chooseBalls[gameManager.turnBalls2].speed + "  spin:" + gameManager.chooseBalls[gameManager.turnBalls2].spin;
                ballDataMenuText.text = gameManager.chooseBalls[gameManager.turnBalls2].lbs + "lbs.  speed:" + gameManager.chooseBalls[gameManager.turnBalls2].speed + "  spin:" + gameManager.chooseBalls[gameManager.turnBalls2].spin;
            }
            else if (playerTurn == 2)
            {
                if (gameManager.bowler.Count != 1)
                {
                    arrowBowler.SetActive(true);
                }
                else
                {
                    arrowBowler.SetActive(false);
                }
                if (gameManager.bowler.Count >= 3)
                {
                    bowlerText.text = gameManager.bowler[gameManager.turnNameIndex3].playerName;
                }
                if (gameManager.chooseBalls[gameManager.turnBalls3].isLock != 1)
                {
                    ballLocked.SetActive(false);
                    ballNeed.SetActive(false);
                    ballUnlock.SetActive(false);
                    if (gameManager.chooseBalls[gameManager.turnBalls3].lockType != ChooseBall.LockType.None && gameManager.chooseBalls[gameManager.turnBalls3].lockType != ChooseBall.LockType.Custom)
                    {
                        ballUnlocked.SetActive(true);
                    }
                    else
                    {
                        ballUnlocked.SetActive(false);
                    }
                    if (gameManager.chooseBalls[gameManager.turnBalls3].lockType != ChooseBall.LockType.Custom)
                    {
                        customBallButton.SetActive(false);
                    }
                    else
                    {
                        customBallButton.SetActive(true);
                    }
                    ballRender.material = gameManager.chooseBalls[gameManager.turnBalls3].ballMat;
                    SetAlwaysBowl(true);
                }
                else
                {
                    customBallButton.SetActive(false);
                    ballLocked.SetActive(true);
                    ballNeed.SetActive(true);
                    ballUnlock.SetActive(true);
                    ballUnlocked.SetActive(false);
                    ballRender.material = gameManager.lockBallMat;
                    SetAlwaysBowl(false);
                }
                if (gameManager.chooseBalls[gameManager.turnBalls3].lockType == ChooseBall.LockType.Score)
                {
                    ballUnlock.GetComponent<Text>().text = "Get a score of " + gameManager.chooseBalls[gameManager.turnBalls3].totalLock;
                }
                else if (gameManager.chooseBalls[gameManager.turnBalls3].lockType == ChooseBall.LockType.Spare)
                {
                    ballUnlock.GetComponent<Text>().text = "Get a spare of " + gameManager.chooseBalls[gameManager.turnBalls3].totalLock;
                }
                else if (gameManager.chooseBalls[gameManager.turnBalls3].lockType == ChooseBall.LockType.Beat)
                {
                    ballUnlock.GetComponent<Text>().text = "Beat " + gameManager.chooseBalls[gameManager.turnBalls3].CPUName;
                }
                else if (gameManager.chooseBalls[gameManager.turnBalls3].lockType == ChooseBall.LockType.Earn)
                {
                    ballUnlock.GetComponent<Text>().text = "Get $" + gameManager.chooseBalls[gameManager.turnBalls3].totalLock * 0.001f + ",000 Earnings";
                }
                if (gameManager.turnBalls3 >= 5 && GameManager.unlockRegister == 1)
                {
                    ballRender.material = gameManager.lockBallMat;
                }
                ballNameText.text = gameManager.chooseBalls[gameManager.turnBalls3].ballName;
                ballNameMenuText.text = gameManager.chooseBalls[gameManager.turnBalls3].ballName;
                ballDataText.text = gameManager.chooseBalls[gameManager.turnBalls3].lbs + "lbs.  speed:" + gameManager.chooseBalls[gameManager.turnBalls3].speed + "  spin:" + gameManager.chooseBalls[gameManager.turnBalls3].spin;
                ballDataMenuText.text = gameManager.chooseBalls[gameManager.turnBalls3].lbs + "lbs.  speed:" + gameManager.chooseBalls[gameManager.turnBalls3].speed + "  spin:" + gameManager.chooseBalls[gameManager.turnBalls3].spin;
            }
            else if (playerTurn == 3)
            {
                if (gameManager.bowler.Count != 1)
                {
                    arrowBowler.SetActive(true);
                }
                else
                {
                    arrowBowler.SetActive(false);
                }
                if (gameManager.bowler.Count >= 4)
                {
                    bowlerText.text = gameManager.bowler[gameManager.turnNameIndex4].playerName;
                }
                if (gameManager.chooseBalls[gameManager.turnBalls4].isLock != 1)
                {
                    ballLocked.SetActive(false);
                    ballNeed.SetActive(false);
                    ballUnlock.SetActive(false);
                    if (gameManager.chooseBalls[gameManager.turnBalls4].lockType != ChooseBall.LockType.None && gameManager.chooseBalls[gameManager.turnBalls4].lockType != ChooseBall.LockType.Custom)
                    {
                        ballUnlocked.SetActive(true);
                    }
                    else
                    {
                        ballUnlocked.SetActive(false);
                    }
                    if (gameManager.chooseBalls[gameManager.turnBalls4].lockType != ChooseBall.LockType.Custom)
                    {
                        customBallButton.SetActive(false);
                    }
                    else
                    {
                        customBallButton.SetActive(true);
                    }
                    ballRender.material = gameManager.chooseBalls[gameManager.turnBalls4].ballMat;
                    SetAlwaysBowl(true);
                }
                else
                {
                    customBallButton.SetActive(false);
                    ballLocked.SetActive(true);
                    ballNeed.SetActive(true);
                    ballUnlock.SetActive(true);
                    ballUnlocked.SetActive(false);
                    ballRender.material = gameManager.lockBallMat;
                    SetAlwaysBowl(false);
                }
                if (gameManager.chooseBalls[gameManager.turnBalls4].lockType == ChooseBall.LockType.Score)
                {
                    ballUnlock.GetComponent<Text>().text = "Get a score of " + gameManager.chooseBalls[gameManager.turnBalls4].totalLock;
                }
                else if (gameManager.chooseBalls[gameManager.turnBalls4].lockType == ChooseBall.LockType.Spare)
                {
                    ballUnlock.GetComponent<Text>().text = "Get a spare of " + gameManager.chooseBalls[gameManager.turnBalls4].totalLock;
                }
                else if (gameManager.chooseBalls[gameManager.turnBalls4].lockType == ChooseBall.LockType.Beat)
                {
                    ballUnlock.GetComponent<Text>().text = "Beat " + gameManager.chooseBalls[gameManager.turnBalls4].CPUName;
                }
                else if (gameManager.chooseBalls[gameManager.turnBalls4].lockType == ChooseBall.LockType.Earn)
                {
                    ballUnlock.GetComponent<Text>().text = "Get $" + gameManager.chooseBalls[gameManager.turnBalls4].totalLock * 0.001f + ",000 Earnings";
                }
                if (gameManager.turnBalls4 >= 5 && GameManager.unlockRegister == 1)
                {
                    ballRender.material = gameManager.lockBallMat;
                }
                ballNameText.text = gameManager.chooseBalls[gameManager.turnBalls4].ballName;
                ballNameMenuText.text = gameManager.chooseBalls[gameManager.turnBalls4].ballName;
                ballDataText.text = gameManager.chooseBalls[gameManager.turnBalls4].lbs + "lbs.  speed:" + gameManager.chooseBalls[gameManager.turnBalls4].speed + "  spin:" + gameManager.chooseBalls[gameManager.turnBalls4].spin;
                ballDataMenuText.text = gameManager.chooseBalls[gameManager.turnBalls4].lbs + "lbs.  speed:" + gameManager.chooseBalls[gameManager.turnBalls4].speed + "  spin:" + gameManager.chooseBalls[gameManager.turnBalls4].spin;
            }
            else if (playerTurn == 4)
            {
                arrowBowler.SetActive(false);
                bowlerText.text = gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].CPUName;
                ballLocked.SetActive(false);
                ballNeed.SetActive(false);
                ballUnlock.SetActive(false);
                ballUnlocked.SetActive(false);
                if (GameManager.unlockRegister == 0 || gameManager.turnBallsCPU < 2 && GameManager.unlockRegister == 1)
                {
                    ballRender.material = gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].ballMat;
                    if (gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].lockType != ChooseBall.LockType.Custom)
                    {
                        customBallButton.SetActive(false);
                    }
                    else
                    {
                        customBallButton.SetActive(true);
                    }
                }
                if (gameManager.turnBallsCPU >= 2 && GameManager.unlockRegister == 1)
                {
                    customBallButton.SetActive(false);
                    ballRender.material = gameManager.lockBallMat;
                }
                SetAlwaysBowl(true);
                ballNameText.text = gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].ballName;
                ballNameMenuText.text = gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].ballName;
                ballDataText.text = gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].lbs + "lbs.  speed:" + gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].speed + "  spin:" + gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].spin;
                ballDataMenuText.text = gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].lbs + "lbs.  speed:" + gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].speed + "  spin:" + gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].spin;
            }
            if (GameManager.unlockRegister == 0 || gameManager.turnBalls1 < 5 && GameManager.unlockRegister == 1 && playerTurn == 0 || gameManager.turnBalls2 < 5 && GameManager.unlockRegister == 1 && playerTurn == 1 || gameManager.turnBalls3 < 5 && GameManager.unlockRegister == 1 && playerTurn == 2 || gameManager.turnBalls4 < 5 && GameManager.unlockRegister == 1 && playerTurn == 3 || gameManager.turnBallsCPU < 2 && GameManager.unlockRegister == 1 && playerTurn == 4)
            {
                ballRegistered.SetActive(false);
                ballsRegisterButton[i].SetActive(false);
                SetAlwaysBowlReg(true);
            }
            else if (gameManager.turnBalls1 >= 5 && GameManager.unlockRegister == 1 && playerTurn == 0 || gameManager.turnBalls2 >= 5 && GameManager.unlockRegister == 1 && playerTurn == 1 || gameManager.turnBalls3 >= 5 && GameManager.unlockRegister == 1 && playerTurn == 2 || gameManager.turnBalls4 >= 5 && GameManager.unlockRegister == 1 && playerTurn == 3 || gameManager.turnBallsCPU >= 2 && GameManager.unlockRegister == 1 && playerTurn == 4)
            {
                customBallButton.SetActive(false);
                ballLocked.SetActive(false);
                ballNeed.SetActive(false);
                ballUnlock.SetActive(false);
                ballUnlocked.SetActive(false);
                ballRegistered.SetActive(true);
                ballsRegisterButton[i].SetActive(true);
                SetAlwaysBowlReg(false);
            }
        }
        gbAnimIndex = Random.Range(0, GameObject.FindObjectOfType<PinSetter>().gutterballAnimations.Length);
        gbAnimIndex2X = Random.Range(0, GameObject.FindObjectOfType<PinSetter>().gutterballAnimationTwoTimes.Length);
        replayIndex = Random.Range(0, GameObject.FindObjectOfType<PinSetter>().replays.Length);
        reactIndex = Random.Range(0, GameObject.FindObjectOfType<PinSetter>().reacts.Length);
        pin7.isHitOne = true;
        pin10.isHitOne = true;
        if (pin7.IsStanding() == false)
        {
            pin8.isHitOne = true;
        }
        if (pin10.IsStanding() == false)
        {
            pin9.isHitOne = true;
        }
        if (pin7.IsStanding() == false && pin8.IsStanding() == false && pin9.IsStanding() == false && pin10.IsStanding() == false)
        {
            pin4.isHitOne = true;
        }
        if (pin7.IsStanding() == false && pin8.IsStanding() == false && pin9.IsStanding() == false && pin10.IsStanding() == false)
        {
            pin5.isHitOne = true;
        }
        if (pin7.IsStanding() == false && pin8.IsStanding() == false && pin9.IsStanding() == false && pin10.IsStanding() == false)
        {
            pin6.isHitOne = true;
        }
        if (pin4.IsStanding() == false && pin5.IsStanding() == false && pin7.IsStanding() == false && pin8.IsStanding() == false && pin10.IsStanding() == false)
        {
            pin2.isHitOne = true;
        }
        if (pin5.IsStanding() == false && pin6.IsStanding() == false && pin7.IsStanding() == false && pin9.IsStanding() == false && pin10.IsStanding() == false)
        {
            pin3.isHitOne = true;
        }
        if (pin2.IsStanding() == false && pin3.IsStanding() == false && pin4.IsStanding() == false && pin5.IsStanding() == false && pin6.IsStanding() == false && pin7.IsStanding() == false && pin8.IsStanding() == false && pin9.IsStanding() == false && pin10.IsStanding() == false)
        {
            pin1.isHitOne = true;
        }
        if (rainIndex == 8)
        {
            rainIndex = 0;
        }
        if (commentatorAudio.isPlaying == isCommentator && commentatorIndex == 1 && allVoices < AllVoices.Perfect)
        {
            commentatorIndex = 2;
        }
        if (commentatorIndex == 2 && allVoices < AllVoices.Perfect)
        {
            commentatorTime += Time.unscaledDeltaTime;
        }
        if (commentatorTime >= 0.5f && commentatorIndex == 2)
        {
            commentator.SecondVoice(commentatorAudio);
            commentatorAudio.Play();
            commentatorTime = 0;
            commentatorIndex = 3;
        }
        if (commentatorAudio.isPlaying == isCommentator && commentatorIndex == 3 || commentatorAudio.isPlaying == isCommentator && allVoices == AllVoices.Perfect)
        {
            if (crowdType == Crowds.CheerBig)
            {
                CheerBig();
            }
            if (crowdType == Crowds.CheerMed)
            {
                CheerMed();
            }
            if (crowdType == Crowds.CrowdOk)
            {
                CrowdOk();
            }
            if (crowdType == Crowds.CrowdHohum)
            {
                CrowdHohum();
            }
            if (crowdType == Crowds.CrowdCrap)
            {
                CrowdCrap();
            }
            if (crowdType == Crowds.Laugh)
            {
                Laugh();
            }
            if (crowdType == Crowds.Oooh)
            {
                Oooh();
            }
            if (crowdType == Crowds.Firework)
            {
                winCrowd.Play();
                fireworksMulti.Play();
            }
            isCommentator = true;
            commentatorTime = 0;
            commentatorIndex = 0;
        }
        pinCounter.UpdateStandingCountAndSettle();
        if (throwBall < maxBalls)
        {
            if (pin1.IsStanding() == false || pin2.IsStanding() == false || pin3.IsStanding() == false || pin4.IsStanding() == false || pin5.IsStanding() == false || pin6.IsStanding() == false || pin7.IsStanding() == false || pin8.IsStanding() == false || pin9.IsStanding() == false || pin10.GetComponent<Pin>().IsStanding() == false)
            {
                isSplit = false;
                is710 = false;
            }
        }
        for (int i = 0; i < pinSplits.Length; i++)
        {
            if (pin1.IsStanding() == pinSplits[i].isPin1 && pin2.IsStanding() == pinSplits[i].isPin2 && pin3.IsStanding() == pinSplits[i].isPin3 && pin4.IsStanding() == pinSplits[i].isPin4 && pin5.IsStanding() == pinSplits[i].isPin5 && pin6.IsStanding() == pinSplits[i].isPin6 && pin7.IsStanding() == pinSplits[i].isPin7 && pin8.IsStanding() == pinSplits[i].isPin8 && pin9.IsStanding() == pinSplits[i].isPin9 && pin10.IsStanding() == pinSplits[i].isPin10 && throwBall < maxBalls)
            {
                isSplit = true;
                is710 = false;
            }
        }
        if (pin1.IsStanding() == false && pin2.IsStanding() == false && pin3.IsStanding() == false && pin4.IsStanding() == false && pin5.IsStanding() == false && pin6.IsStanding() == false && pin7.IsStanding() == true && pin8.IsStanding() == false && pin9.IsStanding() == false && pin10.IsStanding() == true && throwBall < maxBalls)
        {
            isSplit = true;
            is710 = true;
        }
        if (replayTime < 5 && isReplayRecord)
        {
            replayTime += Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (isReplayRecord)
        {
            for (int i = 0; i < replays.Length; i++)
            {
                replays[i].Add();
            }
        }
        float nextIndex;
        if (isCurrentReplay)
        {
            nextIndex = currentReplayIndex + 1;

            for (int i = 0; i < replays.Length; i++)
            {
                if (nextIndex >= 0 && nextIndex < replays[i].actionReplayRecords.Count)
                {
                    replays[i].SetTransform(nextIndex);
                }
            }
        }
        else
        {
            nextIndex = 0;
        }
        if (!isReplayRecord && !isCurrentReplay)
        {
            for (int i = 0; i < replays.Length; i++)
            {
                replays[i].Clear();
            }
        }
    }

    public IEnumerator IntroTime()
    {
        yield return new WaitForSeconds(GameObject.FindObjectOfType<PinSetter>().introAnimations[introAnimIndex].time);
        if (isIntro)
        {
            chooseBallUI.SetActive(true);
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().introAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().introAnimations[i].StopAnimation();
            }
            GameManager.type = GameManager.GameState.Game;
            cameraFollow.type = CameraFollow.CameraType.MoveX;
            isIntro = false;
        }
    }

    public IEnumerator PinTimeA(float time)
	{
        if (b != null)
        {
            StopCoroutine(b);
        }
        if (GameManager.type == GameManager.GameState.Replay)
        {
            GameManager.type = GameManager.GameState.Game;
        }
        yield return new WaitForSeconds(time);
        b = StartCoroutine(PinTimeB());

        yield return null;
    }

    public IEnumerator PinTimeB()
    {
        ball.rollAudio.Stop();
        ball.gutterAudio.Stop();
        if (GameManager.type == GameManager.GameState.Game)
        {
            GameManager.type = GameManager.GameState.Replay;
        }
        GameObject.FindObjectOfType<PinSetter>().DownPins();
        pinCounter.PinsHaveSettled();
        if (maxBalls == 2)
        {
            if (PinCounter.pinCount == 0 && throwBall == 1)
            {
                if (scoreDisplay[turns].strikes == ScoreDisplay.Strikes.Strike)
                {
                    animations = AnimationScenes.Strike;
                    if (GameManager.type == GameManager.GameState.Replay)
                    {
                        VoiceStrike();
                    }
                }
                if (scoreDisplay[turns].strikes == ScoreDisplay.Strikes.Double)
                {
                    animations = AnimationScenes.Double;
                    if (GameManager.type == GameManager.GameState.Replay)
                    {
                        VoiceDouble();
                    }
                    RainCountdown();
                }
                if (scoreDisplay[turns].strikes == ScoreDisplay.Strikes.Turkey)
                {
                    animations = AnimationScenes.Turkey;
                    if (GameManager.type == GameManager.GameState.Replay)
                    {
                        VoiceTurkey();
                    }
                    RainCountdown();
                }
                if (pinCounts == 10)
                {
                    if (playerTurn == 0)
                    {
                        strikes1++;
                    }
                    else if (playerTurn == 1 || playerTurn == 4)
                    {
                        strikes2++;
                    }
                    else if (playerTurn == 2)
                    {
                        strikes3++;
                    }
                    else if (playerTurn == 3)
                    {
                        strikes4++;
                    }
                    scoreDisplay[turns].AllStrike();
                }
            }
        }
        else if (maxBalls == 3)
        {
            if (PinCounter.pinCount == 0 && throwBall == 1)
            {
                if (scoreDisplay3[turns].strikes == ScoreDisplayBall3.Strikes.Strike)
                {
                    animations = AnimationScenes.Strike;
                    if (GameManager.type == GameManager.GameState.Replay)
                    {
                        VoiceStrike();
                    }
                }
                if (scoreDisplay3[turns].strikes == ScoreDisplayBall3.Strikes.Double)
                {
                    animations = AnimationScenes.Double;
                    if (GameManager.type == GameManager.GameState.Replay)
                    {
                        VoiceDouble();
                    }
                    RainCountdown();
                }
                if (scoreDisplay3[turns].strikes == ScoreDisplayBall3.Strikes.Turkey)
                {
                    animations = AnimationScenes.Turkey;
                    if (GameManager.type == GameManager.GameState.Replay)
                    {
                        VoiceTurkey();
                    }
                    RainCountdown();
                }
                if (pinCounts == 10)
                {
                    if (playerTurn == 0)
                    {
                        strikes1++;
                    }
                    else if (playerTurn == 1 || playerTurn == 4)
                    {
                        strikes2++;
                    }
                    else if (playerTurn == 2)
                    {
                        strikes3++;
                    }
                    else if (playerTurn == 3)
                    {
                        strikes4++;
                    }
                    scoreDisplay3[turns].AllStrike();
                }
            }
        }
        if (PinCounter.pinCount == 0 && throwBall == 2)
        {
            animations = AnimationScenes.Spare;
            if (isSplit)
            {
                if (GameManager.type == GameManager.GameState.Replay)
                {
                    VoiceSplitPick();
                }
            }
            else
            {
                if (GameManager.type == GameManager.GameState.Replay)
                {
                    VoiceSpare();
                }
            }
            if (playerTurn == 0)
            {
                spares1++;
            }
            else if (playerTurn == 1 || playerTurn == 4)
            {
                spares2++;
            }
            else if (playerTurn == 2)
            {
                spares3++;
            }
            else if (playerTurn == 3)
            {
                spares4++;
            }
        }
        if (gutterAnimation == 0 && isReplay || PinCounter.pinCount == 0)
        {
            if (replayText != null && GameManager.type == GameManager.GameState.Replay)
            {
                replayText.SetActive(true);
            }
            isReplay = true;
            isReplayRecord = false;
            isCurrentReplay = true;
            for (int i = 0; i < replays.Length; i++)
            {
                replays[i].RigidBodyFreeze(true);
                replays[i].RigidBodyCollider(false);
                replays[i].SetTransform(0);
            }
            cameraFollow.Replay(replayIndex);
            yield return new WaitForSeconds(replayTime);
            for (int i = 0; i < replays.Length; i++)
            {
                replays[i].RigidBodyFreeze(false);
                replays[i].RigidBodyCollider(true);
                replays[i].SetTransform(replays[i].actionReplayRecords.Count - 1);
                replays[i].Clear();
                replays[i].SetVelocity();
            }
            isPin = false;
            isReplayRecord = true;
        }
        if (replayText != null)
        {
            replayText.SetActive(false);
        }
        isCurrentReplay = false;
        currentReplayIndex = 0;
        replayTime = 0;
        if (gutterAnimation == 0 && animations == AnimationScenes.Off)
        {
            cameraFollow.React(reactIndex);
        }
        else if (animations == AnimationScenes.Strike)
        {
            isAnim = true;
            cameraFollow.type = CameraFollow.CameraType.Anim;
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().strikeAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().strikeAnimations[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().spareAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().spareAnimations[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().gutterballAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().gutterballAnimations[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().gutterballAnimationTwoTimes.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().gutterballAnimationTwoTimes[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().doubleAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().doubleAnimations[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().turkeyAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().turkeyAnimations[i].SkipAnimation();
            }
            GameObject.FindObjectOfType<PinSetter>().strikeAnimations[Random.Range(0, GameObject.FindObjectOfType<PinSetter>().strikeAnimations.Length)].PlayAnimation();
        }
        else if (animations == AnimationScenes.Spare)
        {
            isAnim = true;
            cameraFollow.type = CameraFollow.CameraType.Anim;
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().strikeAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().strikeAnimations[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().spareAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().spareAnimations[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().gutterballAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().gutterballAnimations[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().gutterballAnimationTwoTimes.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().gutterballAnimationTwoTimes[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().doubleAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().doubleAnimations[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().turkeyAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().turkeyAnimations[i].SkipAnimation();
            }
            GameObject.FindObjectOfType<PinSetter>().spareAnimations[Random.Range(0, GameObject.FindObjectOfType<PinSetter>().spareAnimations.Length)].PlayAnimation();
        }
        else if (animations == AnimationScenes.Double)
        {
            isAnim = true;
            cameraFollow.type = CameraFollow.CameraType.Anim;
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().strikeAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().strikeAnimations[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().spareAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().spareAnimations[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().gutterballAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().gutterballAnimations[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().gutterballAnimationTwoTimes.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().gutterballAnimationTwoTimes[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().doubleAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().doubleAnimations[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().turkeyAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().turkeyAnimations[i].SkipAnimation();
            }
            GameObject.FindObjectOfType<PinSetter>().doubleAnimations[Random.Range(0, GameObject.FindObjectOfType<PinSetter>().doubleAnimations.Length)].PlayAnimation();
        }
        else if (animations == AnimationScenes.Turkey)
        {
            isAnim = true;
            cameraFollow.type = CameraFollow.CameraType.Anim;
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().strikeAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().strikeAnimations[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().spareAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().spareAnimations[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().gutterballAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().gutterballAnimations[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().gutterballAnimationTwoTimes.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().gutterballAnimationTwoTimes[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().doubleAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().doubleAnimations[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().turkeyAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().turkeyAnimations[i].SkipAnimation();
            }
            GameObject.FindObjectOfType<PinSetter>().turkeyAnimations[Random.Range(0, GameObject.FindObjectOfType<PinSetter>().turkeyAnimations.Length)].PlayAnimation();
        }
        else if (gutterAnimation == 1)
        {
            isReplay = true;
            isAnim = true;
            cameraFollow.type = CameraFollow.CameraType.Anim;
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().strikeAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().strikeAnimations[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().spareAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().spareAnimations[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().gutterballAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().gutterballAnimations[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().gutterballAnimationTwoTimes.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().gutterballAnimationTwoTimes[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().doubleAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().doubleAnimations[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().turkeyAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().turkeyAnimations[i].SkipAnimation();
            }
            GameObject.FindObjectOfType<PinSetter>().gutterballAnimations[gbAnimIndex].PlayAnimation();
        }
        else if (gutterAnimation == 2)
        {
            isReplay = true;
            isAnim = true;
            cameraFollow.type = CameraFollow.CameraType.Anim;
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().strikeAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().strikeAnimations[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().spareAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().spareAnimations[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().gutterballAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().gutterballAnimations[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().gutterballAnimationTwoTimes.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().gutterballAnimationTwoTimes[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().doubleAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().doubleAnimations[i].SkipAnimation();
            }
            for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().turkeyAnimations.Length; i++)
            {
                GameObject.FindObjectOfType<PinSetter>().turkeyAnimations[i].SkipAnimation();
            }
            GameObject.FindObjectOfType<PinSetter>().gutterballAnimationTwoTimes[gbAnimIndex2X].PlayAnimation();
        }
        if (isScooper || !isScooper && PinCounter.pinCount == 0 || !isScooper && throwBall == maxBalls)
        {
            GameObject.FindObjectOfType<PinSetter>().ScooperPins();
        }
        if (!isScooper && throwBall < maxBalls)
        {
            GameObject.FindObjectOfType<PinSetter>().DownPins();
            foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
            {
                pin.PinLight();
            }
        }
        if (gutterAnimation == 1)
        {
            yield return new WaitForSeconds(GameObject.FindObjectOfType<PinSetter>().gutterballAnimations[gbAnimIndex].time);
            isAnim = false;
            if (!isReplay || gutterAnimation != 0)
            {
                if (GameObject.FindObjectOfType<PinSetter>().returnPoint != null)
                {
                    cameraFollow.transform.position = new Vector3(GameObject.FindObjectOfType<PinSetter>().returnPoint.position.x + 100, GameObject.FindObjectOfType<PinSetter>().returnPoint.position.y + 100, GameObject.FindObjectOfType<PinSetter>().returnPoint.position.z + 400);
                    cameraFollow.transform.rotation = Quaternion.LookRotation(ball.transform.position - cameraFollow.transform.position);
                    cameraFollow.type = CameraFollow.CameraType.ReturnBall;
                }
                ball.BallReturn();
            }
            if (GameObject.FindObjectOfType<PinSetter>().returnPoint != null)
            {
                yield return new WaitForSeconds(5);
            }
        } 
        else if(gutterAnimation == 2)
        {
            yield return new WaitForSeconds(GameObject.FindObjectOfType<PinSetter>().gutterballAnimationTwoTimes[gbAnimIndex2X].time);
            isAnim = false;
            if (!isReplay || gutterAnimation != 0)
            {
                if (GameObject.FindObjectOfType<PinSetter>().returnPoint != null)
                {
                    cameraFollow.transform.position = new Vector3(GameObject.FindObjectOfType<PinSetter>().returnPoint.position.x + 100, GameObject.FindObjectOfType<PinSetter>().returnPoint.position.y + 100, GameObject.FindObjectOfType<PinSetter>().returnPoint.position.z + 400);
                    cameraFollow.transform.rotation = Quaternion.LookRotation(ball.transform.position - cameraFollow.transform.position);
                    cameraFollow.type = CameraFollow.CameraType.ReturnBall;
                }
                ball.BallReturn();
            }
            if (GameObject.FindObjectOfType<PinSetter>().returnPoint != null)
            {
                yield return new WaitForSeconds(5);
            }
        }
        else if (gutterAnimation == 0)
        {
            yield return new WaitForSeconds(1);
            if (!isReplay || gutterAnimation != 0)
            {
                ball.BallReturn();
            }
            yield return new WaitForSeconds(4);
        }
        SkipReplay();
        isReplayRecord = false;
    }

    public void InfoCam()
    {
        infoCam.position = GameObject.FindObjectOfType<PinSetter>().reacts[reactIndex].position;
        infoCam.rotation = GameObject.FindObjectOfType<PinSetter>().reacts[reactIndex].rotation;
    }

    public void AlleyTheme(string theme)
    {
        music.clip = Resources.Load<AudioClip>("Music/" + theme);
    }

    public void Bowl(int pinFall)
    {
        if (maxBalls == 1 && GameManager.type == GameManager.GameState.Replay)
        {
            if (PinCounter.pinCount != 0)
            {
                CrowdCrap();
                spareBalls--;
            }
            else
            {
                CheerMed();
                stage++;
            }
            if (spareBalls < 0)
            {
                wins = 0;
                isEndGame = true;
            }
        }
        else if (maxBalls == 2 && GameManager.type == GameManager.GameState.Replay)
        {
            if (GameManager.allPlayers == GameManager.Players.OnePlayer)
            {
                try
                {
                    rolls1.Add(pinFall);
                    GameObject.FindObjectOfType<PinSetter>().PerformAction(ActionMasterOld.NextAction(rolls1));
                }
                catch
                {
                    isEndGame = true;
                    Debug.LogWarning("Something went wrong in Bowl()");
                }

                try
                {
                    scoreDisplay[0].FillRolls(rolls1);
                    scoreDisplay[0].FillFrames(ScoreMaster.ScoreCumulative(rolls1));
                    scores1 = ScoreMaster.ScoreCumulative(rolls1);

                }
                catch
                {
                    Debug.LogWarning("FillRollCard failed");
                }
            }
            else if (GameManager.allPlayers == GameManager.Players.TwoPlayer)
            {
                if (nextTurn == 0)
                {
                    if (ballTurn == 0)
                    {
                        if (pinFall == 10)
                        {
                            if (frames1 != 10)
                            {
                                nextTurn = 1;
                                frames1++;
                            }
                            else
                            {
                                nextTurn = 0;
                            }
                        }
                        else
                        {
                            ballTurn = 1;
                        }
                    }
                    else
                    {
                        if (frames1 != 10)
                        {
                            nextTurn = 1;
                            ballTurn = 0;
                            frames1++;
                        }
                        else
                        {
                            nextTurn = 0;
                        }
                    }
                    try
                    {
                        rolls1.Add(pinFall);
                        GameObject.FindObjectOfType<PinSetter>().PerformAction(ActionMasterOld.NextAction(rolls1));
                    }
                    catch
                    {
                        nextTurn = 1;
                        ballTurn = 0;
                        isResetPins = true;
                        Debug.LogWarning("Something went wrong in Bowl()");
                    }

                    try
                    {
                        scoreDisplay[0].FillRolls(rolls1);
                        scoreDisplay[0].FillFrames(ScoreMaster.ScoreCumulative(rolls1));
                        scores1 = ScoreMaster.ScoreCumulative(rolls1);

                    }
                    catch
                    {
                        Debug.LogWarning("FillRollCard failed");
                    }
                }
                else
                {
                    if (ballTurn == 0)
                    {
                        if (pinFall == 10)
                        {
                            if (frames2 != 10)
                            {
                                nextTurn = 0;
                                frames2++;
                            }
                            else
                            {
                                nextTurn = 1;
                            }
                        }
                        else
                        {
                            ballTurn = 1;
                        }
                    }
                    else
                    {
                        if (frames2 != 10)
                        {
                            nextTurn = 0;
                            ballTurn = 0;
                            frames2++;
                        }
                        else
                        {
                            nextTurn = 1;
                        }
                    }
                    try
                    {
                        rolls2.Add(pinFall);
                        GameObject.FindObjectOfType<PinSetter>().PerformAction(ActionMasterOld.NextAction(rolls2));
                    }
                    catch
                    {
                        isEndGame = true;
                        Debug.LogWarning("Something went wrong in Bowl()");
                    }

                    try
                    {
                        scoreDisplay[1].FillRolls(rolls2);
                        scoreDisplay[1].FillFrames(ScoreMaster.ScoreCumulative(rolls2));
                        scores2 = ScoreMaster.ScoreCumulative(rolls2);
                    }
                    catch
                    {
                        Debug.LogWarning("FillRollCard failed");
                    }
                }
            }
            else if (GameManager.allPlayers == GameManager.Players.ThreePlayer)
            {
                if (nextTurn == 0)
                {
                    if (ballTurn == 0)
                    {
                        if (pinFall == 10)
                        {
                            if (frames1 != 10)
                            {
                                nextTurn = 1;
                                frames1++;
                            }
                            else
                            {
                                nextTurn = 0;
                            }
                        }
                        else
                        {
                            ballTurn = 1;
                        }
                    }
                    else
                    {
                        if (frames1 != 10)
                        {
                            nextTurn = 1;
                            ballTurn = 0;
                            frames1++;
                        }
                        else
                        {
                            nextTurn = 0;
                        }
                    }
                    try
                    {
                        rolls1.Add(pinFall);
                        GameObject.FindObjectOfType<PinSetter>().PerformAction(ActionMasterOld.NextAction(rolls1));
                    }
                    catch
                    {
                        nextTurn = 1;
                        ballTurn = 0;
                        isResetPins = true;
                        Debug.LogWarning("Something went wrong in Bowl()");
                    }

                    try
                    {
                        scoreDisplay[0].FillRolls(rolls1);
                        scoreDisplay[0].FillFrames(ScoreMaster.ScoreCumulative(rolls1));
                        scores1 = ScoreMaster.ScoreCumulative(rolls1);

                    }
                    catch
                    {
                        Debug.LogWarning("FillRollCard failed");
                    }
                }
                else if (nextTurn == 1)
                {
                    if (ballTurn == 0)
                    {
                        if (pinFall == 10)
                        {
                            if (frames2 != 10)
                            {
                                nextTurn = 2;
                                frames2++;
                            }
                            else
                            {
                                nextTurn = 1;
                            }
                        }
                        else
                        {
                            ballTurn = 1;
                        }
                    }
                    else
                    {
                        if (frames2 != 10)
                        {
                            nextTurn = 2;
                            ballTurn = 0;
                            frames2++;
                        }
                        else
                        {
                            nextTurn = 1;
                        }
                    }
                    try
                    {
                        rolls2.Add(pinFall);
                        GameObject.FindObjectOfType<PinSetter>().PerformAction(ActionMasterOld.NextAction(rolls2));
                    }
                    catch
                    {
                        nextTurn = 2;
                        ballTurn = 0;
                        isResetPins = true;
                        Debug.LogWarning("Something went wrong in Bowl()");
                    }

                    try
                    {
                        scoreDisplay[1].FillRolls(rolls2);
                        scoreDisplay[1].FillFrames(ScoreMaster.ScoreCumulative(rolls2));
                        scores2 = ScoreMaster.ScoreCumulative(rolls2);
                    }
                    catch
                    {
                        Debug.LogWarning("FillRollCard failed");
                    }
                }
                else
                {
                    if (ballTurn == 0)
                    {
                        if (pinFall == 10)
                        {
                            if (frames3 != 10)
                            {
                                nextTurn = 0;
                                frames3++;
                            }
                            else
                            {
                                nextTurn = 2;
                            }
                        }
                        else
                        {
                            ballTurn = 1;
                        }
                    }
                    else
                    {
                        if (frames3 != 10)
                        {
                            nextTurn = 0;
                            ballTurn = 0;
                            frames3++;
                        }
                        else
                        {
                            nextTurn = 2;
                        }
                    }
                    try
                    {
                        rolls3.Add(pinFall);
                        GameObject.FindObjectOfType<PinSetter>().PerformAction(ActionMasterOld.NextAction(rolls3));
                    }
                    catch
                    {
                        isEndGame = true;
                        Debug.LogWarning("Something went wrong in Bowl()");
                    }

                    try
                    {
                        scoreDisplay[2].FillRolls(rolls3);
                        scoreDisplay[2].FillFrames(ScoreMaster.ScoreCumulative(rolls3));
                        scores3 = ScoreMaster.ScoreCumulative(rolls3);
                    }
                    catch
                    {
                        Debug.LogWarning("FillRollCard failed");
                    }
                }
            }
            else if (GameManager.allPlayers == GameManager.Players.FourPlayer)
            {
                if (nextTurn == 0)
                {
                    if (ballTurn == 0)
                    {
                        if (pinFall == 10)
                        {
                            if (frames1 != 10)
                            {
                                nextTurn = 1;
                                frames1++;
                            }
                            else
                            {
                                nextTurn = 0;
                            }
                        }
                        else
                        {
                            ballTurn = 1;
                        }
                    }
                    else
                    {
                        if (frames1 != 10)
                        {
                            nextTurn = 0;
                            ballTurn = 0;
                            frames1++;
                        }
                        else
                        {
                            nextTurn = 0;
                        }
                    }
                    try
                    {
                        rolls1.Add(pinFall);
                        GameObject.FindObjectOfType<PinSetter>().PerformAction(ActionMasterOld.NextAction(rolls1));
                    }
                    catch
                    {
                        nextTurn = 1;
                        ballTurn = 0;
                        isResetPins = true;
                        Debug.LogWarning("Something went wrong in Bowl()");
                    }

                    try
                    {
                        scoreDisplay[0].FillRolls(rolls1);
                        scoreDisplay[0].FillFrames(ScoreMaster.ScoreCumulative(rolls1));
                        scores1 = ScoreMaster.ScoreCumulative(rolls1);

                    }
                    catch
                    {
                        Debug.LogWarning("FillRollCard failed");
                    }
                }
                else if (nextTurn == 1)
                {
                    if (ballTurn == 0)
                    {
                        if (pinFall == 10)
                        {
                            if (frames2 != 10)
                            {
                                nextTurn = 2;
                                frames2++;
                            }
                            else
                            {
                                nextTurn = 1;
                            }
                        }
                        else
                        {
                            ballTurn = 1;
                        }
                    }
                    else
                    {
                        if (frames2 != 10)
                        {
                            nextTurn = 2;
                            ballTurn = 0;
                            frames2++;
                        }
                        else
                        {
                            nextTurn = 1;
                        }
                    }
                    try
                    {
                        rolls2.Add(pinFall);
                        GameObject.FindObjectOfType<PinSetter>().PerformAction(ActionMasterOld.NextAction(rolls2));
                    }
                    catch
                    {
                        nextTurn = 2;
                        ballTurn = 0;
                        isResetPins = true;
                        Debug.LogWarning("Something went wrong in Bowl()");
                    }

                    try
                    {
                        scoreDisplay[1].FillRolls(rolls2);
                        scoreDisplay[1].FillFrames(ScoreMaster.ScoreCumulative(rolls2));
                        scores2 = ScoreMaster.ScoreCumulative(rolls2);
                    }
                    catch
                    {
                        Debug.LogWarning("FillRollCard failed");
                    }
                }
                else if (nextTurn == 2)
                {
                    if (ballTurn == 0)
                    {
                        if (pinFall == 10)
                        {
                            if (frames3 != 10)
                            {
                                nextTurn = 3;
                                frames3++;
                            }
                            else
                            {
                                nextTurn = 2;
                            }
                        }
                        else
                        {
                            ballTurn = 1;
                        }
                    }
                    else
                    {
                        if (frames3 != 10)
                        {
                            nextTurn = 3;
                            ballTurn = 0;
                            frames3++;
                        }
                        else
                        {
                            nextTurn = 2;
                        }
                    }
                    try
                    {
                        rolls3.Add(pinFall);
                        GameObject.FindObjectOfType<PinSetter>().PerformAction(ActionMasterOld.NextAction(rolls3));
                    }
                    catch
                    {
                        nextTurn = 3;
                        ballTurn = 0;
                        isResetPins = true;
                        Debug.LogWarning("Something went wrong in Bowl()");
                    }

                    try
                    {
                        scoreDisplay[2].FillRolls(rolls3);
                        scoreDisplay[2].FillFrames(ScoreMaster.ScoreCumulative(rolls3));
                        scores3 = ScoreMaster.ScoreCumulative(rolls3);
                    }
                    catch
                    {
                        Debug.LogWarning("FillRollCard failed");
                    }
                }
                else
                {
                    if (ballTurn == 0)
                    {
                        if (pinFall == 10)
                        {
                            if (frames4 != 10)
                            {
                                nextTurn = 0;
                                frames4++;
                            }
                            else
                            {
                                nextTurn = 3;
                            }
                        }
                        else
                        {
                            ballTurn = 1;
                        }
                    }
                    else
                    {
                        if (frames4 != 10)
                        {
                            nextTurn = 0;
                            ballTurn = 0;
                            frames4++;
                        }
                        else
                        {
                            nextTurn = 3;
                        }
                    }
                    try
                    {
                        rolls4.Add(pinFall);
                        GameObject.FindObjectOfType<PinSetter>().PerformAction(ActionMasterOld.NextAction(rolls4));
                    }
                    catch
                    {
                        isEndGame = true;
                        Debug.LogWarning("Something went wrong in Bowl()");
                    }

                    try
                    {
                        scoreDisplay[3].FillRolls(rolls4);
                        scoreDisplay[3].FillFrames(ScoreMaster.ScoreCumulative(rolls4));
                        scores4 = ScoreMaster.ScoreCumulative(rolls4);
                    }
                    catch
                    {
                        Debug.LogWarning("FillRollCard failed");
                    }
                }
            }
            else if (GameManager.allPlayers == GameManager.Players.Computer)
            {
                if (nextTurn == 0)
                {
                    if (ballTurn == 0)
                    {
                        if (pinFall == 10)
                        {
                            if (frames1 != 10)
                            {
                                nextTurn = 4;
                                frames1++;
                            }
                            else
                            {
                                nextTurn = 0;
                            }
                        }
                        else
                        {
                            ballTurn = 1;
                        }
                    }
                    else
                    {
                        if (frames1 != 10)
                        {
                            nextTurn = 4;
                            ballTurn = 0;
                            frames1++;
                        }
                        else
                        {
                            nextTurn = 0;
                        }
                    }
                    try
                    {
                        rolls1.Add(pinFall);
                        GameObject.FindObjectOfType<PinSetter>().PerformAction(ActionMasterOld.NextAction(rolls1));
                    }
                    catch
                    {
                        nextTurn = 4;
                        ballTurn = 0;
                        isResetPins = true;
                        Debug.LogWarning("Something went wrong in Bowl()");
                    }

                    try
                    {
                        scoreDisplay[0].FillRolls(rolls1);
                        scoreDisplay[0].FillFrames(ScoreMaster.ScoreCumulative(rolls1));
                        scores1 = ScoreMaster.ScoreCumulative(rolls1);

                    }
                    catch
                    {
                        Debug.LogWarning("FillRollCard failed");
                    }
                }
                else
                {
                    if (ballTurn == 0)
                    {
                        if (pinFall == 10)
                        {
                            if (frames2 != 10)
                            {
                                nextTurn = 0;
                                frames2++;
                            }
                            else
                            {
                                nextTurn = 4;
                            }
                        }
                        else
                        {
                            ballTurn = 1;
                        }
                    }
                    else
                    {
                        if (frames2 != 10)
                        {
                            nextTurn = 0;
                            ballTurn = 0;
                            frames2++;
                        }
                        else
                        {
                            nextTurn = 4;
                        }
                    }
                    try
                    {
                        rolls2.Add(pinFall);
                        GameObject.FindObjectOfType<PinSetter>().PerformAction(ActionMasterOld.NextAction(rolls2));
                    }
                    catch
                    {
                        isEndGame = true;
                        Debug.LogWarning("Something went wrong in Bowl()");
                    }

                    try
                    {
                        scoreDisplay[1].FillRolls(rolls2);
                        scoreDisplay[1].FillFrames(ScoreMaster.ScoreCumulative(rolls2));
                        scores2 = ScoreMaster.ScoreCumulative(rolls2);
                    }
                    catch
                    {
                        Debug.LogWarning("FillRollCard failed");
                    }
                }
            }
        }
        if (maxBalls == 3 && GameManager.type == GameManager.GameState.Replay)
        {
            if (GameManager.allPlayers == GameManager.Players.OnePlayer)
            {
                try
                {
                    rolls1.Add(pinFall);
                    GameObject.FindObjectOfType<PinSetter>().PerformAction3(ActionMasterOldBall3.NextAction(rolls1));
                }
                catch
                {
                    isEndGame = true;
                    Debug.LogWarning("Something went wrong in Bowl()");
                }

                try
                {
                    scoreDisplay3[0].FillRolls(rolls1);
                    scoreDisplay3[0].FillFrames(ScoreMasterBall3.ScoreCumulative(rolls1));
                    scores1 = ScoreMasterBall3.ScoreCumulative(rolls1);

                }
                catch
                {
                    Debug.LogWarning("FillRollCard failed");
                }
            }
            else if (GameManager.allPlayers == GameManager.Players.TwoPlayer)
            {
                if (nextTurn == 0)
                {
                    if (ballTurn == 0)
                    {
                        if (pinFall == 10)
                        {
                            if (frames1 != 10)
                            {
                                nextTurn = 1;
                                ballTurn = 0;
                                frames1++;
                            }
                            else
                            {
                                nextTurn = 0;
                                ballTurn = 1;
                            }
                        }
                        else
                        {
                            ballTurn = 1;
                        }
                    }
                    else if (ballTurn == 1)
                    {
                        if (pinFall == PinCounter.pinCount)
                        {
                            if (frames1 != 10)
                            {
                                nextTurn = 1;
                                ballTurn = 0;
                                frames1++;
                            }
                            else
                            {
                                nextTurn = 0;
                                ballTurn = 2;
                            }
                        }
                        else
                        {
                            ballTurn = 2;
                        }
                    }
                    else
                    {
                        if (frames1 != 10)
                        {
                            nextTurn = 1;
                            ballTurn = 0;
                            frames1++;
                        }
                    }
                    try
                    {
                        rolls1.Add(pinFall);
                        GameObject.FindObjectOfType<PinSetter>().PerformAction3(ActionMasterOldBall3.NextAction(rolls1));
                    }
                    catch
                    {
                        nextTurn = 1;
                        ballTurn = 0;
                        isResetPins = true;
                        Debug.LogWarning("Something went wrong in Bowl()");
                    }

                    try
                    {
                        scoreDisplay3[0].FillRolls(rolls1);
                        scoreDisplay3[0].FillFrames(ScoreMasterBall3.ScoreCumulative(rolls1));
                        scores1 = ScoreMasterBall3.ScoreCumulative(rolls1);

                    }
                    catch
                    {
                        Debug.LogWarning("FillRollCard failed");
                    }
                }
                else
                {
                    if (ballTurn == 0)
                    {
                        if (pinFall == 10)
                        {
                            if (frames2 != 10)
                            {
                                nextTurn = 0;
                                ballTurn = 0;
                                frames2++;
                            }
                            else
                            {
                                nextTurn = 1;
                                ballTurn = 1;
                            }
                        }
                        else
                        {
                            ballTurn = 1;
                        }
                    }
                    else if (ballTurn == 1)
                    {
                        if (pinFall == PinCounter.pinCount)
                        {
                            if (frames2 != 10)
                            {
                                nextTurn = 0;
                                ballTurn = 0;
                                frames2++;
                            }
                            else
                            {
                                nextTurn = 1;
                                ballTurn = 2;
                            }
                        }
                        else
                        {
                            ballTurn = 2;
                        }
                    }
                    else
                    {
                        if (frames2 != 10)
                        {
                            nextTurn = 0;
                            ballTurn = 0;
                            frames2++;
                        }
                    }
                    try
                    {
                        rolls2.Add(pinFall);
                        GameObject.FindObjectOfType<PinSetter>().PerformAction3(ActionMasterOldBall3.NextAction(rolls2));
                    }
                    catch
                    {
                        isEndGame = true;
                        Debug.LogWarning("Something went wrong in Bowl()");
                    }

                    try
                    {
                        scoreDisplay3[1].FillRolls(rolls2);
                        scoreDisplay3[1].FillFrames(ScoreMasterBall3.ScoreCumulative(rolls2));
                        scores2 = ScoreMasterBall3.ScoreCumulative(rolls2);
                    }
                    catch
                    {
                        Debug.LogWarning("FillRollCard failed");
                    }
                }
            }
            else if (GameManager.allPlayers == GameManager.Players.ThreePlayer)
            {
                if (nextTurn == 0)
                {
                    if (ballTurn == 0)
                    {
                        if (pinFall == 10)
                        {
                            if (frames1 != 10)
                            {
                                nextTurn = 1;
                                ballTurn = 0;
                                frames1++;
                            }
                            else
                            {
                                nextTurn = 0;
                                ballTurn = 1;
                            }
                        }
                        else
                        {
                            ballTurn = 1;
                        }
                    }
                    else if (ballTurn == 1)
                    {
                        if (pinFall == PinCounter.pinCount)
                        {
                            if (frames1 != 10)
                            {
                                nextTurn = 1;
                                ballTurn = 0;
                                frames1++;
                            }
                            else
                            {
                                nextTurn = 0;
                                ballTurn = 2;
                            }
                        }
                        else
                        {
                            ballTurn = 2;
                        }
                    }
                    else
                    {
                        if (frames1 != 10)
                        {
                            nextTurn = 1;
                            ballTurn = 0;
                            frames1++;
                        }
                    }
                    try
                    {
                        rolls1.Add(pinFall);
                        GameObject.FindObjectOfType<PinSetter>().PerformAction3(ActionMasterOldBall3.NextAction(rolls1));
                    }
                    catch
                    {
                        nextTurn = 1;
                        ballTurn = 0;
                        isResetPins = true;
                        Debug.LogWarning("Something went wrong in Bowl()");
                    }

                    try
                    {
                        scoreDisplay3[0].FillRolls(rolls1);
                        scoreDisplay3[0].FillFrames(ScoreMasterBall3.ScoreCumulative(rolls1));
                        scores1 = ScoreMasterBall3.ScoreCumulative(rolls1);

                    }
                    catch
                    {
                        Debug.LogWarning("FillRollCard failed");
                    }
                }
                else if (nextTurn == 1)
                {
                    if (ballTurn == 0)
                    {
                        if (pinFall == 10)
                        {
                            if (frames2 != 10)
                            {
                                nextTurn = 2;
                                ballTurn = 0;
                                frames2++;
                            }
                            else
                            {
                                nextTurn = 1;
                                ballTurn = 2;
                            }
                        }
                        else
                        {
                            ballTurn = 1;
                        }
                    }
                    else if (ballTurn == 1)
                    {
                        if (pinFall == PinCounter.pinCount)
                        {
                            if (frames2 != 10)
                            {
                                nextTurn = 2;
                                ballTurn = 0;
                                frames2++;
                            }
                            else
                            {
                                nextTurn = 1;
                                ballTurn = 2;
                            }
                        }
                        else
                        {
                            ballTurn = 2;
                        }
                    }
                    else
                    {
                        if (frames2 != 10)
                        {
                            nextTurn = 2;
                            ballTurn = 0;
                            frames2++;
                        }
                    }
                    try
                    {
                        rolls2.Add(pinFall);
                        GameObject.FindObjectOfType<PinSetter>().PerformAction3(ActionMasterOldBall3.NextAction(rolls2));
                    }
                    catch
                    {
                        nextTurn = 2;
                        ballTurn = 0;
                        isResetPins = true;
                        Debug.LogWarning("Something went wrong in Bowl()");
                    }

                    try
                    {
                        scoreDisplay3[1].FillRolls(rolls2);
                        scoreDisplay3[1].FillFrames(ScoreMasterBall3.ScoreCumulative(rolls2));
                        scores2 = ScoreMasterBall3.ScoreCumulative(rolls2);
                    }
                    catch
                    {
                        Debug.LogWarning("FillRollCard failed");
                    }
                }
                else
                {
                    if (ballTurn == 0)
                    {
                        if (pinFall == 10)
                        {
                            if (frames3 != 10)
                            {
                                nextTurn = 0;
                                ballTurn = 0;
                                frames3++;
                            }
                            else
                            {
                                nextTurn = 2;
                                ballTurn = 1;
                            }
                        }
                        else
                        {
                            ballTurn = 1;
                        }
                    }
                    else if (ballTurn == 1)
                    {
                        if (pinFall == PinCounter.pinCount)
                        {
                            if (frames3 != 10)
                            {
                                nextTurn = 0;
                                ballTurn = 0;
                                frames3++;
                            }
                            else
                            {
                                nextTurn = 2;
                                ballTurn = 2;
                            }
                        }
                        else
                        {
                            ballTurn = 2;
                        }
                    }
                    else
                    {
                        if (frames3 != 10)
                        {
                            nextTurn = 0;
                            ballTurn = 0;
                            frames3++;
                        }
                    }
                    try
                    {
                        rolls3.Add(pinFall);
                        GameObject.FindObjectOfType<PinSetter>().PerformAction3(ActionMasterOldBall3.NextAction(rolls3));
                    }
                    catch
                    {
                        isEndGame = true;
                        Debug.LogWarning("Something went wrong in Bowl()");
                    }

                    try
                    {
                        scoreDisplay3[2].FillRolls(rolls3);
                        scoreDisplay3[2].FillFrames(ScoreMasterBall3.ScoreCumulative(rolls3));
                        scores3 = ScoreMasterBall3.ScoreCumulative(rolls3);
                    }
                    catch
                    {
                        Debug.LogWarning("FillRollCard failed");
                    }
                }
            }
            else if (GameManager.allPlayers == GameManager.Players.FourPlayer)
            {
                if (nextTurn == 0)
                {
                    if (ballTurn == 0)
                    {
                        if (pinFall == 10)
                        {
                            if (frames1 != 10)
                            {
                                nextTurn = 1;
                                ballTurn = 0;
                                frames1++;
                            }
                            else
                            {
                                nextTurn = 0;
                                ballTurn = 1;
                            }
                        }
                        else
                        {
                            ballTurn = 1;
                        }
                    }
                    else if (ballTurn == 1)
                    {
                        if (pinFall == PinCounter.pinCount)
                        {
                            if (frames1 != 10)
                            {
                                nextTurn = 1;
                                ballTurn = 0;
                                frames1++;
                            }
                            else
                            {
                                nextTurn = 0;
                                ballTurn = 2;
                            }
                        }
                        else
                        {
                            ballTurn = 2;
                        }
                    }
                    else
                    {
                        if (frames1 != 10)
                        {
                            nextTurn = 1;
                            ballTurn = 0;
                            frames1++;
                        }
                    }
                    try
                    {
                        rolls1.Add(pinFall);
                        GameObject.FindObjectOfType<PinSetter>().PerformAction3(ActionMasterOldBall3.NextAction(rolls1));
                    }
                    catch
                    {
                        nextTurn = 1;
                        ballTurn = 0;
                        isResetPins = true;
                        Debug.LogWarning("Something went wrong in Bowl()");
                    }

                    try
                    {
                        scoreDisplay3[0].FillRolls(rolls1);
                        scoreDisplay3[0].FillFrames(ScoreMasterBall3.ScoreCumulative(rolls1));
                        scores1 = ScoreMasterBall3.ScoreCumulative(rolls1);

                    }
                    catch
                    {
                        Debug.LogWarning("FillRollCard failed");
                    }
                }
                else if (nextTurn == 1)
                {
                    if (ballTurn == 0)
                    {
                        if (pinFall == 10)
                        {
                            if (frames2 != 10)
                            {
                                nextTurn = 2;
                                ballTurn = 0;
                                frames2++;
                            }
                            else
                            {
                                nextTurn = 1;
                                ballTurn = 1;
                            }
                        }
                        else
                        {
                            ballTurn = 1;
                        }
                    }
                    else if (ballTurn == 1)
                    {
                        if (pinFall == PinCounter.pinCount)
                        {
                            if (frames2 != 10)
                            {
                                nextTurn = 2;
                                ballTurn = 0;
                                frames2++;
                            }
                            else
                            {
                                nextTurn = 1;
                                ballTurn = 2;
                            }
                        }
                        else
                        {
                            ballTurn = 2;
                        }
                    }
                    else
                    {
                        if (frames2 != 10)
                        {
                            nextTurn = 2;
                            ballTurn = 0;
                            frames2++;
                        }
                    }
                    try
                    {
                        rolls2.Add(pinFall);
                        GameObject.FindObjectOfType<PinSetter>().PerformAction3(ActionMasterOldBall3.NextAction(rolls2));
                    }
                    catch
                    {
                        nextTurn = 2;
                        ballTurn = 0;
                        isResetPins = true;
                        Debug.LogWarning("Something went wrong in Bowl()");
                    }

                    try
                    {
                        scoreDisplay3[1].FillRolls(rolls2);
                        scoreDisplay3[1].FillFrames(ScoreMasterBall3.ScoreCumulative(rolls2));
                        scores2 = ScoreMasterBall3.ScoreCumulative(rolls2);
                    }
                    catch
                    {
                        Debug.LogWarning("FillRollCard failed");
                    }
                }
                else if (nextTurn == 2)
                {
                    if (ballTurn == 0)
                    {
                        if (pinFall == 10)
                        {
                            if (frames3 != 10)
                            {
                                nextTurn = 3;
                                ballTurn = 0;
                                frames3++;
                            }
                            else
                            {
                                nextTurn = 2;
                                ballTurn = 1;
                            }
                        }
                        else
                        {
                            ballTurn = 1;
                        }
                    }
                    else if (ballTurn == 1)
                    {
                        if (pinFall == PinCounter.pinCount)
                        {
                            if (frames3 != 10)
                            {
                                nextTurn = 3;
                                ballTurn = 0;
                                frames3++;
                            }
                            else
                            {
                                nextTurn = 2;
                                ballTurn = 2;
                            }
                        }
                        else
                        {
                            ballTurn = 2;
                        }
                    }
                    else
                    {
                        if (frames3 != 10)
                        {
                            nextTurn = 3;
                            ballTurn = 0;
                            frames3++;
                        }
                    }
                    try
                    {
                        rolls3.Add(pinFall);
                        GameObject.FindObjectOfType<PinSetter>().PerformAction3(ActionMasterOldBall3.NextAction(rolls3));
                    }
                    catch
                    {
                        nextTurn = 3;
                        ballTurn = 0;
                        isResetPins = true;
                        Debug.LogWarning("Something went wrong in Bowl()");
                    }

                    try
                    {
                        scoreDisplay3[2].FillRolls(rolls3);
                        scoreDisplay3[2].FillFrames(ScoreMasterBall3.ScoreCumulative(rolls3));
                        scores3 = ScoreMasterBall3.ScoreCumulative(rolls3);
                    }
                    catch
                    {
                        Debug.LogWarning("FillRollCard failed");
                    }
                }
                else
                {
                    if (ballTurn == 0)
                    {
                        if (pinFall == 10)
                        {
                            if (frames4 != 10)
                            {
                                nextTurn = 0;
                                ballTurn = 0;
                                frames4++;
                            }
                            else
                            {
                                nextTurn = 3;
                                ballTurn = 1;
                            }
                        }
                        else
                        {
                            ballTurn = 1;
                        }
                    }
                    else if (ballTurn == 1)
                    {
                        if (pinFall == PinCounter.pinCount)
                        {
                            if (frames4 != 10)
                            {
                                nextTurn = 0;
                                ballTurn = 0;
                                frames4++;
                            }
                            else
                            {
                                nextTurn = 3;
                                ballTurn = 2;
                            }
                        }
                        else
                        {
                            ballTurn = 2;
                        }
                    }
                    else
                    {
                        if (frames4 != 10)
                        {
                            nextTurn = 0;
                            ballTurn = 0;
                            frames4++;
                        }
                    }
                    try
                    {
                        rolls4.Add(pinFall);
                        GameObject.FindObjectOfType<PinSetter>().PerformAction3(ActionMasterOldBall3.NextAction(rolls4));
                    }
                    catch
                    {
                        isEndGame = true;
                        Debug.LogWarning("Something went wrong in Bowl()");
                    }

                    try
                    {
                        scoreDisplay3[3].FillRolls(rolls4);
                        scoreDisplay3[3].FillFrames(ScoreMasterBall3.ScoreCumulative(rolls4));
                        scores4 = ScoreMasterBall3.ScoreCumulative(rolls4);
                    }
                    catch
                    {
                        Debug.LogWarning("FillRollCard failed");
                    }
                }
            }
            else if (GameManager.allPlayers == GameManager.Players.Computer)
            {
                if (nextTurn == 0)
                {
                    if (ballTurn == 0)
                    {
                        if (pinFall == 10)
                        {
                            if (frames1 != 10)
                            {
                                nextTurn = 4;
                                frames1++;
                            }
                            else
                            {
                                nextTurn = 0;
                                ballTurn = 1;
                            }
                        }
                        else
                        {
                            ballTurn = 1;
                        }
                    }
                    else if (ballTurn == 1)
                    {
                        if (pinFall == PinCounter.pinCount)
                        {
                            if (frames1 != 10)
                            {
                                nextTurn = 4;
                                ballTurn = 0;
                                frames1++;
                            }
                            else
                            {
                                nextTurn = 0;
                                ballTurn = 2;
                            }
                        }
                        else
                        {
                            ballTurn = 2;
                        }
                    }
                    else
                    {
                        if (frames1 != 10)
                        {
                            nextTurn = 4;
                            ballTurn = 0;
                            frames1++;
                        }
                    }
                    try
                    {
                        rolls1.Add(pinFall);
                        GameObject.FindObjectOfType<PinSetter>().PerformAction3(ActionMasterOldBall3.NextAction(rolls1));
                    }
                    catch
                    {
                        throwBall = maxBalls;
                        Debug.LogWarning("Something went wrong in Bowl()");
                    }

                    try
                    {
                        scoreDisplay3[0].FillRolls(rolls1);
                        scoreDisplay3[0].FillFrames(ScoreMasterBall3.ScoreCumulative(rolls1));
                        scores1 = ScoreMasterBall3.ScoreCumulative(rolls1);

                    }
                    catch
                    {
                        Debug.LogWarning("FillRollCard failed");
                    }
                }
                else
                {
                    if (ballTurn == 0)
                    {
                        if (pinFall == 10)
                        {
                            if (frames2 != 10)
                            {
                                nextTurn = 0;
                                frames2++;
                            }
                            else
                            {
                                nextTurn = 4;
                                ballTurn = 1;
                            }
                        }
                        else
                        {
                            ballTurn = 1;
                        }
                    }
                    else if (ballTurn == 1)
                    {
                        if (pinFall == PinCounter.pinCount)
                        {
                            if (frames2 != 10)
                            {
                                nextTurn = 0;
                                ballTurn = 0;
                                frames2++;
                            }
                            else
                            {
                                nextTurn = 4;
                                ballTurn = 2;
                            }
                        }
                        else
                        {
                            ballTurn = 2;
                        }
                    }
                    else
                    {
                        if (frames2 != 10)
                        {
                            nextTurn = 0;
                            ballTurn = 0;
                            frames2++;
                        }
                    }
                    try
                    {
                        rolls2.Add(pinFall);
                        GameObject.FindObjectOfType<PinSetter>().PerformAction3(ActionMasterOldBall3.NextAction(rolls2));
                    }
                    catch
                    {
                        isEndGame = true;
                        Debug.LogWarning("Something went wrong in Bowl()");
                    }

                    try
                    {
                        scoreDisplay3[1].FillRolls(rolls2);
                        scoreDisplay3[1].FillFrames(ScoreMasterBall3.ScoreCumulative(rolls2));
                        scores2 = ScoreMasterBall3.ScoreCumulative(rolls2);
                    }
                    catch
                    {
                        Debug.LogWarning("FillRollCard failed");
                    }
                }
            }
        }
        pinCounts = pinFall;
        if (throwBall < maxBalls)
        {
            if (isSplit)
            {
                if (is710 && GameManager.type == GameManager.GameState.Replay)
                {
                    VoiceSplit710();
                }
                else if (!is710 && GameManager.type == GameManager.GameState.Replay)
                {
                    VoiceSplit();
                }
            }
            else
            {
                if (pinCounts == 5 || pinCounts == 6)
                {
                    CrowdCrap();
                }
                if (pinCounts == 7 || pinCounts == 8 || pinCounts == 9)
                {
                    CrowdOk();
                }
                if (pinCounts == 0 && PinCounter.pinCount > 0 && GameManager.type == GameManager.GameState.Replay)
                {
                    if (playerTurn == 0)
                    {
                        gutters1++;
                    }
                    else if (playerTurn == 1 || playerTurn == 4)
                    {
                        gutters2++;
                    }
                    else if (playerTurn == 2)
                    {
                        gutters3++;
                    }
                    else if (playerTurn == 3)
                    {
                        gutters4++;
                    }
                    if (gutterAnimation == 0)
                    {
                        VoiceMiss();
                    }
                }
                if (pinCounts == 1 && PinCounter.pinCount > 0 && GameManager.type == GameManager.GameState.Replay)
                {
                    VoiceOne();
                }
                if (pinCounts == 2 && PinCounter.pinCount > 0 && GameManager.type == GameManager.GameState.Replay || pinCounts == 3 && PinCounter.pinCount > 0 && GameManager.type == GameManager.GameState.Replay || pinCounts == 4 && PinCounter.pinCount > 0 && GameManager.type == GameManager.GameState.Replay)
                {
                    VoiceFew();
                }
                if (pinCounts == 5 && PinCounter.pinCount > 0 && GameManager.type == GameManager.GameState.Replay || pinCounts == 6 && PinCounter.pinCount > 0 && GameManager.type == GameManager.GameState.Replay || pinCounts == 7 && PinCounter.pinCount > 0 && GameManager.type == GameManager.GameState.Replay || pinCounts == 8 && PinCounter.pinCount > 0 && GameManager.type == GameManager.GameState.Replay || pinCounts == 9 && PinCounter.pinCount > 0 && GameManager.type == GameManager.GameState.Replay)
                {
                    VoiceMost();
                    if (GameManager.isVoice && GameManager.type != GameManager.GameState.Menu)
                    {
                        isCommentator = false;
                    }
                    crowdType = Crowds.NoCrowd;
                }
            }
        }
        if (throwBall == maxBalls)
        {
            if (pinCounts == 0 && PinCounter.pinCount > 0 && GameManager.type == GameManager.GameState.Replay)
            {
                if (playerTurn == 0)
                {
                    gutters1++;
                }
                else if (playerTurn == 1 || playerTurn == 4)
                {
                    gutters2++;
                }
                else if (playerTurn == 2)
                {
                    gutters3++;
                }
                else if (playerTurn == 3)
                {
                    gutters4++;
                }
                if (gutterAnimation == 0)
                {
                    VoiceMiss();
                }
            }
            if (pinCounts == 1 && PinCounter.pinCount > 0 && GameManager.type == GameManager.GameState.Replay)
            {
                VoiceOne();
            }
            if (pinCounts == 2 && PinCounter.pinCount > 0 && GameManager.type == GameManager.GameState.Replay || pinCounts == 3 && PinCounter.pinCount > 0 && GameManager.type == GameManager.GameState.Replay || pinCounts == 4 && PinCounter.pinCount > 0 && GameManager.type == GameManager.GameState.Replay)
            {
                VoiceFew();
            }
            if (pinCounts == 5 && PinCounter.pinCount > 0 && GameManager.type == GameManager.GameState.Replay || pinCounts == 6 && PinCounter.pinCount > 0 && GameManager.type == GameManager.GameState.Replay || pinCounts == 7 && PinCounter.pinCount > 0 && GameManager.type == GameManager.GameState.Replay || pinCounts == 8 && PinCounter.pinCount > 0 && GameManager.type == GameManager.GameState.Replay || pinCounts == 9 && PinCounter.pinCount > 0 && GameManager.type == GameManager.GameState.Replay || pinCounts == 10 && PinCounter.pinCount > 0 && GameManager.type == GameManager.GameState.Replay)
            {
                VoiceMost();
                if (GameManager.isVoice && GameManager.type != GameManager.GameState.Menu)
                {
                    isCommentator = false;
                    crowdAudio.Stop();
                }
                if (pinCounts == 5 || pinCounts == 6)
                {
                    if (GameManager.isVoice || crowdType > Crowds.NoCrowd)
                    {
                        crowdType = Crowds.CrowdCrap;
                    }
                }
                if (pinCounts == 7 || pinCounts == 8 || pinCounts == 9 || pinCounts == 10)
                {
                    if (GameManager.isVoice || crowdType > Crowds.NoCrowd)
                    {
                        crowdType = Crowds.CrowdOk;
                    }
                }
            }
        }
        if (PinCounter.pinCount > 0)
        {
            scoreDisplay[turns].ResetStrike();
            scoreDisplay3[turns].ResetStrike();
        }
    }

    public void VoiceStrike()
    {
        allVoices = AllVoices.Strike;
        if (GameManager.isVoice && GameManager.type != GameManager.GameState.Menu && maxBalls != 1)
        {
            commentator.Strike(commentatorAudio);
            crowdAudio.Stop();
            commentatorTime = 0;
            commentatorIndex = 1;
            commentatorAudio.Play();
            isCommentator = false;
        }
        if (GameManager.isVoice || crowdType > Crowds.NoCrowd)
        {
            crowdType = Crowds.CheerMed;
        }
    }

    public void VoiceSpare()
    {
        allVoices = AllVoices.Spare;
        if (GameManager.isVoice && GameManager.type != GameManager.GameState.Menu && maxBalls != 1)
        {
            commentator.Spare(commentatorAudio);
            crowdAudio.Stop();
            commentatorTime = 0;
            commentatorIndex = 1;
            commentatorAudio.Play();
            isCommentator = false;
        }
        if (GameManager.isVoice || crowdType > Crowds.NoCrowd)
        {
            crowdType = Crowds.CrowdOk;
        }
    }

    public void VoiceGutterball()
    {
        allVoices = AllVoices.Gutterball;
        if (GameManager.isVoice && GameManager.type != GameManager.GameState.Menu && maxBalls != 1)
        {
            commentator.Gutterball(commentatorAudio);
            crowdAudio.Stop();
            commentatorTime = 0;
            commentatorIndex = 1;
            commentatorAudio.Play();
            isCommentator = false;
        }
        if (GameManager.isVoice || crowdType > Crowds.NoCrowd)
        {
            crowdType = Crowds.Laugh;
        }
    }

    public void VoiceDouble()
    {
        allVoices = AllVoices.Double;
        if (GameManager.isVoice && GameManager.type != GameManager.GameState.Menu && maxBalls != 1)
        {
            commentator.Double(commentatorAudio);
            crowdAudio.Stop();
            commentatorTime = 0;
            commentatorIndex = 1;
            commentatorAudio.Play();
            isCommentator = false;
        }
        if (GameManager.isVoice || crowdType > Crowds.NoCrowd)
        {
            crowdType = Crowds.CheerBig;
        }
    }

    public void VoiceTurkey()
    {
        allVoices = AllVoices.Turkey;
        if (GameManager.isVoice && GameManager.type != GameManager.GameState.Menu && maxBalls != 1)
        {
            commentator.Turkey(commentatorAudio);
            crowdAudio.Stop();
            commentatorTime = 0;
            commentatorIndex = 1;
            commentatorAudio.Play();
            isCommentator = false;
        }
        if (GameManager.isVoice || crowdType > Crowds.NoCrowd)
        {
            crowdType = Crowds.CheerBig;
        }
    }

    public void VoiceSplit()
    {
        allVoices = AllVoices.Split;
        if (GameManager.isVoice && GameManager.type != GameManager.GameState.Menu && maxBalls != 1)
        {
            commentator.Split(commentatorAudio);
            crowdAudio.Stop();
            commentatorTime = 0;
            commentatorIndex = 1;
            commentatorAudio.Play();
            isCommentator = false;
        }
        if (GameManager.isVoice || crowdType > Crowds.NoCrowd)
        {
            crowdType = Crowds.Oooh;
        }
    }

    public void VoiceSplit710()
    {
        allVoices = AllVoices.Split710;
        if (GameManager.isVoice && GameManager.type != GameManager.GameState.Menu && maxBalls != 1)
        {
            commentator.Split710(commentatorAudio);
            crowdAudio.Stop();
            commentatorTime = 0;
            commentatorIndex = 1;
            commentatorAudio.Play();
            isCommentator = false;
        }
        if (GameManager.isVoice || crowdType > Crowds.NoCrowd)
        {
            crowdType = Crowds.Oooh;
        }
    }

    public void VoiceSplitPick()
    {
        allVoices = AllVoices.SplitPick;
        if (GameManager.isVoice && GameManager.type != GameManager.GameState.Menu && maxBalls != 1)
        {
            commentator.SplitPick(commentatorAudio);
            crowdAudio.Stop();
            commentatorTime = 0;
            commentatorIndex = 1;
            commentatorAudio.Play();
            isCommentator = false;
        }
        if (GameManager.isVoice || crowdType > Crowds.NoCrowd)
        {
            crowdType = Crowds.CheerMed;
        }
    }

    public void VoiceMost()
    {
        allVoices = AllVoices.Most;
        if (GameManager.isVoice && GameManager.type != GameManager.GameState.Menu && maxBalls != 1)
        {
            commentator.Most(commentatorAudio);
            commentatorTime = 0;
            commentatorIndex = 1;
            commentatorAudio.Play();
        }
    }

    public void VoiceFew()
    {
        allVoices = AllVoices.Few;
        if (GameManager.isVoice && GameManager.type != GameManager.GameState.Menu && maxBalls != 1)
        {
            commentator.Few(commentatorAudio);
            crowdAudio.Stop();
            commentatorTime = 0;
            commentatorIndex = 1;
            commentatorAudio.Play();
            isCommentator = false;
        }
        if (GameManager.isVoice || crowdType > Crowds.NoCrowd)
        {
            crowdType = Crowds.CrowdCrap;
        }
    }

    public void VoiceOne()
    {
        allVoices = AllVoices.One;
        if (GameManager.isVoice && GameManager.type != GameManager.GameState.Menu && maxBalls != 1)
        {
            commentator.One(commentatorAudio);
            crowdAudio.Stop();
            commentatorTime = 0;
            commentatorIndex = 1;
            commentatorAudio.Play();
            isCommentator = false;
        }
        if (GameManager.isVoice || crowdType > Crowds.NoCrowd)
        {
            crowdType = Crowds.Laugh;
        }
    }

    public void VoiceMiss()
    {
        allVoices = AllVoices.Miss;
        if (GameManager.isVoice && GameManager.type != GameManager.GameState.Menu && maxBalls != 1)
        {
            commentator.Miss(commentatorAudio);
            crowdAudio.Stop();
            commentatorTime = 0;
            commentatorIndex = 1;
            commentatorAudio.Play();
            isCommentator = false;
        }
        if (GameManager.isVoice || crowdType > Crowds.NoCrowd)
        {
            crowdType = Crowds.Laugh;
        }
    }

    public void VoiceEndBad()
    {
        allVoices = AllVoices.EndBad;
        if (GameManager.isVoice && GameManager.type != GameManager.GameState.Menu && maxBalls != 1)
        {
            commentator.EndBad(commentatorAudio);
            commentatorTime = 0;
            commentatorIndex = 1;
            commentatorAudio.Play();
            isCommentator = false;
        }
        if (GameManager.isVoice || crowdType > Crowds.NoCrowd)
        {
            crowdType = Crowds.Firework;
        }
    }

    public void VoiceEndOk()
    {
        allVoices = AllVoices.EndOk;
        if (GameManager.isVoice && GameManager.type != GameManager.GameState.Menu && maxBalls != 1)
        {
            commentator.EndOk(commentatorAudio);
            commentatorTime = 0;
            commentatorIndex = 1;
            commentatorAudio.Play();
            isCommentator = false;
        }
        if (GameManager.isVoice || crowdType > Crowds.NoCrowd)
        {
            crowdType = Crowds.Firework;
        }
    }

    public void VoiceEndGood()
    {
        allVoices = AllVoices.EndGood;
        if (GameManager.isVoice && GameManager.type != GameManager.GameState.Menu && maxBalls != 1)
        {
            commentator.EndGood(commentatorAudio);
            commentatorTime = 0;
            commentatorIndex = 1;
            commentatorAudio.Play();
            isCommentator = false;
        }
        if (GameManager.isVoice || crowdType > Crowds.NoCrowd)
        {
            crowdType = Crowds.Firework;
        }
    }

    public void VoiceEndGreat()
    {
        allVoices = AllVoices.EndGreat;
        if (GameManager.isVoice && GameManager.type != GameManager.GameState.Menu && maxBalls != 1)
        {
            commentator.EndGreat(commentatorAudio);
            commentatorTime = 0;
            commentatorIndex = 1;
            commentatorAudio.Play();
            isCommentator = false;
        }
        if (GameManager.isVoice || crowdType > Crowds.NoCrowd)
        {
            crowdType = Crowds.Firework;
        }
    }

    public void PerfectGame()
    {
        allVoices = AllVoices.Perfect;
        if (GameManager.isVoice && GameManager.type != GameManager.GameState.Menu && maxBalls != 1)
        {
            commentatorAudio.clip = Resources.Load<AudioClip>("Sound/crowd-perfect");
            commentatorAudio.Play();
            isCommentator = false;
        }
        else
        {
            crowdAudio.Stop();
            commentatorAudio.Stop();
            isCommentator = true;
        }
        if (GameManager.isVoice || crowdType > Crowds.NoCrowd)
        {
            crowdType = Crowds.Firework;
        }
    }

    public void VoiceStop()
    {
        commentator.commentators1[(int)GameManager.voices1].Strike.voiceIndex = Random.Range(0, commentator.commentators1[(int)GameManager.voices1].Strike.voices.Length);
        commentator.commentators1[(int)GameManager.voices1].Spare.voiceIndex = Random.Range(0, commentator.commentators1[(int)GameManager.voices1].Spare.voices.Length);
        commentator.commentators1[(int)GameManager.voices1].Gutterball.voiceIndex = Random.Range(0, commentator.commentators1[(int)GameManager.voices1].Gutterball.voices.Length);
        commentator.commentators1[(int)GameManager.voices1].Double.voiceIndex = Random.Range(0, commentator.commentators1[(int)GameManager.voices1].Double.voices.Length);
        commentator.commentators1[(int)GameManager.voices1].Turkey.voiceIndex = Random.Range(0, commentator.commentators1[(int)GameManager.voices1].Turkey.voices.Length);
        commentator.commentators1[(int)GameManager.voices1].Split.voiceIndex = Random.Range(0, commentator.commentators1[(int)GameManager.voices1].Split.voices.Length);
        commentator.commentators1[(int)GameManager.voices1].Split710.voiceIndex = Random.Range(0, commentator.commentators1[(int)GameManager.voices1].Split710.voices.Length);
        commentator.commentators1[(int)GameManager.voices1].SplitPick.voiceIndex = Random.Range(0, commentator.commentators1[(int)GameManager.voices1].SplitPick.voices.Length);
        commentator.commentators1[(int)GameManager.voices1].Most.voiceIndex = Random.Range(0, commentator.commentators1[(int)GameManager.voices1].Most.voices.Length);
        commentator.commentators1[(int)GameManager.voices1].Few.voiceIndex = Random.Range(0, commentator.commentators1[(int)GameManager.voices1].Few.voices.Length);
        commentator.commentators1[(int)GameManager.voices1].One.voiceIndex = Random.Range(0, commentator.commentators1[(int)GameManager.voices1].One.voices.Length);
        commentator.commentators1[(int)GameManager.voices1].Miss.voiceIndex = Random.Range(0, commentator.commentators1[(int)GameManager.voices1].Miss.voices.Length);
        commentator.commentators1[(int)GameManager.voices1].EndBad.voiceIndex = Random.Range(0, commentator.commentators1[(int)GameManager.voices1].EndBad.voices.Length);
        commentator.commentators1[(int)GameManager.voices1].EndOk.voiceIndex = Random.Range(0, commentator.commentators1[(int)GameManager.voices1].EndOk.voices.Length);
        commentator.commentators1[(int)GameManager.voices1].EndGood.voiceIndex = Random.Range(0, commentator.commentators1[(int)GameManager.voices1].EndGood.voices.Length);
        commentator.commentators1[(int)GameManager.voices1].EndGreat.voiceIndex = Random.Range(0, commentator.commentators1[(int)GameManager.voices1].EndGreat.voices.Length);
        commentator.commentators2[(int)GameManager.voices2].Strike.voiceIndex = Random.Range(0, commentator.commentators2[(int)GameManager.voices2].Strike.voices.Length);
        commentator.commentators2[(int)GameManager.voices2].Spare.voiceIndex = Random.Range(0, commentator.commentators2[(int)GameManager.voices2].Spare.voices.Length);
        commentator.commentators2[(int)GameManager.voices2].Gutterball.voiceIndex = Random.Range(0, commentator.commentators2[(int)GameManager.voices2].Gutterball.voices.Length);
        commentator.commentators2[(int)GameManager.voices2].Double.voiceIndex = Random.Range(0, commentator.commentators2[(int)GameManager.voices2].Double.voices.Length);
        commentator.commentators2[(int)GameManager.voices2].Turkey.voiceIndex = Random.Range(0, commentator.commentators2[(int)GameManager.voices2].Turkey.voices.Length);
        commentator.commentators2[(int)GameManager.voices2].Split.voiceIndex = Random.Range(0, commentator.commentators2[(int)GameManager.voices2].Split.voices.Length);
        commentator.commentators2[(int)GameManager.voices2].Split710.voiceIndex = Random.Range(0, commentator.commentators2[(int)GameManager.voices2].Split710.voices.Length);
        commentator.commentators2[(int)GameManager.voices2].SplitPick.voiceIndex = Random.Range(0, commentator.commentators2[(int)GameManager.voices2].SplitPick.voices.Length);
        commentator.commentators2[(int)GameManager.voices2].Most.voiceIndex = Random.Range(0, commentator.commentators2[(int)GameManager.voices2].Most.voices.Length);
        commentator.commentators2[(int)GameManager.voices2].Few.voiceIndex = Random.Range(0, commentator.commentators2[(int)GameManager.voices2].Few.voices.Length);
        commentator.commentators2[(int)GameManager.voices2].One.voiceIndex = Random.Range(0, commentator.commentators2[(int)GameManager.voices2].One.voices.Length);
        commentator.commentators2[(int)GameManager.voices2].Miss.voiceIndex = Random.Range(0, commentator.commentators2[(int)GameManager.voices2].Miss.voices.Length);
        commentator.commentators2[(int)GameManager.voices2].EndBad.voiceIndex = Random.Range(0, commentator.commentators2[(int)GameManager.voices2].EndBad.voices.Length);
        commentator.commentators2[(int)GameManager.voices2].EndOk.voiceIndex = Random.Range(0, commentator.commentators2[(int)GameManager.voices2].EndOk.voices.Length);
        commentator.commentators2[(int)GameManager.voices2].EndGood.voiceIndex = Random.Range(0, commentator.commentators2[(int)GameManager.voices2].EndGood.voices.Length);
        commentator.commentators2[(int)GameManager.voices2].EndGreat.voiceIndex = Random.Range(0, commentator.commentators2[(int)GameManager.voices2].EndGreat.voices.Length);
        commentatorIndex = 0;
        commentatorTime = 0;
        commentatorAudio.Stop();
        isCommentator = true;
    }

    public void CrowdStop()
    {
        if (crowdType != Crowds.NoCrowd)
        {
            crowdAudio.Stop();
        }
    }

    public void CheerBig()
    {
        if (GameManager.isCrowd && GameManager.type != GameManager.GameState.Menu)
        {
            crowd.CheerBig(crowdAudio);
        }
    }

    public void CheerMed()
    {
        if (GameManager.isCrowd && GameManager.type != GameManager.GameState.Menu)
        {
            crowd.CheerMed(crowdAudio);
        }
    }

    public void CrowdOk()
    {
        if (GameManager.isCrowd && GameManager.type != GameManager.GameState.Menu)
        {
            crowd.CrowdOk(crowdAudio);
        }
    }

    public void CrowdHohum()
    {
        if (GameManager.isCrowd && GameManager.type != GameManager.GameState.Menu)
        {
            crowd.CrowdHohum(crowdAudio);
        }
    }

    public void CrowdCrap()
    {
        if (GameManager.isCrowd && GameManager.type != GameManager.GameState.Menu)
        {
            crowd.CrowdCrap(crowdAudio);
        }
    }

    public void Laugh()
    {
        if (GameManager.isCrowd && GameManager.type != GameManager.GameState.Menu)
        {
            crowd.Laugh(crowdAudio);
        }
    }

    public void Roll()
    {
        if (GameManager.isCrowd && GameManager.type != GameManager.GameState.Menu)
        {
            crowd.Roll(rollCrowd);
        }
        if (!isComputer && crowd.roll.Length >= 1 && crowdType == Crowds.NoCrowd && GameManager.type != GameManager.GameState.Menu)
        {
            crowdAudio.Stop();
        }
    }

    public void Oooh()
    {
        if (GameManager.isCrowd && GameManager.type != GameManager.GameState.Menu)
        {
            crowd.Oooh(crowdAudio);
        }
    }

    public void GutterLaugh()
    {
        if (GameManager.isCrowd && !GameManager.isVoice && GameManager.type != GameManager.GameState.Menu)
        {
            crowd.Laugh(commentatorAudio);
            crowdAudio.Stop();
            commentatorIndex = 3;
            commentatorAudio.Play();
            isCommentator = false;
        }
        crowdType = Crowds.Laugh;
    }

    public void StopScooper()
    {
        if (b != null)
        {
            StopCoroutine(b);
        }
        GameObject.FindObjectOfType<PinSetter>().SkipScooper();
        GameObject.FindObjectOfType<PinSetter>().StopScooper();
    }

    public void StopAllAnimations()
    {
        animations = AnimationScenes.Off;
        for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().strikeAnimations.Length; i++)
        {
            GameObject.FindObjectOfType<PinSetter>().strikeAnimations[i].StopAnimation();
        }
        for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().spareAnimations.Length; i++)
        {
            GameObject.FindObjectOfType<PinSetter>().spareAnimations[i].StopAnimation();
        }
        for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().gutterballAnimations.Length; i++)
        {
            GameObject.FindObjectOfType<PinSetter>().gutterballAnimations[i].StopAnimation();
        }
        for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().gutterballAnimationTwoTimes.Length; i++)
        {
            GameObject.FindObjectOfType<PinSetter>().gutterballAnimationTwoTimes[i].StopAnimation();
        }
        for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().doubleAnimations.Length; i++)
        {
            GameObject.FindObjectOfType<PinSetter>().doubleAnimations[i].StopAnimation();
        }
        for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().turkeyAnimations.Length; i++)
        {
            GameObject.FindObjectOfType<PinSetter>().turkeyAnimations[i].StopAnimation();
        }
    }

    void SkipReplay()
    {
        replayText.SetActive(false);
        if (isAnim)
        {
            StopAllAnimations();
        }
        isAnim = false;
        animations = AnimationScenes.Off;
        isReplay = false;
        isReplayRecord = false;
        isCurrentReplay = false;
        ball.isGutter = false;
        gutterAnimation = 0;
        isPin = false;
        for (int i = 0; i < replays.Length; i++)
        {
            replays[i].RigidBodyCollider(true);
            replays[i].Clear();
        }
        currentReplayIndex = 0;
        replayTime = 0;
        GameObject.FindObjectOfType<PinSetter>().SkipScooper();
        GameObject.FindObjectOfType<PinSetter>().StopScooper();
        if (PinCounter.pinCount != 0 && throwBall < maxBalls && !isResetPins)
        {
            GameObject.FindObjectOfType<PinSetter>().OutOfPins();
        }
        else if (PinCounter.pinCount == 0 || throwBall == maxBalls || isResetPins)
        {
            if (GameManager.type == GameManager.GameState.Menu)
            {
                RandomChargeBall();
            }
            if (GameManager.pinMode != GameManager.PinMode.Spare)
            {
                pinCounter.Reset();
                GameObject.FindObjectOfType<PinSetter>().ResetPins();
            }
            else
            {
                GameObject.FindObjectOfType<PinSetter>().ResetPinsFall();
            }
            throwBall = 0;
            isResetPins = false;
            isSplit = false;
            is710 = false;
        }
        foreach (var bounce in GameObject.FindObjectsOfType<TriggerSound>())
        {
            bounce.Reset();
        }
        if (isEndGame)
        {
            if (GameManager.isParticle)
            {
                StartCoroutine(FireworksPop());
            }
            foreach (GameObject falseObject in falseObjects)
            {
                falseObject.SetActive(false);
            }
            foreach (GameObject trueObject in trueObjects)
            {
                trueObject.SetActive(true);
            }
            if (isReplay)
            {
                ballObject.SetActive(false);
            }
            cameraFollow.type = CameraFollow.CameraType.ReactCam;
            GameManager.type = GameManager.GameState.EndGame;
            CrowdStop();
            cameraFollow.transform.rotation = Quaternion.Euler(-GameObject.FindObjectOfType<PinSetter>().winRot.x, 180 - GameObject.FindObjectOfType<PinSetter>().winRot.y, 0);
            Vector3 desiredPosition = new Vector3(-GameObject.FindObjectOfType<PinSetter>().winPos.x, GameObject.FindObjectOfType<PinSetter>().winPos.y, GameObject.FindObjectOfType<PinSetter>().winPos.z);
            cameraFollow.transform.position = desiredPosition;
            if (maxBalls == 1)
            {
                winGameBalls[17].SetActive(true);
                wins = 0;
            }
            else if (GameManager.allPlayers == GameManager.Players.OnePlayer && maxBalls != 1)
            {
                gameManager.bowler[gameManager.turnNameIndex1].playerStrikes += strikes1;
                gameManager.bowler[gameManager.turnNameIndex1].playerSpares += spares1;
                gameManager.bowler[gameManager.turnNameIndex1].playerGutters += gutters1;
                winGameBalls[0].SetActive(true);
                wins = 1;
                if (score1 <= 99)
                {
                    gameManager.bowler[gameManager.turnNameIndex1].playerMoney += 0;
                }
                else if (score1 >= 100 && score1 <= 149)
                {
                    gameManager.bowler[gameManager.turnNameIndex1].playerMoney += 50;
                }
                else if (score1 >= 150 && score1 <= 199)
                {
                    gameManager.bowler[gameManager.turnNameIndex1].playerMoney += 100;
                }
                else if (score1 >= 200 && score1 <= 249)
                {
                    gameManager.bowler[gameManager.turnNameIndex1].playerMoney += 500;
                }
                else if (score1 >= 250 && score1 <= 299)
                {
                    gameManager.bowler[gameManager.turnNameIndex1].playerMoney += 1000;
                }
                else if (score1 >= 300)
                {
                    gameManager.bowler[gameManager.turnNameIndex1].playerMoney += 5000;
                }
                foreach (Text winPrize1 in winGamePrize1)
                {
                    if (score1 <= 99)
                    {
                        winPrize1.text = "prize: 0";
                    }
                    else if (score1 >= 100 && score1 <= 149)
                    {
                        winPrize1.text = "prize: 50";
                    }
                    else if (score1 >= 150 && score1 <= 199)
                    {
                        winPrize1.text = "prize: 100";
                    }
                    else if (score1 >= 200 && score1 <= 249)
                    {
                        winPrize1.text = "prize: 500";
                    }
                    else if (score1 >= 250 && score1 <= 299)
                    {
                        winPrize1.text = "prize: 1,000";
                    }
                    else if (score1 >= 300)
                    {
                        winPrize1.text = "prize: 5,000";
                    }
                }
            }
            else if (GameManager.allPlayers == GameManager.Players.TwoPlayer && maxBalls != 1)
            {
                gameManager.bowler[gameManager.turnNameIndex1].playerStrikes += strikes1;
                gameManager.bowler[gameManager.turnNameIndex1].playerSpares += spares1;
                gameManager.bowler[gameManager.turnNameIndex1].playerGutters += gutters1;
                gameManager.bowler[gameManager.turnNameIndex2].playerStrikes += strikes2;
                gameManager.bowler[gameManager.turnNameIndex2].playerSpares += spares2;
                gameManager.bowler[gameManager.turnNameIndex2].playerGutters += gutters2;
                if (score2 < score1)
                {
                    winGameBalls[0].SetActive(true);
                    wins = 1;
                    gameManager.bowler[gameManager.turnNameIndex1].playerMoney += 1000;
                    gameManager.bowler[gameManager.turnNameIndex1].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerLoss++;
                }
                else if (score1 < score2)
                {
                    winGameBalls[1].SetActive(true);
                    wins = 2;
                    gameManager.bowler[gameManager.turnNameIndex2].playerMoney += 1000;
                    gameManager.bowler[gameManager.turnNameIndex1].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerWin++;
                }
                else if (score1 == score2)
                {
                    winGameBalls[5].SetActive(true);
                    wins = 1;
                    gameManager.bowler[gameManager.turnNameIndex1].playerMoney += 1000;
                    gameManager.bowler[gameManager.turnNameIndex2].playerMoney += 1000;
                    gameManager.bowler[gameManager.turnNameIndex1].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerWin++;
                }
                foreach (Text winPrize1 in winGamePrize1)
                {
                    winPrize1.text = "prize: 1,000";
                }
                foreach (Text winPrize2 in winGamePrize2)
                {
                    winPrize2.text = "prize: 1,000";
                }
            }
            else if (GameManager.allPlayers == GameManager.Players.ThreePlayer && maxBalls != 1)
            {
                gameManager.bowler[gameManager.turnNameIndex1].playerStrikes += strikes1;
                gameManager.bowler[gameManager.turnNameIndex1].playerSpares += spares1;
                gameManager.bowler[gameManager.turnNameIndex1].playerGutters += gutters1;
                gameManager.bowler[gameManager.turnNameIndex2].playerStrikes += strikes2;
                gameManager.bowler[gameManager.turnNameIndex2].playerSpares += spares2;
                gameManager.bowler[gameManager.turnNameIndex2].playerGutters += gutters2;
                gameManager.bowler[gameManager.turnNameIndex3].playerStrikes += strikes3;
                gameManager.bowler[gameManager.turnNameIndex3].playerSpares += spares3;
                gameManager.bowler[gameManager.turnNameIndex3].playerGutters += gutters3;
                if (score2 < score1 && score3 < score1)
                {
                    winGameBalls[0].SetActive(true);
                    wins = 1;
                    gameManager.bowler[gameManager.turnNameIndex1].playerMoney += 2500;
                    gameManager.bowler[gameManager.turnNameIndex1].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex3].playerLoss++;
                }
                else if (score1 < score2 && score3 < score2)
                {
                    winGameBalls[1].SetActive(true);
                    wins = 2;
                    gameManager.bowler[gameManager.turnNameIndex2].playerMoney += 2500;
                    gameManager.bowler[gameManager.turnNameIndex1].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex3].playerLoss++;
                }
                else if (score1 < score3 && score2 < score3)
                {
                    winGameBalls[2].SetActive(true);
                    wins = 3;
                    gameManager.bowler[gameManager.turnNameIndex3].playerMoney += 2500;
                    gameManager.bowler[gameManager.turnNameIndex1].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex3].playerWin++;
                }
                else if (score1 == score2 && score1 < score3)
                {
                    winGameBalls[5].SetActive(true);
                    wins = 1;
                    gameManager.bowler[gameManager.turnNameIndex1].playerMoney += 2500;
                    gameManager.bowler[gameManager.turnNameIndex2].playerMoney += 2500;
                    gameManager.bowler[gameManager.turnNameIndex1].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex3].playerLoss++;
                }
                else if (score1 < score2 && score1 == score3)
                {
                    winGameBalls[6].SetActive(true);
                    wins = 1;
                    gameManager.bowler[gameManager.turnNameIndex1].playerMoney += 2500;
                    gameManager.bowler[gameManager.turnNameIndex3].playerMoney += 2500;
                    gameManager.bowler[gameManager.turnNameIndex1].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex3].playerWin++;
                }
                else if (score1 < score2 && score2 == score3)
                {
                    winGameBalls[9].SetActive(true);
                    wins = 2;
                    gameManager.bowler[gameManager.turnNameIndex2].playerMoney += 2500;
                    gameManager.bowler[gameManager.turnNameIndex3].playerMoney += 2500;
                    gameManager.bowler[gameManager.turnNameIndex1].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex3].playerWin++;
                }
                else if (score1 == score2 && score1 == score3)
                {
                    winGameBalls[12].SetActive(true);
                    wins = 1;
                    gameManager.bowler[gameManager.turnNameIndex1].playerMoney += 2500;
                    gameManager.bowler[gameManager.turnNameIndex2].playerMoney += 2500;
                    gameManager.bowler[gameManager.turnNameIndex3].playerMoney += 2500;
                    gameManager.bowler[gameManager.turnNameIndex1].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex3].playerWin++;
                }
                foreach (Text winPrize1 in winGamePrize1)
                {
                    winPrize1.text = "prize: 2,500";
                }
                foreach (Text winPrize2 in winGamePrize2)
                {
                    winPrize2.text = "prize: 2,500";
                }
                foreach (Text winPrize3 in winGamePrize3)
                {
                    winPrize3.text = "prize: 2,500";
                }
            }
            else if (GameManager.allPlayers == GameManager.Players.FourPlayer && maxBalls != 1)
            {
                gameManager.bowler[gameManager.turnNameIndex1].playerStrikes += strikes1;
                gameManager.bowler[gameManager.turnNameIndex1].playerSpares += spares1;
                gameManager.bowler[gameManager.turnNameIndex1].playerGutters += gutters1;
                gameManager.bowler[gameManager.turnNameIndex2].playerStrikes += strikes2;
                gameManager.bowler[gameManager.turnNameIndex2].playerSpares += spares2;
                gameManager.bowler[gameManager.turnNameIndex2].playerGutters += gutters2;
                gameManager.bowler[gameManager.turnNameIndex3].playerStrikes += strikes3;
                gameManager.bowler[gameManager.turnNameIndex3].playerSpares += spares3;
                gameManager.bowler[gameManager.turnNameIndex3].playerGutters += gutters3;
                gameManager.bowler[gameManager.turnNameIndex4].playerStrikes += strikes4;
                gameManager.bowler[gameManager.turnNameIndex4].playerSpares += spares4;
                gameManager.bowler[gameManager.turnNameIndex4].playerGutters += gutters4;
                if (score2 < score1 && score3 < score1 && score4 < score1)
                {
                    winGameBalls[0].SetActive(true);
                    wins = 1;
                    gameManager.bowler[gameManager.turnNameIndex1].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex1].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex3].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex4].playerLoss++;
                }
                else if (score1 < score2 && score3 < score2 && score4 < score2)
                {
                    winGameBalls[1].SetActive(true);
                    wins = 2;
                    gameManager.bowler[gameManager.turnNameIndex2].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex1].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex3].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex4].playerLoss++;
                }
                else if (score1 < score3 && score2 < score3 && score4 < score3)
                {
                    winGameBalls[2].SetActive(true);
                    wins = 3;
                    gameManager.bowler[gameManager.turnNameIndex3].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex1].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex3].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex4].playerLoss++;
                }
                else if (score1 < score4 && score4 < score2 && score4 < score3)
                {
                    winGameBalls[3].SetActive(true);
                    wins = 4;
                    gameManager.bowler[gameManager.turnNameIndex4].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex1].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex3].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex4].playerWin++;
                }
                else if (score1 == score2 && score3 < score1 && score4 < score1)
                {
                    winGameBalls[5].SetActive(true);
                    wins = 1;
                    gameManager.bowler[gameManager.turnNameIndex1].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex2].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex1].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex3].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex4].playerLoss++;
                }
                else if (score2 < score1 && score1 == score3 && score4 < score1)
                {
                    winGameBalls[6].SetActive(true);
                    wins = 1;
                    gameManager.bowler[gameManager.turnNameIndex1].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex3].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex1].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex3].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex4].playerLoss++;
                }
                else if (score2 < score1 && score3 < score1 && score1 == score4)
                {
                    winGameBalls[7].SetActive(true);
                    wins = 1;
                    gameManager.bowler[gameManager.turnNameIndex1].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex4].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex1].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex3].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex4].playerWin++;
                }
                else if (score1 < score2 && score2 == score3 && score1 < score2)
                {
                    winGameBalls[9].SetActive(true);
                    wins = 2;
                    gameManager.bowler[gameManager.turnNameIndex2].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex3].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex1].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex3].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex4].playerLoss++;
                }
                else if (score1 < score2 && score3 < score2 && score2 == score4)
                {
                    winGameBalls[10].SetActive(true);
                    wins = 2;
                    gameManager.bowler[gameManager.turnNameIndex2].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex4].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex1].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex3].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex4].playerWin++;
                }
                else if (score1 < score3 && score2 < score3 && score3 == score4)
                {
                    winGameBalls[11].SetActive(true);
                    wins = 3;
                    gameManager.bowler[gameManager.turnNameIndex3].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex4].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex1].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex3].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex4].playerWin++;
                }
                else if (score1 == score2 && score1 == score3 && score4 < score1)
                {
                    winGameBalls[12].SetActive(true);
                    wins = 1;
                    gameManager.bowler[gameManager.turnNameIndex1].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex2].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex3].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex1].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex3].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex4].playerLoss++;
                }
                else if (score1 == score2 && score3 < score1 && score1 == score4)
                {
                    winGameBalls[13].SetActive(true);
                    wins = 1;
                    gameManager.bowler[gameManager.turnNameIndex1].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex2].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex4].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex1].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex3].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex4].playerWin++;
                }
                else if (score2 < score1 && score1 == score3 && score1 == score4)
                {
                    winGameBalls[14].SetActive(true);
                    wins = 1;
                    gameManager.bowler[gameManager.turnNameIndex1].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex3].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex4].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex1].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex3].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex4].playerWin++;
                }
                else if (score1 < score2 && score2 == score3 && score2 == score4)
                {
                    winGameBalls[15].SetActive(true);
                    wins = 2;
                    gameManager.bowler[gameManager.turnNameIndex2].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex3].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex4].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex1].playerLoss++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex3].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex4].playerWin++;
                }
                else if (score1 == score2 && score1 == score3 && score1 == score4)
                {
                    winGameBalls[16].SetActive(true);
                    wins = 1;
                    gameManager.bowler[gameManager.turnNameIndex1].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex2].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex3].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex4].playerMoney += 5000;
                    gameManager.bowler[gameManager.turnNameIndex1].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex2].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex3].playerWin++;
                    gameManager.bowler[gameManager.turnNameIndex4].playerWin++;
                }
                foreach (Text winPrize1 in winGamePrize1)
                {
                    winPrize1.text = "prize: 5,000";
                }
                foreach (Text winPrize2 in winGamePrize2)
                {
                    winPrize2.text = "prize: 5,000";
                }
                foreach (Text winPrize3 in winGamePrize3)
                {
                    winPrize3.text = "prize: 5,000";
                }
                foreach (Text winPrize4 in winGamePrize4)
                {
                    winPrize4.text = "prize: 5,000";
                }
            }
            else if (GameManager.allPlayers == GameManager.Players.Computer && maxBalls != 1)
            {
                gameManager.bowler[gameManager.turnNameIndex1].playerStrikes += strikes1;
                gameManager.bowler[gameManager.turnNameIndex1].playerSpares += spares1;
                gameManager.bowler[gameManager.turnNameIndex1].playerGutters += gutters1;
                if (score2 < score1)
                {
                    winGameBalls[0].SetActive(true);
                    wins = 1;
                    gameManager.bowler[gameManager.turnNameIndex1].playerMoney += 1000;
                    gameManager.bowler[gameManager.turnNameIndex1].playerWin++;
                }
                else if (score1 < score2)
                {
                    winGameBalls[4].SetActive(true);
                    wins = 5;
                    gameManager.bowler[gameManager.turnNameIndex1].playerLoss++;
                }
                else if (score1 == score2)
                {
                    winGameBalls[8].SetActive(true);
                    wins = 1;
                    gameManager.bowler[gameManager.turnNameIndex1].playerMoney += 1000;
                    gameManager.bowler[gameManager.turnNameIndex1].playerWin++;
                }
                foreach (Text winPrize1 in winGamePrize1)
                {
                    winPrize1.text = "prize: 1,000";
                }
                foreach (Text winPrize2 in winGamePrize2)
                {
                    winPrize2.text = "prize: 1,000";
                }
            }
            if (wins == 0)
            {
                if (stage >= gameManager.chooseBalls[gameManager.unlockBallSpare].totalLock && gameManager.chooseBalls[gameManager.unlockBallSpare].isLock == 1 && gameManager.chooseBalls[gameManager.unlockBallSpare].lockType == ChooseBall.LockType.Spare)
                {
                    unlockedText.SetActive(true);
                    unlockedBallSpare.SetActive(true);
                    PlayerPrefs.SetInt("SaveBalls" + gameManager.unlockBallSpare, 0);
                    PlayerPrefs.SetInt("SaveBallSpare", gameManager.unlockBallSpare += 1);
                }
            }
            else if (wins == 1)
            {
                playerNameText.text = gameManager.bowler[gameManager.turnNameIndex1].playerName;
                ballNameText.text = gameManager.chooseBalls[gameManager.turnBalls1].ballName;
                ballDataText.text = gameManager.chooseBalls[gameManager.turnBalls1].lbs + "lbs.  speed:" + gameManager.chooseBalls[gameManager.turnBalls1].speed + "  spin:" + gameManager.chooseBalls[gameManager.turnBalls1].spin;
                ballRender.material = gameManager.chooseBalls[gameManager.turnBalls1].ballMat;
                playerTurn = 0;
                turns = 0;
                playersBallTwo[0].SetActive(true);
                playersBallTwo[1].SetActive(false);
                playersBallTwo[2].SetActive(false);
                playersBallTwo[3].SetActive(false);
                playersBallThree[0].SetActive(true);
                playersBallThree[1].SetActive(false);
                playersBallThree[2].SetActive(false);
                playersBallThree[3].SetActive(false);
                if (score1 <= 99)
                {
                    VoiceEndBad();
                    winCrowd.clip = Resources.Load<AudioClip>("Sound/Foo05");
                }
                else if(score1 >= 100 && score1 <= 149)
                {
                    VoiceEndOk();
                }
                else if(score1 >= 150 && score1 <= 249)
                {
                    VoiceEndGood();
                    winCrowd.clip = Resources.Load<AudioClip>("Sound/Yea05");
                }
                else if(score1 >= 250 && score1 <= 299)
                {
                    VoiceEndGreat();
                    winCrowd.clip = Resources.Load<AudioClip>("Sound/App01");
                }
                else if(score1 >= 300)
                {
                    PerfectGame();
                    winCrowd.clip = Resources.Load<AudioClip>("Sound/end-perfect");
                }
                if (score1 >= 200 && gameManager.isLockAlleys[(int)GameManager.alleyLockType] == 1)
                {
                    unlockedText.SetActive(true);
                    unlockedAlley.SetActive(true);
                    PlayerPrefs.SetInt("SaveAlleys" + (int)GameManager.alleyLockType, 2);
                }
                if (GameManager.allPlayers == GameManager.Players.Computer && gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].isLock == 1)
                {
                    unlockedText.SetActive(true);
                    unlockedBallBeat.SetActive(true);
                    PlayerPrefs.SetInt("SaveBalls" + gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex, 0);
                }
                if (score1 >= gameManager.chooseBalls[gameManager.unlockBallScore].totalLock && gameManager.chooseBalls[gameManager.unlockBallScore].isLock == 1 && gameManager.chooseBalls[gameManager.unlockBallScore].lockType == ChooseBall.LockType.Score)
                {
                    unlockedText.SetActive(true);
                    unlockedBallScore.SetActive(true);
                    PlayerPrefs.SetInt("SaveBalls" + gameManager.unlockBallScore, 0);
                    PlayerPrefs.SetInt("SaveBallScore", gameManager.unlockBallScore += 1);
                }
            }
            else if (wins == 2)
            {
                playerNameText.text = gameManager.bowler[gameManager.turnNameIndex2].playerName;
                ballNameText.text = gameManager.chooseBalls[gameManager.turnBalls2].ballName;
                ballDataText.text = gameManager.chooseBalls[gameManager.turnBalls2].lbs + "lbs.  speed:" + gameManager.chooseBalls[gameManager.turnBalls2].speed + "  spin:" + gameManager.chooseBalls[gameManager.turnBalls2].spin;
                ballRender.material = gameManager.chooseBalls[gameManager.turnBalls2].ballMat;
                playerTurn = 1;
                turns = 1;
                playersBallTwo[0].SetActive(false);
                playersBallTwo[1].SetActive(true);
                playersBallTwo[2].SetActive(false);
                playersBallTwo[3].SetActive(false);
                playersBallThree[0].SetActive(false);
                playersBallThree[1].SetActive(true);
                playersBallThree[2].SetActive(false);
                playersBallThree[3].SetActive(false);
                if (score2 <= 99)
                {
                    VoiceEndBad();
                    winCrowd.clip = Resources.Load<AudioClip>("Sound/Foo05");
                }
                else if(score2 >= 100 && score2 <= 149)
                {
                    VoiceEndOk();
                }
                else if(score2 >= 150 && score2 <= 249)
                {
                    VoiceEndGood();
                    winCrowd.clip = Resources.Load<AudioClip>("Sound/Yea05");
                }
                else if(score2 >= 250 && score2 <= 299)
                {
                    VoiceEndGreat();
                    winCrowd.clip = Resources.Load<AudioClip>("Sound/App01");
                }
                else if(score2 >= 300)
                {
                    PerfectGame();
                    winCrowd.clip = Resources.Load<AudioClip>("Sound/end-perfect");
                }
                if (score2 >= 200 && gameManager.isLockAlleys[(int)GameManager.alleyLockType] == 1)
                {
                    unlockedText.SetActive(true);
                    unlockedAlley.SetActive(true);
                    PlayerPrefs.SetInt("SaveAlleys" + (int)GameManager.alleyLockType, 2);
                }
                if (score2 >= gameManager.chooseBalls[gameManager.unlockBallScore].totalLock && gameManager.chooseBalls[gameManager.unlockBallScore].isLock == 1 && gameManager.chooseBalls[gameManager.unlockBallScore].lockType == ChooseBall.LockType.Score)
                {
                    unlockedText.SetActive(true);
                    unlockedBallScore.SetActive(true);
                    PlayerPrefs.SetInt("SaveBalls" + gameManager.unlockBallScore, 0);
                    PlayerPrefs.SetInt("SaveBallScore", gameManager.unlockBallScore += 1);
                }
            }
            else if (wins == 3)
            {
                playerNameText.text = gameManager.bowler[gameManager.turnNameIndex3].playerName;
                ballNameText.text = gameManager.chooseBalls[gameManager.turnBalls3].ballName;
                ballDataText.text = gameManager.chooseBalls[gameManager.turnBalls3].lbs + "lbs.  speed:" + gameManager.chooseBalls[gameManager.turnBalls3].speed + "  spin:" + gameManager.chooseBalls[gameManager.turnBalls3].spin;
                ballRender.material = gameManager.chooseBalls[gameManager.turnBalls3].ballMat;
                playerTurn = 2;
                turns = 2;
                playersBallTwo[0].SetActive(false);
                playersBallTwo[1].SetActive(false);
                playersBallTwo[2].SetActive(true);
                playersBallTwo[3].SetActive(false);
                playersBallThree[0].SetActive(false);
                playersBallThree[1].SetActive(false);
                playersBallThree[2].SetActive(true);
                playersBallThree[3].SetActive(false);
                if (score3 <= 99)
                {
                    VoiceEndBad();
                    winCrowd.clip = Resources.Load<AudioClip>("Sound/Foo05");
                }
                else if (score3 >= 100 && score3 <= 149)
                {
                    VoiceEndOk();
                }
                else if (score3 >= 150 && score3 <= 249)
                {
                    VoiceEndGood();
                    winCrowd.clip = Resources.Load<AudioClip>("Sound/Yea05");
                }
                else if (score3 >= 250 && score3 <= 299)
                {
                    VoiceEndGreat();
                    winCrowd.clip = Resources.Load<AudioClip>("Sound/App01");
                }
                else if (score3 >= 300)
                {
                    PerfectGame();
                    winCrowd.clip = Resources.Load<AudioClip>("Sound/end-perfect");
                }
                if (score3 >= 200 && gameManager.isLockAlleys[(int)GameManager.alleyLockType] == 1)
                {
                    unlockedText.SetActive(true);
                    unlockedAlley.SetActive(true);
                    PlayerPrefs.SetInt("SaveAlleys" + (int)GameManager.alleyLockType, 2);
                }
                if (score3 >= gameManager.chooseBalls[gameManager.unlockBallScore].totalLock && gameManager.chooseBalls[gameManager.unlockBallScore].isLock == 1 && gameManager.chooseBalls[gameManager.unlockBallScore].lockType == ChooseBall.LockType.Score)
                {
                    unlockedText.SetActive(true);
                    unlockedBallScore.SetActive(true);
                    PlayerPrefs.SetInt("SaveBalls" + gameManager.unlockBallScore, 0);
                    PlayerPrefs.SetInt("SaveBallScore", gameManager.unlockBallScore += 1);
                }
            }
            else if (wins == 4)
            {
                playerNameText.text = gameManager.bowler[gameManager.turnNameIndex4].playerName;
                ballNameText.text = gameManager.chooseBalls[gameManager.turnBalls4].ballName;
                ballDataText.text = gameManager.chooseBalls[gameManager.turnBalls4].lbs + "lbs.  speed:" + gameManager.chooseBalls[gameManager.turnBalls4].speed + "  spin:" + gameManager.chooseBalls[gameManager.turnBalls4].spin;
                ballRender.material = gameManager.chooseBalls[gameManager.turnBalls4].ballMat;
                playerTurn = 3;
                turns = 3;
                playersBallTwo[0].SetActive(false);
                playersBallTwo[1].SetActive(false);
                playersBallTwo[2].SetActive(false);
                playersBallTwo[3].SetActive(true);
                playersBallThree[0].SetActive(false);
                playersBallThree[1].SetActive(false);
                playersBallThree[2].SetActive(false);
                playersBallThree[3].SetActive(true);
                if (score4 <= 99)
                {
                    VoiceEndBad();
                    winCrowd.clip = Resources.Load<AudioClip>("Sound/Foo05");
                }
                else if(score4 >= 100 && score4 <= 149)
                {
                    VoiceEndOk();
                }
                else if(score4 >= 150 && score4 <= 249)
                {
                    VoiceEndGood();
                    winCrowd.clip = Resources.Load<AudioClip>("Sound/Yea05");
                }
                else if(score4 >= 250 && score4 <= 299)
                {
                    VoiceEndGreat();
                    winCrowd.clip = Resources.Load<AudioClip>("Sound/App01");
                }
                else if(score4 >= 300)
                {
                    PerfectGame();
                    winCrowd.clip = Resources.Load<AudioClip>("Sound/end-perfect");
                }
                if (score4 >= 200 && gameManager.isLockAlleys[(int)GameManager.alleyLockType] == 1)
                {
                    unlockedText.SetActive(true);
                    unlockedAlley.SetActive(true);
                    PlayerPrefs.SetInt("SaveAlleys" + (int)GameManager.alleyLockType, 2);
                }
                if (score4 >= gameManager.chooseBalls[gameManager.unlockBallScore].totalLock && gameManager.chooseBalls[gameManager.unlockBallScore].isLock == 1 && gameManager.chooseBalls[gameManager.unlockBallScore].lockType == ChooseBall.LockType.Score)
                {
                    unlockedText.SetActive(true);
                    unlockedBallScore.SetActive(true);
                    PlayerPrefs.SetInt("SaveBalls" + gameManager.unlockBallScore, 0);
                    PlayerPrefs.SetInt("SaveBallScore", gameManager.unlockBallScore += 1);
                }
            }
            else if (wins == 5)
            {
                playerNameText.text = gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].CPUName;
                ballNameText.text = gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].ballName;
                ballDataText.text = gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].lbs + "lbs.  speed:" + gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].speed + "  spin:" + gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].spin;
                ballRender.material = gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].ballMat;
                playerTurn = 4;
                turns = 1;
                playersBallTwo[0].SetActive(false);
                playersBallTwo[1].SetActive(true);
                playersBallTwo[2].SetActive(false);
                playersBallTwo[3].SetActive(false);
                playersBallThree[0].SetActive(false);
                playersBallThree[1].SetActive(true);
                playersBallThree[2].SetActive(false);
                playersBallThree[3].SetActive(false);
                if (score2 <= 99)
                {
                    VoiceEndBad();
                    winCrowd.clip = Resources.Load<AudioClip>("Sound/Foo05");
                }
                else if(score2 >= 100 && score2 <= 149)
                {
                    VoiceEndOk();
                }
                else if(score2 >= 150 && score2 <= 249)
                {
                    VoiceEndGood();
                    winCrowd.clip = Resources.Load<AudioClip>("Sound/Yea05");
                }
                else if(score2 >= 250 && score2 <= 299)
                {
                    VoiceEndGreat();
                    winCrowd.clip = Resources.Load<AudioClip>("Sound/App01");
                }
                else if(score2 >= 300)
                {
                    PerfectGame();
                    winCrowd.clip = Resources.Load<AudioClip>("Sound/end-perfect");
                }
            }
            foreach (PlayerObj playerEarn in gameManager.bowler)
            {
                if (playerEarn.playerMoney >= gameManager.chooseBalls[gameManager.unlockBallEarn].totalLock && gameManager.chooseBalls[gameManager.unlockBallEarn].isLock == 1 && gameManager.chooseBalls[gameManager.unlockBallEarn].lockType == ChooseBall.LockType.Earn)
                {
                    unlockedText.SetActive(true);
                    unlockedBallEarn.SetActive(true);
                    PlayerPrefs.SetInt("SaveBalls" + gameManager.unlockBallEarn, 0);
                    if (gameManager.unlockBallEarn < 39)
                    {
                        PlayerPrefs.SetInt("SaveBallEarn", gameManager.unlockBallEarn += 5);
                    }
                    else if (gameManager.unlockBallEarn == 39)
                    {
                        PlayerPrefs.SetInt("SaveBallEarn", 84);
                    }
                }
            }
            FileData.SaveToSAV<PlayerObj>(gameManager.bowler, "SaveBowler");
        }
        else
        {
            if (GameManager.type != GameManager.GameState.Menu)
            {
                if (nextTurn == 0)
                {
                    playerNameText.text = gameManager.bowler[gameManager.turnNameIndex1].playerName;
                    ballNameText.text = gameManager.chooseBalls[gameManager.turnBalls1].ballName;
                    ballDataText.text = gameManager.chooseBalls[gameManager.turnBalls1].lbs + "lbs.  speed:" + gameManager.chooseBalls[gameManager.turnBalls1].speed + "  spin:" + gameManager.chooseBalls[gameManager.turnBalls1].spin;
                    ballRender.material = gameManager.chooseBalls[gameManager.turnBalls1].ballMat;
                    ball.ChargeBall(gameManager.chooseBalls[gameManager.turnBalls1].ballMat, gameManager.chooseBalls[gameManager.turnBalls1].lbs, gameManager.chooseBalls[gameManager.turnBalls1].speed, gameManager.chooseBalls[gameManager.turnBalls1].spin);
                    chooseBallUI.SetActive(true);
                    playerTurn = 0;
                    turns = 0;
                    isComputer = false;
                    playersBallTwo[0].SetActive(true);
                    playersBallTwo[1].SetActive(false);
                    playersBallTwo[2].SetActive(false);
                    playersBallTwo[3].SetActive(false);
                    playersBallThree[0].SetActive(true);
                    playersBallThree[1].SetActive(false);
                    playersBallThree[2].SetActive(false);
                    playersBallThree[3].SetActive(false);
                }
                else if (nextTurn == 1)
                {
                    playerNameText.text = gameManager.bowler[gameManager.turnNameIndex2].playerName;
                    ballNameText.text = gameManager.chooseBalls[gameManager.turnBalls2].ballName;
                    ballDataText.text = gameManager.chooseBalls[gameManager.turnBalls2].lbs + "lbs.  speed:" + gameManager.chooseBalls[gameManager.turnBalls2].speed + "  spin:" + gameManager.chooseBalls[gameManager.turnBalls2].spin;
                    ballRender.material = gameManager.chooseBalls[gameManager.turnBalls2].ballMat;
                    ball.ChargeBall(gameManager.chooseBalls[gameManager.turnBalls2].ballMat, gameManager.chooseBalls[gameManager.turnBalls2].lbs, gameManager.chooseBalls[gameManager.turnBalls2].speed, gameManager.chooseBalls[gameManager.turnBalls2].spin);
                    chooseBallUI.SetActive(true);
                    playerTurn = 1;
                    turns = 1;
                    isComputer = false;
                    playersBallTwo[0].SetActive(false);
                    playersBallTwo[1].SetActive(true);
                    playersBallTwo[2].SetActive(false);
                    playersBallTwo[3].SetActive(false);
                    playersBallThree[0].SetActive(false);
                    playersBallThree[1].SetActive(true);
                    playersBallThree[2].SetActive(false);
                    playersBallThree[3].SetActive(false);
                }
                else if (nextTurn == 2)
                {
                    playerNameText.text = gameManager.bowler[gameManager.turnNameIndex3].playerName;
                    ballNameText.text = gameManager.chooseBalls[gameManager.turnBalls3].ballName;
                    ballDataText.text = gameManager.chooseBalls[gameManager.turnBalls3].lbs + "lbs.  speed:" + gameManager.chooseBalls[gameManager.turnBalls3].speed + "  spin:" + gameManager.chooseBalls[gameManager.turnBalls3].spin;
                    ballRender.material = gameManager.chooseBalls[gameManager.turnBalls3].ballMat;
                    ball.ChargeBall(gameManager.chooseBalls[gameManager.turnBalls3].ballMat, gameManager.chooseBalls[gameManager.turnBalls3].lbs, gameManager.chooseBalls[gameManager.turnBalls3].speed, gameManager.chooseBalls[gameManager.turnBalls3].spin);
                    chooseBallUI.SetActive(true);
                    playerTurn = 2;
                    turns = 2;
                    isComputer = false;
                    playersBallTwo[0].SetActive(false);
                    playersBallTwo[1].SetActive(false);
                    playersBallTwo[2].SetActive(true);
                    playersBallTwo[3].SetActive(false);
                    playersBallThree[0].SetActive(false);
                    playersBallThree[1].SetActive(false);
                    playersBallThree[2].SetActive(true);
                    playersBallThree[3].SetActive(false);
                }
                else if (nextTurn == 3)
                {
                    playerNameText.text = gameManager.bowler[gameManager.turnNameIndex4].playerName;
                    ballNameText.text = gameManager.chooseBalls[gameManager.turnBalls4].ballName;
                    ballDataText.text = gameManager.chooseBalls[gameManager.turnBalls4].lbs + "lbs.  speed:" + gameManager.chooseBalls[gameManager.turnBalls4].speed + "  spin:" + gameManager.chooseBalls[gameManager.turnBalls4].spin;
                    ballRender.material = gameManager.chooseBalls[gameManager.turnBalls4].ballMat;
                    ball.ChargeBall(gameManager.chooseBalls[gameManager.turnBalls4].ballMat, gameManager.chooseBalls[gameManager.turnBalls4].lbs, gameManager.chooseBalls[gameManager.turnBalls4].speed, gameManager.chooseBalls[gameManager.turnBalls4].spin);
                    chooseBallUI.SetActive(true);
                    playerTurn = 3;
                    turns = 3;
                    isComputer = false;
                    playersBallTwo[0].SetActive(false);
                    playersBallTwo[1].SetActive(false);
                    playersBallTwo[2].SetActive(false);
                    playersBallTwo[3].SetActive(true);
                    playersBallThree[0].SetActive(false);
                    playersBallThree[1].SetActive(false);
                    playersBallThree[2].SetActive(false);
                    playersBallThree[3].SetActive(true);
                }
                else if (nextTurn == 4)
                {
                    playerNameText.text = gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].CPUName;
                    ballNameText.text = gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].ballName;
                    ballDataText.text = gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].lbs + "lbs.  speed:" + gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].speed + "  spin:" + gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].spin;
                    ballRender.material = gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].ballMat;
                    ball.ChargeBall(gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].ballMat, gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].lbs, gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].speed, gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].spin);
                    chooseBallUI.SetActive(false);
                    playerTurn = 4;
                    turns = 1;
                    isComputer = true;
                    playersBallTwo[0].SetActive(false);
                    playersBallTwo[1].SetActive(true);
                    playersBallTwo[2].SetActive(false);
                    playersBallTwo[3].SetActive(false);
                    playersBallThree[0].SetActive(false);
                    playersBallThree[1].SetActive(true);
                    playersBallThree[2].SetActive(false);
                    playersBallThree[3].SetActive(false);
                }
            }
            else
            {
                ball.ResetBowl();
                ball.ResetCam();
            }
            if (GameManager.type == GameManager.GameState.Replay)
            {
                if (isComputer)
                {
                    ball.ResetBowl();
                    ball.ResetCam();
                }
                else
                {
                    ball.Reset();
                    ball.ResetCam();
                }
                GameManager.type = GameManager.GameState.Game;
            }
        }
    }

    public void RainCountdown()
    {
        if (rainIndex == 0 && GameObject.FindObjectOfType<PinSetter>().isRain)
        {
            if (GameObject.FindObjectOfType<PinSetter>().psDrop != null && GameManager.isWeather)
            {
                GameObject.FindObjectOfType<PinSetter>().psDrop.Play();
            }
            if (GameObject.FindObjectOfType<PinSetter>().isThunder && GameManager.isWeather)
            {
                if (audioSource != null && gameManager != null && GameManager.isSound && GameManager.type != GameManager.GameState.Menu)
                {
                    PlayClip("thunder");
                }
                if (rainPorch != null && gameManager != null && GameManager.isSound && GameManager.type != GameManager.GameState.Menu)
                {
                    rainPorch.Play();
                }
                thunderAnimation.Play();
            }
        }
        else if (rainIndex == 5)
        {
            if (GameObject.FindObjectOfType<PinSetter>().psDrop != null)
            {
                GameObject.FindObjectOfType<PinSetter>().psDrop.Stop();
            }
            if (GameObject.FindObjectOfType<PinSetter>().isThunder)
            {
                if (rainPorch != null)
                {
                    rainPorch.Stop();
                }
            }
        }
        rainIndex++;
    }

    public static void PlayClip(string clipName)
    {
        if (GameManager.isSound && GameManager.type != GameManager.GameState.Menu)
        {
            audioSource.PlayOneShot(Resources.Load<AudioClip>("Sound/" + clipName));
        }
    }

    public void MouseDown()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.type == GameManager.GameState.Replay)
        {
            if (isAnim)
            {
                for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().strikeAnimations.Length; i++)
                {
                    GameObject.FindObjectOfType<PinSetter>().strikeAnimations[i].SkipAnimation();
                }
                for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().spareAnimations.Length; i++)
                {
                    GameObject.FindObjectOfType<PinSetter>().spareAnimations[i].SkipAnimation();
                }
                for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().gutterballAnimations.Length; i++)
                {
                    GameObject.FindObjectOfType<PinSetter>().gutterballAnimations[i].SkipAnimation();
                }
                for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().doubleAnimations.Length; i++)
                {
                    GameObject.FindObjectOfType<PinSetter>().doubleAnimations[i].SkipAnimation();
                }
                for (int i = 0; i < GameObject.FindObjectOfType<PinSetter>().turkeyAnimations.Length; i++)
                {
                    GameObject.FindObjectOfType<PinSetter>().turkeyAnimations[i].SkipAnimation();
                }
                StopAllAnimations();
            }
            isAnim = false;
            if (b != null)
            {
                StopCoroutine(b);
            }
            if (isCurrentReplay)
            {
                for (int i = 0; i < replays.Length; i++)
                {
                    replays[i].RigidBodyFreeze(false);
                    replays[i].RigidBodyCollider(true);
                    replays[i].SetTransform(replays[i].actionReplayRecords.Count - 1);
                    replays[i].Clear();
                    if (!isScooper && throwBall < maxBalls)
                    {
                        replays[i].SetVelocity();
                    }
                }
            }
            SkipReplay();
        }
    }

    public void PlayGame()
    {
        GameManager.isHighScore = false;
        VoiceStop();
        AudioStop();
        loadingUI.SetActive(true);
        SceneManager.LoadScene("Main");
        GameManager.type = GameManager.GameState.Intro;
        PlayerPrefs.SetInt("PinModes", (int)GameManager.pinMode);
    }

    public void Sending()
    {
        StartCoroutine(EmailSend());
    }

    public void QuitMenu()
    {
        VoiceStop();
        CrowdStop();
        AudioStop();
        SceneManager.LoadScene("Main");
        GameManager.type = GameManager.GameState.Menu;
    }

    public void EndGame()
    {
        if (GameManager.pinMode != GameManager.PinMode.Spare)
        {
            switch (GameManager.chooseAlleys)
            {
                case GameManager.Alley.Retro:
                    if (GameManager.allPlayers == GameManager.Players.OnePlayer)
                    {
                        AddBowlerScore(gameManager.r_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Retro");
                    }
                    if (GameManager.allPlayers == GameManager.Players.TwoPlayer)
                    {
                        AddBowlerScore(gameManager.r_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Retro");
                        AddBowlerScore(gameManager.r_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex2].playerName, score2, strikes2, spares2, gutters2), "HS_Retro");
                    }
                    if (GameManager.allPlayers == GameManager.Players.ThreePlayer)
                    {
                        AddBowlerScore(gameManager.r_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Retro");
                        AddBowlerScore(gameManager.r_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex2].playerName, score2, strikes2, spares2, gutters2), "HS_Retro");
                        AddBowlerScore(gameManager.r_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex3].playerName, score3, strikes3, spares3, gutters3), "HS_Retro");
                    }
                    if (GameManager.allPlayers == GameManager.Players.FourPlayer)
                    {
                        AddBowlerScore(gameManager.r_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Retro");
                        AddBowlerScore(gameManager.r_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex2].playerName, score2, strikes2, spares2, gutters2), "HS_Retro");
                        AddBowlerScore(gameManager.r_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex3].playerName, score3, strikes3, spares3, gutters3), "HS_Retro");
                        AddBowlerScore(gameManager.r_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex4].playerName, score4, strikes4, spares4, gutters4), "HS_Retro");
                    }
                    if (GameManager.allPlayers == GameManager.Players.Computer)
                    {
                        AddBowlerScore(gameManager.r_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Retro");
                        AddBowlerScore(gameManager.r_hs, new ScoreBowler(gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].CPUName, score2, strikes2, spares2, gutters2), "HS_Retro");
                    }
                    break;
                case GameManager.Alley.Wacky:
                    if (GameManager.allPlayers == GameManager.Players.OnePlayer)
                    {
                        AddBowlerScore(gameManager.w_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Wacky");
                    }
                    if (GameManager.allPlayers == GameManager.Players.TwoPlayer)
                    {
                        AddBowlerScore(gameManager.w_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Wacky");
                        AddBowlerScore(gameManager.w_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex2].playerName, score2, strikes2, spares2, gutters2), "HS_Wacky");
                    }
                    if (GameManager.allPlayers == GameManager.Players.ThreePlayer)
                    {
                        AddBowlerScore(gameManager.w_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Wacky");
                        AddBowlerScore(gameManager.w_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex2].playerName, score2, strikes2, spares2, gutters2), "HS_Wacky");
                        AddBowlerScore(gameManager.w_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex3].playerName, score3, strikes3, spares3, gutters3), "HS_Wacky");
                    }
                    if (GameManager.allPlayers == GameManager.Players.FourPlayer)
                    {
                        AddBowlerScore(gameManager.w_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Wacky");
                        AddBowlerScore(gameManager.w_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex2].playerName, score2, strikes2, spares2, gutters2), "HS_Wacky");
                        AddBowlerScore(gameManager.w_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex3].playerName, score3, strikes3, spares3, gutters3), "HS_Wacky");
                        AddBowlerScore(gameManager.w_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex4].playerName, score4, strikes4, spares4, gutters4), "HS_Wacky");
                    }
                    if (GameManager.allPlayers == GameManager.Players.Computer)
                    {
                        AddBowlerScore(gameManager.w_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Wacky");
                        AddBowlerScore(gameManager.w_hs, new ScoreBowler(gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].CPUName, score2, strikes2, spares2, gutters2), "HS_Wacky");
                    }
                    break;
                case GameManager.Alley.Iceberg:
                    if (GameManager.allPlayers == GameManager.Players.OnePlayer)
                    {
                        AddBowlerScore(gameManager.i_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Iceberg");
                    }
                    if (GameManager.allPlayers == GameManager.Players.TwoPlayer)
                    {
                        AddBowlerScore(gameManager.i_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Iceberg");
                        AddBowlerScore(gameManager.i_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex2].playerName, score2, strikes2, spares2, gutters2), "HS_Iceberg");
                    }
                    if (GameManager.allPlayers == GameManager.Players.ThreePlayer)
                    {
                        AddBowlerScore(gameManager.i_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Iceberg");
                        AddBowlerScore(gameManager.i_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex2].playerName, score2, strikes2, spares2, gutters2), "HS_Iceberg");
                        AddBowlerScore(gameManager.i_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex3].playerName, score3, strikes3, spares3, gutters3), "HS_Iceberg");
                    }
                    if (GameManager.allPlayers == GameManager.Players.FourPlayer)
                    {
                        AddBowlerScore(gameManager.i_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Iceberg");
                        AddBowlerScore(gameManager.i_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex2].playerName, score2, strikes2, spares2, gutters2), "HS_Iceberg");
                        AddBowlerScore(gameManager.i_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex3].playerName, score3, strikes3, spares3, gutters3), "HS_Iceberg");
                        AddBowlerScore(gameManager.i_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex4].playerName, score4, strikes4, spares4, gutters4), "HS_Iceberg");
                    }
                    if (GameManager.allPlayers == GameManager.Players.Computer)
                    {
                        AddBowlerScore(gameManager.i_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Iceberg");
                        AddBowlerScore(gameManager.i_hs, new ScoreBowler(gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].CPUName, score2, strikes2, spares2, gutters2), "HS_Iceberg");
                    }
                    break;
                case GameManager.Alley.Jungle:
                    if (GameManager.allPlayers == GameManager.Players.OnePlayer)
                    {
                        AddBowlerScore(gameManager.j_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Jungle");
                    }
                    if (GameManager.allPlayers == GameManager.Players.TwoPlayer)
                    {
                        AddBowlerScore(gameManager.j_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Jungle");
                        AddBowlerScore(gameManager.j_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex2].playerName, score2, strikes2, spares2, gutters2), "HS_Jungle");
                    }
                    if (GameManager.allPlayers == GameManager.Players.ThreePlayer)
                    {
                        AddBowlerScore(gameManager.j_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Jungle");
                        AddBowlerScore(gameManager.j_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex2].playerName, score2, strikes2, spares2, gutters2), "HS_Jungle");
                        AddBowlerScore(gameManager.j_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex3].playerName, score3, strikes3, spares3, gutters3), "HS_Jungle");
                    }
                    if (GameManager.allPlayers == GameManager.Players.FourPlayer)
                    {
                        AddBowlerScore(gameManager.j_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Jungle");
                        AddBowlerScore(gameManager.j_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex2].playerName, score2, strikes2, spares2, gutters2), "HS_Jungle");
                        AddBowlerScore(gameManager.j_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex3].playerName, score3, strikes3, spares3, gutters3), "HS_Jungle");
                        AddBowlerScore(gameManager.j_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex4].playerName, score4, strikes4, spares4, gutters4), "HS_Jungle");
                    }
                    if (GameManager.allPlayers == GameManager.Players.Computer)
                    {
                        AddBowlerScore(gameManager.j_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Jungle");
                        AddBowlerScore(gameManager.j_hs, new ScoreBowler(gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].CPUName, score2, strikes2, spares2, gutters2), "HS_Jungle");
                    }
                    break;
                case GameManager.Alley.Zen:
                    if (GameManager.allPlayers == GameManager.Players.OnePlayer)
                    {
                        AddBowlerScore(gameManager.z_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Zen");
                    }
                    if (GameManager.allPlayers == GameManager.Players.TwoPlayer)
                    {
                        AddBowlerScore(gameManager.z_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Zen");
                        AddBowlerScore(gameManager.z_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex2].playerName, score2, strikes2, spares2, gutters2), "HS_Zen");
                    }
                    if (GameManager.allPlayers == GameManager.Players.ThreePlayer)
                    {
                        AddBowlerScore(gameManager.z_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Zen");
                        AddBowlerScore(gameManager.z_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex2].playerName, score2, strikes2, spares2, gutters2), "HS_Zen");
                        AddBowlerScore(gameManager.z_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex3].playerName, score3, strikes3, spares3, gutters3), "HS_Zen");
                    }
                    if (GameManager.allPlayers == GameManager.Players.FourPlayer)
                    {
                        AddBowlerScore(gameManager.z_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Zen");
                        AddBowlerScore(gameManager.z_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex2].playerName, score2, strikes2, spares2, gutters2), "HS_Zen");
                        AddBowlerScore(gameManager.z_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex3].playerName, score3, strikes3, spares3, gutters3), "HS_Zen");
                        AddBowlerScore(gameManager.z_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex4].playerName, score4, strikes4, spares4, gutters4), "HS_Zen");
                    }
                    if (GameManager.allPlayers == GameManager.Players.Computer)
                    {
                        AddBowlerScore(gameManager.z_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Zen");
                        AddBowlerScore(gameManager.z_hs, new ScoreBowler(gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].CPUName, score2, strikes2, spares2, gutters2), "HS_Zen");
                    }
                    break;
                case GameManager.Alley.Cosmic:
                    if (GameManager.allPlayers == GameManager.Players.OnePlayer)
                    {
                        AddBowlerScore(gameManager.c_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Cosmic");
                    }
                    if (GameManager.allPlayers == GameManager.Players.TwoPlayer)
                    {
                        AddBowlerScore(gameManager.c_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Cosmic");
                        AddBowlerScore(gameManager.c_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex2].playerName, score2, strikes2, spares2, gutters2), "HS_Cosmic");
                    }
                    if (GameManager.allPlayers == GameManager.Players.ThreePlayer)
                    {
                        AddBowlerScore(gameManager.c_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Cosmic");
                        AddBowlerScore(gameManager.c_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex2].playerName, score2, strikes2, spares2, gutters2), "HS_Cosmic");
                        AddBowlerScore(gameManager.c_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex3].playerName, score3, strikes3, spares3, gutters3), "HS_Cosmic");
                    }
                    if (GameManager.allPlayers == GameManager.Players.FourPlayer)
                    {
                        AddBowlerScore(gameManager.c_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Cosmic");
                        AddBowlerScore(gameManager.c_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex2].playerName, score2, strikes2, spares2, gutters2), "HS_Cosmic");
                        AddBowlerScore(gameManager.c_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex3].playerName, score3, strikes3, spares3, gutters3), "HS_Cosmic");
                        AddBowlerScore(gameManager.c_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex4].playerName, score4, strikes4, spares4, gutters4), "HS_Cosmic");
                    }
                    if (GameManager.allPlayers == GameManager.Players.Computer)
                    {
                        AddBowlerScore(gameManager.c_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Cosmic");
                        AddBowlerScore(gameManager.c_hs, new ScoreBowler(gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].CPUName, score2, strikes2, spares2, gutters2), "HS_Cosmic");
                    }
                    break;
                case GameManager.Alley.Barnyard:
                    if (GameManager.allPlayers == GameManager.Players.OnePlayer)
                    {
                        AddBowlerScore(gameManager.b_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Barnyard");
                    }
                    if (GameManager.allPlayers == GameManager.Players.TwoPlayer)
                    {
                        AddBowlerScore(gameManager.b_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Barnyard");
                        AddBowlerScore(gameManager.b_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex2].playerName, score2, strikes2, spares2, gutters2), "HS_Barnyard");
                    }
                    if (GameManager.allPlayers == GameManager.Players.ThreePlayer)
                    {
                        AddBowlerScore(gameManager.b_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Barnyard");
                        AddBowlerScore(gameManager.b_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex2].playerName, score2, strikes2, spares2, gutters2), "HS_Barnyard");
                        AddBowlerScore(gameManager.b_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex3].playerName, score3, strikes3, spares3, gutters3), "HS_Barnyard");
                    }
                    if (GameManager.allPlayers == GameManager.Players.FourPlayer)
                    {
                        AddBowlerScore(gameManager.b_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Barnyard");
                        AddBowlerScore(gameManager.b_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex2].playerName, score2, strikes2, spares2, gutters2), "HS_Barnyard");
                        AddBowlerScore(gameManager.b_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex3].playerName, score3, strikes3, spares3, gutters3), "HS_Barnyard");
                        AddBowlerScore(gameManager.b_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex4].playerName, score4, strikes4, spares4, gutters4), "HS_Barnyard");
                    }
                    if (GameManager.allPlayers == GameManager.Players.Computer)
                    {
                        AddBowlerScore(gameManager.b_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Barnyard");
                        AddBowlerScore(gameManager.b_hs, new ScoreBowler(gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].CPUName, score2, strikes2, spares2, gutters2), "HS_Barnyard");
                    }
                    break;
                case GameManager.Alley.Mineshaft:
                    if (GameManager.allPlayers == GameManager.Players.OnePlayer)
                    {
                        AddBowlerScore(gameManager.m_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Mineshaft");
                    }
                    if (GameManager.allPlayers == GameManager.Players.TwoPlayer)
                    {
                        AddBowlerScore(gameManager.m_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Mineshaft");
                        AddBowlerScore(gameManager.m_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex2].playerName, score2, strikes2, spares2, gutters2), "HS_Mineshaft");
                    }
                    if (GameManager.allPlayers == GameManager.Players.ThreePlayer)
                    {
                        AddBowlerScore(gameManager.m_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Mineshaft");
                        AddBowlerScore(gameManager.m_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex2].playerName, score2, strikes2, spares2, gutters2), "HS_Mineshaft");
                        AddBowlerScore(gameManager.m_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex3].playerName, score3, strikes3, spares3, gutters3), "HS_Mineshaft");
                    }
                    if (GameManager.allPlayers == GameManager.Players.FourPlayer)
                    {
                        AddBowlerScore(gameManager.m_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Mineshaft");
                        AddBowlerScore(gameManager.m_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex2].playerName, score2, strikes2, spares2, gutters2), "HS_Mineshaft");
                        AddBowlerScore(gameManager.m_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex3].playerName, score3, strikes3, spares3, gutters3), "HS_Mineshaft");
                        AddBowlerScore(gameManager.m_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex4].playerName, score4, strikes4, spares4, gutters4), "HS_Mineshaft");
                    }
                    if (GameManager.allPlayers == GameManager.Players.Computer)
                    {
                        AddBowlerScore(gameManager.m_hs, new ScoreBowler(gameManager.bowler[gameManager.turnNameIndex1].playerName, score1, strikes1, spares1, gutters1), "HS_Mineshaft");
                        AddBowlerScore(gameManager.m_hs, new ScoreBowler(gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].CPUName, score2, strikes2, spares2, gutters2), "HS_Mineshaft");
                    }
                    break;
            }
            GameManager.isHighScore = true;
        }
        VoiceStop();
        CrowdStop();
        crowdAudio.Stop();
        rollCrowd.Stop();
        winCrowd.Stop();
        fireworksMulti.Stop();
        audioSource.Stop();
        rainPorch.Stop();
        SceneManager.LoadScene("Main");
        GameManager.type = GameManager.GameState.Menu;
    }

    void AddBowlerScore(List<ScoreBowler> bowlerList, ScoreBowler element, string filename)
    {
        for (int i = 0; i < bowlerList.Count; i++)
        {
            if (i > bowlerList.Count || element.playerScore > bowlerList[i].playerScore)
            {
                bowlerList.Insert(i, element);

                FileData.SaveToSAV<ScoreBowler>(bowlerList, filename);

                if (onHighscoreListChanged != null)
                {
                    onHighscoreListChanged.Invoke(bowlerList);
                }

                break;
            }
        }
        if (bowlerList.Count == 0 || bowlerList.Count >= 1 && element.playerScore <= bowlerList[bowlerList.Count - 1].playerScore)
        {
            bowlerList.Add(element);

            FileData.SaveToSAV<ScoreBowler>(bowlerList, filename);

            if (onHighscoreListChanged != null)
            {
                onHighscoreListChanged.Invoke(bowlerList);
            }
        }
    }

    IEnumerator EmailSend()
    {
        sendingEmail.SetActive(true);
        yield return new WaitForSeconds(3);
        sendingEmail.SetActive(false);
        emailSent.SetActive(true);
        yield return new WaitForSeconds(3);
        emailSent.SetActive(false);
        menuAlleyUI.SetActive(true);
    }

    public void ChargeBall(int chargeBalls)
    {
        ball.ChargeBall(gameManager.chooseBalls[chargeBalls].ballMat, gameManager.chooseBalls[chargeBalls].lbs, gameManager.chooseBalls[chargeBalls].speed, gameManager.chooseBalls[chargeBalls].spin);
    }

    public void RandomChargeBall()
    {
        chargeBallIndex = Random.Range(0, gameManager.chooseBalls.Length);
        ball.ChargeBall(gameManager.chooseBalls[chargeBallIndex].ballMat, gameManager.chooseBalls[chargeBallIndex].lbs, gameManager.chooseBalls[chargeBallIndex].speed, gameManager.chooseBalls[chargeBallIndex].spin);
    }

    public void PrevGutterball1()
    {
        GameManager.voices1--;
        if (GameManager.voices1 < GameManager.Commentators.Baxter)
        {
            GameManager.voices1 = GameManager.Commentators.Master;
        }
        if (GameManager.isVoice)
        {
            OpeningStop();
            commentator.PlayGutterball1(commentatorAudio);
            crowdAudio.Stop();
            commentatorTime = 0;
            commentatorIndex = 0;
            commentatorAudio.Play();
            isCommentator = true;
        }
    }

    public void NextGutterball1()
    {
        GameManager.voices1++;
        if (GameManager.voices1 > GameManager.Commentators.Master)
        {
            GameManager.voices1 = GameManager.Commentators.Baxter;
        }
        if (GameManager.isVoice)
        {
            OpeningStop();
            commentator.PlayGutterball1(commentatorAudio);
            crowdAudio.Stop();
            commentatorTime = 0;
            commentatorIndex = 0;
            commentatorAudio.Play();
            isCommentator = true;
        }
    }

    public void PrevGutterball2()
    {
        GameManager.voices2--;
        if (GameManager.voices2 < GameManager.Commentators.Baxter)
        {
            GameManager.voices2 = GameManager.Commentators.Master;
        }
        if (GameManager.isVoice)
        {
            OpeningStop();
            commentator.PlayGutterball2(commentatorAudio);
            crowdAudio.Stop();
            commentatorTime = 0;
            commentatorIndex = 0;
            commentatorAudio.Play();
            isCommentator = true;
        }
    }

    public void NextGutterball2()
    {
        GameManager.voices2++;
        if (GameManager.voices2 > GameManager.Commentators.Master)
        {
            GameManager.voices2 = GameManager.Commentators.Baxter;
        }
        if (GameManager.isVoice)
        {
            OpeningStop();
            commentator.PlayGutterball2(commentatorAudio);
            crowdAudio.Stop();
            commentatorTime = 0;
            commentatorIndex = 0;
            commentatorAudio.Play();
            isCommentator = true;
        }
    }

    public void PrevQuality()
    {
        gameManager.qualityIndex--;
        if (gameManager.qualityIndex < 0)
        {
            gameManager.qualityIndex = 5;
        }
        QualitySettings.SetQualityLevel(gameManager.qualityIndex);
        PlayerPrefs.SetInt("SaveQuality", gameManager.qualityIndex);
    }

    public void NextQuality()
    {
        gameManager.qualityIndex++;
        if (gameManager.qualityIndex > 5)
        {
            gameManager.qualityIndex = 0;
        }
        QualitySettings.SetQualityLevel(gameManager.qualityIndex);
        PlayerPrefs.SetInt("SaveQuality", gameManager.qualityIndex);
    }

    public void PrevResolution()
    {
        gameManager.resolutionIndex--;
        if (gameManager.resolutionIndex < 0)
        {
            gameManager.resolutionIndex = GameManager.resolutions.Length - 1;
        }
        Screen.SetResolution(GameManager.resolutions[gameManager.resolutionIndex].width, GameManager.resolutions[gameManager.resolutionIndex].height, Screen.fullScreen);
        PlayerPrefs.SetInt("SaveResolution", gameManager.resolutionIndex);
    }

    public void NextResolution()
    {
        gameManager.resolutionIndex++;
        if (gameManager.resolutionIndex > GameManager.resolutions.Length - 1)
        {
            gameManager.resolutionIndex = 0;
        }
        Screen.SetResolution(GameManager.resolutions[gameManager.resolutionIndex].width, GameManager.resolutions[gameManager.resolutionIndex].height, Screen.fullScreen);
        PlayerPrefs.SetInt("SaveResolution", gameManager.resolutionIndex);
    }

    public void TenPin()
    {
        GameManager.pinMode = GameManager.PinMode.Tenpin;
    }

    public void Spare(GameObject setObject)
    {
        if (GameManager.unlockRegister == 0)
        {
            setObject.SetActive(true);
            GameManager.pinMode = GameManager.PinMode.Spare;
        }
        else if (GameManager.unlockRegister == 1)
        {
            registerUI.SetActive(true);
        }
    }

    public void Duckpin(GameObject setObject)
    {
        if (GameManager.unlockRegister == 0)
        {
            setObject.SetActive(true);
            GameManager.pinMode = GameManager.PinMode.Duckpin;
        }
        else if (GameManager.unlockRegister == 1)
        {
            registerUI.SetActive(true);
        }
    }

    public void Candlepin(GameObject setObject)
    {
        if (GameManager.unlockRegister == 0)
        {
            setObject.SetActive(true);
            GameManager.pinMode = GameManager.PinMode.Candlepin;
        }
        else if (GameManager.unlockRegister == 1)
        {
            registerUI.SetActive(true);
        }
    }

    public void PrevAlleys()
    {
        GameManager.chooseAlleys--;
        if (GameManager.chooseAlleys < GameManager.Alley.Retro)
        {
            GameManager.chooseAlleys = GameManager.Alley.Cosmic;
        }
        ChargeAlleys();
        StartChargeBalls();
        AlleyRegister();
        PlayerPrefs.SetInt("ChooseAlleys", (int)GameManager.chooseAlleys);
    }

    public void NextAlleys()
    {
        GameManager.chooseAlleys++;
        if (GameManager.chooseAlleys > GameManager.Alley.Cosmic)
        {
            GameManager.chooseAlleys = GameManager.Alley.Retro;
        }
        ChargeAlleys();
        StartChargeBalls();
        AlleyRegister();
        PlayerPrefs.SetInt("ChooseAlleys", (int)GameManager.chooseAlleys);
    }

    public void PrevBowler()
    {
        if (playerTurn == 0)
        {
            gameManager.turnNameIndex1--;
        }
        else if (playerTurn == 1)
        {
            gameManager.turnNameIndex2--;
        }
        else if (playerTurn == 2)
        {
            gameManager.turnNameIndex3--;
        }
        else if (playerTurn == 3)
        {
            gameManager.turnNameIndex4--;
        }
        if (gameManager.turnNameIndex1 < 0)
        {
            gameManager.turnNameIndex1 = gameManager.bowler.Count - 1;
        }
        else if (gameManager.turnNameIndex2 < 0)
        {
            gameManager.turnNameIndex2 = gameManager.bowler.Count - 1;
        }
        else if (gameManager.turnNameIndex3 < 0)
        {
            gameManager.turnNameIndex3 = gameManager.bowler.Count - 1;
        }
        else if (gameManager.turnNameIndex4 < 0)
        {
            gameManager.turnNameIndex4 = gameManager.bowler.Count - 1;
        }
        PlayerPrefs.SetInt("SavePlayer1", gameManager.turnNameIndex1);
        PlayerPrefs.SetInt("SavePlayer2", gameManager.turnNameIndex2);
        PlayerPrefs.SetInt("SavePlayer3", gameManager.turnNameIndex3);
        PlayerPrefs.SetInt("SavePlayer4", gameManager.turnNameIndex4);
    }

    public void NextBowler()
    {
        if (playerTurn == 0)
        {
            gameManager.turnNameIndex1++;
        }
        else if (playerTurn == 1)
        {
            gameManager.turnNameIndex2++;
        }
        else if (playerTurn == 2)
        {
            gameManager.turnNameIndex3++;
        }
        else if (playerTurn == 3)
        {
            gameManager.turnNameIndex4++;
        }
        if (gameManager.turnNameIndex1 >= gameManager.bowler.Count)
        {
            gameManager.turnNameIndex1 = 0;
        }
        else if (gameManager.turnNameIndex2 >= gameManager.bowler.Count)
        {
            gameManager.turnNameIndex2 = 0;
        }
        else if (gameManager.turnNameIndex3 >= gameManager.bowler.Count)
        {
            gameManager.turnNameIndex3 = 0;
        }
        else if (gameManager.turnNameIndex4 >= gameManager.bowler.Count)
        {
            gameManager.turnNameIndex4 = 0;
        }
        PlayerPrefs.SetInt("SavePlayer1", gameManager.turnNameIndex1);
        PlayerPrefs.SetInt("SavePlayer2", gameManager.turnNameIndex2);
        PlayerPrefs.SetInt("SavePlayer3", gameManager.turnNameIndex3);
        PlayerPrefs.SetInt("SavePlayer4", gameManager.turnNameIndex4);
    }

    public void PrevBalls()
    {
        if (playerTurn == 0)
        {
            gameManager.turnBalls1--;
        }
        else if (playerTurn == 1)
        {
            gameManager.turnBalls2--;
        }
        else if (playerTurn == 2)
        {
            gameManager.turnBalls3--;
        }
        else if (playerTurn == 3)
        {
            gameManager.turnBalls4--;
        }
        else if (playerTurn == 4)
        {
            gameManager.turnBallsCPU--;
        }
        if (GameManager.type != GameManager.GameState.Menu)
        {
            if (gameManager.turnBalls1 < 0)
            {
                if (GameManager.unlockRegister == 0)
                {
                    gameManager.turnBalls1 = gameManager.chooseBalls.Length - 1;
                }
                else if (GameManager.unlockRegister == 1)
                {
                    gameManager.turnBalls1 = 4;
                }
            }
            else if (gameManager.turnBalls2 < 0)
            {
                if (GameManager.unlockRegister == 0)
                {
                    gameManager.turnBalls2 = gameManager.chooseBalls.Length - 1;
                }
                else if (GameManager.unlockRegister == 1)
                {
                    gameManager.turnBalls2 = 4;
                }
            }
            else if (gameManager.turnBalls3 < 0)
            {
                if (GameManager.unlockRegister == 0)
                {
                    gameManager.turnBalls3 = gameManager.chooseBalls.Length - 1;
                }
                else if (GameManager.unlockRegister == 1)
                {
                    gameManager.turnBalls3 = 4;
                }
            }
            else if (gameManager.turnBalls4 < 0)
            {
                if (GameManager.unlockRegister == 0)
                {
                    gameManager.turnBalls4 = gameManager.chooseBalls.Length - 1;
                }
                else if (GameManager.unlockRegister == 1)
                {
                    gameManager.turnBalls4 = 4;
                }
            }
            for (int i = 0; i < gameManager.chooseBalls.Length; i++)
            {
                if (playerTurn == 0 && GameManager.unlockRegister == 0 && gameManager.chooseBalls[gameManager.turnBalls1].isLock == 1)
                {
                    gameManager.turnBalls1 -= gameManager.chooseBalls[i].isLock;
                }
                else if (playerTurn == 1 && GameManager.unlockRegister == 0 && gameManager.chooseBalls[gameManager.turnBalls2].isLock == 1)
                {
                    gameManager.turnBalls2 -= gameManager.chooseBalls[i].isLock;
                }
                else if (playerTurn == 2 && GameManager.unlockRegister == 0 && gameManager.chooseBalls[gameManager.turnBalls3].isLock == 1)
                {
                    gameManager.turnBalls3 -= gameManager.chooseBalls[i].isLock;
                }
                else if (playerTurn == 3 && GameManager.unlockRegister == 0 && gameManager.chooseBalls[gameManager.turnBalls4].isLock == 1)
                {
                    gameManager.turnBalls4 -= gameManager.chooseBalls[i].isLock;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (playerTurn == 0 && GameManager.unlockRegister == 1 && gameManager.chooseBalls[gameManager.turnBalls1].isLock == 1)
                {
                    gameManager.turnBalls1 -= gameManager.chooseBalls[i].isLock;
                }
                else if (playerTurn == 1 && GameManager.unlockRegister == 1 && gameManager.chooseBalls[gameManager.turnBalls2].isLock == 1)
                {
                    gameManager.turnBalls2 -= gameManager.chooseBalls[i].isLock;
                }
                else if (playerTurn == 2 && GameManager.unlockRegister == 1 && gameManager.chooseBalls[gameManager.turnBalls3].isLock == 1)
                {
                    gameManager.turnBalls3 -= gameManager.chooseBalls[i].isLock;
                }
                else if (playerTurn == 3 && GameManager.unlockRegister == 1 && gameManager.chooseBalls[gameManager.turnBalls4].isLock == 1)
                {
                    gameManager.turnBalls4 -= gameManager.chooseBalls[i].isLock;
                }
            }
        }
        else
        {
            if (gameManager.turnBalls1 < 0)
            {
                gameManager.turnBalls1 = gameManager.chooseBalls.Length - 1;
            }
            else if (gameManager.turnBalls2 < 0)
            {
                gameManager.turnBalls2 = gameManager.chooseBalls.Length - 1;
            }
            else if (gameManager.turnBalls3 < 0)
            {
                gameManager.turnBalls3 = gameManager.chooseBalls.Length - 1;
            }
            else if (gameManager.turnBalls4 < 0)
            {
                gameManager.turnBalls4 = gameManager.chooseBalls.Length - 1;
            }
            else if (gameManager.turnBallsCPU < 0)
            {
                gameManager.turnBallsCPU = gameManager.compuObj.Length - 1;
            }
        }
    }

    public void NextBalls()
    {
        if (playerTurn == 0)
        {
            gameManager.turnBalls1++;
        }
        else if (playerTurn == 1)
        {
            gameManager.turnBalls2++;
        }
        else if (playerTurn == 2)
        {
            gameManager.turnBalls3++;
        }
        else if (playerTurn == 3)
        {
            gameManager.turnBalls4++;
        }
        else if (playerTurn == 4)
        {
            gameManager.turnBallsCPU++;
        }
        if (GameManager.type != GameManager.GameState.Menu)
        {
            if (gameManager.turnBalls1 >= gameManager.chooseBalls.Length || gameManager.turnBalls1 >= 5 && GameManager.unlockRegister == 1)
            {
                gameManager.turnBalls1 = 0;
            }
            else if (gameManager.turnBalls2 >= gameManager.chooseBalls.Length || gameManager.turnBalls2 >= 5 && GameManager.unlockRegister == 1)
            {
                gameManager.turnBalls2 = 0;
            }
            else if (gameManager.turnBalls3 >= gameManager.chooseBalls.Length || gameManager.turnBalls3 >= 5 && GameManager.unlockRegister == 1)
            {
                gameManager.turnBalls3 = 0;
            }
            else if (gameManager.turnBalls4 >= gameManager.chooseBalls.Length || gameManager.turnBalls4 >= 5 && GameManager.unlockRegister == 1)
            {
                gameManager.turnBalls4 = 0;
            }
            for (int i = 0; i < gameManager.chooseBalls.Length; i++)
            {
                if (playerTurn == 0 && gameManager.chooseBalls[gameManager.turnBalls1].isLock == 1)
                {
                    gameManager.turnBalls1 += gameManager.chooseBalls[i].isLock;
                }
                else if (playerTurn == 1 && gameManager.chooseBalls[gameManager.turnBalls2].isLock == 1)
                {
                    gameManager.turnBalls2 += gameManager.chooseBalls[i].isLock;
                }
                else if (playerTurn == 2 && gameManager.chooseBalls[gameManager.turnBalls3].isLock == 1)
                {
                    gameManager.turnBalls3 += gameManager.chooseBalls[i].isLock;
                }
                else if (playerTurn == 3 && gameManager.chooseBalls[gameManager.turnBalls4].isLock == 1)
                {
                    gameManager.turnBalls4 += gameManager.chooseBalls[i].isLock;
                }
                if (gameManager.turnBalls1 >= gameManager.chooseBalls.Length || gameManager.turnBalls1 >= 5 && GameManager.unlockRegister == 1)
                {
                    gameManager.turnBalls1 = 0;
                }
                else if (gameManager.turnBalls2 >= gameManager.chooseBalls.Length || gameManager.turnBalls2 >= 5 && GameManager.unlockRegister == 1)
                {
                    gameManager.turnBalls2 = 0;
                }
                else if (gameManager.turnBalls3 >= gameManager.chooseBalls.Length || gameManager.turnBalls3 >= 5 && GameManager.unlockRegister == 1)
                {
                    gameManager.turnBalls3 = 0;
                }
                else if (gameManager.turnBalls4 >= gameManager.chooseBalls.Length || gameManager.turnBalls4 >= 5 && GameManager.unlockRegister == 1)
                {
                    gameManager.turnBalls4 = 0;
                }
            }
        }
        else
        {
            if (gameManager.turnBalls1 >= gameManager.chooseBalls.Length)
            {
                gameManager.turnBalls1 = 0;
            }
            else if (gameManager.turnBalls2 >= gameManager.chooseBalls.Length)
            {
                gameManager.turnBalls2 = 0;
            }
            else if (gameManager.turnBalls3 >= gameManager.chooseBalls.Length)
            {
                gameManager.turnBalls3 = 0;
            }
            else if (gameManager.turnBalls4 >= gameManager.chooseBalls.Length)
            {
                gameManager.turnBalls4 = 0;
            }
            else if (gameManager.turnBallsCPU >= gameManager.compuObj.Length)
            {
                gameManager.turnBallsCPU = 0;
            }
        }
    }

    public void SetPlayer(int playerBalls)
    {
        playerTurn = playerBalls;
    }

    public void SetMusic(bool isMusic)
    {
        GameManager.isMusic = isMusic;
        PlayerPrefs.SetInt("SaveMusic", (isMusic ? 0 : 1));
    }

    public void SetSound(bool isSound)
    {
        GameManager.isSound = isSound;
        PlayerPrefs.SetInt("SaveSound", (isSound ? 0 : 1));
    }

    public void SetCrowd(bool isCrowd)
    {
        GameManager.isCrowd = isCrowd;
        PlayerPrefs.SetInt("SaveCrowd", (isCrowd ? 0 : 1));
    }

    public void SetVoice(bool isVoice)
    {
        GameManager.isVoice = isVoice;
        PlayerPrefs.SetInt("SaveVoice", (isVoice ? 0 : 1));
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetChars(bool isChars)
    {
        GameManager.isChars = isChars;
        PlayerPrefs.SetInt("SaveChars", (isChars ? 0 : 1));
    }

    public void SetParticle(bool isParticle)
    {
        GameManager.isParticle = isParticle;
        PlayerPrefs.SetInt("SaveParticle", (isParticle ? 0 : 1));
    }

    public void SetReflect(bool isReflect)
    {
        GameManager.isReflect = isReflect;
        PlayerPrefs.SetInt("SaveReflect", (isReflect ? 0 : 1));
    }

    public void SetWeather(bool isWeather)
    {
        GameManager.isWeather = isWeather;
        PlayerPrefs.SetInt("SaveWeather", (isWeather ? 0 : 1));
    }

    public void SetShake(bool isShake)
    {
        GameManager.isShake = isShake;
        PlayerPrefs.SetInt("SaveShake", (isShake ? 0 : 1));
    }

    public void SetAlwaysBowl(bool isAlwaysBowl)
    {
        for (int i = 0; i < nextButton.Length; i++)
        {
            nextButton[i].GetComponent<Button>().interactable = isAlwaysBowl;
        }
        for (int i = 0; i < bowlButton.Length; i++)
        {
            bowlButton[i].GetComponent<Button>().interactable = isAlwaysBowl;
        }
    }

    public void SetAlwaysBowlReg(bool isAlwaysReg)
    {
        for (int i = 0; i < nextButton.Length; i++)
        {
            nextButton[i].SetActive(isAlwaysReg);
        }
        for (int i = 0; i < bowlButton.Length; i++)
        {
            bowlButton[i].SetActive(isAlwaysReg);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpeningStop()
    {
        if (GameManager.isOpening)
        {
            opening.Stop();
            music.Play();
            GameManager.isOpening = false;
        }
    }

    public void AudioStop()
    {
        opening.Stop();
        music.Stop();
        GameManager.isOpening = false;
        foreach (GameObject sound in sounds)
        {
            sound.GetComponent<AudioSource>().Stop();
        }
    }

    public void HideAlleyScores()
    {
        alleyScores[0].SetActive(false);
        alleyScores[1].SetActive(false);
        alleyScores[2].SetActive(false);
        alleyScores[3].SetActive(false);
        alleyScores[4].SetActive(false);
        alleyScores[5].SetActive(false);
        alleyScores[6].SetActive(false);
        alleyScores[7].SetActive(false);
    }

    public void ShowAlleyScores()
    {
        switch (GameManager.chooseAlleys)
        {
            case GameManager.Alley.Retro:
                alleyScores[0].SetActive(true);
                break;
            case GameManager.Alley.Wacky:
                alleyScores[1].SetActive(true);
                break;
            case GameManager.Alley.Iceberg:
                alleyScores[2].SetActive(true);
                break;
            case GameManager.Alley.Jungle:
                alleyScores[3].SetActive(true);
                break;
            case GameManager.Alley.Zen:
                alleyScores[4].SetActive(true);
                break;
            case GameManager.Alley.Cosmic:
                alleyScores[5].SetActive(true);
                break;
            case GameManager.Alley.Barnyard:
                alleyScores[6].SetActive(true);
                break;
            case GameManager.Alley.Mineshaft:
                alleyScores[7].SetActive(true);
                break;
        }
    }

    public void PlayerOne()
    {
        playerTurn = 0;
        GameManager.allPlayers = GameManager.Players.OnePlayer;
    }

    public void PlayerTwo()
    {
        playerTurn = 0;
        GameManager.allPlayers = GameManager.Players.TwoPlayer;
    }

    public void PlayerThree()
    {
        playerTurn = 0;
        GameManager.allPlayers = GameManager.Players.ThreePlayer;
    }

    public void PlayerFour()
    {
        playerTurn = 0;
        GameManager.allPlayers = GameManager.Players.FourPlayer;
    }

    public void PlayerComputer()
    {
        playerTurn = 0;
        GameManager.allPlayers = GameManager.Players.Computer;
    }

    public void ChargeAlleys()
    {
        switch (GameManager.chooseAlleys)
        {
            case GameManager.Alley.Retro:
                GameManager.voices1 = GameManager.Commentators.Maria;
                GameManager.voices2 = GameManager.Commentators.Jensen;
                GameManager.alleyLockType = GameManager.Alley.Retro;
                break;
            case GameManager.Alley.Wacky:
                GameManager.voices1 = GameManager.Commentators.Baxter;
                GameManager.voices2 = GameManager.Commentators.Maria;
                GameManager.alleyLockType = GameManager.Alley.Cosmic;
                break;
            case GameManager.Alley.Iceberg:
                GameManager.voices1 = GameManager.Commentators.Natasha;
                GameManager.voices2 = GameManager.Commentators.Jensen;
                GameManager.alleyLockType = GameManager.Alley.Barnyard;
                break;
            case GameManager.Alley.Jungle:
                GameManager.voices1 = GameManager.Commentators.Jensen;
                GameManager.voices2 = GameManager.Commentators.Master;
                GameManager.alleyLockType = GameManager.Alley.Mineshaft;
                break;
            case GameManager.Alley.Zen:
                GameManager.voices1 = GameManager.Commentators.Master;
                GameManager.voices2 = GameManager.Commentators.Natasha;
                GameManager.alleyLockType = GameManager.Alley.Retro;
                break;
            case GameManager.Alley.Cosmic:
                GameManager.voices1 = GameManager.Commentators.Master;
                GameManager.voices2 = GameManager.Commentators.Baxter;
                lockAlleyText.text = "Score 200 in Wacky to Unlock";
                break;
            case GameManager.Alley.Barnyard:
                GameManager.voices1 = GameManager.Commentators.Jensen;
                GameManager.voices2 = GameManager.Commentators.Natasha;
                lockAlleyText.text = "Score 200 in Iceberg to Unlock";
                break;
            case GameManager.Alley.Mineshaft:
                GameManager.voices1 = GameManager.Commentators.Baxter;
                GameManager.voices2 = GameManager.Commentators.Jensen;
                lockAlleyText.text = "Score 200 in Jungle to Unlock";
                break;
        }
    }

    public void StartChargeBalls()
    {
        switch (GameManager.chooseAlleys)
        {
            case GameManager.Alley.Retro:
                gameManager.turnBalls1 = 0;
                gameManager.turnBalls2 = 1;
                gameManager.turnBalls3 = 2;
                gameManager.turnBalls4 = 3;
                gameManager.turnBallsCPU = 0;
                break;
            case GameManager.Alley.Wacky:
                gameManager.turnBalls1 = 5;
                gameManager.turnBalls2 = 6;
                gameManager.turnBalls3 = 7;
                gameManager.turnBalls4 = 8;
                gameManager.turnBallsCPU = 2;
                break;
            case GameManager.Alley.Iceberg:
                gameManager.turnBalls1 = 10;
                gameManager.turnBalls2 = 11;
                gameManager.turnBalls3 = 12;
                gameManager.turnBalls4 = 13;
                gameManager.turnBallsCPU = 4;
                break;
            case GameManager.Alley.Jungle:
                gameManager.turnBalls1 = 15;
                gameManager.turnBalls2 = 16;
                gameManager.turnBalls3 = 17;
                gameManager.turnBalls4 = 18;
                gameManager.turnBallsCPU = 6;
                break;
            case GameManager.Alley.Zen:
                gameManager.turnBalls1 = 20;
                gameManager.turnBalls2 = 21;
                gameManager.turnBalls3 = 22;
                gameManager.turnBalls4 = 23;
                gameManager.turnBallsCPU = 8;
                break;
            case GameManager.Alley.Cosmic:
                gameManager.turnBalls1 = 25;
                gameManager.turnBalls2 = 26;
                gameManager.turnBalls3 = 27;
                gameManager.turnBalls4 = 28;
                gameManager.turnBallsCPU = 10;
                break;
            case GameManager.Alley.Barnyard:
                gameManager.turnBalls1 = 30;
                gameManager.turnBalls2 = 31;
                gameManager.turnBalls3 = 32;
                gameManager.turnBalls4 = 33;
                gameManager.turnBallsCPU = 12;
                break;
            case GameManager.Alley.Mineshaft:
                gameManager.turnBalls1 = 35;
                gameManager.turnBalls2 = 36;
                gameManager.turnBalls3 = 37;
                gameManager.turnBalls4 = 38;
                gameManager.turnBallsCPU = 14;
                break;
        }
    }

    public void AlleyRegister()
    {
        if (gameManager.isLockAlleys[(int)GameManager.chooseAlleys] == 0 && GameManager.unlockRegister == 0)
        {
            alleyRegistered.SetActive(false);
            startButton.SetActive(true);
            menuRegisterButton.SetActive(false);
            startButton.GetComponent<Button>().interactable = true;
            lockAlleyUI.SetActive(false);
            unlockAlleyUI.SetActive(false);
        }
        else if (gameManager.isLockAlleys[(int)GameManager.chooseAlleys] == 1 && GameManager.unlockRegister == 0)
        {
            alleyRegistered.SetActive(false);
            startButton.SetActive(true);
            menuRegisterButton.SetActive(false);
            startButton.GetComponent<Button>().interactable = false;
            unlockAlleyUI.SetActive(false);
            lockAlleyUI.SetActive(true);
        }
        else if (gameManager.isLockAlleys[(int)GameManager.chooseAlleys] == 2 && GameManager.unlockRegister == 0)
        {
            alleyRegistered.SetActive(false);
            startButton.SetActive(true);
            menuRegisterButton.SetActive(false);
            startButton.GetComponent<Button>().interactable = true;
            lockAlleyUI.SetActive(false);
            unlockAlleyUI.SetActive(true);
        }
        if ((int)GameManager.chooseAlleys == 0 && GameManager.unlockRegister == 1)
        {
            alleyRegistered.SetActive(false);
            startButton.SetActive(true);
            menuRegisterButton.SetActive(false);
        }
        else if ((int)GameManager.chooseAlleys >= 1 && GameManager.unlockRegister == 1)
        {
            alleyRegistered.SetActive(true);
            startButton.SetActive(false);
            menuRegisterButton.SetActive(true);
        }
    }

    public void UnlockRegister()
    {
        for (int i = 0; i < gameManager.serialKeys.Length; i++)
        {
            if (keyField.text != gameManager.serialKeys[i])
            {
                registerComplete.SetActive(false);
                registerFail.SetActive(true);
            }
            else
            {
                GameManager.unlockRegister = 0;
                PlayerPrefs.SetInt("UnlockRegister", GameManager.unlockRegister);
                registerFail.SetActive(false);
                registerComplete.SetActive(true);
            }
        }
        AlleyRegister();
    }

    public void GoBackMenu()
    {
        if (GameManager.isHighScore)
        {
            highScoreUI.SetActive(true);
            ShowAlleyScores();
        }
        else
        {
            menuAlleyUI.SetActive(true);
        }
        GameManager.isHighScore = false;
    }

    public void CancelBowlerToList()
    {
        bowlerField.text = "";
    }

    public void AddBowlerToList()
    {
        if (bowlerField.text != "")
        {
            gameManager.bowler.Add(new PlayerObj(bowlerField.text, 0, 0, 0, 0, 0, 0));
            GameObject element = Instantiate(bowlerUIElement, bowlerWrapper) as GameObject;
            element.GetComponent<BowlerUI>().BowlerUpdate(bowlerField.text, 0, 0, 0, 0, 0, 0);
        }
        bowlerField.text = "";
        FileData.SaveToSAV<PlayerObj>(gameManager.bowler, "SaveBowler");
    }

    public void CustomBall()
    {
        if (playerTurn == 0)
        {
            customBallNameField.text = PlayerPrefs.GetString("CustomBallName" + gameManager.turnBalls1, gameManager.chooseBalls[gameManager.turnBalls1].ballName);
            customBallLbs.value = PlayerPrefs.GetInt("CustomBallLbs" + gameManager.turnBalls1, gameManager.chooseBalls[gameManager.turnBalls1].lbs);
            customBallSpeed.value = PlayerPrefs.GetInt("CustomBallSpeed" + gameManager.turnBalls1, gameManager.chooseBalls[gameManager.turnBalls1].speed);
            customBallSpin.value = PlayerPrefs.GetInt("CustomBallSpin" + gameManager.turnBalls1, gameManager.chooseBalls[gameManager.turnBalls1].spin);
            customBallFileField.text = PlayerPrefs.GetString("CustomBallURL" + gameManager.turnBalls1, gameManager.chooseBalls[gameManager.turnBalls1].urlTextureBall);
        }
        else if (playerTurn == 1)
        {
            customBallNameField.text = PlayerPrefs.GetString("CustomBallName" + gameManager.turnBalls2, gameManager.chooseBalls[gameManager.turnBalls2].ballName);
            customBallLbs.value = PlayerPrefs.GetInt("CustomBallLbs" + gameManager.turnBalls2, gameManager.chooseBalls[gameManager.turnBalls2].lbs);
            customBallSpeed.value = PlayerPrefs.GetInt("CustomBallSpeed" + gameManager.turnBalls2, gameManager.chooseBalls[gameManager.turnBalls2].speed);
            customBallSpin.value = PlayerPrefs.GetInt("CustomBallSpin" + gameManager.turnBalls2, gameManager.chooseBalls[gameManager.turnBalls2].spin);
            customBallFileField.text = PlayerPrefs.GetString("CustomBallURL" + gameManager.turnBalls2, gameManager.chooseBalls[gameManager.turnBalls2].urlTextureBall);
        }
        else if (playerTurn == 2)
        {
            customBallNameField.text = PlayerPrefs.GetString("CustomBallName" + gameManager.turnBalls3, gameManager.chooseBalls[gameManager.turnBalls3].ballName);
            customBallLbs.value = PlayerPrefs.GetInt("CustomBallLbs" + gameManager.turnBalls3, gameManager.chooseBalls[gameManager.turnBalls3].lbs);
            customBallSpeed.value = PlayerPrefs.GetInt("CustomBallSpeed" + gameManager.turnBalls3, gameManager.chooseBalls[gameManager.turnBalls3].speed);
            customBallSpin.value = PlayerPrefs.GetInt("CustomBallSpin" + gameManager.turnBalls3, gameManager.chooseBalls[gameManager.turnBalls3].spin);
            customBallFileField.text = PlayerPrefs.GetString("CustomBallURL" + gameManager.turnBalls3, gameManager.chooseBalls[gameManager.turnBalls3].urlTextureBall);
        }
        else if (playerTurn == 3)
        {
            customBallNameField.text = PlayerPrefs.GetString("CustomBallName" + gameManager.turnBalls4, gameManager.chooseBalls[gameManager.turnBalls4].ballName);
            customBallLbs.value = PlayerPrefs.GetInt("CustomBallLbs" + gameManager.turnBalls4, gameManager.chooseBalls[gameManager.turnBalls4].lbs);
            customBallSpeed.value = PlayerPrefs.GetInt("CustomBallSpeed" + gameManager.turnBalls4, gameManager.chooseBalls[gameManager.turnBalls4].speed);
            customBallSpin.value = PlayerPrefs.GetInt("CustomBallSpin" + gameManager.turnBalls4, gameManager.chooseBalls[gameManager.turnBalls4].spin);
            customBallFileField.text = PlayerPrefs.GetString("CustomBallURL" + gameManager.turnBalls4, gameManager.chooseBalls[gameManager.turnBalls4].urlTextureBall);
        }
        else if (playerTurn == 4)
        {
            customBallNameField.text = PlayerPrefs.GetString("CustomBallName" + gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex, gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].ballName);
            customBallLbs.value = PlayerPrefs.GetInt("CustomBallLbs" + gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex, gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].lbs);
            customBallSpeed.value = PlayerPrefs.GetInt("CustomBallSpeed" + gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex, gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].speed);
            customBallSpin.value = PlayerPrefs.GetInt("CustomBallSpin" + gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex, gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].spin);
            customBallFileField.text = PlayerPrefs.GetString("CustomBallURL" + gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex, gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].urlTextureBall);
        }
    }

    public void ApplyCustomBall()
    {
        if (playerTurn == 0)
        {
            gameManager.chooseBalls[gameManager.turnBalls1].ballName = customBallNameField.text;
            gameManager.chooseBalls[gameManager.turnBalls1].lbs = (int)customBallLbs.value;
            gameManager.chooseBalls[gameManager.turnBalls1].speed = (int)customBallSpeed.value;
            gameManager.chooseBalls[gameManager.turnBalls1].spin = (int)customBallSpin.value;
            gameManager.chooseBalls[gameManager.turnBalls1].urlTextureBall = customBallFileField.text;
            PlayerPrefs.SetString("CustomBallName" + gameManager.turnBalls1, gameManager.chooseBalls[gameManager.turnBalls1].ballName);
            PlayerPrefs.SetInt("CustomBallLbs" + gameManager.turnBalls1, gameManager.chooseBalls[gameManager.turnBalls1].lbs);
            PlayerPrefs.SetInt("CustomBallSpeed" + gameManager.turnBalls1, gameManager.chooseBalls[gameManager.turnBalls1].speed);
            PlayerPrefs.SetInt("CustomBallSpin" + gameManager.turnBalls1, gameManager.chooseBalls[gameManager.turnBalls1].spin);
            PlayerPrefs.SetString("CustomBallURL" + gameManager.turnBalls1, gameManager.chooseBalls[gameManager.turnBalls1].urlTextureBall);
            StartCoroutine(gameManager.DownloadTexture(customBallFileField.text, gameManager.chooseBalls[gameManager.turnBalls1].ballMat));
        }
        else if (playerTurn == 1)
        {
            gameManager.chooseBalls[gameManager.turnBalls2].ballName = customBallNameField.text;
            gameManager.chooseBalls[gameManager.turnBalls2].lbs = (int)customBallLbs.value;
            gameManager.chooseBalls[gameManager.turnBalls2].speed = (int)customBallSpeed.value;
            gameManager.chooseBalls[gameManager.turnBalls2].spin = (int)customBallSpin.value;
            gameManager.chooseBalls[gameManager.turnBalls2].urlTextureBall = customBallFileField.text;
            PlayerPrefs.SetString("CustomBallName" + gameManager.turnBalls2, gameManager.chooseBalls[gameManager.turnBalls2].ballName);
            PlayerPrefs.SetInt("CustomBallLbs" + gameManager.turnBalls2, gameManager.chooseBalls[gameManager.turnBalls2].lbs);
            PlayerPrefs.SetInt("CustomBallSpeed" + gameManager.turnBalls2, gameManager.chooseBalls[gameManager.turnBalls2].speed);
            PlayerPrefs.SetInt("CustomBallSpin" + gameManager.turnBalls2, gameManager.chooseBalls[gameManager.turnBalls2].spin);
            PlayerPrefs.SetString("CustomBallURL" + gameManager.turnBalls2, gameManager.chooseBalls[gameManager.turnBalls2].urlTextureBall);
            StartCoroutine(gameManager.DownloadTexture(customBallFileField.text, gameManager.chooseBalls[gameManager.turnBalls2].ballMat));
        }
        else if (playerTurn == 2)
        {
            gameManager.chooseBalls[gameManager.turnBalls3].ballName = customBallNameField.text;
            gameManager.chooseBalls[gameManager.turnBalls3].lbs = (int)customBallLbs.value;
            gameManager.chooseBalls[gameManager.turnBalls3].speed = (int)customBallSpeed.value;
            gameManager.chooseBalls[gameManager.turnBalls3].spin = (int)customBallSpin.value;
            gameManager.chooseBalls[gameManager.turnBalls3].urlTextureBall = customBallFileField.text;
            PlayerPrefs.SetString("CustomBallName" + gameManager.turnBalls3, gameManager.chooseBalls[gameManager.turnBalls3].ballName);
            PlayerPrefs.SetInt("CustomBallLbs" + gameManager.turnBalls3, gameManager.chooseBalls[gameManager.turnBalls3].lbs);
            PlayerPrefs.SetInt("CustomBallSpeed" + gameManager.turnBalls3, gameManager.chooseBalls[gameManager.turnBalls3].speed);
            PlayerPrefs.SetInt("CustomBallSpin" + gameManager.turnBalls3, gameManager.chooseBalls[gameManager.turnBalls3].spin);
            PlayerPrefs.SetString("CustomBallURL" + gameManager.turnBalls3, gameManager.chooseBalls[gameManager.turnBalls3].urlTextureBall);
            StartCoroutine(gameManager.DownloadTexture(customBallFileField.text, gameManager.chooseBalls[gameManager.turnBalls3].ballMat));
        }
        else if (playerTurn == 3)
        {
            gameManager.chooseBalls[gameManager.turnBalls4].ballName = customBallNameField.text;
            gameManager.chooseBalls[gameManager.turnBalls4].lbs = (int)customBallLbs.value;
            gameManager.chooseBalls[gameManager.turnBalls4].speed = (int)customBallSpeed.value;
            gameManager.chooseBalls[gameManager.turnBalls4].spin = (int)customBallSpin.value;
            gameManager.chooseBalls[gameManager.turnBalls4].urlTextureBall = customBallFileField.text;
            PlayerPrefs.SetString("CustomBallName" + gameManager.turnBalls4, gameManager.chooseBalls[gameManager.turnBalls4].ballName);
            PlayerPrefs.SetInt("CustomBallLbs" + gameManager.turnBalls4, gameManager.chooseBalls[gameManager.turnBalls4].lbs);
            PlayerPrefs.SetInt("CustomBallSpeed" + gameManager.turnBalls4, gameManager.chooseBalls[gameManager.turnBalls4].speed);
            PlayerPrefs.SetInt("CustomBallSpin" + gameManager.turnBalls4, gameManager.chooseBalls[gameManager.turnBalls4].spin);
            PlayerPrefs.SetString("CustomBallURL" + gameManager.turnBalls4, gameManager.chooseBalls[gameManager.turnBalls4].urlTextureBall);
            StartCoroutine(gameManager.DownloadTexture(customBallFileField.text, gameManager.chooseBalls[gameManager.turnBalls4].ballMat));
        }
        else if (playerTurn == 4)
        {
            gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].ballName = customBallNameField.text;
            gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].lbs = (int)customBallLbs.value;
            gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].speed = (int)customBallSpeed.value;
            gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].spin = (int)customBallSpin.value;
            gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].urlTextureBall = customBallFileField.text;
            PlayerPrefs.SetString("CustomBallName" + gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex, gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].ballName);
            PlayerPrefs.SetInt("CustomBallLbs" + gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex, gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].lbs);
            PlayerPrefs.SetInt("CustomBallSpeed" + gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex, gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].speed);
            PlayerPrefs.SetInt("CustomBallSpin" + gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex, gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].spin);
            PlayerPrefs.SetString("CustomBallURL" + gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex, gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].urlTextureBall);
            StartCoroutine(gameManager.DownloadTexture(customBallFileField.text, gameManager.chooseBalls[gameManager.compuObj[gameManager.turnBallsCPU].cpuIndex].ballMat));
        }
    }

    public void CancelFileInfo()
    {
        infoFileField.text = "";
    }

    public void AddFileInfo()
    {
        if (infoFileField.text != "")
        {
            gameManager.urlInfoScreen.Add(infoFileField.text);
        }
        infoFileField.text = "";
        FileData.SaveToSAV<string>(gameManager.urlInfoScreen, "InfoURL");
    }

    public void ClickAudio()
    {
        if (GameManager.isSound)
        {
            GameObject.Find("UIClick").GetComponent<AudioSource>().Play();
        }
    }

    public void CodeAudio()
    {
        if (GameManager.isSound)
        {
            GameObject.Find("UICode").GetComponent<AudioSource>().Play();
        }
    }

    IEnumerator FireworksPop()
    {
        yield return new WaitForSeconds(Random.Range(0.1f, 0.75f));
        while (true)
        {
            GameObject pop = Instantiate(fireworks, new Vector3(Random.Range(-512, 512), Random.Range(-256, 256), 5000), Quaternion.identity) as GameObject;
            var main = pop.GetComponent<ParticleSystem>().main;
            main.startColor = pop.GetComponent<Fireworks>().colorFireworks[Random.Range(0, pop.GetComponent<Fireworks>().colorFireworks.Length)];
            yield return new WaitForSeconds(Random.Range(0.1f, 0.75f));
        }
    }
}
