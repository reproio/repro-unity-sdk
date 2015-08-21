using System.Runtime.InteropServices;
using UnityEngine;

public class Repro {

#if UNITY_IPHONE
	[DllImport ("__Internal")]
	private static extern void RPR_setup (string token);

	[DllImport ("__Internal")]
	private static extern void RPR_setLogLevel (string logLevel);

	[DllImport ("__Internal")]
	private static extern void RPR_startRecording ();

	[DllImport ("__Internal")]
	private static extern void RPR_stopRecording ();

	[DllImport ("__Internal")]
	private static extern void RPR_pauseRecording ();

	[DllImport ("__Internal")]
	private static extern void RPR_resumeRecording ();

	[DllImport ("__Internal")]
	private static extern void RPR_maskWithRect (float x, float y, float width, float height, string key);

	[DllImport ("__Internal")]
	private static extern void RPR_unmaskWithRect (string key);

	[DllImport ("__Internal")]
	private static extern void RPR_setUserID (string userId);

	[DllImport ("__Internal")]
	private static extern void RPR_track (string eventName);

	[DllImport ("__Internal")]
	private static extern void RPR_trackWithProperties (string eventName, string jsonDictionary);

	[DllImport ("__Internal")]
	private static extern void RPR_enableCrashReporting ();

	// [DllImport ("__Internal")]
	// private static extern void RPR_survey ();

	[DllImport ("__Internal")]
	private static extern void RPR_enableUsabilityTesting ();

	[DllImport ("__Internal")]
	private static extern void RPR_setPushDeviceToken (string token);

	[DllImport ("__Internal")]
	private static extern void RPR_disableInAppMessageOnActive();

	[DllImport ("__Internal")]
	private static extern void RPR_showInAppMessage();

	public static void Setup (string token) {
		RPR_setup (token);
	}

	public static void SetLogLevel (string logLevel) {
		RPR_setLogLevel (logLevel);
	}

	public static void StartRecording () {
		RPR_startRecording ();
	}

	public static void StopRecording () {
		RPR_stopRecording ();
	}

	public static void PauseRecording () {
		RPR_pauseRecording ();
	}

	public static void ResumeRecording () {
		RPR_resumeRecording ();
	}

	public static void MaskWithRect (float x, float y, float width, float height, string key) {
		RPR_maskWithRect (x, y, width, height, key);
	}

	public static void UnmaskWithRect (string key) {
		RPR_unmaskWithRect (key);
	}

	public static void SetUserID (string userId) {
		RPR_setUserID (userId);
	}

	public static void Track (string eventName) {
		RPR_track (eventName);
	}

	public static void TrackWithProperties (string eventName, string jsonDictionary) {
		// TODO
		RPR_trackWithProperties (eventName, jsonDictionary);
	}

	public static void EnableCrashReporting () {
		RPR_enableCrashReporting ();
	}

	// public static void Survey () {
	// 	_survey ();
	// }

	public static void EnableUsabilityTesting () {
		RPR_enableUsabilityTesting ();
	}

	public static void SetPushDeviceToken (string token) {
		RPR_setPushDeviceToken (token);
	}

	public static void DisableInAppMessageOnActive () {
		RPR_disableInAppMessageOnActive ();
	}

	public static void ShowInAppMessage () {
		RPR_showInAppMessage ();
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

	public static void SetPushDeviceToken (string token) {
		Debug.Log( "Repro: Android is not yet supportd." );
	}

#endif

}
