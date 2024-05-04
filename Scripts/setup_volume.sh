#!/bin/bash

VOLUME_NAME="3dpc-org-db"
PATH_TO_DATABASE="./Server/Database/db"
FILE_TO_COPY="organizer.db"

if ! podman volume inspect "$VOLUME_NAME" &> /dev/null; then
    # Create the volume in rootless mode
    podman volume create "$VOLUME_NAME"
fi

# Create the database file
mkdir -p "$PATH_TO_DATABASE"
touch "$PATH_TO_DATABASE/$FILE_TO_COPY"