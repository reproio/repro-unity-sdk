using System.Runtime.InteropServices;

public class Repro {

#if UNITY_IPHONE
	[DllImport ("__Internal")]
	private static extern void  _setup (string token);

	[DllImport ("__Internal")]
	private static extern void _startRecording ();
#endif

	public static void Setup (string token) {
#if UNITY_IPHONE
		_setup (token);
#elif UNITY_ANDROID
		Debug.Log( "Repro: Android is not yet supportd." );
#endif
	}

	public static void StartRecording () {
#if UNITY_IPHONE
		_startRecording ();
#elif UNITY_ANDROID
		Debug.Log( "Repro: Android is not yet supportd." );
#endif
	}
}
