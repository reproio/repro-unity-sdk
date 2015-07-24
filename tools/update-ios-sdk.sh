#! /bin/bash

SDK_REPO="../repro-ios-sdk"
SDK="Repro.embeddedframework"
PACKAGE="./package"

# update SDK repository
cd $SDK_REPO
git checkout master
git pull
VERSION=$(git tag --sort v:refname | grep "[0-9]$" | tail -1)
cd -

# copy SDK into Unity package
rm -rf $PACKAGE/Repro/Plugins/iOS/$SDK
cp -r $SDK_REPO/$SDK $PACKAGE/Repro/Plugins/iOS

# touch Version file
echo $VERSION > $PACKAGE/Repro/Plugins/iOS/VERSION
