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

void RPR_setup(const char* token) {
    [Repro setup:convertCStringToNSString(token)];
}

void RPR_setLogLevel(const char* logLevel) {
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

void RPR_startRecording() {
    [Repro startRecording];
}

void RPR_stopRecording() {
    [Repro stopRecording];
}

void RPR_pauseRecording() {
    [Repro pauseRecording];
}

void RPR_resumeRecording() {
    [Repro resumeRecording];
}

void RPR_maskWithRect(float x, float y, float width, float height, const char* key) {
    [Repro maskWithRect:CGRectMake(x,y,width,height) key:convertCStringToNSString(key)];
}

void RPR_unmaskWithRect(const char* key) {
    [Repro unmaskForKey:convertCStringToNSString(key)];
}

void RPR_setUserID(const char* userId) {
    [Repro setUserID:convertCStringToNSString(userId)];
}

void RPR_track(const char* eventName) {
    [Repro track:convertCStringToNSString(eventName) properties:nil];
}

void RPR_trackWithProperties(const char* eventName, const char* jsonDictionary) {
    [Repro track:convertCStringToNSString(eventName) properties:convertCStringJSONToNSDictionary(jsonDictionary)];
}

void RPR_enableCrashReporting() {
    [Repro enableCrashReporting];
}

// void RPR_survey() {
//     NSError *error = nil;
//     [Repro survey:&error];
// }

void RPR_enableUsabilityTesting() {
    [Repro enableUsabilityTesting];
}

void RPR_setPushDeviceToken(const char* token) {
    [Repro setPushDeviceTokenString:convertCStringToNSString(token)];
}
