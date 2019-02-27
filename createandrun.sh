#!/bin/bash
output=$(./create.sh)
if
    [ "$output" = "[3J[H[2JCOMPILED SUCCESSFULLY\
" ];
then
    ./run.sh
else
    echo "DID NOT COMPILE"
    echo "COMPILE OUTPUT:"
    echo "$output"
fi
