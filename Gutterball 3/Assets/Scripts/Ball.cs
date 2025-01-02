using UnityEngine;

public class Ball : MonoBehaviour
{
    public enum BallType { MoveX, ThrowBall, SpinBall, FallBall }
    public BallType type;
    [Range(8, 16)]
    public int lbs = 12;
    [Range(10, 100)]
    public int speed = 55;
    [Range(0, 100)]
    public int spin = 50;
    public AudioSource throwAudio;
    public AudioSource rollAudio;
    public AudioSource gutterAudio;
    public AudioSource netAudio;
    public AudioSource pinAudio;
    public AudioSource splashAudio;
    public AudioClip[] tubSplashs;
    public Game game;
    public GameObject hit;
    public GameObject splash;
    public CameraFollow cameraFollow;
    public BoxCollider roll;
    public BoxCollider replay;
    public Camera spinUI;
    public bool isGutter = false;
    public bool isGutterAnimation = false;
    public bool isGutterAnimation2X = false;
    public GameObject controlArrow;
    public Renderer meshBall;

    private Vector2 moveMouse;
    private Vector2 direction;
    private bool isMoveY = false;
    private bool isThrow = false;
    private bool isNet = false;
    private bool isBackWall = false;
    private bool isSplash;
    private Vector3 spinStart;
    private Vector3 spinEnd;
    private Rigidbody rigidBody;
    private ConstantForce force;

    // Use this for initialization
    void Start ()
    {
        splashAudio = GameObject.Find("Splash").GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.mass = lbs;
        force = GetComponent<ConstantForce>();
    }

    // Update is called once per frame
    void Update ()
    {
        spinStart = Input.mousePosition;
        spinEnd = spinUI.ScreenToWorldPoint(spinStart);

        direction = new Vector2(spinEnd.x, spinEnd.y);

        controlArrow.transform.up = direction;
        controlArrow.transform.rotation = new Quaternion(0, 0, Mathf.Clamp(controlArrow.transform.rotation.z, -90, 90), 1);
        if (type == BallType.MoveX && GameManager.type == GameManager.GameState.Game && !game.isComputer && !isMoveY)
        {
            moveMouse = direction;
        }
        if (type == BallType.MoveX && GameManager.type == GameManager.GameState.Game && spinEnd.x <= -75 && spinEnd.x >= -150 && spinEnd.y > -125 && !game.isComputer && !isMoveY)
        {
            transform.Translate(30 * Time.deltaTime, 0, 0, Space.World);
        }
        if (type == BallType.MoveX && GameManager.type == GameManager.GameState.Game && spinEnd.x >= 75 && spinEnd.x <= 150 && spinEnd.y > -125 && !game.isComputer && !isMoveY)
        {
            transform.Translate(-30 * Time.deltaTime, 0, 0, Space.World);
        }
        if (type == BallType.MoveX && GameManager.type == GameManager.GameState.Game && spinEnd.x <= 150 && spinEnd.y > -125 && !game.isComputer && !isMoveY)
        {
            transform.Translate(60 * Time.deltaTime, 0, 0, Space.World);
        }
        if (type == BallType.MoveX && GameManager.type == GameManager.GameState.Game && spinEnd.x >= -150 && spinEnd.y > -125 && !game.isComputer && !isMoveY)
        {
            transform.Translate(-60 * Time.deltaTime, 0, 0, Space.World);
        }
        if (type == BallType.MoveX && GameManager.type == GameManager.GameState.Game && !game.isComputer)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -120, 120), transform.position.y, transform.position.z);
        }
        if (transform.position.z < GameObject.FindObjectOfType<PinSetter>().ballPos.z && type == BallType.MoveX && GameManager.type == GameManager.GameState.Game && !game.isComputer)
        {
            isThrow = true;
        }
        if (isMoveY && type == BallType.MoveX && GameManager.type == GameManager.GameState.Game && !game.isComputer)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, GameObject.FindObjectOfType<PinSetter>().ballPos.z + moveMouse.y - direction.y);
        }
        if (type == BallType.SpinBall && GameManager.type == GameManager.GameState.Game && !game.isComputer)
        {
            rigidBody.AddForce(-spinEnd.x * spin * rigidBody.mass * 6f * Time.deltaTime, 0, 0);
            rigidBody.AddTorque(0, 0, spinEnd.x * spin * rigidBody.mass * 30f * Time.deltaTime);
        }
        if (isGutter)
        {
            rigidBody.AddForce(0, 0, -rigidBody.mass * 6000);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Lane" && type == BallType.ThrowBall && !game.isComputer && GameManager.type == GameManager.GameState.Game)
        {
            controlArrow.SetActive(true);
        }
        if (collision.gameObject.tag == "Lane" && type == BallType.ThrowBall)
        {
            rollAudio.Play();
            isGutter = false;
            game.isPin = false;
            roll.enabled = true;
            replay.enabled = true;
            type = BallType.SpinBall;
            cameraFollow.type = CameraFollow.CameraType.FollowBall;
            if (GameObject.FindObjectOfType<PinSetter>().gutter != null)
            {
                GameObject.FindObjectOfType<PinSetter>().gutter.enabled = true;
            }
        }

        if (collision.gameObject.tag == "Pin" && collision.relativeVelocity.magnitude > rigidBody.mass * 15 && !game.isPin && !isBackWall)
        {
            rollAudio.Stop();
            gutterAudio.Stop();
            isSplash = GameObject.FindObjectOfType<PinSetter>().isSplash;
            game.isReplay = true;
            controlArrow.SetActive(false);
            if (GameManager.isParticle)
            {
                Instantiate(hit, collision.transform.position, Quaternion.identity);
            }
            if (PinCounter.pinCount == 1 || collision.gameObject.GetComponent<Pin>().isHitOne)
            {
                GameObject.FindObjectOfType<CameraShake>().Shake(1);
                pinAudio.clip = game.bowling1;
            }
            else if (PinCounter.pinCount == 2 && !collision.gameObject.GetComponent<Pin>().isHitOne || PinCounter.pinCount == 3 && !collision.gameObject.GetComponent<Pin>().isHitOne)
            {
                GameObject.FindObjectOfType<CameraShake>().Shake(2);
                pinAudio.clip = game.bowling2;
            }
            else if (PinCounter.pinCount == 4 && !collision.gameObject.GetComponent<Pin>().isHitOne || PinCounter.pinCount == 5 && !collision.gameObject.GetComponent<Pin>().isHitOne)
            {
                GameObject.FindObjectOfType<CameraShake>().Shake(4);
                pinAudio.clip = game.bowling4;
            }
            else if (PinCounter.pinCount == 6 && !collision.gameObject.GetComponent<Pin>().isHitOne || PinCounter.pinCount == 7 && !collision.gameObject.GetComponent<Pin>().isHitOne || PinCounter.pinCount == 8 && !collision.gameObject.GetComponent<Pin>().isHitOne)
            {
                GameObject.FindObjectOfType<CameraShake>().Shake(10);
                pinAudio.clip = game.bowling10;
            }
            else if (PinCounter.pinCount == 9 && !collision.gameObject.GetComponent<Pin>().isHitOne || PinCounter.pinCount == 10 && !collision.gameObject.GetComponent<Pin>().isHitOne)
            {
                GameObject.FindObjectOfType<CameraShake>().Shake(6);
                pinAudio.clip = game.bowling6;
            }
            pinAudio.Play();
            if (!GameObject.FindObjectOfType<PinSetter>().isGravity)
            {
                rigidBody.useGravity = false;
                force.force = new Vector3(force.force.x, -rigidBody.mass * 100, -rigidBody.mass * 1000);
            }
            game.isPin = true;
            type = BallType.FallBall;
            cameraFollow.FallMove(transform.position);
            cameraFollow.type = CameraFollow.CameraType.MoveCam;
            GameObject.FindObjectOfType<PinSetter>().StopScooper();
            StartCoroutine(game.PinTimeA(2));
        }
        else if (collision.gameObject.tag == "Pin" && collision.relativeVelocity.magnitude > rigidBody.mass * 15 && game.isPin)
        {
            if (PinCounter.pinCount == 1 || collision.gameObject.GetComponent<Pin>().isHitOne)
            {
                GameObject.FindObjectOfType<CameraShake>().Shake(1);
            }
            else if (PinCounter.pinCount == 2 && !collision.gameObject.GetComponent<Pin>().isHitOne || PinCounter.pinCount == 3 && !collision.gameObject.GetComponent<Pin>().isHitOne)
            {
                GameObject.FindObjectOfType<CameraShake>().Shake(2);
            }
            else if (PinCounter.pinCount == 4 && !collision.gameObject.GetComponent<Pin>().isHitOne || PinCounter.pinCount == 5 && !collision.gameObject.GetComponent<Pin>().isHitOne)
            {
                GameObject.FindObjectOfType<CameraShake>().Shake(4);
            }
            else if (PinCounter.pinCount == 6 && !collision.gameObject.GetComponent<Pin>().isHitOne || PinCounter.pinCount == 7 && !collision.gameObject.GetComponent<Pin>().isHitOne || PinCounter.pinCount == 8 && !collision.gameObject.GetComponent<Pin>().isHitOne)
            {
                GameObject.FindObjectOfType<CameraShake>().Shake(10);
            }
            else if (PinCounter.pinCount == 9 && !collision.gameObject.GetComponent<Pin>().isHitOne || PinCounter.pinCount == 10 && !collision.gameObject.GetComponent<Pin>().isHitOne)
            {
                GameObject.FindObjectOfType<CameraShake>().Shake(6);
            }
        }

        if (collision.gameObject.tag == "Backwall" && collision.relativeVelocity.magnitude > rigidBody.mass * 30 && !isBackWall)
        {
            rollAudio.Stop();
            gutterAudio.Stop();
            netAudio.Play();
            isBackWall = true;
            if (!isNet)
            {
                if (collision.relativeVelocity.magnitude > rigidBody.mass * 75)
                {
                    game.isReplay = true;
                }
                if (GameManager.type == GameManager.GameState.Replay)
                {
                    GameObject.FindObjectOfType<PinSetter>().LandPins();
                    game.isReplay = false;
                    game.isReplayRecord = false;
                }
                if (GameManager.type != GameManager.GameState.Menu)
                {
                    game.rollCrowd.Stop();
                }
                controlArrow.SetActive(false);
                isNet = true;
                game.StopScooper();
                type = BallType.FallBall;
                GameObject.FindObjectOfType<PinSetter>().StopScooper();
                if (!game.isPin)
                {
                    cameraFollow.FallMove(transform.position);
                    cameraFollow.type = CameraFollow.CameraType.MoveCam;
                    StartCoroutine(game.PinTimeA(2));
                    game.isPin = true;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Vector3 splashPosition = new Vector3(transform.position.x, other.transform.position.y, transform.position.z);
        if (other.CompareTag("Roll"))
        {
            game.Roll();
            roll.enabled = false;
        }
        if (other.CompareTag("Replay"))
        {
            replay.enabled = false;
            game.isReplayRecord = true;
        }
        if (other.CompareTag("Fall") && isSplash && type == BallType.ThrowBall || other.CompareTag("Fall") && isSplash && type == BallType.SpinBall || other.CompareTag("Fall") && isSplash && type == BallType.FallBall || other.CompareTag("Gutter") && isSplash && type == BallType.SpinBall && !game.isPin && !game.isPin || other.CompareTag("Water") && isSplash && type == BallType.SpinBall || other.CompareTag("Water") && isSplash && type == BallType.FallBall)
        {
            if (GameManager.isSound && GameManager.type != GameManager.GameState.Menu)
            {
                splashAudio.PlayOneShot(tubSplashs[Random.Range(0, tubSplashs.Length)]);
            }
            if (GameManager.isParticle)
            {
                Instantiate(splash, splashPosition, Quaternion.identity);
            }
            isSplash = false;
        }
        if (other.CompareTag("Fall") && type == BallType.ThrowBall || other.CompareTag("Fall") && type == BallType.SpinBall || other.CompareTag("Fall") && type == BallType.FallBall && isGutter)
        {
            if (PinCounter.pinCount == 0)
            {
                game.isReplay = true;
            }
            rollAudio.Stop();
            gutterAudio.Stop();
            if (!game.isComputer && game.gutterAnimation == 0 && GameManager.type != GameManager.GameState.Menu)
            {
                game.rollCrowd.Stop();
            }
            controlArrow.SetActive(false);
            if (!GameObject.FindObjectOfType<PinSetter>().isGravity)
            {
                rigidBody.useGravity = false;
                force.force = new Vector3(force.force.x, -rigidBody.mass * 100, -rigidBody.mass * 1000);
            }
            if (transform.position.z >= -3200 || game.isComputer && game.gutterAnimation == 0 || GameManager.type == GameManager.GameState.Menu && game.gutterAnimation == 0)
            {
                if (type == BallType.SpinBall)
                {
                    game.VoiceGutterball();
                }
                if (game.gutterAnimation == 0)
                {
                    isGutter = false;
                    game.gutterAnimation = 1;
                }
                else
                {
                    isGutter = false;
                    game.gutterAnimation = 2;
                }
                isNet = true;
            }
            roll.enabled = false;
            game.isReplayRecord = false;
            if (GameObject.FindObjectOfType<PinSetter>().gutter != null)
            {
                GameObject.FindObjectOfType<PinSetter>().gutter.enabled = false;
            }
            type = BallType.FallBall;
            StartCoroutine(game.PinTimeA(0));
        }
        if (other.CompareTag("Gutter") && !game.isPin)
        {
            rollAudio.Stop();
            controlArrow.SetActive(false);
            game.CrowdStop();
            if (type == BallType.ThrowBall)
            {
                game.GutterLaugh();
            }
            game.VoiceGutterball();
            if (game.gutterAnimation == 0)
            {
                gutterAudio.Play();
                game.rollCrowd.Stop();
                isGutter = true;
                game.gutterAnimation = 1;
                game.isPin = true;
                roll.enabled = false;
                game.isReplayRecord = false;
            }
            else if (game.gutterAnimation == 1)
            {
                gutterAudio.Stop();
                isGutter = false;
                game.gutterAnimation = 2;
                game.isPin = true;
                roll.enabled = false;
                game.isReplayRecord = false;
                StartCoroutine(game.PinTimeA(0));
            }
            isNet = true;
            cameraFollow.FallMove(transform.position);
            cameraFollow.type = CameraFollow.CameraType.MoveCam;
            if (GameObject.FindObjectOfType<PinSetter>().gutter != null)
            {
                GameObject.FindObjectOfType<PinSetter>().gutter.enabled = false;
            }
            if (type == BallType.SpinBall)
            {
                type = BallType.FallBall;
            }
        }
    }

    public void MouseDown()
    {
        if (type == BallType.MoveX && GameManager.type == GameManager.GameState.Game && !game.isComputer && Input.GetMouseButtonDown(0))
        {
            isMoveY = true;
        }
        if (type == BallType.SpinBall && GameManager.type == GameManager.GameState.Game && !game.isComputer && Input.GetMouseButtonDown(0))
        {
            rigidBody.AddForce(0, 0, -rigidBody.mass * 25000);
        }
    }

    public void MouseUp()
    {
        if (type == BallType.MoveX && GameManager.type == GameManager.GameState.Game && !game.isComputer && Input.GetMouseButtonUp(0))
        {
            if (isThrow)
            {
                Bowl();
            }
            else
            {
                isMoveY = false;
                transform.position = GameObject.FindObjectOfType<PinSetter>().ballPos;
            }
        }
    }

    public void MoveX(float move)
    {
        transform.Translate(-move, 0, 0);
    }

    public void Bowl()
    {
        game.chooseBallUI.SetActive(false);
        rigidBody.isKinematic = false;
        game.VoiceStop();
        game.CrowdStop();
        rigidBody.AddForce(moveMouse.x - direction.x * spin * rigidBody.mass * 6, 0, moveMouse.y - direction.y * speed * 1250);
        throwAudio.Play();
        type = BallType.ThrowBall;
        cameraFollow.type = CameraFollow.CameraType.DropBall;
        game.throwBall++;
    }

    public void BallReturn()
    {
        isGutter = false;
        rigidBody.useGravity = true;
        force.force = new Vector3(0, 0, 0);
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        if (GameObject.FindObjectOfType<PinSetter>().returnPoint != null)
        {
            transform.position = GameObject.FindObjectOfType<PinSetter>().returnPoint.position;
            rigidBody.velocity = Vector3.forward * 450;
        }
    }

    public void Reset()
    {
        rigidBody.useGravity = true;
        force.force = new Vector3(0, 0, 0);
        rigidBody.isKinematic = true;
        transform.position = GameObject.FindObjectOfType<PinSetter>().ballPos;
        transform.rotation = Quaternion.Euler(45, 0, 0);
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        isMoveY = false;
        isThrow = false;
        isGutter = false;
        isNet = false;
        isBackWall = false;
        isSplash = GameObject.FindObjectOfType<PinSetter>().isSplash;
        game.isReplayRecord = false;
        type = BallType.MoveX;
        cameraFollow.type = CameraFollow.CameraType.MoveX;
        if (GameObject.FindObjectOfType<PinSetter>().gutter != null)
        {
            GameObject.FindObjectOfType<PinSetter>().gutter.enabled = true;
        }
    }

    public void ResetBowl()
    {
        rigidBody.useGravity = true;
        rigidBody.isKinematic = false;
        transform.position = new Vector3(Random.Range(-75, 75), GameObject.FindObjectOfType<PinSetter>().ballPos.y, GameObject.FindObjectOfType<PinSetter>().ballPos.z);
        transform.rotation = Quaternion.Euler(45, 0, 0);
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        isMoveY = false;
        isThrow = false;
        isGutter = false;
        isNet = false;
        isBackWall = false;
        isSplash = GameObject.FindObjectOfType<PinSetter>().isSplash;
        game.isReplayRecord = false;
        if (speed <= 30)
        {
            rigidBody.AddForce(Vector3.forward * -speed * rigidBody.mass * 20000);
        }
        else if (speed > 30 && speed <= 40)
        {
            rigidBody.AddForce(Vector3.forward * -speed * rigidBody.mass * 17500);
        }
        else if (speed > 40 && speed <= 50)
        {
            rigidBody.AddForce(Vector3.forward * -speed * rigidBody.mass * 15000);
        }
        else if (speed > 50 && speed <= 60)
        {
            rigidBody.AddForce(Vector3.forward * -speed * rigidBody.mass * 12500);
        }
        else if (speed > 60)
        {
            rigidBody.AddForce(Vector3.forward * -speed * 120000);
        }
        if (transform.position.x < GameObject.FindObjectOfType<PinSetter>().ballPos.x)
        {
            if (spin < 25)
            {
                force.force = new Vector3(spin * -rigidBody.mass * 1.5f, 0, 0);
                rigidBody.AddForce(Vector3.right * spin * rigidBody.mass * Random.Range(250, 1500));
            }
            else if (spin >= 25 && spin < 50)
            {
                force.force = new Vector3(spin * -rigidBody.mass * 1f, 0, 0);
                rigidBody.AddForce(Vector3.right * spin * rigidBody.mass * Random.Range(250, 1000));
            }
            else if (spin >= 50)
            {
                force.force = new Vector3(spin * -rigidBody.mass * 0.25f, 0, 0);
                rigidBody.AddForce(Vector3.right * spin * rigidBody.mass * Random.Range(250, 500));
            }
        }
        else if (transform.position.x == GameObject.FindObjectOfType<PinSetter>().ballPos.x)
        {
            force.force = new Vector3(0, 0, 0);
            if (spin < 25)
            {
                rigidBody.AddForce(Vector3.right * spin * rigidBody.mass * Random.Range(-1500, 1500));
            }
            else if (spin >= 25 && spin < 50)
            {
                rigidBody.AddForce(Vector3.right * spin * rigidBody.mass * Random.Range(1000, 1000));
            }
            else if (spin >= 50)
            {
                rigidBody.AddForce(Vector3.right * spin * rigidBody.mass * Random.Range(-500, 500));
            }
        }
        else if (transform.position.x > GameObject.FindObjectOfType<PinSetter>().ballPos.x)
        {
            if (spin < 25)
            {
                force.force = new Vector3(spin * rigidBody.mass * 1.5f, 0, 0);
                rigidBody.AddForce(Vector3.right * spin * rigidBody.mass * Random.Range(-1500, -250));
            }
            else if (spin >= 25 && spin < 50)
            {
                force.force = new Vector3(spin * rigidBody.mass * 1f, 0, 0);
                rigidBody.AddForce(Vector3.right * spin * rigidBody.mass * Random.Range(-1000, -250));
            }
            else if (spin >= 50)
            {
                force.force = new Vector3(spin * rigidBody.mass * 0.25f, 0, 0);
                rigidBody.AddForce(Vector3.right * spin * rigidBody.mass * Random.Range(-500, -250));
            }
        }
        throwAudio.Play();
        type = BallType.ThrowBall;
        cameraFollow.type = CameraFollow.CameraType.DropBall;
        if (GameObject.FindObjectOfType<PinSetter>().gutter != null)
        {
            GameObject.FindObjectOfType<PinSetter>().gutter.enabled = true;
        }
        game.throwBall++;
    }

    public void ResetCam()
    {
        cameraFollow.Reset();
    }

    public void ChargeBall(Material ballMat, int chargeLbs, int chargeSpeed, int chargeSpin)
    {
        meshBall.material = ballMat;
        lbs = chargeLbs;
        speed = chargeSpeed;
        spin = chargeSpin;
        rigidBody.mass = lbs;
    }
}
