#! /bin/bash
#
# copy Unity Package into project dirctory
#

PACKAGE="./package"
PROJECT4="./build/4"

rm -rf $PROJECT4/Assets/Editor
rm -rf $PROJECT4/Assets/Plugins

cp -r $PACKAGE/Editor $PROJECT4/Assets
cp -r $PACKAGE/Plugins $PROJECT4/Assets
