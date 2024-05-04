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

# Setup database volume if it doesn't exist
VOLUME_NAME="3dpc-org-db"
PATH_TO_DATABASE="./Server/Database/db"
FILE_TO_COPY="organizer.db"
MOUNT_POINT="/mnt"

if ! podman volume inspect "$VOLUME_NAME" &> /dev/null; then
    # Create the volume in rootless mode
    podman volume create "$VOLUME_NAME"

    # Create the database file
    mkdir -p "$PATH_TO_DATABASE"
    touch "$PATH_TO_DATABASE/$FILE_TO_COPY"

    # Copy the file to the volume
    VOLUME_DATA=$(podman unshare podman volume mount "$VOLUME_NAME")
    cp "$PATH_TO_DATABASE/$FILE_TO_COPY" "$VOLUME_DATA/$FILE_TO_COPY"
    podman volume unmount "$VOLUME_NAME"
fi

# Set the name of the container with the version number appended
container_name="$1"

# Build the podman container
podman build -t "${container_name}" .
