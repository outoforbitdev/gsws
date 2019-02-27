#!/bin/bash
compile="/mnt/c/Windows/Microsoft.NET/Framework/v4.0.30319/csc.exe -recurse:*.cs"
core="gsws.cs"
game=("./game/faction.cs" "game/player.cs" "game/world.cs")
init="initialize/mainmenu.cs initialize/newgame.cs"
ui="ui/display.cs ui/menu.cs ui/menupool.cs"
output="/mnt/c/Users/Jay/Documents/Jay's Documents/coding/starwars/gsws/compile/real.out"
expected="/mnt/c/Users/Jay/Documents/Jay's Documents/coding/starwars/gsws/compile/expected.out"

clear
rm "$output"

$compile > "$output"

diff=$(diff "$output" "$expected")

if 
    $diff
then
    echo "COMPILED SUCCESSFULLY"
else
    echo "DID NOT COMPILE"
    echo "COMPILE OUTPUT:"
    more "$output"
fi