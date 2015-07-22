#! /bin/bash

UNITY="/Applications/Unity4.0/Unity.app/Contents/MacOS/Unity"
UNITY_PROJECT_DIR="$(pwd)/build"
UNITY_PACKAGE_DIR="$(pwd)/package"
UNITY_PACKAGE="$(pwd)/Repro.unitypackage"

# create Unity Project for build Unity Package
mkdir -p $UNITY_PROJECT_DIR
$UNITY -batchmode -quit -createProject $UNITY_PROJECT_DIR

# copy assets to Unity Project
cp -r $UNITY_PACKAGE_DIR/Editor $UNITY_PROJECT_DIR/Assets
cp -r $UNITY_PACKAGE_DIR/Plugins $UNITY_PROJECT_DIR/Assets

# build Unity Package
$UNITY -batchmode -quit -projectPath $UNITY_PROJECT_DIR -exportPackage Assets/Editor Assets/Plugins $UNITY_PACKAGE

# remove Unity Project dir
rm -rf $UNITY_PROJECT_DIR
