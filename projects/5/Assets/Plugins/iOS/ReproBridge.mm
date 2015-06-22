//
//  ReproBridge.mm
//
//  Created by nekoe on 6/11/15.
//  Copyright (c) 2015 Repro Inc. All rights reserved.
//

#include "ReproBridge.h"
#import <Repro/Repro.h>

static NSString* convertCStringToNSString(const char* string) {
    if (string) {
        return [NSString stringWithUTF8String:string];
    } else {
        return @"";
    }
}

static NSDictionary* convertCStringJSONToNSDictionary(const char* string) {
    if (string) {
        NSString* json = convertCStringToNSString(string);
        NSData* data = [json dataUsingEncoding:NSUTF8StringEncoding];
        return [NSJSONSerialization JSONObjectWithData:data options:kNilOptions error:nil];
    } else {
        return nil;
    }
}

void _setup(const char* token) {
    [Repro setup:convertCStringToNSString(token)];
}

void _setLogLevel(const char* logLevel) {
    if ([convertCStringToNSString(logLevel) isEqualToString:@"Debug"]) {
        [Repro setLogLevel:RPRLogLevelDebug];
    } else if ([convertCStringToNSString(logLevel) isEqualToString:@"Info"]) {
        [Repro setLogLevel:RPRLogLevelInfo];
    } else if ([convertCStringToNSString(logLevel) isEqualToString:@"Warn"]) {
        [Repro setLogLevel:RPRLogLevelWarn];
    } else if ([convertCStringToNSString(logLevel) isEqualToString:@"Error"]) {
        [Repro setLogLevel:RPRLogLevelError];
    } else if ([convertCStringToNSString(logLevel) isEqualToString:@"None"]) {
        [Repro setLogLevel:RPRLogLevelNone];
    }
}

void _startRecording() {
    [Repro startRecording];
}

void _stopRecording() {
    [Repro stopRecording];
}

void _pauseRecording() {
    [Repro pauseRecording];
}

void _resumeRecording() {
    [Repro resumeRecording];
}

void _maskWithRect(float x, float y, float width, float height, const char* key) {
    [Repro maskWithRect:CGRectMake(x,y,width,height) key:convertCStringToNSString(key)];
}

void _unmaskWithRect(const char* key) {
    [Repro unmaskForKey:convertCStringToNSString(key)];
}

void _setUserID(const char* userId) {
    [Repro setUserID:convertCStringToNSString(userId)];
}

void _track(const char* eventName) {
    [Repro track:convertCStringToNSString(eventName) properties:nil];
}

void _trackWithProperties(const char* eventName, const char* jsonDictionary) {
    [Repro track:convertCStringToNSString(eventName) properties:convertCStringJSONToNSDictionary(jsonDictionary)];
}

void _enableCrashReporting() {
    [Repro enableCrashReporting];
}

// void _survey() {
//     NSError *error = nil;
//     [Repro survey:&error];
// }

void _enableUsabilityTesting() {
    [Repro enableUsabilityTesting];
}
