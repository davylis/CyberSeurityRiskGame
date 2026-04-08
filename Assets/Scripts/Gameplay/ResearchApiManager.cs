using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ResearchApiManager : MonoBehaviour
{
    [Header("API")]
    public string baseUrl = "http://cybermaze-backend.davylis.com/api";

    [Header("Auto Save")]
    public float saveInterval = 5f;

    [Header("Next Scene After Form")]
    public string nextSceneName = "PlayInfo";

    public static ResearchApiManager Instance { get; private set; }

    private string sessionId;
    private float elapsedSeconds;
    private bool gameStarted;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if (gameStarted)
        {
            elapsedSeconds += Time.deltaTime;
        }
    }

    public void StartSession()
    {
        StartCoroutine(CreateSessionAndStartGame());
    }

    private IEnumerator CreateSessionAndStartGame()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance is null.");
            yield break;
        }

        SessionRequest requestData = new SessionRequest
        {
            participantCode = GameManager.Instance.participantCode,
            name = GameManager.Instance.playerName,
            degree = GameManager.Instance.playerDegree,
            ageGroup = GameManager.Instance.age,
            agree = GameManager.Instance.agreedToResearch
        };

        string json = JsonUtility.ToJson(requestData);

        UnityWebRequest request = new UnityWebRequest(baseUrl + "/session", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Failed to create session: " + request.error);
            Debug.LogError("Server response: " + request.downloadHandler.text);
            yield break;
        }

        SessionResponse response = JsonUtility.FromJson<SessionResponse>(request.downloadHandler.text);
        sessionId = response.sessionId;

        Debug.Log("Session created: " + sessionId);

        gameStarted = true;
        StartCoroutine(SendProgressPeriodically());

        if (!string.IsNullOrWhiteSpace(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    private IEnumerator SendProgressPeriodically()
    {
        while (gameStarted)
        {
            yield return new WaitForSeconds(saveInterval);
            yield return StartCoroutine(SendProgress("in_progress"));
        }
    }

    public void SendProgressNow()
    {
        if (gameStarted)
        {
            StartCoroutine(SendProgress("in_progress"));
        }
    }

    public void FinishGame()
    {
        gameStarted = false;
        StartCoroutine(SendProgress("completed"));
    }

    private IEnumerator SendProgress(string status)
    {
        if (string.IsNullOrEmpty(sessionId))
        {
            Debug.LogWarning("No sessionId. Progress not sent.");
            yield break;
        }

        if (GameManager.Instance == null)
        {
            Debug.LogWarning("GameManager.Instance is null. Progress not sent.");
            yield break;
        }

        ProgressRequest requestData = new ProgressRequest
        {
            sessionId = sessionId,
            points = GameManager.Instance.score,
            currentTask = GameManager.Instance.currentTask,

            case1Score = GameManager.Instance.case1Score,
            case2Score = GameManager.Instance.case2Score,
            case3Score = GameManager.Instance.case3Score,
            case4Score = GameManager.Instance.case4Score,
            case5Score = GameManager.Instance.case5Score,
            case6Score = GameManager.Instance.case6Score,
            case7Score = GameManager.Instance.case7Score,
            case8Score = GameManager.Instance.case8Score,
            case9Score = GameManager.Instance.case9Score,
            case10Score = GameManager.Instance.case10Score,
            case11Score = GameManager.Instance.case11Score,

            case5Choices = GameManager.Instance.case5Choices.ToArray(),
            case6Choices = GameManager.Instance.case6Choices.ToArray(),
            case7Choices = GameManager.Instance.case7Choices.ToArray(),
            case8Choices = GameManager.Instance.case8Choices.ToArray(),
            case9Choices = GameManager.Instance.case9Choices.ToArray(),
            case10Choices = GameManager.Instance.case10Choices.ToArray(),
            case11Choices = GameManager.Instance.case11Choices.ToArray(),

            elapsedSeconds = Mathf.RoundToInt(elapsedSeconds),
            status = status
        };

        string json = JsonUtility.ToJson(requestData);

        UnityWebRequest request = new UnityWebRequest(baseUrl + "/progress", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Failed to send progress: " + request.error);
            Debug.LogError("Server response: " + request.downloadHandler.text);
        }
        else
        {
            Debug.Log("Progress saved: " + request.downloadHandler.text);
        }
    }
}

[System.Serializable]
public class SessionRequest
{
    public string participantCode;
    public string name;
    public string degree;
    public string ageGroup;
    public bool agree;
}

[System.Serializable]
public class SessionResponse
{
    public string sessionId;
}

[System.Serializable]
public class ProgressRequest
{
    public string sessionId;
    public int points;
    public int currentTask;

    public int case1Score;
    public int case2Score;
    public int case3Score;
    public int case4Score;
    public int case5Score;
    public int case6Score;
    public int case7Score;
    public int case8Score;
    public int case9Score;
    public int case10Score;
    public int case11Score;

    public int[] case5Choices;
    public int[] case6Choices;
    public int[] case7Choices;
    public int[] case8Choices;
    public int[] case9Choices;
    public int[] case10Choices;
    public int[] case11Choices;

    public int elapsedSeconds;
    public string status;
}