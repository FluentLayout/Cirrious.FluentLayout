#!/bin/bash

FAKE_VERSION="4.21.0"

function restore {
	# assume if the directory is there then the package is fine
	# this avoids waiting for NuGet to figure it out, because I'm impatient
	if [ ! -d "packages/$1.$2" ]; then
		mono --runtime=v4.0 tools/nuget.exe install $1 -Version $2
	fi
}

restore "FAKE" $FAKE_VERSION

mono packages/FAKE.$FAKE_VERSION/tools/FAKE.exe "$@"