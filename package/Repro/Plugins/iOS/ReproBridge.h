//
//  ReproBridge.h
//
//  Created by nekoe on 6/11/15.
//  Copyright (c) 2015 Repro Inc. All rights reserved.
//
//

#ifndef _ReproBridge_h
#define _ReproBridge_h

#ifdef __cplusplus
extern "C" {
#endif

    // Setup
    void RPR_setup(const char* token);

    // Log Level
    void RPR_setLogLevel(const char* logLevel);

    // Screen Recording
    void RPR_startRecording();
    void RPR_stopRecording();
    void RPR_pauseRecording();
    void RPR_resumeRecording();

    // UIView Masking
    void RPR_maskWithRect(float x, float y, float width, float height, const char* key);
    void RPR_unmaskWithRect(const char* key);

    // User ID
    void RPR_setUserID(const char* userId);

    // Track Events
    void RPR_track(const char* eventName);
    void RPR_trackWithProperties(const char* eventName, const char* jsonDictionary);

    // Crash Reporting
    void RPR_enableCrashReporting();

    // // Survey
    // void RPR_survey();

    // Usablity Testing
    void RPR_enableUsabilityTesting();

    // Push Notification
    void RPR_setPushDeviceToken(const char* token);

    // In-App Message
    void RPR_disableInAppMessageOnActive();
    void RPR_showInAppMessage();

#ifdef __cplusplus
}
#endif

#endif
