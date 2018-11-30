using UnityEngine;
using System.Collections;

public class DisplayData : MonoBehaviour
{
	public Texture2D[] signalIcons;
	
	private int indexSignalIcons = 1;
	
    TGCConnectionController controller;

	[SerializeField]
    private int poorSignal1;

	[SerializeField]
    private int attention1;

	[SerializeField]
    private int meditation1;
	
	private float delta;

    void Start()
    {
		
		controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
		
		controller.UpdatePoorSignalEvent += OnUpdatePoorSignal;
		controller.UpdateAttentionEvent += OnUpdateAttention;
		controller.UpdateMeditationEvent += OnUpdateMeditation;
		
		controller.UpdateDeltaEvent += OnUpdateDelta;
		
    }
	
	void OnUpdatePoorSignal(int value){
		poorSignal1 = value;
		if(value < 25){
      		indexSignalIcons = 0; // connected
		}else if(value >= 25 && value < 51){
      		indexSignalIcons = 4; // strong
		}else if(value >= 51 && value < 78){
      		indexSignalIcons = 3; // medium
		}else if(value >= 78 && value < 107){
      		indexSignalIcons = 2; // weak
		}else if(value >= 107){
      		indexSignalIcons = 1; // disconnected
		}
	}
	void OnUpdateAttention(int value){
		attention1 = value;
	}
	void OnUpdateMeditation(int value){
		meditation1 = value;
	}
	void OnUpdateDelta(float value){
		delta = value;
	}


    void OnGUI()
    {
		GUILayout.BeginHorizontal();
		
		
        if (GUILayout.Button("Connect"))
        {
            controller.Connect();
        }
        if (GUILayout.Button("Disconnect"))
        {
            controller.Disconnect();
			indexSignalIcons = 1;
        }
		
		GUILayout.Space(Screen.width-250);
		GUILayout.Label(signalIcons[indexSignalIcons]);
		
		GUILayout.EndHorizontal();

        GUILayout.Label("Signal:" + poorSignal1);
        GUILayout.Label("Attention:" + attention1);
        GUILayout.Label("Meditation:" + meditation1);
		GUILayout.Label("Delta:" + delta);

    }
}
