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
    void _setup(const char* token);

    // Log Level
    void _setLogLevel(const char* logLevel);

    // Screen Recording
    void _startRecording();
    void _stopRecording();
    void _pauseRecording();
    void _resumeRecording();

    // UIView Masking
    void _maskWithRect(float x, float y, float width, float height, const char* key);
    void _unmaskWithRect(const char* key);

    // User ID
    void _setUserID(const char* userId);

    // Track Events
    void _track(const char* eventName);
    void _trackWithProperties(const char* eventName, const char* jsonDictionary);

    // Crash Reporting
    void _enableCrashReporting();

    // // Survey
    // void _survey();

    // Usablity Testing
    void _enableUsabilityTesting();

#ifdef __cplusplus
}
#endif

#endif
