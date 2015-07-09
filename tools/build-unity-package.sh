#! /bin/bash

UNITY="/Applications/Unity4.0/Unity.app/Contents/MacOS/Unity"
UNITY_PACKAGE="Repro.unitypackage"

$UNITY -batchmode -quit -logFile build.log -projectPath $(pwd)/projects/4 -exportPackage Assets/Editor Assets/Plugins $(pwd)/$UNITY_PACKAGE
