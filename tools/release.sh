#! /bin/bash

if [ "$1" == "major" ] || [ "$1" == "minor" ] || [ "$1" == "" ]; then
  BUMP_OPTION="$1"
else
	echo "invalid option"
	exit
fi

# update repo
git checkout master
git pull

# update iOS / Android SDK
. tools/update-ios-sdk.sh
. tools/update-android-sdk.sh

# bump version of Repro.unitypackage
. tools/bump-version.sh "$BUMP_OPTION"

# copy unity package files to project
. tools/copy-package-to-build-project.sh

# biild Repro.unitypackage
. tools/build-unity-package.sh

# push
. tools/push.sh "$NEW_VERSION"
