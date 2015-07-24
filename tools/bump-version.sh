#! /bin/bash

CURRENT_VERSION="$(git describe --abbrev=0)"
read MAJOR_VER MINOR_VER PATCH_VER <<< $(IFS='.'; echo $CURRENT_VERSION)

if [ "$1" == "major" ]; then
	MAJOR_VER=$((MAJOR_VER+1))
	MINOR_VER=0
	PATCH_VER=0
elif [ "$1" == "minor" ]; then
	MINOR_VER=$((MINOR_VER+1))
	PATCH_VER=0
else
	PATCH_VER=$((PATCH_VER+1))
fi

NEW_VERSION="$MAJOR_VER"."$MINOR_VER"."$PATCH_VER"
echo "$NEW_VERSION" > ./package/Repro/Plugins/VERSION
