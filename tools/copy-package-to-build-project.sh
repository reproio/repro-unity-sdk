#! /bin/bash
#
# copy Unity Package into project dirctory
#

PACKAGE="./package"
PROJECT4="./build/4"
PROJECT5="./build/5"

rm -rf $PROJECT4/Assets/Editor
rm -rf $PROJECT4/Assets/Plugins
cp -r $PACKAGE/Editor $PROJECT4/Assets
cp -r $PACKAGE/Plugins $PROJECT4/Assets

rm -rf $PROJECT5/Assets/Editor
rm -rf $PROJECT5/Assets/Plugins
cp -r $PACKAGE/Editor $PROJECT5/Assets
cp -r $PACKAGE/Plugins $PROJECT5/Assets
