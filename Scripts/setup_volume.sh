#!/bin/bash

VOLUME_NAME="3dpc-org-db"
PATH_TO_DATABASE="./Server/Database/db"
FILE_TO_COPY="organizer.db"
MOUNT_POINT="/mnt"

# Check if the volume exists
if ! podman volume inspect "$VOLUME_NAME" &> /dev/null; then
    # Create the volume in rootless mode
    podman volume create "$VOLUME_NAME"

    # Create the database file
    touch "$PATH_TO_DATABASE/$FILE_TO_COPY"

    # Copy the file to the volume
    VOLUME_DATA=$(podman unshare podman volume mount "$VOLUME_NAME")
    cp "$PATH_TO_DATABASE/$FILE_TO_COPY" "$VOLUME_DATA/$FILE_TO_COPY"
    podman volume unmount "$VOLUME_NAME"
fi

