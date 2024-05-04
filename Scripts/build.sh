#!/bin/bash

# Check if the podman daemon is running
if ! podman info >/dev/null 2>&1; then
    echo "podman daemon is not running. Please start podman before running this script."
    exit 1
fi

# Check if both solution name and version number are provided as command line arguments
if [ $# -ne 1 ]; then
    echo "Please provide the container name as command line arguments."
    exit 1
fi

# Verify database file exists
touch ./Server/Database/organizer.db

# Set the name of the container with the version number appended
container_name="$1"

# Build the podman container
podman build -t "${container_name}" .
