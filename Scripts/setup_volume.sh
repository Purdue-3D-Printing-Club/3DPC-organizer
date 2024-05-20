#!/bin/bash

VOLUME_NAME="3dpc-org-db"
PATH_TO_DATABASE="./Scripts"
FILE_TO_COPY="organizer.db"

if ! podman volume inspect "$VOLUME_NAME" &> /dev/null; then
    # Create the volume in rootless mode
    podman volume create "$VOLUME_NAME"
fi

# Check if FILE_TO_COPY already exists at VOLUME_DATA
if [ -f "$VOLUME_DATA/$FILE_TO_COPY" ]; then
    # Add your code here to handle the case when FILE_TO_COPY already exists
    echo "FILE_TO_COPY already exists at VOLUME_DATA"
else
    # Copy the file to the volume
    VOLUME_DATA=$(podman unshare podman volume mount "$VOLUME_NAME")
    cp "$PATH_TO_DATABASE/$FILE_TO_COPY" "$VOLUME_DATA/$FILE_TO_COPY"
    podman volume unmount "$VOLUME_NAME"
fi