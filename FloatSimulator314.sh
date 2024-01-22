#!/bin/sh
echo -ne '\033c\033]0;FloatSimulator\a'
base_path="$(dirname "$(realpath "$0")")"
"$base_path/FloatSimulator314.x86_64" "$@"
