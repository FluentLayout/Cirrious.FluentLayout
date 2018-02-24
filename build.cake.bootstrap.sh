#!/bin/bash
if [ -f "build.sh" ]
then
	echo "build.sh found."
else
	echo "Script build.sh not found, downloading..."
	curl -Lsfo build.sh http://cakebuild.net/download/bootstrapper/osx
	echo "Download complete, setting permissions on build.sh"
	chmod +x build.sh
	echo "Getting ready for first run..."
	./build.sh -version
fi

