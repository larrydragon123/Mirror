using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class LogDataUpdater : MonoBehaviour
{
    /// <summary>
    /// URL at which the .php file interfacing with the SQL database is stored.
    /// </summary>
    private const string DataStorageURL =
        "https://brandonlymangamedev.com/mirror_research.php";
    
    [Header("Data To Store")]
    [SerializeField] private IntVariable _subjectNumber;
    [SerializeField] private IntVariable _treatmentIndex;
    [SerializeField] private BoolVariable _completion;
    [SerializeField] private IntVariable _cloneCount;
    [SerializeField] private IntVariable _jumpCount;
    [SerializeField] private FloatVariable _timeSpentPushingBoxes;
    [SerializeField] private FloatVariable _timeToClearLevel;
    [SerializeField] private IntVariable _killCountSpikeTotal;
    [SerializeField] private IntVariable _killCountSpikeA;
    [SerializeField] private IntVariable _killCountSpikeB;
    [SerializeField] private IntVariable _killCountSpikeC;
    [SerializeField] private IntVariable _killCountSpikeD;
    [SerializeField] private IntVariable _killCountSpikeE;
    [SerializeField] private IntVariable _killCountSpikeF;
    [SerializeField] private IntVariable _pressCountButtonTotal;
    [SerializeField] private IntVariable _pressCountButtonA;
    [SerializeField] private IntVariable _pressCountButtonB;
    [SerializeField] private IntVariable _pressCountButtonC;
    [SerializeField] private IntVariable _pressCountButtonD;

    public void PostData()
    {
        StartCoroutine(PostDataRoutine());
    }
    
    /// <summary>
    /// Routine to post a score to the online leaderboard.
    /// </summary>
    private IEnumerator PostDataRoutine()
    {
        WWWForm form = new WWWForm();
        form.AddField("post_research", "true");
        form.AddField("ID", _subjectNumber.Value);
        form.AddField("TREAT", _treatmentIndex.Value);

        int compInt = _completion.Value ? 1 : 0;
        form.AddField("CMP", compInt);
        
        form.AddField("CLN", _cloneCount.Value);
        form.AddField("JMP", _jumpCount.Value);
        form.AddField("TSPB", _timeSpentPushingBoxes.Value.ToString());
        form.AddField("TTCL", _timeToClearLevel.Value.ToString());
        form.AddField("KCST", _killCountSpikeTotal.Value);
        form.AddField("KCSA", _killCountSpikeA.Value);
        form.AddField("KCSB", _killCountSpikeB.Value);
        form.AddField("KCSC", _killCountSpikeC.Value);
        form.AddField("KCSD", _killCountSpikeD.Value);
        form.AddField("KCSE", _killCountSpikeE.Value);
        form.AddField("KCSF", _killCountSpikeF.Value);
        form.AddField("PCBT", _pressCountButtonTotal.Value);
        form.AddField("PCBA", _pressCountButtonA.Value);
        form.AddField("PCBB", _pressCountButtonB.Value);
        form.AddField("PCBC", _pressCountButtonC.Value);
        form.AddField("PCBD", _pressCountButtonD.Value);

        using (UnityWebRequest www = UnityWebRequest.Post(DataStorageURL, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError ||
                www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Successfully posted score!");
            }
        }
    }
}   

