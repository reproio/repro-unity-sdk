using System.Runtime.InteropServices;
using UnityEngine;

public class Repro {

#if UNITY_IPHONE
	[DllImport ("__Internal")]
	private static extern void  _setup (string token);

	[DllImport ("__Internal")]
	private static extern void _setLogLevel (string logLevel);

	[DllImport ("__Internal")]
	private static extern void _startRecording ();

	[DllImport ("__Internal")]
	private static extern void _stopRecording ();

	[DllImport ("__Internal")]
	private static extern void _pauseRecording ();

	[DllImport ("__Internal")]
	private static extern void _resumeRecording ();

	[DllImport ("__Internal")]
	private static extern void _maskWithRect (float x, float y, float width, float height, string key);

	[DllImport ("__Internal")]
	private static extern void _unmaskWithRect (string key);

	[DllImport ("__Internal")]
	private static extern void _setUserID (string userId);

	[DllImport ("__Internal")]
	private static extern void _track (string eventName);

	[DllImport ("__Internal")]
	private static extern void _trackWithProperties (string eventName, string jsonDictionary);

	[DllImport ("__Internal")]
	private static extern void _enableCrashReporting ();

	// [DllImport ("__Internal")]
	// private static extern void _survey ();

	[DllImport ("__Internal")]
	private static extern void _enableUsabilityTesting ();

	public static void Setup (string token) {
		_setup (token);
	}

	public static void SetLogLevel (string logLevel) {
		_setLogLevel (logLevel);
	}

	public static void StartRecording () {
		_startRecording ();
	}

	public static void StopRecording () {
		_stopRecording ();
	}

	public static void PauseRecording () {
		_pauseRecording ();
	}

	public static void ResumeRecording () {
		_resumeRecording ();
	}

	public static void MaskWithRect (float x, float y, float width, float height, string key) {
		_maskWithRect (x, y, width, height, key);
	}

	public static void UnmaskWithRect (string key) {
		_unmaskWithRect (key);
	}

	public static void SetUserID (string userId) {
		_setUserID (userId);
	}

	public static void Track (string eventName) {
		_track (eventName);
	}

	public static void TrackWithProperties (string eventName, string jsonDictionary) {
		// TODO
		_trackWithProperties (eventName, jsonDictionary);
	}

	public static void EnableCrashReporting () {
		_enableCrashReporting ();
	}

	// public static void Survey () {
	// 	_survey ();
	// }

	public static void EnableUsabilityTesting () {
		_enableUsabilityTesting ();
	}

#elif UNITY_ANDROID
	public static void Setup (string token) {
		Debug.Log( "Repro: Android is not yet supportd." );
	}

	public static void SetLogLevel (string logLevel) {
		Debug.Log( "Repro: Android is not yet supportd." );
	}

	public static void StartRecording () {
		Debug.Log( "Repro: Android is not yet supportd." );
	}

	public static void StopRecording () {
		Debug.Log( "Repro: Android is not yet supportd." );
	}

	public static void PauseRecording () {
		Debug.Log( "Repro: Android is not yet supportd." );
	}

	public static void ResumeRecording () {
		Debug.Log( "Repro: Android is not yet supportd." );
	}

	public static void MaskWithRect (float x, float y, float width, float height, string key) {
		Debug.Log( "Repro: Android is not yet supportd." );
	}

	public static void UnmaskWithRect (string key) {
		Debug.Log( "Repro: Android is not yet supportd." );
	}

	public static void SetUserID (string userId) {
		Debug.Log( "Repro: Android is not yet supportd." );
	}

	public static void Track (string eventName) {
		Debug.Log( "Repro: Android is not yet supportd." );
	}

	public static void TrackWithProperties (string eventName, string jsonDictionary) {
		Debug.Log( "Repro: Android is not yet supportd." );
	}

	public static void EnableCrashReporting () {
		Debug.Log( "Repro: Android is not yet supportd." );
	}

	// public static void Survey () {
	// 	Debug.Log( "Repro: Android is not yet supportd." );
	// }

	public static void EnableUsabilityTesting () {
		Debug.Log( "Repro: Android is not yet supportd." );
	}

#endif

}
