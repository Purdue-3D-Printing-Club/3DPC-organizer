#!/bin/bash

# Check if the Podman daemon is running
if ! podman info >/dev/null 2>&1; then
    echo "Podman daemon is not running. Please start Podman before running this script."
    exit 1
fi

# Check if both solution name and version number are provided as command line arguments
if [ $# -ne 2 ]; then
    echo "Please provide the solution name and version number as command line arguments."
    exit 1
fi

# Set the name of the solution and version number from the command line arguments
solution_name="$1"
version_number="$2"

./build.sh solution_name version_name
./run.sh solution_name version_name